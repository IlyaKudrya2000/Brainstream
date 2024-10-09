using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        if (Input.GetKey(KeyCode.E))
    //        {
    //            _door.Open();
    //        }
    //    }
    //}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                _door.Toggle();
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    
    //    if (other.tag == "Player")
    //    {
    //        if (Input.GetKey(KeyCode.E))
    //        {
    //            _door.Close();
    //        }
    //    }
    //}
}
