using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MostrarDatos : MonoBehaviour
{
    public DatosGlobales datosGlobales; // Referencia al ScriptableObject
    public TMP_Text textoNombre; // Texto para el nombre del jugador
    public TMP_Text textoDificultad; // Texto para la dificultad seleccionada
    public TMP_Text textoPuntuacion; // Texto para la puntuación

    private void Start()
    {
        textoNombre.text = $"Nombre: {datosGlobales.nombreJugador}";
        textoDificultad.text = $"Dificultad: {datosGlobales.dificultad}";
        textoPuntuacion.text = $"Puntuación: {datosGlobales.puntuacion}";
    }
}
