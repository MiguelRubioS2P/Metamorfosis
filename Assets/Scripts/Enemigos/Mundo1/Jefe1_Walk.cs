using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe1_Walk : StateMachineBehaviour
{
    private Transform player;
    private Jefe1 jefe;
    private Rigidbody2D rb2d;

    private float velocidad = 2.5f;
    public float rangoAtaque = 5f;
    private float siguienteDisparo = 5f;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerControll>().transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        jefe = animator.GetComponent<Jefe1>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefe.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb2d.position.y);
        Vector2 nuevaPosicion = Vector2.MoveTowards(rb2d.position, target, velocidad * Time.fixedDeltaTime);
        rb2d.MovePosition(nuevaPosicion);

        if (Vector2.Distance(player.position, rb2d.position) <= rangoAtaque)
        {
            if (Time.time > siguienteDisparo)
            {
                animator.SetTrigger("ataque");
                siguienteDisparo = Time.time + 5f;
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("ataque");
    }
}
