using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal2Parado : StateMachineBehaviour
{

    private JefeFinal2 jefeFinal2;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefeFinal2 = animator.GetComponent<JefeFinal2>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        jefeFinal2.stun = false;
        animator.ResetTrigger("Stun");
    }


}
