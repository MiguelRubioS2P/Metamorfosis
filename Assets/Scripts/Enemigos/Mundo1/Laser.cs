using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float velocidadDisparo = 12f;

    private Rigidbody2D rigidbody2d;
    private PlayerControll player;
    private Vector2 dondeDispara;
    private GameManager gameManager;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerControll>();
        

        if (gameObject.transform.position.x < player.transform.position.x)
        {
            rigidbody2d.velocity = new Vector2(1f * velocidadDisparo, rigidbody2d.velocity.y);
        }
        else if (gameObject.transform.position.x > player.transform.position.x)
        {
            rigidbody2d.velocity = new Vector2(-1f * velocidadDisparo, rigidbody2d.velocity.y);
        }
        Destroy(gameObject, 1f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            Debug.Log("Dado laser");
            gameManager.PerderVida();
            Destroy(gameObject);
        }
    }
}
