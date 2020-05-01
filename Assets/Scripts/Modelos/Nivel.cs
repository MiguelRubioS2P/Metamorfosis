using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Nivel
{
    private string nombre;
    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    private bool estado;
    public bool Estado
    {
        get { return estado; }
        set { estado = value; }
    }

    private int monedas;
    public int Monedas
    {
        get { return monedas; }
        set { monedas = value; }
    }

    private int estrellas;
    public int Estrellas
    {
        get { return estrellas; }
        set { estrellas = value; }
    }

    public Nivel(string nombre, bool estado, int monedas, int estrellas)
    {
        Nombre = nombre;
        Estado = estado;
        Monedas = monedas;
        Estrellas = estrellas;
    }
}
