using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNiveles : MonoBehaviour
{
    private TranscionMenus transcion;
    private OptionsManager optionsManager; // Obtenemos la referencia del GO DontDestroOnLoad
    public GameObject nivel1;
    public GameObject nivel2;
    public GameObject nivel3;
    public GameObject nivel4, nivel5, nivel6, nivel7, nivel8, nivel9;
    public Sprite fotoNivel2,fotoNivel3,fotoNivel4,fotoNivel5,fotoNivel6,fotoNivel7,fotoNivel8,fotoNivel9;


    private void Awake()
    {
        Cursor.visible = true;
        optionsManager = FindObjectOfType<OptionsManager>();
        transcion = FindObjectOfType<TranscionMenus>();
    }

    private void Start()
    {
        ComprobacionNiveles();
    }

    public void OnClickElementos()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if(boton == "Atras Boton")
        {
            StartCoroutine(transcion.cambioEscena("Menu Guardado"));
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
            transcion.cargarNivelEscena("Nivel 1");
        } else if (boton == "Nivel 2")
        {
            Debug.Log("Pulsando Botón Nivel 2");
           transcion.cargarNivelEscena("Nivel 2");
        }
        else if (boton == "Nivel 3")
        {
            Debug.Log("Pulsando Botón Nivel 3");
            transcion.cargarNivelEscena("Nivel 3");
        }
    }

    public void OnClickMundo2()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == "Nivel 4")
        {
            transcion.cargarNivelEscena("Nivel 4");
        }
        else if (boton == "Nivel 5")
        {
            transcion.cargarNivelEscena("Nivel 5");
        }
        else if (boton == "Nivel 6")
        {
            transcion.cargarNivelEscena("Nivel 6");
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


    /// <summary>
    /// Este Método es el encargado de recuperar el estado de los niveles desbloqueados que tiene el jugador.
    /// </summary>
    private void ComprobacionNiveles()
    {
        if (optionsManager.EstadoActivo(nivel1.name,optionsManager.nombrePartida))
        {
            nivel1.GetComponent<Button>().interactable = true;
            
        }
        else
        {
            nivel1.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel2.name, optionsManager.nombrePartida))
        {
            nivel2.GetComponent<Button>().interactable = true;
            nivel2.transform.GetChild(0).GetComponent<Image>().sprite = fotoNivel2;
            

        }
        else
        {
            nivel2.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel3.name, optionsManager.nombrePartida))
        {
            nivel3.GetComponent<Button>().interactable = true;
            nivel3.transform.GetChild(0).GetComponent<Image>().sprite = fotoNivel3;
        }
        else
        {
            nivel3.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel4.name, optionsManager.nombrePartida))
        {
            nivel4.GetComponent<Button>().interactable = true;
        }
        else
        {
            nivel4.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel5.name, optionsManager.nombrePartida))
        {
            nivel5.GetComponent<Button>().interactable = true;
        }
        else
        {
            nivel5.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel6.name, optionsManager.nombrePartida))
        {
            nivel6.GetComponent<Button>().interactable = true;
        }
        else
        {
            nivel6.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel7.name, optionsManager.nombrePartida))
        {
            nivel7.GetComponent<Button>().interactable = true;
        }
        else
        {
            nivel7.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel8.name, optionsManager.nombrePartida))
        {
            nivel8.GetComponent<Button>().interactable = true;
        }
        else
        {
            nivel8.GetComponent<Button>().interactable = false;
        }
        if (optionsManager.EstadoActivo(nivel9.name, optionsManager.nombrePartida))
        {
            nivel9.GetComponent<Button>().interactable = true;
        }
        else
        {
            nivel9.GetComponent<Button>().interactable = false;
        }
    }
    
}
