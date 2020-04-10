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
    


    private void Awake()
    {
        salto = true;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        escena = SceneManager.GetActiveScene().name;
    }

    void Update()
    {

        if (spriteRenderer.sprite.name == "Knight_die_08")
        {
            SceneManager.LoadScene(escena);
        }

        if (Input.GetKey("a"))
        {
            
            rigidbody2d.velocity = new Vector2(-1f * fuerzaMovimiento, rigidbody2d.velocity.y);
            animator.SetBool("moverse", true);
            animator.SetBool("saltar", false);
            spriteRenderer.flipX = true;
           
        } 
        else if (Input.GetKey("d"))
        {
            rigidbody2d.velocity = new Vector2(1f * fuerzaMovimiento, rigidbody2d.velocity.y);
            animator.SetBool("moverse", true);
            animator.SetBool("saltar", false);
            spriteRenderer.flipX = false;
            
        }
        else if(Input.GetKeyUp("a") || Input.GetKeyUp("d"))
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
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetBool("atacar", true);
        }
        else
        {
            animator.SetBool("atacar", false);
        }
    }

    void Salto()
    {
        if(Input.GetKeyDown("space") && salto)
        {
            salto = false;
            animator.SetBool("saltar", true);
            rigidbody2d.AddForce(new Vector2(0f, 1f) * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "suelo")
        {
            salto = true;
            animator.SetBool("saltar", false);
        }
        if(collision.transform.tag == "rodillo" || collision.transform.tag == "pincho")
        {
            Morir();
        }
        
    }

    /// <summary>
    /// Método que activa la animación de morir
    /// </summary>
   private void Morir()
    {
        salto = false;
        animator.SetBool("saltar", false);
        animator.SetBool("muerto", true);
        
        
    }

    

    
}

