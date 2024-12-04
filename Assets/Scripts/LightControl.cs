using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LightControl : MonoBehaviour
{
    // Start is called before the first frame update
    

    float duration  = 3.0f;
    float originalRange;
    [SerializeField] private string url = "http://127.0.0.1:8000/data"; // URL сервера
    [SerializeField] private int requestsPerSecond = 10; // Количество запросов в секунду
    private float delay;

    private float numericValue; // Значение из JSON

    Light lt;

    void Start()
    {
        lt = GetComponent<Light>();
        originalRange = lt.range;
        Debug.Log("Range:" + originalRange);
        // Вычисляем задержку между запросами
        delay = 1f / requestsPerSecond;

        // Запускаем корутину для выполнения запросов
        StartCoroutine(SendRequest());
    }
    private IEnumerator SendRequest()
    {
        while (true)
        {
            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;

                    try
                    {
                        // Парсим JSON и сохраняем значение
                        JsonData jsonData = JsonUtility.FromJson<JsonData>(json);
                        numericValue = jsonData.value;
                        Debug.Log($"Получено значение: {numericValue}");
                    }
                    catch
                    {
                        Debug.LogError("Ошибка при разборе JSON");
                    }
                }
                else
                {
                    Debug.LogError($"Ошибка HTTP: {request.error}");
                }
            }

            yield return new WaitForSeconds(0.1f); // 10 запросов в секунду
        }
    }

    void Update()
    {
        // lt.range = lt.range * (float)0.99999;
        // if(Input.GetKey(KeyCode.M))
        // {
        //     lt.range -= 1;
        // }
        // else if(Input.GetKey(KeyCode.B))
        // {
        //     lt.range += 1;
        // }
        lt.range = originalRange * (numericValue * (float)1.5);
    }
    // Класс для парсинга JSON
    [System.Serializable]
    private class JsonData
    {
        public float value; // Имя поля должно совпадать с ключом JSON
    }
}
