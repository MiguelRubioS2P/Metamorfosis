using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    float deltaTime = 0.0f; // Varible donde guardamos los float (FPS)
    public Text fpsText; // Texto donde mostramos los fps
    List<Nivel> niveles1 = new List<Nivel>();
    List<Nivel> niveles2 = new List<Nivel>();
    List<Nivel> niveles3 = new List<Nivel>();
    private string rutaDeGuardado;
    List<Partida> partidas = new List<Partida>();
    public string nombrePartida;
    
    
    

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
        

        if (File.Exists(rutaDeGuardado))
        {
            CargarDatos();
        }
        else
        {
            CreacionNiveles(9);
            CreacionPartidas();
        }
        
        
    }

    private void Awake()
    {
        rutaDeGuardado = Application.absoluteURL + "datos.dat";
        
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
    private void CreacionNiveles(int niveles)
    {
        // creación de niveles para la lista niveles1
        for(int i = 1; i <= niveles; i++)
        {
            if(i == 1)
            {
                niveles1.Add(new Nivel("Nivel " + i, true, 0, 0));
            }
            else
            {
                niveles1.Add(new Nivel("Nivel " + i, false, 0, 0));
            }
        }

        foreach (Nivel n in niveles1)
        {
            Debug.Log(n.Nombre);
            Debug.Log(n.Estado);
            Debug.Log(n.Monedas);
            Debug.Log(n.Estrellas);
        }

        // Creación de niveles para la lista niveles2
        for (int i = 1; i <= niveles; i++)
        {
            if (i == 1)
            {
                niveles2.Add(new Nivel("Nivel " + i, true, 0, 0));
            }
            else
            {
                niveles2.Add(new Nivel("Nivel " + i, false, 0, 0));
            }
        }

        foreach (Nivel n in niveles2)
        {
            Debug.Log(n.Nombre);
            Debug.Log(n.Estado);
            Debug.Log(n.Monedas);
            Debug.Log(n.Estrellas);
        }

        // Creación de niveles para la lista niveles3
        for (int i = 1; i <= niveles; i++)
        {
            if (i == 1)
            {
                niveles3.Add(new Nivel("Nivel " + i, true, 0, 0));
            }
            else
            {
                niveles3.Add(new Nivel("Nivel " + i, false, 0, 0));
            }
        }

        foreach (Nivel n in niveles3)
        {
            Debug.Log(n.Nombre);
            Debug.Log(n.Estado);
            Debug.Log(n.Monedas);
            Debug.Log(n.Estrellas);
        }
    }

    /// <summary>
    /// Recibimos por parametro el nombre del nivel, y cambiamos el estado del nivel en el List niveles.
    /// </summary>
    /// <param name="nivel"></param>
    public void CambiarEstado(string nivel,string nombre)
    {
        
        for(int i = 0; i < partidas.Count; i++)
        {
            if(partidas[i].nombre == nombre)
            {
                for(int n = 0; n < partidas[i].niveles.Count; n++)
                {
                    if(partidas[i].niveles[n].Nombre == nivel)
                    {
                        partidas[i].niveles[n].Estado = true;
                    }
                }
            }
        }

    }

    /// <summary>
    /// Devolvemos el valor del estado del nivel que nos piden por parametro.
    /// </summary>
    /// <param name="nivel"></param>
    /// <returns></returns>
    public bool EstadoActivo(string nivel,string nombre)
    {
        bool estado = false;
        Debug.Log(nombre + " " + nivel);
        for (int i = 0; i < partidas.Count; i++)
        {
            if (partidas[i].nombre == nombre)
            {

                for (int n = 0; n < partidas[i].niveles.Count; n++)
                {
                    if (partidas[i].niveles[n].Nombre == nivel)
                    {
                        estado = partidas[i].niveles[n].Estado;
                        break;
                    }
                }
                break;
            }
        }

        return estado;
    }


    public void CreacionPartidas()
    {
        Partida partida1 = new Partida();
        Partida partida2 = new Partida();
        Partida partida3 = new Partida();

        partida1.slot = "Slot 1 Boton";
        partida1.niveles = niveles1;
        partida2.slot = "Slot 2 Boton";
        partida2.niveles = niveles2;
        partida3.slot = "Slot 3 Boton";
        partida3.niveles = niveles3;

        partidas.Add(partida1);
        partidas.Add(partida2);
        partidas.Add(partida3);
    }


    public void PonerNombreJugador(string slot, string nombre)
    {
        for(int i = 0; i < partidas.Count; i++)
        {
            if(partidas[i].slot == slot)
            {
                partidas[i].nombre = nombre;
                break;
            }
        }
    }

    /// <summary>
    /// Este método es para recuperar el nombre que esta guardado en el archivo de guardado
    /// </summary>
    /// <param name="slot">Ejemplo de valor: Slot 1 Boton</param>
    /// <returns>Nombre de guardado de la partida</returns>
    public string NombrePartidaJugador(string slot)
    {
        string nombre = null;

        for (int i = 0; i < partidas.Count; i++)
        {
            if (partidas[i].slot == slot)
            {
                nombre = partidas[i].nombre;
                Debug.Log("Método ejecutado NombrePartidaJugador() " + nombre);
                break;
            }
        }

        return nombre;
    }

    public bool ExisteNombre(string nombre)
    {
        bool existe = false;
        foreach(Partida p in partidas)
        {
            if(p.nombre == nombre)
            {
                existe = true;
                break;
            }
        }

        return existe;
    }

    public void GuardarDatos()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream archivo = File.Create(rutaDeGuardado);

        InformacionJuego info = new InformacionJuego();
        // Aquí guardamos la información de la variable partidas en una nueva variable que se guardará en el archivo.
        info.partidas = partidas;

        bf.Serialize(archivo, info);

        archivo.Close();
    }

    public void CargarDatos()
    {
        if (File.Exists(rutaDeGuardado))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream archivo = File.Open(rutaDeGuardado, FileMode.Open);

            InformacionJuego info = bf.Deserialize(archivo) as InformacionJuego;

            // Aquí en partidas tenemos la información del archivo.
            partidas = info.partidas;
            
            archivo.Close();
        }
    }

    
}
