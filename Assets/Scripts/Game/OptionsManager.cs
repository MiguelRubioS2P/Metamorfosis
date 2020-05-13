using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    float deltaTime = 0.0f; // Varible donde guardamos los float (FPS)
    public Text fpsText; // Texto donde mostramos los fps
    // Cada variable son los niveles de un slot
    List<Nivel> niveles1 = new List<Nivel>();
    List<Nivel> niveles2 = new List<Nivel>();
    List<Nivel> niveles3 = new List<Nivel>();
    private string rutaDeGuardado;
    List<Partida> partidas = new List<Partida>();
    public string nombrePartida;


    public AudioClip[] canciones;
    private bool primeraVez = true;
    private bool jugando = false;

    void Update()
    {
        // Por cada update sumamos por tiempo el tiempo real al final convertimos en string para mostrar 
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        int numero = (int) fps;
        fpsText.text = numero.ToString();
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 4 && primeraVez)
        {
            primeraVez = false;
        }
        if (level == 5)
        {
            transform.GetChild(0).GetComponent<AudioSource>().Stop();
        }
        if (level == 6 || level == 7 || level == 9 || level == 10 || level == 12 || level == 13)
        {
            //Niveles nommales
            jugando = true;
            transform.GetChild(0).GetComponent<AudioSource>().clip = canciones[Random.Range(1,4)];
            transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        if (level == 8 || level == 11 || level == 14)
        {
            //Musica pelea jefes
            jugando = true;
            transform.GetChild(0).GetComponent<AudioSource>().clip = canciones[5];
            transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
        if (level == 1 && !primeraVez || level == 4 && jugando)
        {
            jugando = false;
            transform.GetChild(0).GetComponent<AudioSource>().clip = canciones[0];
            transform.GetChild(0).GetComponent<AudioSource>().Play();
        }
    }

    void Start()
    {
        transform.GetChild(0).GetComponent<AudioSource>().volume = 0.5f;
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
    /// <param name="nivel">Nombre del nivel que buscamos </param>
    /// <param name="nombre">Nombre del jugador de la partida</param>
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
                        break;
                    }
                }
            }
        }

    }

    /// <summary>
    /// Método para añadir las monedas ganadas de un nivel
    /// </summary>
    /// <param name="nivel">Nombre del nivel</param>
    /// <param name="nombrePartida">Nombre de la partida guardada y en juego</param>
    /// <param name="monedas">Total monedas ganadas del nivel</param>
    public void SumarMonedasNivel(string nivel,string nombrePartida,int monedas)
    {
        foreach(Partida p in partidas)
        {
            if(p.nombre == nombrePartida)
            {
                foreach(Nivel n in p.niveles)
                {
                    if(n.Nombre == nivel)
                    {
                        n.Monedas = monedas;
                        Debug.Log("Total de monedas del nivel: " + n.Nombre + " es de " + n.Monedas + " monedas");
                        break;
                    }
                }
                break;
            }
        }
    }

    /// <summary>
    /// Método para añadir las estrellas ganadas de un nivel
    /// </summary>
    /// <param name="nivel">Nombre del nivel</param>
    /// <param name="nombrePartida">Nombre de la partida guardada y en juego</param>
    /// <param name="estrellas">Total estrellas ganadas del nivel</param>
    public void SumarEstrellasNivel(string nivel,string nombrePartida,int estrellas)
    {
        foreach (Partida p in partidas)
        {
            if (p.nombre == nombrePartida)
            {
                foreach (Nivel n in p.niveles)
                {
                    if (n.Nombre == nivel)
                    {
                        n.Estrellas = estrellas;
                        Debug.Log("Total de estrellas del nivel: " + n.Nombre + " es de " + n.Estrellas + " estrellas");
                        break;
                    }
                }
                break;
            }
        }
    }

    /// <summary>
    /// Método para obtener el nombre del último nivel que ha jugado la partida seleccionada
    /// </summary>
    /// <param name="slot">Nombre de la posición del slot</param>
    /// <returns>Nombre del último nivel jugado</returns>
    public string ObtenerUltimoNivelJugado(string slot)
    {
        string ultimoNivelJugado = "";
        foreach(Partida p in partidas)
        {
            if(p.slot == slot)
            {
                ultimoNivelJugado = p.ultimoNivel;
                break;
            }
        }
        return ultimoNivelJugado;
    }

    /// <summary>
    /// Método para añadir el último nivel jugado
    /// </summary>
    /// <param name="nivel">Nombre del nivel</param>
    /// <param name="nombrePartida">Nombre de la partida activa</param>
    public void PonerUltimoNivelJugado(string nivel,string nombrePartida)
    {
        foreach(Partida p in partidas)
        {
            if(p.nombre == nombrePartida)
            {
                p.ultimoNivel = nivel;
                Debug.Log("El último nivel jugado de la partida: " + p.nombre + " es el nivel " + p.ultimoNivel);
                break;
            }
        }
    }

    /// <summary>
    /// Devolvemos el valor del estado del nivel que nos piden por parametro.
    /// </summary>
    /// <param name="nivel">El nombre del nivel que buscas</param>
    /// <param name="nombre">El nombre de la partida activa</param>
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

    /// <summary>
    /// Método para eliminar los datos de una partida guardada
    /// </summary>
    /// <param name="nombrePartida">Nombre de la partida guardada</param>
    public void EliminarPartidaGuardada(string nombrePartida)
    {
        List<Nivel> niveles = new List<Nivel>();
        int numeroNiveles = 9;

        for(int i = 1; i <= numeroNiveles; i++)
        {
            if (i == 1)
            {
                niveles.Add(new Nivel("Nivel " + i, true, 0, 0));
            }
            else
            {
                niveles.Add(new Nivel("Nivel " + i, false, 0, 0));
            }
        }

        foreach (Partida p in partidas)
        {
            if(p.nombre == nombrePartida)
            {
                p.niveles = niveles;
                p.ultimoNivel = "";
                p.nombre = "";
            }
        }
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

    /// <summary>
    /// Método para añadir un nombre a una partida, para guardar el slot de partidas guardadas
    /// </summary>
    /// <param name="slot">Nombre del slot donde se guardara</param>
    /// <param name="nombre">Nombre para guardar la partida</param>
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

    /// <summary>
    /// Método para saber si ya hay otra partida con este nombre guardado
    /// </summary>
    /// <param name="nombre">Nombre para guardar la partida</param>
    /// <returns>Boolean</returns>
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
