using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jefe1_Daño : StateMachineBehaviour
{
    private GameObject player;
    private Rigidbody2D rb2d;
    private Jefe1 jefe;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerControll>().gameObject;
        rb2d = animator.GetComponent<Rigidbody2D>();
        jefe = animator.GetComponent<Jefe1>();

        if (jefe.PerderVida() < 0)
        {
            jefe.Morir();
        }
        if (animator.gameObject.transform.position.x < player.transform.position.x)
        {
            rb2d.velocity = new Vector2(-3f, rb2d.velocity.y);
        }
        else if (animator.gameObject.transform.position.x > player.transform.position.x)
        {
            rb2d.velocity = new Vector2(3f, rb2d.velocity.y);
        }
    }
}
