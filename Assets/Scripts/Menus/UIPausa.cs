using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{

    private PlayerControll player;
    private bool activo;
    private GameManager gameManager;
    public GameObject menuOpciones;


    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        activo = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (activo)
            {
                Desactivar();
            }
            else
            {
                Activar();
            }

        }
        
    }

    public void Activar()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        activo = true;
        player.enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
    }

    public void Desactivar()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        activo = false;
        Time.timeScale = 1;
        player.enabled = true;
        Cursor.visible = false;
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
        gameObject.GetComponent<Canvas>().enabled = false;
        menuOpciones.GetComponent<Canvas>().enabled = true;
        menuOpciones.GetComponent<UiOpciones>().Activar();
    }
}
