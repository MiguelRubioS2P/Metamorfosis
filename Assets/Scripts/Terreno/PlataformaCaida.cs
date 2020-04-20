using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{

    public float temporizadorCaida = 1f;
    public float temporizadorSpawn = 3f;
    private Rigidbody2D rigidbody2d;
    private Vector3 inicio;
    private BoxCollider2D boxCollider2d;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        inicio = transform.position;
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Caer", temporizadorCaida);
            Invoke("Respawn", temporizadorCaida + temporizadorSpawn);
        }
    }

    void Caer()
    {
        rigidbody2d.isKinematic = false;
        boxCollider2d.isTrigger = true;
    }

    void Respawn()
    {
        transform.position = inicio;
        rigidbody2d.isKinematic = true;
        rigidbody2d.velocity = Vector3.zero;
        boxCollider2d.isTrigger = false;
    }
}
