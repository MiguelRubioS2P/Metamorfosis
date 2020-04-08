using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private bool salto;
    private Animator animator;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        salto = false;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Input.GetKey("a"))
        {

            rigidbody2d.AddForce(Vector2.left * Time.deltaTime * 10f, ForceMode2D.Impulse);
            
            animator.SetBool("moverse", true);
            animator.SetBool("saltar", false);
            spriteRenderer.flipX = true;
           
        }
        else if (Input.GetKey("d"))
        {

            rigidbody2d.AddForce(Vector2.right * Time.deltaTime * 10f, ForceMode2D.Impulse);
            
            animator.SetBool("moverse", true);
            animator.SetBool("saltar", false);
            spriteRenderer.flipX = false;
            
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
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
            //Si pulsamos para salta, podemos saltar y la altura es menor que 10, es decir que este en el suelo
            rigidbody2d.AddForce(new Vector3(0, 3f, 0) * 5f, ForceMode2D.Impulse);
        }
        else
        {
            if(gameObject.transform.position.y > 0)
            {

                //si esta saltando, hacemos que baje
                //gameObject.transform.Translate(0, -50f * Time.deltaTime, 0);
                // GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -3f, 0) * 2f, ForceMode2D.Impulse);
                rigidbody2d.AddForce(new Vector3(0, -2f, 0) * 0.5f, ForceMode2D.Impulse);
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "suelo")
        {
            salto = true;
            animator.SetBool("saltar", false);
        }
    }

    /*void Update()
    {
        if (Input.GetKey("a"))
        {
            //transform.Translate(-20f * Time.deltaTime, 0, 0);
            //GetComponent<Rigidbody2D>().velocity = (new Vector2(-20f, GetComponent<Rigidbody2D>().velocity.y));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-900f * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey("d"))
        {
            //transform.Translate(20f * Time.deltaTime, 0, 0);
            //GetComponent<Rigidbody2D>().velocity = (new Vector2(20f, GetComponent<Rigidbody2D>().velocity.y));
            GetComponent<Rigidbody2D>().AddForce(new Vector2(900f * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if (Input.GetKeyDown("space") && salto)
        {
            salto = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0 , 500f));
            //transform.Translate(0, 100f * Time.deltaTime, 0);
            //GetComponent<Rigidbody2D>().velocity = (new Vector2(GetComponent<Rigidbody2D>().velocity.x, 100f));
        }
    }*/
}

