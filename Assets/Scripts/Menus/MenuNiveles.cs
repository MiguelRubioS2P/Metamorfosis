using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNiveles : MonoBehaviour
{

    private OptionsManager optionsManager; // Obtenemos la referencia del GO DontDestroOnLoad
    public GameObject nivel1;
    public GameObject nivel2;
    public GameObject nivel3;
    public GameObject nivel4, nivel5, nivel6, nivel7, nivel8, nivel9;
    public Sprite fotoNivel2;


    private void Awake()
    {
        optionsManager = FindObjectOfType<OptionsManager>();
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
            Debug.Log("Pulsando Botón Nivel 2");
            SceneManager.LoadScene("Nivel 2");
        }
        else if (boton == "Nivel 3")
        {
            Debug.Log("Pulsando Botón Nivel 3");
            SceneManager.LoadScene("Nivel 3");
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

    // esto va a los niveles de manera individual junto event trigger component, de momento desactivado hasta encontrar
    // otra solución para reproducir esto.
    public void Prueba()
    {
        Debug.Log("Hola");
        GameObject body = transform.GetChild(1).gameObject;
        GameObject mundo1 = body.transform.GetChild(1).gameObject;
        GameObject nivel1 = mundo1.transform.GetChild(0).gameObject;
        nivel1.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
    }
    public void Prueba2()
    {
        Debug.Log("Adios");
        GameObject body = transform.GetChild(1).gameObject;
        GameObject mundo1 = body.transform.GetChild(1).gameObject;
        GameObject nivel1 = mundo1.transform.GetChild(0).gameObject;
        nivel1.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    private void ComprobacionNiveles()
    {
        // Cada vez que iniciamos hacemos las comprobaciones del estado de los niveles
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
