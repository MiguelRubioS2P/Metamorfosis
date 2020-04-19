﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{

    public Transform target;
    public float speed;
    private Vector3 start, end;

    
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
            transform.position = Vector3.MoveTowards(transform.position,target.position,fixedSpeed);
        }

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
