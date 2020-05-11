using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalNiveles : MonoBehaviour
{
    public Text nivel; // Texto nivel
    public Canvas canvas; // Canavs donde se muestra
    
    public Text obtenido; //Texto obtenido
    public Text monedasGameManager; //Texto dodne obtendremos monedas del gamemanager
    private GameManager gameManager; //Referencia gamemanager

    public Text tieneNivel; // Texto mostramos monedas nivel
    public GameObject objetoMonedas; // GO contenedor de todas las monedas del nivel.
    [SerializeField]
    private int monedasQueTieneNivel; // Varibale para cada nivel que tenga x estrellas
    public Text monedasNivel; // Texto donde mostramos las monedas que tiene el nivel

    public Text rango; // Texto rango
    public Image noob, intermedio, avanzado; // Imagen de estrellas para el rango

    private string escena; // Nombre de la escena
    private OptionsManager optionsManager;
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Si el player llega a la zona final, lo destruimos para que no se mueva, y iniciamos coroutina
            player.SetActive(false);
            StartCoroutine(MenuNiveles());
        }
    }

    private void Awake()
    {
        // Obtenemos game manager
        gameManager = FindObjectOfType<GameManager>();
        // Obtenemos los hijos totales del GO que contiene todas las monedas del nivel
        monedasQueTieneNivel = objetoMonedas.transform.childCount;
        // Obtenemos el nombre de la escena actualmente activa.
        escena = SceneManager.GetActiveScene().name;
        // Obtenemos OptionsManager
        optionsManager = FindObjectOfType<OptionsManager>();
        player = FindObjectOfType<PlayerControll>().gameObject;
    }

    private IEnumerator MenuNiveles()
    {
        // vamos activando todo progresivamente
        canvas.gameObject.SetActive(true);
        nivel.text = SceneManager.GetActiveScene().name;
        yield return new WaitForSeconds(2);

        obtenido.gameObject.SetActive(true);
        monedasGameManager.text = gameManager._dinero.ToString();
        yield return new WaitForSeconds(2);

        tieneNivel.gameObject.SetActive(true);
        monedasNivel.text = monedasQueTieneNivel.ToString();
        yield return new WaitForSeconds(2);

        rango.gameObject.SetActive(true);

        // Condiciones de nivel, segun el dinero seran mas estrellas o no
        if (monedasQueTieneNivel == gameManager._dinero)
        {
            noob.gameObject.SetActive(true);
            intermedio.gameObject.SetActive(true);
            avanzado.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            CargarMenuNiveles(3,gameManager.PintarDinero());
        } else if (gameManager._dinero >= monedasQueTieneNivel / 2)
        {
            noob.gameObject.SetActive(true);
            intermedio.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            CargarMenuNiveles(2,gameManager.PintarDinero());
        } else
        {
            noob.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            CargarMenuNiveles(1,gameManager.PintarDinero());
        }

    }

    /// <summary>
    /// Método que carga la escena Niveles
    /// </summary>
    private void CargarMenuNiveles(int estrellas,int monedas)
    {
        gameManager.DineroInicial();
        gameManager.VidasIniciales();
        GuardarEstrellasYMonedas(estrellas, monedas);
        NivelesDesbloqueados(escena);
        SceneManager.LoadScene("Menu Niveles");
    }

    /// <summary>
    /// Desbloqueamos el nivel que sigue al completar el nivel actual
    /// </summary>
    /// <param name="escena"></param>
    private void NivelesDesbloqueados(string escena)
    {
        switch (escena)
        {
            case "Nivel 1":
                // si es nivel 1 hay que desbloquear Nivel 2
                optionsManager.CambiarEstado("Nivel 2", optionsManager.nombrePartida);
                break;
            case "Nivel 2":
                // si es nivel 2 hay que desbloquear Nivel 3
                optionsManager.CambiarEstado("Nivel 3", optionsManager.nombrePartida);
                
                break;
            case "Nivel 3":
                // si es nivel 3 hay que desbloquear Nivel 4 pero como es pa pre-alpha aqui termina el flujo.
                optionsManager.CambiarEstado("Nivel 4", optionsManager.nombrePartida);
                break;
            case "Nivel 4":
                optionsManager.CambiarEstado("Nivel 5", optionsManager.nombrePartida);
                break;
            case "Nivel 5":
                optionsManager.CambiarEstado("Nivel 6", optionsManager.nombrePartida);
                break;
            case "Nivel 6":
                break;
        }

        optionsManager.PonerUltimoNivelJugado(escena, optionsManager.nombrePartida);
        optionsManager.GuardarDatos();
    }

    /// <summary>
    /// Método para guardar las estrellas y las monedas conseguidas en el nivel
    /// </summary>
    /// <param name="estrellas">Total de estrellas conseguidas</param>
    /// <param name="monedas">Total de monedas conseguidas</param>
    private void GuardarEstrellasYMonedas(int estrellas,int monedas)
    {
        optionsManager.SumarMonedasNivel(escena, optionsManager.nombrePartida, monedas);
        optionsManager.SumarEstrellasNivel(escena, optionsManager.nombrePartida, estrellas);
    }
}
