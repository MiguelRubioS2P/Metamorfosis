using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDragonDisparar : StateMachineBehaviour
{
    private PlayerDisparo scriptPlayerDisparo;
    private PlayerControll player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerControll>();
        scriptPlayerDisparo = FindObjectOfType<PlayerDisparo>();

        if (player.transform.localScale.x == -1)
        {
            scriptPlayerDisparo.DispararIzquierda();
        }
        else
        {
            scriptPlayerDisparo.DispararDerecha();
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Disparar", false);
    }

}
