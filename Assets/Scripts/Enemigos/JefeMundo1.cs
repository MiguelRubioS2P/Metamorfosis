using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeMundo1 : MonoBehaviour
{
    private GameObject player;
    private GameObject rango;
    private GameManager gameManager;

    private Rigidbody2D rigidbody2d;
    private float fuerzaMovimiento = 2f;

    private bool dentroAreaAtaque;
    private SpriteRenderer spriteRenderer;

    private Animator animator;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>().gameObject;
        rango = gameObject.transform.GetChild(0).gameObject;
        gameManager = FindObjectOfType<GameManager>();

        rigidbody2d = GetComponent<Rigidbody2D>();

        dentroAreaAtaque = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            dentroAreaAtaque = true;
            animator.SetBool("caminar", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            dentroAreaAtaque = false;
            animator.SetBool("caminar", false);
        }
    }
    void Update()
    {
        if (dentroAreaAtaque)
        {
            Moverse();
        }
    }

    private void Moverse()
    {
        if(gameObject.transform.position.x < player.transform.position.x)
        {
            spriteRenderer.flipX = true;
            rigidbody2d.velocity = new Vector2(1f * fuerzaMovimiento, rigidbody2d.velocity.y);
        } else
        {
            spriteRenderer.flipX = false;
            rigidbody2d.velocity = new Vector2(-1f * fuerzaMovimiento, rigidbody2d.velocity.y);
        }
    }

}
