using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "DatosGlobales",menuName = "Datos/DatosGlobales")]
public class DatosGlobales : ScriptableObject
{

    public string nombreJugador;
    public string dificultad;
    public int puntuacion;

    public void ReiniciarDatos()
    {
        nombreJugador = "";
        dificultad = "";
        puntuacion = 0;
        Debug.Log("DatosGlobales reiniciados.");
    }
}
