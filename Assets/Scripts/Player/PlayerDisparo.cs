using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisparo : MonoBehaviour
{
    public Transform disparoIzquierda, disparoDerecha;
    public GameObject espadaIzquierda,espadaDerecha;
    private PlayerControll player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>();
    }

    private void Update()
    {
        if (!player.muerto)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && player.GetComponent<SpriteRenderer>().flipX)
            {
                LanzarIzquierda();
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && !player.GetComponent<SpriteRenderer>().flipX)
            {
                LanzarDerecha();
            }
        }
    }

    private void LanzarIzquierda()
    {
        Instantiate(espadaIzquierda, disparoIzquierda.position, disparoIzquierda.rotation);
    }

    private void LanzarDerecha()
    {
        Instantiate(espadaDerecha, disparoDerecha.position, disparoDerecha.rotation);
    }
}
