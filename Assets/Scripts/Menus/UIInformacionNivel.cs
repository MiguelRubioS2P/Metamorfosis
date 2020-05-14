using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInformacionNivel : MonoBehaviour
{
    public Text monedas;
    public Text nivel;
    public Text estrellas;
    private OptionsManager option;
    List<Partida> partidas = new List<Partida>();

    private void Awake()
    {
        option = FindObjectOfType<OptionsManager>();
    }
    public void Mostrar(Button boton)
    {
        //Version Obteniendo de nuevo el archivo
        /* gameObject.GetComponent<Canvas>().enabled = true;

         if (File.Exists(Application.absoluteURL + "datos.dat"))
         {
             BinaryFormatter bf = new BinaryFormatter();
             FileStream archivo = File.Open(Application.absoluteURL + "datos.dat", FileMode.Open);

             InformacionJuego info = bf.Deserialize(archivo) as InformacionJuego;

             partidas = info.partidas;

             archivo.Close();
         }

         foreach(Partida i in partidas)
         {
             if(i.nombre.Equals(option.nombrePartida))
             {
                 foreach(Nivel z in i.niveles)
                 {
                    if(z.Nombre.Equals(boton.name))
                     {
                         nivel.text = z.Nombre;
                         monedas.text = z.Monedas.ToString();
                         estrellas.text = z.Estrellas.ToString();
                     }
                 }
             }

         }*/


        //Version usando el option manager

        gameObject.GetComponent<Canvas>().enabled = true;
        partidas = option.partidas;
        foreach (Partida i in partidas)
        {
            if (i.nombre.Equals(option.nombrePartida))
            {
                foreach (Nivel z in i.niveles)
                {
                    if (z.Nombre.Equals(boton.name))
                    {
                        nivel.text = z.Nombre;
                        monedas.text = z.Monedas.ToString();
                        estrellas.text = z.Estrellas.ToString();
                    }
                }
            }

        }

    }

    public void Esconder()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
