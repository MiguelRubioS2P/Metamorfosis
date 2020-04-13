using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void OnClick()
    {
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == "Play Boton")
        {
            SceneManager.LoadScene("Menu Guardado");
        } 
        else if (boton == "Opciones Boton")
        {
            SceneManager.LoadScene("Menu Opciones");
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
