using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal2 : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;
    public bool moverse, stun;
    public Vector2 posicionInicial;
    public GameObject final;
    private int vida;

    private void Start()
    {
        vida = 5;
        moverse = false;
        stun = false;
        posicionInicial = gameObject.transform.position;
    }


    public void LookAtPlayer()
    {
        

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = new Vector3(1f,1f,1f);
            isFlipped = false;
        }else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFlipped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Ataque")
        {
            Debug.Log("Me has dado");
            Destroy(collision.gameObject);
            vida--;
            if (vida == 0)
            {
                Destroy(gameObject);
                final.GetComponent<SpriteRenderer>().enabled = true;
                final.GetComponent<BoxCollider2D>().enabled = true;
            }
            Debug.Log("Mi vida es: " + vida);
        }

        if(collision.transform.tag == "Rango espada")
        {
            Debug.Log("Me has dado");
            vida--;
            if (vida == 0)
            {
                Destroy(gameObject);
                final.GetComponent<SpriteRenderer>().enabled = true;
                final.GetComponent<BoxCollider2D>().enabled = true;
            }
            Debug.Log("Mi vida es: " + vida);
        }
    }
}
