using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivadorPlataforma : MonoBehaviour
{

    public GameObject icono;

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
