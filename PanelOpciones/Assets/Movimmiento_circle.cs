using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimmiento_circle : MonoBehaviour
{
    public float speed = 5f;
    public float movex = Input.GetAxis("Horizontal");
    public float movez = Input.GetAxis("Vertical");

    // Start is called before the first frame update
    void Start()
    {
    }

    public void movimiento()
    {
        transform.Translate(new Vector3(movex, 0, movez) * speed * Time.deltaTime);

    }

}
