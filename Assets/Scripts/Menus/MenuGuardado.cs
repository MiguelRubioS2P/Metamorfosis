using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuGuardado : MonoBehaviour
{
    public Button slot1, slot2, slot3;
    private bool selecionado;
    public GameObject botones;
    private OptionsManager optionsManager;
    public InputField IFslot1, IFslot2, IFslot3;
    private bool slot1Select, slot2Select, slot3Select, vacio;
    private TranscionMenus transcion;
    private UISalir salir;
    private string nivelBorrar;

    private void Awake()
    {
        transcion = FindObjectOfType<TranscionMenus>();
        salir = FindObjectOfType<UISalir>();
        vacio = true;

        // Variables para controlas donde esta el usuario pulsando.
        selecionado = false;
        slot1Select = false;
        slot2Select = false;
        slot3Select = false;
        botones.SetActive(false);

        // Encontramos el OptionsManager script
        optionsManager = FindObjectOfType<OptionsManager>();

        // Controlamos los distintos GO slot que tenemos en la escena
        if (optionsManager.NombrePartidaJugador(slot1.gameObject.name) != null)
        {
            slot1.transform.GetChild(0).GetComponent<Text>().text = optionsManager.NombrePartidaJugador(slot1.gameObject.name);
            slot1.transform.GetChild(1).GetComponent<Text>().text = optionsManager.ObtenerUltimoNivelJugado(slot1.gameObject.name);
        } 
        if (optionsManager.NombrePartidaJugador(slot2.gameObject.name) != null)
        {
            slot2.transform.GetChild(0).GetComponent<Text>().text = optionsManager.NombrePartidaJugador(slot2.gameObject.name);
            slot2.transform.GetChild(1).GetComponent<Text>().text = optionsManager.ObtenerUltimoNivelJugado(slot2.gameObject.name);
        } 
        if (optionsManager.NombrePartidaJugador(slot3.gameObject.name) != null)
        {
            slot3.transform.GetChild(0).GetComponent<Text>().text = optionsManager.NombrePartidaJugador(slot3.gameObject.name);
            slot3.transform.GetChild(1).GetComponent<Text>().text = optionsManager.ObtenerUltimoNivelJugado(slot3.gameObject.name);
        }
        Cursor.visible = true;
    }

    /// <summary>
    /// Intentamos saber en cada slot, si tenemos un dato guardado que provenga del archivo de guardado
    /// Aunque quizás el control del if se pueda hacer con la información directamente con el GO Text que tiene cada slot.
    /// </summary>
    public void OnClick()
    {
        // Guardamos en una variable el gameobject selecionado para saber por el 
        // nombre que boton se ha seleccionado
        string boton = EventSystem.current.currentSelectedGameObject.name;
        if (boton == ("Slot 1 Boton"))
        {
            if (optionsManager.NombrePartidaJugador(slot1.gameObject.name) != null)
            {
                nivelBorrar = slot1.transform.GetChild(0).GetComponent<Text>().text;
                selecionado = true;
                slot1Select = true;
                slot2Select = false;
                slot3Select = false;
                slot1.image.color = Color.green;
                slot2.image.color = Color.red;
                slot3.image.color = Color.red;
                botones.SetActive(true);
                BloquearInputField(IFslot2);
                BloquearInputField(IFslot3);
            }
            else
            {
                slot1.gameObject.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(false);
                BloquearInputField(IFslot2);
                BloquearInputField(IFslot3);
                selecionado = true;
                slot1Select = true;
                slot2Select = false;
                slot3Select = false;
                slot1.image.color = Color.green;
                slot2.image.color = Color.red;
                slot3.image.color = Color.red;
                botones.SetActive(false);
                DesbloquearInputField(IFslot1);
            }
            
        } else if (boton == ("Slot 2 Boton"))
        {

            if (optionsManager.NombrePartidaJugador(slot2.gameObject.name) != null)
            {
                nivelBorrar = slot2.transform.GetChild(0).GetComponent<Text>().text;
                selecionado = true;
                slot1Select = false;
                slot2Select = true;
                slot3Select = false;
                slot2.image.color = Color.green;
                slot1.image.color = Color.red;
                slot3.image.color = Color.red;
                botones.SetActive(true);
                BloquearInputField(IFslot1);
                BloquearInputField(IFslot3);
            }
            else
            {
                slot2.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(false);
                BloquearInputField(IFslot1);
                BloquearInputField(IFslot3);
                selecionado = true;
                slot1Select = false;
                slot2Select = true;
                slot3Select = false;
                slot2.image.color = Color.green;
                slot1.image.color = Color.red;
                slot3.image.color = Color.red;
                botones.SetActive(false);
                DesbloquearInputField(IFslot2);
            }
            
        }
        else if (boton == ("Slot 3 Boton"))
        {
            if (optionsManager.NombrePartidaJugador(slot3.gameObject.name) != null)
            {
                nivelBorrar = slot3.transform.GetChild(0).GetComponent<Text>().text;
                selecionado = true;
                slot1Select = false;
                slot2Select = false;
                slot3Select = true;
                slot3.image.color = Color.green;
                slot2.image.color = Color.red;
                slot1.image.color = Color.red;
                botones.SetActive(true);
                BloquearInputField(IFslot1);
                BloquearInputField(IFslot2);
            }
            else
            {
                slot3.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(false);
                BloquearInputField(IFslot1);
                BloquearInputField(IFslot2);
                selecionado = true;
                slot1Select = false;
                slot2Select = false;
                slot3Select = true;
                slot3.image.color = Color.green;
                slot2.image.color = Color.red;
                slot1.image.color = Color.red;
                botones.SetActive(false);
                DesbloquearInputField(IFslot3);
            }
            
        }  else if (boton == ("Cancelar Boton"))
        {
            selecionado = false;
            slot1.image.color = Color.red;
            slot2.image.color = Color.red;
            slot3.image.color = Color.red;
            botones.SetActive(false);
            slot1Select = false;
            slot2Select = false;
            slot3Select = false;
            BloquearInputField(IFslot1);
            BloquearInputField(IFslot2);
            BloquearInputField(IFslot3);
            
        } else if (boton == "Salir Boton")
        {
            salir.salirJuego();
        }
    }

    public void OnVolverMenu()
    {
        // Volver al menu
        StartCoroutine(transcion.cambioEscena("Menu Principal"));
    }

    public void OnIrMenuNiveles()
    {
        // Aqui iria saber si ya tiene partida empezada o no
        if (selecionado)
        {
            if (slot1Select)
            {
                if (slot1.transform.GetChild(0).GetComponent<Text>().text != "Slot 1")
                {
                    //Si ya tiene una partida guardada
                    if (optionsManager.ExisteNombre(slot1.transform.GetChild(0).GetComponent<Text>().text.ToUpper()))
                    {
                        optionsManager.nombrePartida = slot1.transform.GetChild(0).GetComponent<Text>().text.ToUpper();
                        StartCoroutine(transcion.cambioEscena("Menu Niveles"));
                    }
                    else
                    {
                        //Sino existe guardo ell nombre y creo la partida
                        //ElegirNombre(slot1.gameObject.name, slot1.transform.GetChild(0).GetComponent<Text>().text.ToUpper());
                        //optionsManager.GuardarDatos();
                        //optionsManager.nombrePartida = slot1.transform.GetChild(0).GetComponent<Text>().text.ToUpper();
                        StartCoroutine(transcion.cambioEscena("Menu Niveles"));

                    }
                }
            }


            if (slot2Select)
            {
                if (slot2.transform.GetChild(0).GetComponent<Text>().text != "Slot 2")
                {
                    //Si ya tiene una partida guardada
                    if (optionsManager.ExisteNombre(slot2.transform.GetChild(0).GetComponent<Text>().text.ToUpper()))
                    {
                        optionsManager.nombrePartida = slot2.transform.GetChild(0).GetComponent<Text>().text.ToUpper();
                        StartCoroutine(transcion.cambioEscena("Menu Niveles"));
                    }
                    else
                    {
                        //Sino existe guardo ell nombre y creo la partida
                        //ElegirNombre(slot2.gameObject.name, slot2.transform.GetChild(0).GetComponent<Text>().text.ToUpper());
                        //optionsManager.GuardarDatos();
                        //optionsManager.nombrePartida = slot2.transform.GetChild(0).GetComponent<Text>().text.ToUpper();
                        StartCoroutine(transcion.cambioEscena("Menu Niveles"));
                    }
                }
            }
            else
            {
                Debug.Log("No has introduciodo ningun nombre para el guardado");
            }

            if (slot3Select)
            {
                if (slot3.transform.GetChild(0).GetComponent<Text>().text != "Slot 3")
                {
                    //Si ya tiene una partida guardada
                    if (optionsManager.ExisteNombre(slot3.transform.GetChild(0).GetComponent<Text>().text.ToUpper()))
                    {
                        optionsManager.nombrePartida = slot3.transform.GetChild(0).GetComponent<Text>().text.ToUpper();
                        StartCoroutine(transcion.cambioEscena("Menu Niveles"));
                    }
                    else
                    {
                        //Sino existe guardo ell nombre y creo la partida
                        //ElegirNombre(slot3.gameObject.name, slot3.transform.GetChild(0).GetComponent<Text>().text.ToUpper());
                        //optionsManager.GuardarDatos();
                        //optionsManager.nombrePartida = slot3.transform.GetChild(0).GetComponent<Text>().text.ToUpper();
                        StartCoroutine(transcion.cambioEscena("Menu Niveles"));

                    }
                }
            }
        }
    }

    private void DesbloquearInputField(InputField inputfield)
    {
        inputfield.gameObject.SetActive(true);
        inputfield.Select();
    }
    
    private void BloquearInputField(InputField inputfield)
    {
        inputfield.gameObject.SetActive(false);
    }

    /// <summary>
    /// Añadimos el nombre a la partida para guardarlo
    /// </summary>
    /// <param name="slot">El nombre del slot que esta seleccionado</param>
    /// <param name="nombre">El nombre que esta en el Inputfield del slot seleccionado</param>
    /// 
    //private void ElegirNombre(string slot, InputField nombre)
    private void ElegirNombre(string slot, string nombre)
    {
        //optionsManager.PonerNombreJugador(slot, nombre.text);    
        optionsManager.PonerNombreJugador(slot, nombre);
        optionsManager.nombrePartida = nombre;
        optionsManager.GuardarDatos();
    }

    public void CambiarNombreSlotInput(Button slot)
    {
        
        if (!string.IsNullOrEmpty(slot.transform.GetChild(2).GetComponent<InputField>().text.ToUpper()))
        {
            if (optionsManager.ExisteNombre(slot.transform.GetChild(2).GetComponent<InputField>().text.ToUpper()))
            {
                Debug.Log("Existe nombre en la BD");
            }
            else
            {
                nivelBorrar = slot.transform.GetChild(2).GetComponent<InputField>().text.ToUpper();
                slot.transform.GetChild(0).GetComponent<Text>().text = slot.transform.GetChild(2).GetComponent<InputField>().text.ToUpper();
                ElegirNombre(slot.name, slot.transform.GetChild(2).GetComponent<InputField>().text.ToUpper());
                slot.transform.GetChild(2).GetComponent<InputField>().gameObject.SetActive(false);
                //-
                slot.transform.GetChild(1).GetComponent<Text>().text = optionsManager.ObtenerUltimoNivelJugado(slot.gameObject.name);
                //-
                slot.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(true);
                botones.SetActive(true);
            }
        }
        else
        {
            slot.transform.GetChild(2).GetComponent<InputField>().gameObject.SetActive(false);
            slot.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(true);
            slot.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
            Debug.Log("Nombre de partida vacia");
        }
        
    }   
    
    public void BorrarPartida()
    {
        optionsManager.EliminarPartidaGuardada(nivelBorrar);
        if(slot1Select)
        {
            slot1.transform.GetChild(0).GetComponent<Text>().text = "Slot 1";
            slot1.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(true);
            slot1.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
            slot1.image.color = Color.red;
        }
        else if (slot2Select)
        {
            slot2.transform.GetChild(0).GetComponent<Text>().text = "Slot 2";
            slot2.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(true);
            slot2.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
            slot2.image.color = Color.red;
        } else if (slot3Select)
        {
            slot3.transform.GetChild(0).GetComponent<Text>().text = "Slot 3";
            slot3.transform.GetChild(1).GetComponent<Text>().gameObject.SetActive(true);
            slot3.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
            slot3.image.color = Color.red;
        }
        selecionado = false;
        botones.SetActive(false);
    }
}
