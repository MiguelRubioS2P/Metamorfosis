using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{

    public float temporizadorCaida = 1f; // Tiempo que tarda en caer
    public float temporizadorSpawn = 3f; // Tiempo que tarda en aparecer de nuevo
    private Rigidbody2D rigidbody2d;
    private Vector3 inicio;
    private BoxCollider2D boxCollider2d;

    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        inicio = transform.position;
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Caer", temporizadorCaida);
            Invoke("Respawn", temporizadorCaida + temporizadorSpawn);
        }
    }


    /// <summary>
    /// Hacemos que ya no solo le afecten unas pocos tipos de fuerza desactivando el Kinematic
    /// y aparte lo hacemos trigger por si hubiera plataformas o suelo debajo
    /// para que no colisione con el entorno de manera extraña
    /// </summary>
    void Caer()
    {
        rigidbody2d.isKinematic = false;
        boxCollider2d.isTrigger = true;
    }

    /// <summary>
    /// Le indicamos la posición que es la misma que el inicio que la tenemos guardada
    /// activamos el kinematic y desactivamos el trigger porque sino no podría tener 
    /// al personaje o otro elemento por último
    /// ponemos la velocidad a  0 porque como ha estado bajando hacia el vacío, a pesar de
    /// que lo pongamos en la posición bajaria instantaneo.
    /// </summary>
    void Respawn()
    {
        transform.position = inicio;
        rigidbody2d.isKinematic = true;
        rigidbody2d.velocity = Vector3.zero;
        boxCollider2d.isTrigger = false;
    }
}
