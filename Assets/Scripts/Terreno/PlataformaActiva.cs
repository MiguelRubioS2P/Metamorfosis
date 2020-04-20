using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaActiva : MonoBehaviour
{
    public GameObject go;
    private PlataformaMovil scriptPlataformaMovil;
    private bool encima;
    // Start is called before the first frame update
    void Start()
    {
        encima = false;
        scriptPlataformaMovil = go.GetComponent<PlataformaMovil>();
    }

    // Update is called once per frame
    void Update()
    {
        if (encima)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                scriptPlataformaMovil.enabled = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            encima = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            encima = false;
            scriptPlataformaMovil.enabled = false;
        }
    }
}
