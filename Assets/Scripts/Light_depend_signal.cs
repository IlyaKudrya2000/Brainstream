//using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light lightSource; // ������ �� ��������
   // public PostProcessVolume postProcessVolume; // ������ �� Post-Processing Volume
    public float smoothTime = 0.3f; // ����� �����������
    //private float targetIntensity; // ������� �������
    private float currentVelocity; // ������� �������� ���������
    private float currentVelocityAngle;
    private float time; // ����� ��� �������������� �������
  //  private Vignette vignette; // ������ ��������

    void Start()
    {
        // �������� ������ �������� �� �������
       // postProcessVolume.profile.TryGetSettings(out vignette);
        // if (postProcessVolume == null)
        // {
       // Debug.Log("��������� ��� �������");
        //}
    }
    void Update()
    {
       // postProcessVolume.profile.TryGetSettings(out vignette);
        // ��������� �����
        time += Time.deltaTime;

        // �������� �������� �������� ������� �� ������ �������������� �������
        float inputSignal = Mathf.Sin(time);

        // ����������� ������ � �������� �� 0 �� 1
        inputSignal = ((inputSignal + 1) / 2);

        // ������ �������� ������� ��������
        lightSource.intensity = Mathf.SmoothDamp(lightSource.intensity, inputSignal <= 0.2f ? 0.2f : inputSignal, ref currentVelocity, smoothTime);
        lightSource.spotAngle = Mathf.SmoothDamp(lightSource.spotAngle, (inputSignal * 60 + 30), ref currentVelocityAngle, smoothTime);
        // �������� ������������� �������� �� ������ �������� �������
        //vignette.intensity.value = Mathf.SmoothDamp(vignette.intensity.value, inputSignal, ref currentVelocity, smoothTime);
    }
}
