using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Configurar_Jugador : MonoBehaviour
{
    public DatosGlobales datosGlobales; // Referencia al ScriptableObject
    public TMP_InputField inputNombre; // Referencia al componente InputField                                   
    public Button botonFacil, botonMedio, botonDificil; // Botones de dificultad
    public TMP_Text textoPuntuacion; // Referencia al texto de la puntuación


    private void Start()
    {
        if (datosGlobales == null)
        {
            Debug.LogError("El objeto DatosGlobales no está asignado.");
            return;  // Termina la ejecución si datosGlobales es null
        }

        // Configurar los botones para seleccionar dificultad
        botonFacil.onClick.AddListener(() => SeleccionarDificultad("Facil"));
        botonMedio.onClick.AddListener(() => SeleccionarDificultad("Medio"));
        botonDificil.onClick.AddListener(() => SeleccionarDificultad("Dificil"));

        if (!string.IsNullOrEmpty(datosGlobales.nombreJugador))
        {
            inputNombre.text = datosGlobales.nombreJugador;
        }

        inputNombre.onEndEdit.AddListener(GuardarNombre);
        ActualizarTextoPuntuacion();
        ReiniciarDatos();
    }

    public void GuardarNombre(string nuevoNombre)
    {
        datosGlobales.nombreJugador = inputNombre.text; // Guardar el nombre
        Debug.Log($"Nombre guardado: {datosGlobales.nombreJugador}");
    }

    private void SeleccionarDificultad(string dificultad)
    {
        datosGlobales.dificultad = dificultad; // Guardar la dificultad seleccionada
        Debug.Log($"Dificultad seleccionada: {dificultad}");
    }

    public void IncrementarPuntuacion()
    {
        datosGlobales.puntuacion++; // Incrementar la puntuación
        ActualizarTextoPuntuacion();
    }

    private void ActualizarTextoPuntuacion()
    {
        textoPuntuacion.text = $"Puntuación: {datosGlobales.puntuacion}";
    }


    public void ReiniciarDatos()
    {
        datosGlobales.ReiniciarDatos(); // Reinicia los datos en el ScriptableObject
        Debug.Log("Datos globales reiniciados.");
    }

    public void ReiniciarJuegoDesdeBoton()
    {
        ReiniciarDatos(); // Reinicia los datos
        SceneManager.LoadScene(0); // Reinicia al nivel inicial
    }


}
