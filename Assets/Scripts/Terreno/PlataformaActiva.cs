using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaActiva : MonoBehaviour
{

    // Este script debe ir con un collider para controlar si esta en la región que le 
    // posibilite activar el GO

    public GameObject go; //GO plataforma que queremos mover
    private PlataformaMovil scriptPlataformaMovil; // Script de mover plataforma
    private bool encima;
    
    void Start()
    {
        encima = false;
        scriptPlataformaMovil = go.GetComponent<PlataformaMovil>();
    }

    
    void Update()
    {
        if (encima)
        {
            // Si pulsamos la E activamos el script de moverse y ya funciona todo
            if (Input.GetKeyDown(KeyCode.E))
            {
                scriptPlataformaMovil.enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            encima = true;
        }
    }

    /// <summary>
    /// Cuando salimos de la región paramos el movimiento de la plataforma
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            encima = false;
            scriptPlataformaMovil.enabled = false;
        }
    }
}
