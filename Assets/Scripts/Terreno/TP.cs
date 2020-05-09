using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{

    public GameObject posicionFinal;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Hola, estoy dentro");
            player.transform.position = posicionFinal.transform.position;
            Destroy(gameObject);
        }
    }
}
