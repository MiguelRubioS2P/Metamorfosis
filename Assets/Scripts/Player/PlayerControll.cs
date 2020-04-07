using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private bool salto;

    private void Awake()
    {
        salto = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey("a"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-1f * Time.deltaTime, 0, 0) * 10f, ForceMode2D.Impulse);
            GetComponent<Animator>().SetBool("moverse", true);
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GetComponent<Animator>().SetBool("atacar", true);
            }
            //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f * Time.deltaTime, 0));
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey("d"))
        {
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(1000f * Time.deltaTime, 0));
            GetComponent<Rigidbody2D>().AddForce(new Vector3(1f * Time.deltaTime, 0, 0) * 10f, ForceMode2D.Impulse);
            GetComponent<Animator>().SetBool("moverse", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<Animator>().SetBool("atacar", true);
        } else
        {
            GetComponent<Animator>().SetBool("moverse", false);
            GetComponent<Animator>().SetBool("atacar", false);
        }
        Salto();
       
    }

    void Salto()
    {
        if(Input.GetKeyDown("space") && salto)
        {
            salto = false;
            GetComponent<Animator>().SetBool("saltar", true);
            //Si pulsamos para salta, podemos saltar y la altura es menor que 10, es decir que este en el suelo
            GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 3f, 0) * 5f, ForceMode2D.Impulse);
        }
        else
        {
            if(gameObject.transform.position.y > 0)
            {
                
                //si esta saltando, hacemos que baje
                //gameObject.transform.Translate(0, -50f * Time.deltaTime, 0);
                // GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -3f, 0) * 2f, ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().AddForce(new Vector3(0, -1f, 0) * 0.5f, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "suelo")
        {
            salto = true;
            GetComponent<Animator>().SetBool("saltar", false);
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

