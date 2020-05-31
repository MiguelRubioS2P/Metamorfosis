using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal3Activarse : MonoBehaviour
{

    private JefeFinal3 jefeFinal3;

    private void Awake()
    {
        jefeFinal3 = FindObjectOfType<JefeFinal3>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            jefeFinal3.moverse = true;
            Destroy(gameObject);
        }
    }
}
