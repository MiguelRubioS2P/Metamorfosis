using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JefeFinal2 : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;
    public bool moverse, stun,muerto;
    public Vector2 posicionInicial;
    public GameObject final;
    private int vida;
    public Image[] vidas;
    

    private void Awake()
    {
        muerto = false;
    }
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

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.tag == "Ataque")
    //    {
    //        Debug.Log("Me has dado");
    //        Destroy(collision.gameObject);
    //        vida--;
    //        vidas[vida].gameObject.SetActive(false);
    //        if (vida == 0)
    //        {
    //            muerto = true;
    //            Destroy(gameObject,1.3f);
    //            final.GetComponent<SpriteRenderer>().enabled = true;
    //            final.GetComponent<BoxCollider2D>().enabled = true;
    //        }
    //        Debug.Log("Mi vida es: " + vida);
    //    }

    //    if(collision.transform.tag == "Rango espada")
    //    {
    //        Debug.Log("Me has dado");
    //        vida--;
    //        vidas[vida].gameObject.SetActive(false);
    //        if (vida == 0)
    //        {
    //            muerto = true;
    //            Destroy(gameObject, 1.3f);
    //            final.GetComponent<SpriteRenderer>().enabled = true;
    //            final.GetComponent<BoxCollider2D>().enabled = true;
    //        }
    //        Debug.Log("Mi vida es: " + vida);
    //    }
    //}


    public void RecibirDaño(int daño)
    {
        vida -= daño;
        vidas[vida].gameObject.SetActive(false);
        if(vida <= 0)
        {
            muerto = true;
            Destroy(gameObject, 1.3f);
            final.GetComponent<SpriteRenderer>().enabled = true;
            final.GetComponent<BoxCollider2D>().enabled = true;
        }

    }
}
