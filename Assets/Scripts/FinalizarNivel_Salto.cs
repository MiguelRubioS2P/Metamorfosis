using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalizarNivel_Salto : StateMachineBehaviour
{

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FinalizarNivel final = FindObjectOfType<FinalizarNivel>();
        final.GetComponent<Animator>().SetBool("saltando", false);
    }
}
