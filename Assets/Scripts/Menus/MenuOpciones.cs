using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    public AudioMixer mixer;
    public Toggle pantallaCompleta, fps, wasd, arrows;

    public void ControlVoluemnGeneral(float sliderValue)
    {
        mixer.SetFloat("Volumen", Mathf.Log10(sliderValue) * 20);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Menu Principal");
    }

    public void CambiarEstadoFPS()
    {
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