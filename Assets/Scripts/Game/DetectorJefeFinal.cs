using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorJefeFinal : MonoBehaviour
{
    public Canvas canvas;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Cuerpo")
        {
            canvas.gameObject.SetActive(true);
        }
    }
}
