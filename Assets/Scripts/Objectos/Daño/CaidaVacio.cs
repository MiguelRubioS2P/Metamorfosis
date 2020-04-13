using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaidaVacio : MonoBehaviour
{

    private PlayerControll player;
    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            player.Morir();
        }
    }
}
