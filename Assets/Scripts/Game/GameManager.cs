using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int vidas;
    private int dineroMonedasNivel;
    private int dineroDiamantes;
    public AudioClip sonidoMoneda;
    private AudioSource audioSource;
    
    private void Awake()
    {
        
        int count = FindObjectsOfType<GameManager>().Length;
        if(count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        dineroMonedasNivel = 0;
        dineroDiamantes = 0;
        vidas = 5;
        audioSource = GetComponent<AudioSource>();
    }

    public void DineroInicial()
    {
        dineroMonedasNivel = 0;
        dineroDiamantes = 0;
    }

    public void GanarDinero(int cantidad)
    {
        dineroMonedasNivel += cantidad;
        Debug.Log("El dinero que tengo es: " + dineroMonedasNivel);
        audioSource.clip = sonidoMoneda;
        audioSource.Play();
    }

    public void GanarDineroDiamantes(int cantidad)
    {
        dineroDiamantes += cantidad;
        audioSource.clip = sonidoMoneda;
        audioSource.Play();
    }

    public void PerderDinero()
    {
        dineroMonedasNivel = 0;
        dineroDiamantes = 0;
    }

    public int DineroTotal()
    {
        int dineroTotal = dineroDiamantes + dineroMonedasNivel;
        Debug.Log("El dinero total en este nivel es: " + dineroTotal);
        return dineroTotal;
    }

    public int PintarDinero()
    {
        if(dineroMonedasNivel < 0)
        {
            dineroMonedasNivel = 0;
            return dineroMonedasNivel;
        }
        else
        {
            return dineroMonedasNivel;
        }
    }

    public void VidasIniciales()
    {
        vidas = 5;
    }

    public void GanarVida()
    {
        vidas++;
    }

    public void PerderVida()
    {
        vidas--;
    }

    public int PintarVida()
    {
        if(vidas < 0)
        {
            vidas = 0;
            return vidas;
        }
        else
        {
            return vidas;
        }
    }

    public int _dinero
    {
        // Añadido para obtener el dinero en el final de nivel
        get { return dineroMonedasNivel; }
    }

}
