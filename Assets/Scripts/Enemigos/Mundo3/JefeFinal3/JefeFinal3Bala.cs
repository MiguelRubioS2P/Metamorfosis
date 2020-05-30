using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal3Bala : MonoBehaviour
{
    public float velocidadDisparo = 10f;

    private Rigidbody2D rb;
    private JefeFinal3 jefe;
    private GameManager gameManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        jefe = FindObjectOfType<JefeFinal3>();
    }

    private void Start()
    {
        rb.velocity = transform.up * velocidadDisparo;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.tag == "personaje")
        {
            Debug.Log("Impacto");
            gameManager.PerderVida();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5f);
        }
    }
}
