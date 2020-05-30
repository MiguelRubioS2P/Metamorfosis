using UnityEngine;

public class JefeFinal2Run : StateMachineBehaviour
{
    public float velocidad = 2.5f;
    public float rangoAtaque = 3f;

    private Transform player;
    private Rigidbody2D rb2d;
    private JefeFinal2 jefeFinal2;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = FindObjectOfType<PlayerControll>().transform;
        rb2d = animator.GetComponent<Rigidbody2D>();
        jefeFinal2 = animator.GetComponent<JefeFinal2>();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!jefeFinal2.muerto)
        {
            if (jefeFinal2.moverse)
            {
                if (!jefeFinal2.stun)
                {
                    jefeFinal2.LookAtPlayer();
                    Vector2 target = new Vector2(player.position.x, rb2d.position.y);
                    Vector2 nuevaPosicion = Vector2.MoveTowards(rb2d.position, target, velocidad * Time.fixedDeltaTime);
                    rb2d.MovePosition(nuevaPosicion);

                    if (Vector2.Distance(player.position, rb2d.position) <= rangoAtaque)
                    {
                        animator.SetTrigger("Atacar");
                    }
                }
                else
                {
                    animator.SetTrigger("Stun");
                }
            }
            else
            {
                Vector2 posicionPrincipio = Vector2.MoveTowards(rb2d.position, jefeFinal2.posicionInicial, velocidad * Time.fixedDeltaTime);
                rb2d.MovePosition(posicionPrincipio);
                if (posicionPrincipio == jefeFinal2.posicionInicial)
                {
                    animator.SetBool("Moverse", false);
                }
            }
        }
        else
        {
            animator.SetTrigger("Morir");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Atacar");
    }

}
