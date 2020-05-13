using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float velocidadDisparo = 12f;

    private Rigidbody2D rigidbody2d;
    private Jefe1 jefe;
    private GameManager gameManager;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        jefe = FindObjectOfType<Jefe1>();
        

        if (jefe.isFlipped)
        {
            rigidbody2d.velocity = new Vector2(1f * velocidadDisparo, rigidbody2d.velocity.y);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(-1f * velocidadDisparo, rigidbody2d.velocity.y);
        }
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            gameManager.PerderVida();
            Destroy(gameObject);
        }
    }
}
