using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour
{
    private bool salto;
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private float fuerzaMovimiento = 6f;
    private float fuerzaSalto = 10f;
    public string escena;
    private GameManager gameManager;
    public AudioClip sonidoSalto;
    private AudioSource audioSource;
    private bool muerto;

    private GameObject RangoAtaque;


    private void Awake()
    {
        salto = true;
        RangoAtaque = gameObject.transform.GetChild(0).gameObject;
        Cursor.visible = false;
        muerto = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        escena = SceneManager.GetActiveScene().name;
        gameManager = FindObjectOfType<GameManager>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sonidoSalto;
        
    }

    void Update()
    {

        if (spriteRenderer.sprite.name == "Knight_die_08")
        {
            gameManager.PerderDinero();
            gameManager.PerderVida();
            muerto = false;
            SceneManager.LoadScene(escena);
        }

        if (Input.GetKey("a") && (salto || !salto) && !muerto)
        {
            
            rigidbody2d.velocity = new Vector2(-1f * fuerzaMovimiento, rigidbody2d.velocity.y);
            animator.SetBool("moverse", true);
            spriteRenderer.flipX = true;
           
        }
        else if (Input.GetKey("d") && (salto || !salto) && !muerto)
        {
            rigidbody2d.velocity = new Vector2(1f * fuerzaMovimiento, rigidbody2d.velocity.y);
            animator.SetBool("moverse", true);
            spriteRenderer.flipX = false;
            
        }
        //(Input.GetKeyUp("a") || Input.GetKeyUp("d")) && !muerto
        else if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
        {
            rigidbody2d.velocity = new Vector2(0f, rigidbody2d.velocity.y);
        }
        else if (!salto)
        {
            animator.SetBool("saltar", true);
            animator.SetBool("moverse", false);
        }
        else
        {
            animator.SetBool("moverse", false);
        }
        Salto();
        Atacar();
    }

    void Atacar()
    {
        //Input.GetKey(KeyCode.Mouse0) && !muerto
        if (Input.GetKey(KeyCode.Mouse0) && !muerto)
        {
            animator.SetBool("atacar", true);
            RangoAtaque.SetActive(true);
        }
        else
        {
            animator.SetBool("atacar", false);
            RangoAtaque.SetActive(false);
        }
    }

    void Salto()
    {
        //Input.GetKeyDown("space") && salto && !muerto
        if (Input.GetKeyDown("space") && salto && !muerto)
        {
            salto = false;
            animator.SetBool("saltar", true);
            rigidbody2d.AddForce(new Vector2(0f, 1f) * fuerzaSalto, ForceMode2D.Impulse);
            audioSource.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "suelo")
        {
            salto = true;
            animator.SetBool("saltar", false);
        }
        if(collision.transform.tag == "pincho" ||collision.transform.tag == "muerte")
        {
            
            Morir();
        }
        if(collision.transform.tag == "plataforma")
        {
            rigidbody2d.velocity = Vector2.zero;
            // Estamos haciendo que player sea hijo del elemento con el que colisiona, en este caso la plataforma
            gameObject.transform.parent = collision.transform;
            salto = true;
            animator.SetBool("saltar", false);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "plataforma")
        {
            gameObject.transform.parent = null;
        }
    }

    /// <summary>
    /// Método que activa la animación de morir
    /// </summary>
    public void Morir()
    {
        muerto = true;
        salto = false;
        animator.SetBool("saltar", false);
        animator.SetBool("muerto", true);
        

    }

    




}

