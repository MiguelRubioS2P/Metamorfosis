using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuGuardado : MonoBehaviour
{
    public Button slot1, slot2, slot3;
    private bool selecionado;
    public GameObject botones;

    private void Awake()
    {
        selecionado = false;
        botones.SetActive(false);
        Cursor.visible = true;
    }
    public void OnClick()
    {
        // Guardamos en una variable el gameobject selecionado para saber por el 
        // nombre que boton se ha seleccionado
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == ("Slot 1 Boton"))
        {
            selecionado = true;
            slot1.image.color = Color.green;
            slot2.image.color = Color.red;
            slot3.image.color = Color.red;
            botones.SetActive(true);
        } else if (boton == ("Slot 2 Boton"))
        {
            selecionado = true;
            slot2.image.color = Color.green;
            slot1.image.color = Color.red;
            slot3.image.color = Color.red;
            botones.SetActive(true);
        }
        else if (boton == ("Slot 3 Boton"))
        {
            selecionado = true;
            slot3.image.color = Color.green;
            slot2.image.color = Color.red;
            slot1.image.color = Color.red;
            botones.SetActive(true);
        }  else if (boton == ("Cancelar Boton"))
        {
            selecionado = false;
            slot1.image.color = Color.red;
            slot2.image.color = Color.red;
            slot3.image.color = Color.red;
            botones.SetActive(false);
        } else if (boton == "Salir Boton")
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void OnVolverMenu()
    {
        // Volver al menu
        SceneManager.LoadScene("Menu Principal");
    }

    public void OnIrMenuNiveles()
    {
        // Aqui iria saber si ya tiene partida empezada o no
        if(selecionado)
        {
            SceneManager.LoadScene("Menu Niveles");
        }
        
    }
}
