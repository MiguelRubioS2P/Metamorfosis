using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMuerte : MonoBehaviour
{

    private PlayerControll player;
    private string escena;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        escena = SceneManager.GetActiveScene().name;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void Activar()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        player.gameObject.SetActive(false);
        Cursor.visible = true;
    }

    public void Reiniciar()
    {
        Debug.Log("Ejecutando este método, Reiniciar() desde UIMuerte");
        // reiniciar la escena propia y recargar las vidas base y las monedas base del gamemanager
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
        SceneManager.LoadScene(escena);
    }

    public void Desactivar()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        player.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    public void Opciones()
    {
        Debug.Log("Menú opciones");
    }

    public void Niveles()
    {
        Debug.Log("Ejecutando este método, Niveles() desde UIMuerte");
        SceneManager.LoadScene("Menu Niveles");
    }

    public void Principal()
    {
        Debug.Log("Ejecutando este método, Principal() desde UIMuerte");
        SceneManager.LoadScene("Menu Principal");
    }

    public void Salir()
    {
        Debug.Log("Ejecutando este método, Salir() desde UIMuerte");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
