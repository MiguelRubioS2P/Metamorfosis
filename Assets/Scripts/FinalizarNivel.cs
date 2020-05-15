using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarNivel : MonoBehaviour
{
    private Animator animator;
    private OptionsManager option;
    List<Partida> partidas = new List<Partida>();
    private void Awake()
    {
        option = FindObjectOfType<OptionsManager>();
        animator = GetComponent<Animator>();
        StartCoroutine(animacionGuardando());
    }
    public IEnumerator animacionGuardando()
    {
        comprobarRecord();
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu Niveles");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("saltando", true);
        }
    }

    
    private void comprobarRecord()
    {
        partidas = option.partidas;
        foreach (Partida i in partidas)
        {
            if (i.nombre == option.GetNombrePartida())
            {
                foreach (Nivel z in i.niveles)
                {
                    if (z.Nombre.Equals(option._ultimaEscenaJugada))
                    {
                        if(option._utlimasMonedasConseguidas > z.Monedas || option._ultimasEstrellasConseguidas > z.Estrellas)
                        {
                            
                            GuardarEstrellasYMonedas();
                        }
                    }
                }
            }

        }
    }

    /// <summary>
    /// Método para guardar las estrellas y las monedas conseguidas en el nivel
    /// </summary>
    private void GuardarEstrellasYMonedas()
    {
        option.SumarMonedasNivel(option._ultimaEscenaJugada, option.GetNombrePartida(), option._utlimasMonedasConseguidas);
        option.SumarEstrellasNivel(option._ultimaEscenaJugada, option.GetNombrePartida(), option._ultimasEstrellasConseguidas);
        option.GuardarDatos();
    }

}
