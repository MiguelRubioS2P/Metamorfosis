using UnityEngine;

public class JefeFinal3 : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;

    private JefeFinal3Atacar scriptJefeFinalAtacar;
    private float posicionXAtaqueIzquierda = -0.8f;
    private float posicionYAtaque = -0.4f;
    private float posicionXAtaqueDerecha = 0.8f;
    private void Awake()
    {
        scriptJefeFinalAtacar = FindObjectOfType<JefeFinal3Atacar>();
    }

    private void Start()
    {
        
    }

    public void LookAtPlayer()
    {


        if (transform.position.x > player.position.x && isFlipped)
        {
            // Izquierda
            scriptJefeFinalAtacar.attackOffset = new Vector3(posicionXAtaqueIzquierda, posicionYAtaque, 0);
            transform.localScale = new Vector3(-1f, 1f, 1f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            // Derecha
            scriptJefeFinalAtacar.attackOffset = new Vector3(posicionXAtaqueDerecha, posicionYAtaque, 0);
            transform.localScale = new Vector3(1f, 1f, 1f);
            isFlipped = true;
        }
    }
}
