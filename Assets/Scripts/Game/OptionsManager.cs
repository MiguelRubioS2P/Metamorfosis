using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    float deltaTime = 0.0f;
    public Text fpsText;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        int numero = (int) fps;
        fpsText.text = numero.ToString();
    }

    void Start()
    {
        fpsText.gameObject.SetActive(false);
    }

    private void Awake()
    {
        int count = FindObjectsOfType<OptionsManager>().Length;
        if (count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
