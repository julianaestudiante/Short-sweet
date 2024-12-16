using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para trabajar con escenas

public class fadeTester : MonoBehaviour
{
    public fade fade; // Referencia al script CameraFade

    private void OnEnable()
    {
        // Suscribirse al evento cuando una escena se ha cargado
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Desuscribirse del evento cuando este objeto se desactiva
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Este método se llama cada vez que se carga una nueva escena
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Llama al fade out cuando se carga una nueva escena
        fade.StartFadeOut();
    }

    // Si quieres agregar un fade in antes de cargar la siguiente escena (opcional)
    public void ChangeSceneWithFade(string sceneName)
    {
        fade.StartFadeIn();
        StartCoroutine(LoadSceneAfterFade(sceneName));
    }

    // Coroutine para cargar la escena después de que el fade in termine
    private IEnumerator LoadSceneAfterFade(string sceneName)
    {
        yield return new WaitForSeconds(1f); // Espera el tiempo del fade (ajústalo a tu necesidad)
        SceneManager.LoadScene(sceneName);
    }
}
