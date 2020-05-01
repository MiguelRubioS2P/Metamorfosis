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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            dentroAreaAtaque = true;
            moverse = true;
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

    void Update()
    {
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
            animator.SetBool("atacar", true);
            moverse = false;
            yield return new WaitForSeconds(3f);
            Instantiate(laser, transform.position, Quaternion.identity);
            siguienteDisparo = Time.time + cadaCuantoDispara;
            moverse = true;
            animator.SetBool("atacar", false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.tag);
        if (collision.transform.tag == "Rango espada")
        {
            StartCoroutine(Daño());
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
