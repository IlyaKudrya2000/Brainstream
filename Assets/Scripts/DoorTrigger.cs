using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    public enum openType
    {
        full90degrees,
        partiallyToAngle
    }
    public openType openTypeState;

    public float openAngle = 45;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (openTypeState == openType.full90degrees)
                    _door.Toggle();
                else
                    _door.ToggleToAngle(openAngle);
            }
        }
    }

}
