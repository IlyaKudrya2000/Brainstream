//using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light lightSource; // Ссылка на лампочку
   // public PostProcessVolume postProcessVolume; // Ссылка на Post-Processing Volume
    public float smoothTime = 0.3f; // Время сглаживания
    //private float targetIntensity; // Целевая яркость
    private float currentVelocity; // Текущая скорость изменения
    private float currentVelocityAngle;
    private float time; // Время для синусоидальной функции
  //  private Vignette vignette; // Эффект виньетки

    void Start()
    {
        // Получаем эффект виньетки из профиля
       // postProcessVolume.profile.TryGetSettings(out vignette);
        // if (postProcessVolume == null)
        // {
       // Debug.Log("Сообщение для отладки");
        //}
    }
    void Update()
    {
       // postProcessVolume.profile.TryGetSettings(out vignette);
        // Обновляем время
        time += Time.deltaTime;

        // Получаем значение входного сигнала на основе синусоидальной функции
        float inputSignal = Mathf.Sin(time);

        // Преобразуем сигнал в диапазон от 0 до 1
        inputSignal = ((inputSignal + 1) / 2);

        // Плавно изменяем яркость лампочки
        lightSource.intensity = Mathf.SmoothDamp(lightSource.intensity, inputSignal <= 0.2f ? 0.2f : inputSignal, ref currentVelocity, smoothTime);
        lightSource.spotAngle = Mathf.SmoothDamp(lightSource.spotAngle, (inputSignal * 60 + 30), ref currentVelocityAngle, smoothTime);
        // Изменяем интенсивность виньетки на основе входного сигнала
        //vignette.intensity.value = Mathf.SmoothDamp(vignette.intensity.value, inputSignal, ref currentVelocity, smoothTime);
    }
}
