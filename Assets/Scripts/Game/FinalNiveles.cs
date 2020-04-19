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
    public int monedasQueTieneNivel; // Varibale para cada nivel que tenga x estrellas
    public Text monedasNivel; // Texto donde mostramos las monedas que tiene el nivel

    public Text rango; // Texto rango
    public Image noob, intermedio, avanzado; // Imagen de estrellas para el rango

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            //Si el player llega a la zona final, lo destruimos para que no se mueva, y iniciamos coroutina
            collision.gameObject.SetActive(false);
            StartCoroutine(MenuNiveles());
        }
    }

    private void Awake()
    {
        // Obtenemos game manager
        gameManager = FindObjectOfType<GameManager>();
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
            SceneManager.LoadScene("Menu Niveles");
        } else if (gameManager._dinero >= monedasQueTieneNivel / 2)
        {
            noob.gameObject.SetActive(true);
            intermedio.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Menu Niveles");
        } else
        {
            noob.gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene("Menu Niveles");
        }

    }
}
