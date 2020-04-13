using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void OnClickElementos()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if(boton == "Atras Boton")
        {
            SceneManager.LoadScene("Menu Guardado");
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
    
    public void OnClickMundo1()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if(boton == "Nivel 1")
        {
            SceneManager.LoadScene("Nivel 1");
        } else if (boton == "Nivel 2")
        {

        }
        else if (boton == "Nivel 3")
        {

        }
    }

    public void OnClickMundo2()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == "Nivel 4")
        {

        }
        else if (boton == "Nivel 5")
        {

        }
        else if (boton == "Nivel 6")
        {

        }
    }

    public void OnClickMundo3()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == "Nivel 7")
        {

        }
        else if (boton == "Nivel 8")
        {

        }
        else if (boton == "Nivel 9")
        {

        }
    }
}
