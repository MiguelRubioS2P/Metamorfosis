﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    private TranscionMenus transcion;
    
    private void Awake()
    {
        transcion = FindObjectOfType<TranscionMenus>();
        Cursor.visible = true;
    }
    public void OnClick()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == "Play Boton")
        {
            StartCoroutine(transcion.cambioEscena("Menu Guardado"));

        } 
        else if (boton == "Opciones Boton")
        {
            StartCoroutine(transcion.cambioEscena("Menu Opciones"));
        } 
        else if (boton == "Salir Boton")
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}
