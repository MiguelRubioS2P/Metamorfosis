using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal3DePie : StateMachineBehaviour
{
    private Transform player;
    private Rigidbody2D rb2d;
    private JefeFinal3 jefeFinal3;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerControll>().transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        jefeFinal3 = animator.GetComponent<JefeFinal3>();

        jefeFinal3.inmortal = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefeFinal3.inmortal = false;
    }


}
