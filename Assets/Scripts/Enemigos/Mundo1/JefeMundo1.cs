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

    private float fuerzaMovimiento = 3f;
    private bool dentroAreaAtaque, moverse;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public Image[] vidas;

    private int vida;
    private float distancia;
    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>().gameObject;
        rigidbody2d = GetComponent<Rigidbody2D>();

        dentroAreaAtaque = false;
        moverse = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        cadaCuantoDispara = 3f;
        siguienteDisparo = Time.time;

        vida = 4;
    }

    void Update()
    {
        distancia = player.transform.position.x - gameObject.transform.position.x;
        if (dentroAreaAtaque && moverse)
        {
            Moverse();
            StartCoroutine(Ataque());
        }
    }

    IEnumerator Ataque()
    {
        if (Time.time > siguienteDisparo)
        {
            moverse = false;
            animator.SetBool("atacar", true);
            
            yield return new WaitForSeconds(3f);
            Instantiate(laser, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2.2f);

            animator.SetBool("atacar", false);
            moverse = true;
            
            siguienteDisparo = Time.time + cadaCuantoDispara;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            dentroAreaAtaque = true;
            moverse = true;
        }
        if (collision.transform.tag == "Rango espada")
        {
            if((distancia > 0 && distancia < 2f) || (distancia < 0 && distancia > -2f))
            {
                StartCoroutine(Daño());
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            dentroAreaAtaque = false;
            moverse = false;
            animator.SetBool("caminar", false);
        }
    }

    void Moverse()
    {
        if(gameObject.transform.position.x < player.transform.position.x)
        {
            animator.SetBool("caminar", true);
            spriteRenderer.flipX = true;
            rigidbody2d.velocity = new Vector2(1f * fuerzaMovimiento, rigidbody2d.velocity.y);
        } else if (gameObject.transform.position.x > player.transform.position.x)
        {
            animator.SetBool("caminar", true);
            spriteRenderer.flipX = false;
            rigidbody2d.velocity = new Vector2(-1f * fuerzaMovimiento, rigidbody2d.velocity.y);
        }
    }

    IEnumerator Muerto()
    {
        animator.SetBool("muerto", true);
        rigidbody2d.velocity = new Vector2(0f, 0f);
        final.GetComponent<SpriteRenderer>().enabled = true;
        final.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(1.7f);
        Destroy(gameObject);
    }

    IEnumerator Daño()
    {
        moverse = false;
        vidas[vida].gameObject.SetActive(false);
        animator.SetBool("daño", true);

        vida--;
        if (vida < 0)
        {
            StartCoroutine(Muerto());
        }
        if (gameObject.transform.position.x < player.transform.position.x)
        {
            rigidbody2d.velocity = new Vector2(-1f * fuerzaMovimiento, rigidbody2d.velocity.y);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(1f * fuerzaMovimiento, rigidbody2d.velocity.y);
        }
            
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("daño", false);
        moverse = true;
    }
}
