using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierra_Movimiento : MonoBehaviour
{
    public float fuerzaRotacion; // Variable para aplicar la fuerza de rotacion del objecto

    void Update()
    {
        // Cada frame se rota el objecto por la fuerza de rotacion
        transform.Rotate(0f, 0f, 1f * fuerzaRotacion);
    }
}
