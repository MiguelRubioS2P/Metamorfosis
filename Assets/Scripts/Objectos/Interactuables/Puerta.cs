using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject puertaAbierta, puertaCerrada;
    private bool dentro;
    public GameObject indicador;

    private void Start()
    {
        dentro = false;
    }

    private void Update()
    {
        if (dentro)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                puertaAbierta.SetActive(true);
                puertaCerrada.SetActive(false);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            dentro = true;
            indicador.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            dentro = false;
            indicador.SetActive(false);
            Destroy(indicador);
        }
    }


}
