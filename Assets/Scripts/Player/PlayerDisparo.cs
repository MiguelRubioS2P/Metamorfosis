using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisparo : MonoBehaviour
{
    public Animator animator;
    private PlayerControll player;

    public float ratioAtaque = 2f;
    private float siguienteAtaque = 0f;

    public GameObject bolaFuegoDerecha,bolaFuegoIzquierda;
    public Transform posicionDerecha,posicionIzquierda;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>();
    }

    private void Update()
    {
        if (Time.time >= siguienteAtaque)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Disparar();
                siguienteAtaque = Time.time + 1f / ratioAtaque;
            }
        }
    }

    public void DispararDerecha()
    {
        
        Instantiate(bolaFuegoDerecha, posicionDerecha.position, posicionDerecha.rotation);
    }

    public void DispararIzquierda()
    {
        
        Instantiate(bolaFuegoIzquierda, posicionIzquierda.position, posicionIzquierda.rotation);
    }

    public void Disparar()
    {
        animator.SetBool("Disparar", true);
    }

}
