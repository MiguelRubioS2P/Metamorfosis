using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMenu : MonoBehaviour
{
    private GameObject menuPausa, menuOpciones;
    private UIPausa scriptUIPausa;
    private UiOpciones scriptUiOpciones;
    public bool estaActivoPausa, estaActivoOpciones, estaActivoMuerte;

    private void Awake()
    {
        // Los GO están activos
        menuPausa = GameObject.Find("UI de Pausa");
        scriptUIPausa = menuPausa.GetComponent<UIPausa>();
        menuOpciones = GameObject.Find("UI de Opciones");
        scriptUiOpciones = menuOpciones.GetComponent<UiOpciones>();
    }

    private void Start()
    {
        // GO los desactivamos
        menuPausa.SetActive(false);
        menuOpciones.SetActive(false);
        estaActivoPausa = false;
        estaActivoOpciones = false;
        estaActivoMuerte = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaActivoMuerte)
            {
                menuPausa.SetActive(false);
                menuOpciones.SetActive(false);
            }
            else if (estaActivoPausa && !estaActivoOpciones)
            {
                estaActivoPausa = false;
                scriptUIPausa.Desactivar();
                menuPausa.SetActive(false);
            }
            else if(!estaActivoPausa && !estaActivoOpciones)
            {
                estaActivoPausa = true;
                menuPausa.SetActive(true);
                scriptUIPausa.Activar();
            }else if(estaActivoPausa && estaActivoOpciones)
            {
                estaActivoPausa = false;
                estaActivoOpciones = false;

                scriptUIPausa.Desactivar();
                menuPausa.SetActive(false);
                scriptUiOpciones.Desactivar();
                menuOpciones.SetActive(false);
            }

        }
    }

}
