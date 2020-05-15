using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNiveles : MonoBehaviour
{
    private TranscionMenus transcion;
    private UISalir salir;
    private OptionsManager optionsManager; // Obtenemos la referencia del GO DontDestroOnLoad

    public GameObject[] niveles;
    public Sprite[] fotosNivel;
    private int indiceFoto = 0;

    private void Awake()
    {
        Cursor.visible = true;
        optionsManager = FindObjectOfType<OptionsManager>();
        transcion = FindObjectOfType<TranscionMenus>();
        salir = FindObjectOfType<UISalir>();
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
            salir.salirJuego();
        }
    }
    
    public void OnClickMundo()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        transcion.cargarNivelEscena(boton);
    }


    /// <summary>
    /// Este Método es el encargado de recuperar el estado de los niveles desbloqueados que tiene el jugador.
    /// </summary>
    private void ComprobacionNiveles()
    {
        foreach (GameObject i in niveles)
        {
            if (optionsManager.EstadoActivo(i.name, optionsManager.GetNombrePartida()))
            {
                activarSegunEstrellas(i);
            }
            else
            {
                i.GetComponent<Button>().interactable = false;
            }
        }
    }

    private void activarSegunEstrellas(GameObject nivel)
    {
        
            nivel.GetComponent<Button>().interactable = true;
            nivel.transform.GetChild(0).GetComponent<Image>().sprite = fotosNivel[indiceFoto];
            indiceFoto++;

            for (int i = 1; i <= 3; i++)
            {
                nivel.transform.GetChild(i).gameObject.SetActive(true);
            }

        foreach (Partida i in optionsManager.partidas)
        {
            if (i.nombre == optionsManager.GetNombrePartida())
            {
                foreach (Nivel z in i.niveles)
                {
                    if (z.Nombre.Equals(nivel.name))
                    {
                        for (int j = 1; j <= z.Estrellas; j++)
                        {
                            nivel.transform.GetChild(j).GetComponent<Image>().color = Color.white;
                        }
                    }
                }
            }

        }

    }
}