using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal3Disparar : MonoBehaviour
{

    public GameObject bala;
    public Transform posicion;
    public void Disparar()
    {
        Instantiate(bala, posicion.position,posicion.rotation);
    }
}
