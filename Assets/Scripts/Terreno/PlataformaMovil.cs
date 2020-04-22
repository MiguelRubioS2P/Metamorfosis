using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{

    public Transform target; // Punto hacia donde tiene que ir la plataforma o GO
    public float speed;
    private Vector3 start, end; // Guardamos la posición inical del GO y la posición final con el punto hacia se dirige el GO

    
    void Start()
    {
        if(target != null)
        {
            //hacemos que target que era hijo de la plataforma ya no sea hijo
            target.parent = null;
            start = transform.position;
            end = target.position;
        }
    }

    
    void Update()
    {
        if(target != null)
        {
            float fixedSpeed = speed * Time.deltaTime;
            // para que se mueva en la linea creada entre el punto origen y el punto final
            transform.position = Vector3.MoveTowards(transform.position,target.position,fixedSpeed);
        }

        // controlamos que si la posicion es la del objetivo
        // cambie y vuelva a la otra
        // movimiento ciclico
        if(transform.position == target.position)
        {
            if(target.position == start)
            {
                target.position = end;
            }
            else
            {
                target.position = start;
            }
        }
    }
}
