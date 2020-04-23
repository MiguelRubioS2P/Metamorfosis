using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera camara;
    public float zoom;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            camara.GetComponent<Camera>().orthographicSize = zoom;
            Debug.Log("Hola");
        }
    }
}
