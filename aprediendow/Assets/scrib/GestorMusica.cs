using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorMusica : MonoBehaviour
{
    public static GestorMusica instancia; // Singleton para garantizar una única instancia
    public Musica musica; // Referencia al ScriptableObject
    private AudioSource audioSource; // Reproductor de audio

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Si ya existe un gestor, destruir este
            return;
        }

        // Configurar el AudioSource
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Repetir la música en bucle
        audioSource.playOnAwake = false;
    }

    private void Start()
    {
        // Reproducir la música inicial (si está configurada)
        if (musica.musicaActual != null)
        {
            CambiarMusica(musica.musicaActual);
        }

        // Configurar el volumen inicial
        audioSource.volume = musica.volumenMusica;
    }

    private void Update()
    {
        // Actualizar el volumen dinámicamente si se cambia en el ScriptableObject
        audioSource.volume = musica.volumenMusica;
    }

    public void CambiarMusica(AudioClip nuevaMusica)
    {
        if (audioSource.clip == nuevaMusica) return; // No cambiar si ya está reproduciendo

        audioSource.clip = nuevaMusica;
        audioSource.Play();
        musica.musicaActual = nuevaMusica; // Actualizar en el ScriptableObject
    }

    public void DetenerMusica()
    {
        audioSource.Stop();
        musica.musicaActual = null;
    }
}
