using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;
using UnityEngine.UIElements;

public class DoorTrigger : MonoBehaviour
{
    public enum openType
    {
        full90degrees,
        partiallyToAngle
    }
    public openType openTypeState;
    [SerializeField] float speed;
    public float openAngle = 45;
    [SerializeField] bool isClosed=true;

    float nowAngle = 0;
    Vector3 startingAngles;
    public void Start(){
        startingAngles = transform.rotation.eulerAngles;
    }   
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(startingAngles.x,nowAngle+startingAngles.y,startingAngles.z);
        if(openAngle > 0)
        {
            if (nowAngle < openAngle && !isClosed)
                nowAngle += speed*Time.deltaTime;
            if (nowAngle > 0 && isClosed)
                nowAngle -= speed*Time.deltaTime;
        }
        else{
            if (nowAngle > openAngle && !isClosed)
                nowAngle -= speed*Time.deltaTime;
            if (nowAngle < 0 && isClosed)
                nowAngle += speed*Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                isClosed = !isClosed;
                Debug.Log(transform.rotation.eulerAngles);
                // if (openTypeState == openType.full90degrees)
                //     _door.Toggle();
                // else
                //     _door.ToggleToAngle(openAngle);
            }
        }
    }

}
