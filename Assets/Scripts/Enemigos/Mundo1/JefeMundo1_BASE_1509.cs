using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JefeMundo1 : MonoBehaviour
{
   [SerializeField] GameObject laser;

    float cadaCuantoDispara;
    float siguienteDisparo;
    
    private GameObject player;
    public GameObject final;
    private Rigidbody2D rigidbody2d;
    private float fuerzaMovimiento = 2f;
    private bool dentroAreaAtaque;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public Image[] vidas;

    private int vida;
    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>().gameObject;
        rigidbody2d = GetComponent<Rigidbody2D>();

        dentroAreaAtaque = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        cadaCuantoDispara = 3f;
        siguienteDisparo = Time.time;

        vida = 4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            dentroAreaAtaque = true;
            animator.SetBool("caminar", true);
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
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
            Ataque();
        }
    }

    void Ataque()
    {
        if (Time.time > siguienteDisparo)
        {
            Instantiate(laser, transform.position, Quaternion.identity);
            siguienteDisparo = Time.time + cadaCuantoDispara;
        }
    }

    void Moverse()
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.name == "Rango Ataque")
        {
            Debug.Log(collision.collider.name);
            vidas[vida].gameObject.SetActive(false);

            vida--;
            if (vida < 0)
            {
                StartCoroutine(Muerto());
            }
        }
    }

    IEnumerator Muerto()
    {
        animator.SetBool("muerto", true);
        final.SetActive(true);
        yield return new WaitForSeconds(1.7f);
        Destroy(gameObject);
    }
}
