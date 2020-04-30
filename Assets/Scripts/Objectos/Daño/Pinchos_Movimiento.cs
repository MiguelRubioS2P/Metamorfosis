using System.Collections;
using UnityEngine;

public class Pinchos_Movimiento : MonoBehaviour
{
    private Vector2 posicionInicial; // Variable donde guardamos la posicion inicial
    private float posicionFinal;
    private Rigidbody2D rigidbody2d;




    void Awake()
    {
        //Al inicar cogemos su posicion para poder volver a ella, despues iniciamos la coroutina.
        posicionInicial = new Vector2(transform.position.x, transform.position.y);
        rigidbody2d = GetComponent<Rigidbody2D>();
        StartCoroutine(Bajar());
    }

    IEnumerator Bajar()
    {
        //Esperamos 3s despues cambiamos su posicion hacia abajo dependiendo de la fuerza, 
        //volvemos a esperar 3s y volvemos a la posicion inicial y volvemos a ejecutar.
        yield return new WaitForSeconds(3);
        rigidbody2d.isKinematic = false;

        yield return new WaitForSeconds(3);
        rigidbody2d.isKinematic = true;

        var posicionActual = transform.position;
        var tiempo = 0f;
        var segundos = 1f;
        while (tiempo < 1)
        {
            tiempo += Time.deltaTime / segundos;
            transform.position = Vector3.Lerp(posicionActual, posicionInicial, tiempo);
            yield return null;
        }

        StartCoroutine(Bajar());
    }
}
