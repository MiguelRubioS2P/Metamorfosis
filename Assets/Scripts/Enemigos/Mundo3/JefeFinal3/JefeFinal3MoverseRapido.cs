using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal3MoverseRapido : StateMachineBehaviour
{

    public float velocidad = 4f;

    private Transform player;
    private Rigidbody2D rb2d;
    private JefeFinal3 jefeFinal3;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerControll>().transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        jefeFinal3 = animator.GetComponent<JefeFinal3>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // El jefe final ya sigue al player.
        jefeFinal3.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb2d.position.y);
        Vector2 nuevaPosicion = Vector2.MoveTowards(rb2d.position, target, velocidad * Time.fixedDeltaTime);
        rb2d.MovePosition(nuevaPosicion);

        if (Vector2.Distance(player.position, rb2d.position) < 6)
        {
            animator.SetBool("MoverseRapido", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
