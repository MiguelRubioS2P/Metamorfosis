using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombate : MonoBehaviour
{
    public Animator animator;
    public Transform puntoAtaque;
    public float rangoAtaque = 1f;
    public LayerMask maskEnemigos;

    public float ratioAtaque = 2f;
    private float siguienteAtaque = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= siguienteAtaque)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Atacar();
                siguienteAtaque = Time.time + 1f / ratioAtaque;
            }
        }
    }

    private void Atacar()
    {
        animator.SetTrigger("Atacar");
        Collider2D[] golpeEnemigos = Physics2D.OverlapCircleAll(puntoAtaque.position, rangoAtaque, maskEnemigos);

        foreach(Collider2D enemigo in golpeEnemigos)
        {
            Debug.Log("Golpeado " + enemigo.name);
            if(enemigo.name == "Jefe Final 2")
            {
                enemigo.GetComponent<JefeFinal2>().RecibirDaño(1);
            }else if(enemigo.name == "Pinchos")
            {
                enemigo.GetComponent<Pinchos>().RecibirDaño(1);
            }else if(enemigo.name == "JefeMundo1")
            {
                enemigo.GetComponent<Jefe1>().RecibirDaño();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        

        Gizmos.DrawWireSphere(puntoAtaque.position, rangoAtaque);
    }
}
