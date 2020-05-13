using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargaNivel : MonoBehaviour
{
    //public GameObject LoadingText;
    //public Text ProgressIndicator;
    public Image LoadingBar;
    float currentValue;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (currentValue < 100)
        {
            currentValue += speed * Time.deltaTime;
            //ProgressIndicator.text = ((int)currentValue).ToString() + "%";
            //LoadingText.SetActive(true);
        }
        else
        {
            //LoadingText.SetActive(false);
            //ProgressIndicator.text = "Done";
        }

        LoadingBar.fillAmount = currentValue / 100;
    }
}
