using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] private Transform _rotatingLeaf;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _duration = 1.0f;
    [Range(-180, 180)][SerializeField] private float _openAngle = 90.0f;
    private Coroutine _rotateCoroutine;

    private IEnumerator Rotate(float start, float end)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _duration)
        {
            _rotatingLeaf.transform.rotation = Quaternion.Lerp(
            Quaternion.Euler(0, start, 0),
            Quaternion.Euler(0, end, 0),
            _animationCurve.Evaluate(i));

            yield return null;
        }

        _rotatingLeaf.transform.rotation = Quaternion.Euler(0, end, 0);
        _rotateCoroutine = null;
    }
    private enum DoorState
    {
        Undefined,
        Open,
        Close,
    }

    private DoorState GetDoorState(float angle)
    {
        if (Mathf.Approximately(0, angle))
            return DoorState.Close;

        if (Mathf.Approximately(_openAngle, angle))
            return DoorState.Open;

        return DoorState.Undefined;
    }
    private float GetCurrentAngle()
    {
        float currentAngle = Quaternion.Angle(Quaternion.identity, _rotatingLeaf.transform.rotation);
        currentAngle *= _openAngle > 0 ? 1 : -1;
        return currentAngle;
    }

    public void Toggle()
    {
        var currentAngle = GetCurrentAngle();
        if (GetDoorState(currentAngle) == DoorState.Close)
            Open();
        else if (GetDoorState(currentAngle) == DoorState.Open)
            Close();
    }

    //public void RotateToAngle(float angle)

    public void Open()
    {
        var currentAngle = GetCurrentAngle();

        if (GetDoorState(currentAngle) == DoorState.Open)
            return;

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(Rotate(currentAngle, _openAngle));
    }

    public void Close()
    {
        var currentAngle = GetCurrentAngle();

        if (GetDoorState(currentAngle) == DoorState.Close)
            return;

        if (_rotateCoroutine != null)
            StopCoroutine(_rotateCoroutine);

        _rotateCoroutine = StartCoroutine(Rotate(currentAngle, 0));
    }
}
