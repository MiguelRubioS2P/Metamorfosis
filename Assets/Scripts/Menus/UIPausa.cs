using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPausa : MonoBehaviour
{

    private PlayerControll player;
    private bool activo;


    private void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        activo = false;
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
    }

    public void Desactivar()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        activo = false;
        player.gameObject.SetActive(true);
    }

    public void Opciones()
    {
        Debug.Log("Menú opciones");
    }

    public void Principal()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
