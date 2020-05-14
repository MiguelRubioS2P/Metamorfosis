﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{

    private PlayerControll player;
    private PlayerCombate scriptPlayerCombate;
    private GameManager gameManager;
    public GameObject menuOpciones;
    private ControladorMenu scriptControladorMenu;

    private void Awake()
    {
        player = FindObjectOfType<PlayerControll>();
        gameManager = FindObjectOfType<GameManager>();
        scriptPlayerCombate = FindObjectOfType<PlayerCombate>();
        scriptControladorMenu = FindObjectOfType<ControladorMenu>();
    }

    public void Activar()
    {
        player.enabled = false;
        scriptPlayerCombate.enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void Desactivar()
    {
        
        Time.timeScale = 1;
        player.enabled = true;
        scriptPlayerCombate.enabled = true;
        Cursor.visible = false;
        scriptControladorMenu.estaActivoPausa = false;
        gameObject.SetActive(false);
    }

    public void Principal()
    {
        Debug.Log("Ejecutando este método, Principal() desde UIPausa");
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu Principal");
    }

    public void Salir()
    {
        Debug.Log("Ejecutando este método, Salir() desde UIPausa");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Opciones()
    {
        //gameObject.GetComponent<Canvas>().enabled = false;
        gameObject.SetActive(false);
        scriptControladorMenu.estaActivoOpciones = true;
        menuOpciones.SetActive(true);
        //menuOpciones.GetComponent<UiOpciones>().Activar();
    }
}
