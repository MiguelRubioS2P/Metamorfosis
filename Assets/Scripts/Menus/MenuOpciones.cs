﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public AudioMixer mixer; // Contiene la pista de audio
    public Toggle pantallaCompleta, fps, wasd, arrows; // Checks de opciones

    public void ControlVoluemnGeneral(float sliderValue)
    {
        // Si modificamos el valor del slider, modificamos "Volume" del audio mixer
        mixer.SetFloat("Volumen", Mathf.Log10(sliderValue) * 20);
    }

    public void MenuPrincipal()
    {
        // Si volvemos atras 
        SceneManager.LoadScene("Menu Principal");
    }

    public void CambiarEstadoFPS()
    {
        // Condiciones para cambiar el estado de mostrar o no los fps
        if(fps.isOn)
        {
            GameObject.FindObjectOfType<OptionsManager>().GetComponent<OptionsManager>().fpsText.gameObject.SetActive(true);
            //FindObjectOfType<OptionsManager>().fpsText.gameObject.SetActive(true);
        }
        else
        {
            GameObject.FindObjectOfType<OptionsManager>().GetComponent<OptionsManager>().fpsText.gameObject.SetActive(false);
            //FindObjectOfType<OptionsManager>().fpsText.gameObject.SetActive(false);
        }
        
    }
}