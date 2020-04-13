using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


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
    }

    public void GanarDinero()
    {
        dinero++;
        Debug.Log("El dinero que tengo es: " + dinero);
    }


}
