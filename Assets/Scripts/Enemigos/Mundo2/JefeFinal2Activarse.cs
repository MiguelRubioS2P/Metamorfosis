using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal2Activarse : MonoBehaviour
{

    private JefeFinal2 jefeFinal2;
    private Animator animator;

    private void Start()
    {
        jefeFinal2 = FindObjectOfType<JefeFinal2>();
        animator = jefeFinal2.GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            animator.SetBool("Moverse", true);
            jefeFinal2.moverse = true;
        }

        if(collision.transform.tag == "Jefes")
        {
            jefeFinal2.moverse = false;
        }
    }


}
