using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int vidas;
    private int dinero;
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
        dinero = 0;
        vidas = 5;
        audioSource = GetComponent<AudioSource>();
    }

    public void DineroInicial()
    {
        dinero = 0;
    }

    public void GanarDinero()
    {
        dinero++;
        Debug.Log("El dinero que tengo es: " + dinero);
        audioSource.clip = sonidoMoneda;
        audioSource.Play();
    }

    public void PerderDinero()
    {
        dinero = 0;
    }

    public int PintarDinero()
    {
        if(dinero < 0)
        {
            dinero = 0;
            return dinero;
        }
        else
        {
            return dinero;
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
        get { return dinero; }
    }

}
