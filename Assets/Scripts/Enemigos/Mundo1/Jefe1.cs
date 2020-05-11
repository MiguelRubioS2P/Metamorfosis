﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jefe1 : MonoBehaviour
{
    private GameObject player;
    private bool isFlipped;
    private float rangoDaño = 3f;
    public Image[] vidas;
    private int vida = 4;
    public GameObject final;
    // ----------------------------------------
    private Animator animator;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>().gameObject;
        animator = GetComponent<Animator>();
        final = FindObjectOfType<FinalNiveles>().gameObject;
    }

    public void LookAtPlayer()
    {
        if (transform.position.x > player.transform.position.x && isFlipped)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFlipped = false;
        }
        else if (transform.position.x < player.transform.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFlipped = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            animator.SetBool("caminar", true);
        }
        if (collision.transform.tag == "Rango espada")
        {
            Debug.Log("Daño espada");
            if (Vector2.Distance(player.transform.position, gameObject.transform.position) <= rangoDaño)
            {
                animator.SetBool("daño", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            animator.SetBool("caminar", false);
        }
        if (collision.transform.tag == "Rango espada")
        {
            animator.SetBool("daño", false);

        }
    }

    public int PerderVida()
    {
        vidas[vida].gameObject.SetActive(false);
        vida--;
        return vida;
    }
    public void Morir()
    {
        animator.SetBool("muerto", true);
        final.GetComponent<SpriteRenderer>().enabled = true;
        final.GetComponent<BoxCollider2D>().enabled = true;
        Destroy(gameObject, 1.5f);
    }

}