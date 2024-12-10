using UnityEngine;

public class FallOnTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private bool AccelerationMove;
    public Vector3 initialForce = new Vector3(0, -10, 0);
    //[SerializeField] private Collider other;
    void Start()
    {
     //   rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
           //Debug.Log("’ÛÈ");
            rb.isKinematic = false;
            rb.AddForce(initialForce, ForceMode.Impulse);
        }
    }
}
