using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EfectoZoom : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Button boton;
    private UIInformacionNivel info;

    private void Start()
    {
        boton = GetComponent<Button>();
        info = FindObjectOfType<UIInformacionNivel>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (boton.interactable)
        {
            Debug.Log("Es posible interactuar con el botón");
            gameObject.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
            info.Mostrar(boton);
        }
        else
        {
            Debug.Log("No es posible interactuar con el botón");
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (boton.interactable)
        {
            info.Esconder();
            Debug.Log("Es posible interactuar con el botón");
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else
        {
            Debug.Log("No es posible interactuar con el botón");
        }


    }


}
