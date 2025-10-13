/* Player movement script*/

using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float speed = 10f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();       
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0f, v);
        rb.AddForce(dir * speed);
    }
}
