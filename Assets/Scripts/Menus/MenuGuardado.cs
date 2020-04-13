using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuGuardado : MonoBehaviour
{
    public Button slot1, slot2, slot3;
   
    public void OnClick()
    {
        // Guardamos en una variable el gameobject selecionado para saber por el 
        // nombre que boton se ha seleccionado
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == ("Slot 1 Boton"))
        {
            slot1.image.color = Color.green;
            slot2.image.color = Color.red;
            slot3.image.color = Color.red;
        } else if (boton == ("Slot 2 Boton"))
        {
            slot2.image.color = Color.green;
            slot1.image.color = Color.red;
            slot3.image.color = Color.red;
        }
        else if (boton == ("Slot 3 Boton"))
        {
            slot3.image.color = Color.green;
            slot2.image.color = Color.red;
            slot1.image.color = Color.red;
        }  else if (boton == ("Cancelar Boton"))
        {
            slot1.image.color = Color.red;
            slot2.image.color = Color.red;
            slot3.image.color = Color.red;
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
        SceneManager.LoadScene("Menu Niveles");
    }
}
