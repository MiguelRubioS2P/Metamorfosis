using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Murete : MonoBehaviour
{
    private int vida;

    private void Awake()
    {
        vida = 3;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Rango Ataque")
        {
            vida--;
            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
