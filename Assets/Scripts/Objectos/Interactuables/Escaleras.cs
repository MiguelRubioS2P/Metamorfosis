using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour
{
    private float velocidadSubida = 6f;
    private PlayerControll player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {        
        if (collision.tag == "Player" && Input.GetKey("w"))
        {
            Debug.Log(collision.tag + "subir");
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1f * velocidadSubida);
        }
        else if (collision.tag == "Player" && Input.GetKey("s"))
        {
            Debug.Log(collision.tag + "bajar");
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1f * -velocidadSubida);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
