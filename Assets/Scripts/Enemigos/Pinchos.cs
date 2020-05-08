using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private GameObject player;
    private float fuerzaMovimiento = 2f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private GameManager gameManager;

    private bool moverse, atacando, meHacenDaño;

    private float distancia;
    private int vidas;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>().gameObject;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        moverse = false;
        atacando = false;
        meHacenDaño = false;
        gameManager = FindObjectOfType<GameManager>();
        vidas = 1;
    }

    void Update()
    {
        distancia = player.transform.position.x - gameObject.transform.position.x;
        if (moverse && !atacando && !meHacenDaño)
        {
            Moverse();
        }
    }

    void Moverse()
    {
        if (gameObject.transform.position.x < player.transform.position.x)
        {
            animator.SetBool("caminar", true);
            spriteRenderer.flipX = true;
            rigidbody2d.velocity = new Vector2(1f * fuerzaMovimiento, 0f);
        }
        else if (gameObject.transform.position.x > player.transform.position.x)
        {
            animator.SetBool("caminar", true);
            spriteRenderer.flipX = false;
            rigidbody2d.velocity = new Vector2(-1f * fuerzaMovimiento, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            moverse = true;
        }
        if (collision.transform.tag == "Rango espada")
        {
            if ((distancia > 0 && distancia < 2f) || (distancia < 0 && distancia > -2f))
            {
                StartCoroutine(Daño());
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {           
            moverse = false;
            animator.SetBool("caminar", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Atacar());
        }
    }

    IEnumerator Atacar()
    {
        if(!atacando)
        {
            atacando = true;
            moverse = false;
            animator.SetBool("atacar", true);

            yield return new WaitForSeconds(0.5f);
            if ((distancia > 0 && distancia < 1f) || (distancia < 0 && distancia > -1f))
            {
                gameManager.PerderVida();
            }
            yield return new WaitForSeconds(0.5f);

            animator.SetBool("atacar", false);
            atacando = false;
            moverse = true;
        }
        
    }

    IEnumerator Daño()
    {
        if (!meHacenDaño)
        {
            meHacenDaño = true;
            moverse = false;
            animator.SetBool("daño", true);

            vidas--;
            if (vidas < 0)
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

            yield return new WaitForSeconds(0.35f);
            animator.SetBool("daño", false);
            moverse = true;
            meHacenDaño = false;
        }

    }

    IEnumerator Muerto()
    {
        rigidbody2d.velocity = new Vector2(0f, 0f);
        moverse = false;
        animator.SetBool("muerto", true);
        yield return new WaitForSeconds(2.05f);
        Destroy(gameObject);
    }
}
