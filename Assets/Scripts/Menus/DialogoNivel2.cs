using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoNivel2 : MonoBehaviour
{

    public GameObject iconoActivar;
    public GameObject coco;
    public GameObject mensajeCoco;
    public float temporizadorIcono = 1f;
    public float temporizadorCoco = 3f;
    public float temporizadorAdios = 6f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Invoke("Icono", temporizadorIcono);
            Invoke("CocoDialogo", temporizadorCoco + temporizadorIcono);
            Invoke("CocoDialogoAdios", temporizadorAdios + temporizadorCoco + temporizadorIcono);
            Invoke("Autodestruccion", temporizadorAdios + temporizadorCoco + temporizadorIcono + 4f);
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            coco.SetActive(false);
            mensajeCoco.SetActive(false);
        }
    }

    private void Icono()
    {
        iconoActivar.SetActive(true);
    }

    private void CocoDialogo()
    {
        coco.SetActive(true);
        mensajeCoco.SetActive(true);
    }

    private void CocoDialogoAdios()
    {
        coco.SetActive(false);
        mensajeCoco.SetActive(false);
    }

    private void Autodestruccion()
    {
        Destroy(gameObject);
    }
}
