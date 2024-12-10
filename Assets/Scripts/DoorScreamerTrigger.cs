using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScreamerTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _door.Toggle();
        }
    }
}
