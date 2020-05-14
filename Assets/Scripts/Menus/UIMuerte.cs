using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMuerte : MonoBehaviour
{

    private PlayerControll player;
    private PlayerCombate scriptPlayerCombate;
    private string escena;
    private GameManager gameManager;
    private ControladorMenu controladorMenu;
    private UISalir salir;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerControll>();
        escena = SceneManager.GetActiveScene().name;
        gameManager = FindObjectOfType<GameManager>();
        scriptPlayerCombate = FindObjectOfType<PlayerCombate>();
        controladorMenu = FindObjectOfType<ControladorMenu>();
        salir = FindObjectOfType<UISalir>();
    }

    public void Activar()
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
        player.enabled = false;
        scriptPlayerCombate.enabled = false;
        Cursor.visible = true;
    }

    public void Reiniciar()
    {
        Debug.Log("Ejecutando este método, Reiniciar() desde UIMuerte");
        // reiniciar la escena propia y recargar las vidas base y las monedas base del gamemanager
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
        player.enabled = true;
        scriptPlayerCombate.enabled = true;
        controladorMenu.estaActivoMuerte = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(escena);
    }

    public void Desactivar()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1;
        controladorMenu.estaActivoMuerte = false;
        //player.gameObject.SetActive(true);
        Cursor.visible = false;
    }

    public void Opciones()
    {
        Debug.Log("Menú opciones");
    }

    public void Niveles()
    {
        Debug.Log("Ejecutando este método, Niveles() desde UIMuerte");
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
        Time.timeScale = 1;
        controladorMenu.estaActivoMuerte = false;
        SceneManager.LoadScene("Menu Niveles");
    }

    public void Principal()
    {
        Debug.Log("Ejecutando este método, Principal() desde UIMuerte");
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
        Time.timeScale = 1;
        controladorMenu.estaActivoMuerte = false;
        SceneManager.LoadScene("Menu Principal");
    }

    public void Salir()
    {
        Debug.Log("Método Salir en el script UIMuerte");
        salir.salirJuego();
    }

}
