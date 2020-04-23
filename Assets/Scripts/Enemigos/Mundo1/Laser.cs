using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float velocidadDisparo = 10f;

    private Rigidbody2D rigidbody2d;
    private PlayerControll player;
    private Vector2 dondeDispara;

    private GameManager gameManager;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerControll>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        
        dondeDispara = (player.transform.position - transform.position).normalized * velocidadDisparo;
        
        rigidbody2d.velocity = new Vector2(dondeDispara.x, dondeDispara.y);
        Destroy(gameObject, 3f);
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
