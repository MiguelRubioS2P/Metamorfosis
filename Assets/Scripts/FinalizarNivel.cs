﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarNivel : MonoBehaviour
{
    private Animator animator;
    private static int _estrellas, _monedas;
    private static string _escena;
    private OptionsManager option;
    List<Partida> partidas = new List<Partida>();
    private void Awake()
    {
        option = FindObjectOfType<OptionsManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(animacionGuardando());
    }
    public IEnumerator animacionGuardando()
    {
        comprobarRecord();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu Niveles");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("saltando", true);
        }
    }

    
    private void comprobarRecord()
    {
        partidas = option.partidas;
        foreach (Partida i in partidas)
        {
            if (i.nombre.Equals(option.nombrePartida))
            {
                foreach (Nivel z in i.niveles)
                {
                    if (z.Nombre.Equals(option._ultimaEscenaJugada))
                    {
                        if(option._utlimasMonedasConseguidas >= z.Monedas)
                        {
                            //si tenemos mas monedas tendremos mas estrellas
                            GuardarEstrellasYMonedas();
                        }
                    }
                }
            }

        }
    }

    /// <summary>
    /// Método para guardar las estrellas y las monedas conseguidas en el nivel
    /// </summary>
    private void GuardarEstrellasYMonedas()
    {
        option.SumarMonedasNivel(option._ultimaEscenaJugada, option.nombrePartida, option._utlimasMonedasConseguidas);
        option.SumarEstrellasNivel(option._ultimaEscenaJugada, option.nombrePartida, option._ultimasEstrellasConseguidas);
    }

}
