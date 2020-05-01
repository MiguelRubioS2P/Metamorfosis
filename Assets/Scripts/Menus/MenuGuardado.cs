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
    private bool slot1Select, slot2Select, slot3Select;
    

    private void Awake()
    {
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
            slot1.transform.GetChild(1).GetComponent<Text>().text = optionsManager.NombrePartidaJugador(slot1.gameObject.name);
            Debug.Log("El último nivel jugado es el nivel " + optionsManager.ObtenerUltimoNivelJugado(optionsManager.nombrePartida));
        }
        else
        {
            slot1.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
        }
        if (optionsManager.NombrePartidaJugador(slot2.gameObject.name) != null)
        {
            slot2.transform.GetChild(1).GetComponent<Text>().text = optionsManager.NombrePartidaJugador(slot2.gameObject.name);
        }
        else
        {
            slot2.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
        }
        if (optionsManager.NombrePartidaJugador(slot3.gameObject.name) != null)
        {
            slot3.transform.GetChild(1).GetComponent<Text>().text = optionsManager.NombrePartidaJugador(slot3.gameObject.name);
        }
        else
        {
            slot3.transform.GetChild(1).GetComponent<Text>().text = "Vacio";
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
                BloquearInputField(IFslot2);
                BloquearInputField(IFslot3);
                selecionado = true;
                slot1Select = true;
                slot2Select = false;
                slot3Select = false;
                slot1.image.color = Color.green;
                slot2.image.color = Color.red;
                slot3.image.color = Color.red;
                botones.SetActive(true);
                DesbloquearInputField(IFslot1);
            }
            
        } else if (boton == ("Slot 2 Boton"))
        {

            if (optionsManager.NombrePartidaJugador(slot2.gameObject.name) != null)
            {
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
                BloquearInputField(IFslot1);
                BloquearInputField(IFslot3);
                selecionado = true;
                slot1Select = false;
                slot2Select = true;
                slot3Select = false;
                slot2.image.color = Color.green;
                slot1.image.color = Color.red;
                slot3.image.color = Color.red;
                botones.SetActive(true);
                DesbloquearInputField(IFslot2);
            }
            
        }
        else if (boton == ("Slot 3 Boton"))
        {
            if (optionsManager.NombrePartidaJugador(slot3.gameObject.name) != null)
            {
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
                BloquearInputField(IFslot1);
                BloquearInputField(IFslot2);
                selecionado = true;
                slot1Select = false;
                slot2Select = false;
                slot3Select = true;
                slot3.image.color = Color.green;
                slot2.image.color = Color.red;
                slot1.image.color = Color.red;
                botones.SetActive(true);
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
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }

    public void OnVolverMenu()
    {
        // Volver al menu
        SceneManager.LoadScene("Menu Principal");
    }

    public void OnIrMenuNiveles()
    {
        // Aqui iria saber si ya tiene partida empezada o no
        if(selecionado)
        {
            if (slot1Select)
            {
                if (IFslot1.IsActive())
                {
                    if (TieneTexto(IFslot1))
                    {
                        if (optionsManager.ExisteNombre(IFslot1.text))
                        {
                            Debug.Log("No puedes poner ese nombre, ya existe");
                        }
                        else
                        {
                            ElegirNombre(slot1.gameObject.name, IFslot1);
                            optionsManager.GuardarDatos();
                            optionsManager.nombrePartida = IFslot1.text;
                            SceneManager.LoadScene("Menu Niveles");
                        }
                    }
                    
                }
                else
                {
                    optionsManager.nombrePartida = slot1.transform.GetChild(1).GetComponent<Text>().text;
                    SceneManager.LoadScene("Menu Niveles");
                }
               
            }

            if (slot2Select)
            {
                if (IFslot2.IsActive())
                {
                    if (TieneTexto(IFslot2))
                    {
                        if (optionsManager.ExisteNombre(IFslot2.text))
                        {
                            Debug.Log("No puedes poner ese nombre, ya existe");
                        }
                        else
                        {
                            ElegirNombre(slot2.gameObject.name, IFslot2);
                            optionsManager.GuardarDatos();
                            optionsManager.nombrePartida = IFslot2.text;
                            SceneManager.LoadScene("Menu Niveles");
                        }
                    }
                }
                else
                {
                    optionsManager.nombrePartida = slot2.transform.GetChild(1).GetComponent<Text>().text;
                    SceneManager.LoadScene("Menu Niveles");
                }
            }

            if (slot3Select)
            {
                if (IFslot3.IsActive())
                {
                    if (TieneTexto(IFslot3))
                    {
                        if (optionsManager.ExisteNombre(IFslot3.text))
                        {
                            Debug.Log("No puedes poner ese nombre, ya existe");
                        }
                        else
                        {
                            ElegirNombre(slot3.gameObject.name, IFslot3);
                            optionsManager.GuardarDatos();
                            optionsManager.nombrePartida = IFslot3.text;
                            SceneManager.LoadScene("Menu Niveles");
                        }
                    }
                }
                else
                {
                    optionsManager.nombrePartida = slot3.transform.GetChild(1).GetComponent<Text>().text;
                    SceneManager.LoadScene("Menu Niveles");
                }
            }
            
        }
        
    }


    private void DesbloquearInputField(InputField inputfield)
    {
        inputfield.gameObject.SetActive(true);
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
    private void ElegirNombre(string slot, InputField nombre)
    {
        optionsManager.PonerNombreJugador(slot, nombre.text);    
    }

    /// <summary>
    /// Comprobamos si el valor que tiene el inputfield es vacio o con espacios pero vacio
    /// </summary>
    /// <param name="nombre">valor texto del inputfield</param>
    /// <returns></returns>
    private bool TieneTexto(InputField nombre)
    {
        bool vacio = false;

        if (nombre.text.Trim().Equals(""))
        {
            vacio = false;
        }
        else
        {
            vacio = true;
        }

        return vacio;
    }
    
}
