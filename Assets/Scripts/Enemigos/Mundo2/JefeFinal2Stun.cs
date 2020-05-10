using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal2Stun : MonoBehaviour
{
    private JefeFinal2 jefeFinal2;
    private Animator animator;

    private void Start()
    {
        jefeFinal2 = FindObjectOfType<JefeFinal2>();
        animator = jefeFinal2.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            Debug.Log("Stun");
            jefeFinal2.stun = true;
        }
    }
}
