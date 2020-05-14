using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIJugador : MonoBehaviour
{
    public Text textoVidas;
    public Text textoMonedas;
    private GameManager gameManager;
    private int vidas,dinero;
    private GameObject menuMuerte;
    private UIMuerte scriptUIMuerte;
    private ControladorMenu controladorMenu;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        menuMuerte = GameObject.Find("UI de Muerte");
        scriptUIMuerte = menuMuerte.GetComponent<UIMuerte>();
        scriptUIMuerte.gameObject.SetActive(false);
        controladorMenu = FindObjectOfType<ControladorMenu>();
        
    }

    private void Update()
    {
        vidas = gameManager.PintarVida();
        dinero = gameManager.PintarDinero();

        if(vidas == 0)
        {
            scriptUIMuerte.gameObject.SetActive(true);
            scriptUIMuerte.Activar();
            controladorMenu.estaActivoMuerte = true;
        }

        textoMonedas.text = dinero.ToString();
        textoVidas.text = vidas.ToString();
    }

}
