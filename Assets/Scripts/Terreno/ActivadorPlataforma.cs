using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorPlataforma : MonoBehaviour
{
    
    // Este script solo tiene la funcion de controlar una región para que el jugador sepa que es 
    // un GO activable.

    public GameObject icono; // Simbolo que indica que la plataforma se puede activar

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            icono.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            icono.SetActive(false);
        }
    }
}
