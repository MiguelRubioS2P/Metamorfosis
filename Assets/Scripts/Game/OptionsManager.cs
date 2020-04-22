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
            CreacionNiveles();
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

        niveles1.Add(nivel1);
        niveles1.Add(nivel2);
        niveles1.Add(nivel3);
        niveles1.Add(nivel4);
        niveles1.Add(nivel5);
        niveles1.Add(nivel6);
        niveles1.Add(nivel7);
        niveles1.Add(nivel8);
        niveles1.Add(nivel9);

        Nivel nivel11 = new Nivel();
        Nivel nivel22 = new Nivel();
        Nivel nivel33 = new Nivel();
        Nivel nivel44 = new Nivel();
        Nivel nivel55 = new Nivel();
        Nivel nivel66 = new Nivel();
        Nivel nivel77 = new Nivel();
        Nivel nivel88 = new Nivel();
        Nivel nivel99 = new Nivel();

        nivel11.Nombre = "Nivel 1";
        nivel11.Estado = true;
        nivel22.Nombre = "Nivel 2";
        nivel22.Estado = false;
        nivel33.Nombre = "Nivel 3";
        nivel33.Estado = false;
        nivel44.Nombre = "Nivel 4";
        nivel44.Estado = false;
        nivel55.Nombre = "Nivel 5";
        nivel55.Estado = false;
        nivel66.Nombre = "Nivel 6";
        nivel66.Estado = false;
        nivel77.Nombre = "Nivel 7";
        nivel77.Estado = false;
        nivel88.Nombre = "Nivel 8";
        nivel88.Estado = false;
        nivel99.Nombre = "Nivel 9";
        nivel99.Estado = false;

        niveles2.Add(nivel11);
        niveles2.Add(nivel22);
        niveles2.Add(nivel33);
        niveles2.Add(nivel44);
        niveles2.Add(nivel55);
        niveles2.Add(nivel66);
        niveles2.Add(nivel77);
        niveles2.Add(nivel88);
        niveles2.Add(nivel99);


        Nivel nivel111 = new Nivel();
        Nivel nivel222 = new Nivel();
        Nivel nivel333 = new Nivel();
        Nivel nivel444 = new Nivel();
        Nivel nivel555 = new Nivel();
        Nivel nivel666 = new Nivel();
        Nivel nivel777 = new Nivel();
        Nivel nivel888 = new Nivel();
        Nivel nivel999 = new Nivel();

        nivel111.Nombre = "Nivel 1";
        nivel111.Estado = true;
        nivel222.Nombre = "Nivel 2";
        nivel222.Estado = false;
        nivel333.Nombre = "Nivel 3";
        nivel333.Estado = false;
        nivel444.Nombre = "Nivel 4";
        nivel444.Estado = false;
        nivel555.Nombre = "Nivel 5";
        nivel555.Estado = false;
        nivel666.Nombre = "Nivel 6";
        nivel666.Estado = false;
        nivel777.Nombre = "Nivel 7";
        nivel777.Estado = false;
        nivel888.Nombre = "Nivel 8";
        nivel888.Estado = false;
        nivel999.Nombre = "Nivel 9";
        nivel999.Estado = false;

        niveles3.Add(nivel111);
        niveles3.Add(nivel222);
        niveles3.Add(nivel333);
        niveles3.Add(nivel444);
        niveles3.Add(nivel555);
        niveles3.Add(nivel666);
        niveles3.Add(nivel777);
        niveles3.Add(nivel888);
        niveles3.Add(nivel999);



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
    //public Sprite ImagenNivel(string nivel)
    //{
    //    Sprite foto = null;
    //    for (int i = 0; i < niveles.Count; i++)
    //    {
    //        if (niveles[i].Nombre == nivel)
    //        {
    //            foto = niveles[i].Imagen;
    //            break;
    //        }
    //    }

    //    return foto;
    //}

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
    /// <param name="slot"></param>
    /// <returns></returns>
    public string NombrePartidaJugador(string slot)
    {
        string nombre = "Vacio";

        for (int i = 0; i < partidas.Count; i++)
        {
            if (partidas[i].slot == slot)
            {
                nombre = partidas[i].nombre;
                break;
            }
        }

        return nombre;
    }

    public void GuardarDatos()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream archivo = File.Create(rutaDeGuardado);

        InformacionJuego info = new InformacionJuego();
        info.partidas = partidas;
        //info.niveles = niveles;

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

            //Debug.Log(info.nombrePartida);
            partidas = info.partidas;
            //niveles = info.niveles;

            archivo.Close();
        }
    }

    
}
