using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicaConfig", menuName = "Datos/MusicaConfig")]
public class Musica : ScriptableObject
{
    public AudioClip musicaActual; // Clip de música que se reproducirá
    public float volumenMusica = 1.0f; // Volumen de la música
}
