using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    //public enum openType
    //{
    //    full90degrees,
    //    partiallyToAngle
    //}
    //public openType openTypeState;
    //
    //public float openAngle = 45;
    private bool _isEnter;

    private void OnTriggerEnter(Collider other)
    {
        _isEnter = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && _isEnter)
        {
            _door.Toggle();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _isEnter = false;
    }

}
