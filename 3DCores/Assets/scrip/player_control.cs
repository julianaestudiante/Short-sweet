using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class player_control : MonoBehaviour
{
    [Header("Salud")]
    [Space(13)]
    [SerializeField, Range(1, 5)] private int vida;
   
    [ContextMenuItem("restablecer Salud", "RestableceSaludMaxima")]
    [SerializeField, Range(1f, 10f)] private float salud;
    public int SaludMaxima = 100;

    [Tooltip("rango salud player")]
    [HideInInspector] private float daño;


    [Header("movimiento")]
    [SerializeField] private int velocidad;
    [SerializeField, Min(2)] private float velocidadDeslizamiento;

    [Header("personaje")]
    [TextArea(1, 10)]
    [SerializeField] private string Descripcion;

    [ContextMenu("Restar Vida")]
    private void RestarVida()
    {
        vida--;
    }

    private void RestableceSaludMaxima()
    {
        salud = SaludMaxima;
    }
}


