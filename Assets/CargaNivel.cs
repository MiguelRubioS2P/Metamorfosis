using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CargaNivel : MonoBehaviour
{
    public Image LoadingBar;
    float currentValue;
    public float speed;
    
    private static string _escena;

    public Text textoNivel;
    private static char[] caracteresAnimacion;
    private int i = 0;
    private float cadaCuantoLetra = 0f;
    private float ratioLetra = 0.2f;

    void Update()
    {
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
            if (i < caracteresAnimacion.Length && Time.time > cadaCuantoLetra)
            {
                cadaCuantoLetra = Time.time + ratioLetra;
                textoNivel.text = textoNivel.text + caracteresAnimacion[i];
                i++;
            }
        }
        else
        {
            cambioEscena();
        }

        LoadingBar.fillAmount = currentValue / 100;
    }

    

    private void cambioEscena()
    {
        SceneManager.LoadScene(_escena);
    }

    public void SetEscena(string escena)
    {
        _escena = escena;
        caracteresAnimacion = escena.ToCharArray();
    }
}
