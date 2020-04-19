using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogoNivel1 : MonoBehaviour
{

    public GameObject guia;
    public Image dialogo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            guia.SetActive(true);
            dialogo.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            guia.SetActive(false);
            dialogo.gameObject.SetActive(false);
        }
    }
}
