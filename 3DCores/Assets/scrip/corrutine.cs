using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corrutine : MonoBehaviour
{
    // Start is called before the first frame update
    // Referencia al Renderer del objeto
    private Renderer objRenderer;

 
    void Start()
    {
        // Obtiene el Renderer del objeto para acceder al material
        objRenderer = GetComponent<Renderer>();
        StartCoroutine(cambiarColor());
    }

    IEnumerator cambiarColor()
    {
        while(true)
        {
            objRenderer.material.color = Color.red;
            yield return new WaitForSeconds(2);

            objRenderer.material.color = Color.green;
            Debug.Log("cambiar color");
            yield return new WaitForSeconds(3);

            objRenderer.material.color = Color.blue;
            Debug.Log("cambiar color");
            yield return new WaitForSeconds(2);
        }
       

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
