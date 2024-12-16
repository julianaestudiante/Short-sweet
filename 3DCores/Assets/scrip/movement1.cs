using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement1 : MonoBehaviour
{
    public float velocidad = 30f;
    public float gravedadExtra = 20f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movimiento = (transform.right * x + transform.forward * z);
        rb.velocity = new Vector3(movimiento.x * velocidad, rb.velocity.y, movimiento.z * velocidad);
        rb.AddForce(Vector3.down * gravedadExtra, ForceMode.Acceleration); // masa 
    }
}
