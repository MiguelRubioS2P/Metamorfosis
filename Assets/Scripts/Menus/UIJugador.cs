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

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        vidas = gameManager.PintarVida();
        dinero = gameManager.PintarDinero();

        textoMonedas.text = dinero.ToString();
        textoVidas.text = vidas.ToString();
    }

}
