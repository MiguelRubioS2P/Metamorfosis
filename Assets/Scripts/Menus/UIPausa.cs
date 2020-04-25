using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{

    private PlayerControll player;
    private bool activo;
    private GameManager gameManager;


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
        player.gameObject.SetActive(false);
        Cursor.visible = true;
    }

    public void Desactivar()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        activo = false;
        player.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    public void Opciones()
    {
        Debug.Log("Menú opciones");
    }

    public void Principal()
    {
        Debug.Log("Ejecutando este método, Principal() desde UIPausa");
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
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
}
