using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Partida
{
    public string slot;
    public string nombre;
    public List<Nivel> niveles = new List<Nivel>();
}
