using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarCanvasVidas : MonoBehaviour
{
    public GameObject canvasVidaJefeFinal3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            canvasVidaJefeFinal3.SetActive(true);
        }
    }
}
