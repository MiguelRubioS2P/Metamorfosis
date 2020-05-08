using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamanteColecionable : MonoBehaviour
{
    private GameManager gameManager;
    private int cuantoVale = 10;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            for(int i = 0; i < cuantoVale; i++)
            {
                gameManager.GanarDinero();
            }
            
            Destroy(gameObject);
        }
    }
}
