using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISalir : MonoBehaviour
{
    public void salirJuego()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
    }

    public void OnClick()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if(boton == "Si")
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }else if (boton == "No")
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }
}
