using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private int vidas;
    private int dinero;
    
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
    }

    public void GanarDinero()
    {
        dinero++;
        Debug.Log("El dinero que tengo es: " + dinero);
    }

    public void PerderDinero()
    {
        dinero-= 2;
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

}
