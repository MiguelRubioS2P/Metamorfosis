using System.Collections;
using UnityEngine;

public class Pinchos_Movimiento : MonoBehaviour
{
    
    public float fuerzaMovimiento; // Variable de fuerza de movimiento
    private Vector2 posicionInicial; // Variable donde guardamos la posicion inicial

    void Awake()
    {
        //Al inicar cogemos su posicion para poder volver a ella, despues iniciamos la coroutina.

        posicionInicial = new Vector2(transform.position.x, transform.position.y);
        StartCoroutine(Bajar());
    }

    IEnumerator Bajar()
    {
        //Esperamos 3s despues cambiamos su posicion hacia abajo dependiendo de la fuerza, 
        //volvemos a esperar 3s y volvemos a la posicion inicial y volvemos a ejecutar.

        yield return new WaitForSeconds(3);
        transform.position = new Vector2(transform.position.x, transform.position.y * fuerzaMovimiento);
        yield return new WaitForSeconds(3);
        transform.position = posicionInicial;
        StartCoroutine(Bajar());

    }
}
