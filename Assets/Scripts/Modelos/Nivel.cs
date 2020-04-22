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

    
}
