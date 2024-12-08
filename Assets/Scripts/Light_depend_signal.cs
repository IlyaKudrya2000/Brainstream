using UnityEngine;
using System.Collections;
public class LightController : MonoBehaviour
{
    public Light lightSource;
    public float smoothTime = 0.3f;
    private float currentVelocity;
    private float currentVelocityAngle;
    private float time;
    private float signalDuration = 0f;
    private bool isFlickering = false;

    void Start()
    {

    }

    void Update()
    {
        time += Time.deltaTime;
        float inputSignal = Mathf.Sin(time);
        inputSignal = (inputSignal + 1) / 2;

        if (inputSignal > 0.5f)
        {
            signalDuration += Time.deltaTime;
            if (signalDuration >= 2f && !isFlickering)
            {
                StartCoroutine(FlickerLight());
            }
        }
        else
        {
            signalDuration = 0f;
        }

        if (!isFlickering)
        {
            lightSource.intensity = Mathf.SmoothDamp(lightSource.intensity, inputSignal <= 0.2f ? 0.2f : inputSignal, ref currentVelocity, smoothTime);
            lightSource.spotAngle = Mathf.SmoothDamp(lightSource.spotAngle, (inputSignal * 60 + 30), ref currentVelocityAngle, smoothTime);
        }
    }

    IEnumerator FlickerLight()
    {
        isFlickering = true;
        while (signalDuration >= 2f)
        {
            lightSource.enabled = !lightSource.enabled;
            yield return new WaitForSeconds(0.1f);
        }
        lightSource.enabled = true;
        isFlickering = false;
    }
}
