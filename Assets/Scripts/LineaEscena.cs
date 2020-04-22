using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineaEscena : MonoBehaviour
{

    public Transform from; // Punto de origen
    public Transform to; // Punto de final


    /// <summary>
    /// Utilizamos un método de unity para trazar una linea visual solo en la escena, en el juego no es visible
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        if(from != null && to != null)
        {
            Gizmos.color = Color.cyan;
            // creamos la linea de la posición inicio a la posición final
            Gizmos.DrawLine(from.position,to.position);
            // añadimos en las posiciones un gizmos esfera
            Gizmos.DrawSphere(from.position, 0.15f);
            Gizmos.DrawSphere(to.position, 0.15f);
        }
    }

}
