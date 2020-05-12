﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioJuego : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        StartCoroutine(CargarJuego());
    }

    IEnumerator CargarJuego()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Menu Principal");
    }
}