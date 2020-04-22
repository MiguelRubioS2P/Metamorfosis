using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    float deltaTime = 0.0f; // Varible donde guardamos los float (FPS)
    public Text fpsText; // Texto donde mostramos los fps
    List<Nivel> niveles = new List<Nivel>();
    
    

    void Update()
    {
        // Por cada update sumamos por tiempo el tiempo real al final convertimos en string para mostrar 
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        int numero = (int) fps;
        fpsText.text = numero.ToString();
    }

    void Start()
    {
        // Al ser don't destroy decimos que sea false a no ser que el usuario lo quiera activar
        fpsText.gameObject.SetActive(false);

        // Resolucion incial
        Screen.SetResolution(1920, 1080, false);

        CreacionNiveles();
        
    }

    private void Awake()
    {
        int count = FindObjectsOfType<OptionsManager>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public void cambiarResolucion(int width, int height, bool panatallaCompleta)
    {
        Screen.SetResolution(width, height, panatallaCompleta);
    }

    /// <summary>
    /// Método que nos crea los niveles y los añade al List niveles
    /// </summary>
    private void CreacionNiveles()
    {
        Nivel nivel1 = new Nivel();
        Nivel nivel2 = new Nivel();
        Nivel nivel3 = new Nivel();
        Nivel nivel4 = new Nivel();
        Nivel nivel5 = new Nivel();
        Nivel nivel6 = new Nivel();
        Nivel nivel7 = new Nivel();
        Nivel nivel8 = new Nivel();
        Nivel nivel9 = new Nivel();

        nivel1.Nombre = "Nivel 1";
        nivel1.Estado = true;
        nivel2.Nombre = "Nivel 2";
        nivel2.Estado = false;
        //nivel2.Imagen = Resources.Load("Assets/Imagenes/nivel2.PNG") as Sprite;
        nivel3.Nombre = "Nivel 3";
        nivel3.Estado = false;
        nivel4.Nombre = "Nivel 4";
        nivel4.Estado = false;
        nivel5.Nombre = "Nivel 5";
        nivel5.Estado = false;
        nivel6.Nombre = "Nivel 6";
        nivel6.Estado = false;
        nivel7.Nombre = "Nivel 7";
        nivel7.Estado = false;
        nivel8.Nombre = "Nivel 8";
        nivel8.Estado = false;
        nivel9.Nombre = "Nivel 9";
        nivel9.Estado = false;

        niveles.Add(nivel1);
        niveles.Add(nivel2);
        niveles.Add(nivel3);
        niveles.Add(nivel4);
        niveles.Add(nivel5);
        niveles.Add(nivel6);
        niveles.Add(nivel7);
        niveles.Add(nivel8);
        niveles.Add(nivel9);

    }

    /// <summary>
    /// Recibimos por parametro el nombre del nivel, y cambiamos el estado del nivel en el List niveles.
    /// </summary>
    /// <param name="nivel"></param>
    public void CambiarEstado(string nivel)
    {
        for(int i = 0; i < niveles.Count; i++)
        {
            if(niveles[i].Nombre == nivel)
            {
                niveles[i].Estado = true;
            }
        }
    }

    /// <summary>
    /// Devolvemos el valor del estado del nivel que nos piden por parametro.
    /// </summary>
    /// <param name="nivel"></param>
    /// <returns></returns>
    public bool EstadoActivo(string nivel)
    {
        bool estado = false;
        for (int i = 0; i < niveles.Count; i++)
        {
            if (niveles[i].Nombre == nivel)
            {
                estado = niveles[i].Estado;
                break;
            }
        }

        return estado;
    }


    // Este método no es funcional!!!!!!!!!!!!!!!
    /// <summary>
    /// Para obtener la imagen del nivel
    /// </summary>
    /// <param name="nivel"></param>
    /// <returns></returns>
    public Sprite ImagenNivel(string nivel)
    {
        Sprite foto = null;
        for (int i = 0; i < niveles.Count; i++)
        {
            if (niveles[i].Nombre == nivel)
            {
                foto = niveles[i].Imagen;
                break;
            }
        }

        return foto;
    }
}
