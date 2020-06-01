using UnityEngine;
using UnityEngine.UI;

public class JefeFinal3 : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = false;
    public bool levantado,inmortal,muerto,moverse;
    public GameObject final;
    public GameObject canvasVidas;
    public Text vidasTexto;

   

    private int vida;
    private JefeFinal3Atacar scriptJefeFinalAtacar;
    private float posicionXAtaqueIzquierda = -0.8f;
    private float posicionYAtaque = -0.4f;
    private float posicionXAtaqueDerecha = 0.8f;
    private BoxCollider2D boxCollider2d;

    private float offsetX, offsetY, sizeX, sizeY;
    private void Awake()
    {
        scriptJefeFinalAtacar = FindObjectOfType<JefeFinal3Atacar>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        offsetX = -0.2090588f;
        offsetY = -0.04375648f;
        sizeX = 0.4455452f;
        sizeY = 1.121329f;
    }

    private void Start()
    {
        levantado = false;
        inmortal = false;
        muerto = false;
        moverse = false;
        vida = 20;
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

    public void RecibirDaño(int daño)
    {
        if (!inmortal)
        {
            vida -= daño;
            vidasTexto.text = vida.ToString();
            Debug.Log("Mi vida es del valor: " + vida);
            if (vida == 10)
            {
                levantado = true;
                Debug.Log("Estoy modo fase enfadado");
                boxCollider2d.offset = new Vector2(offsetX, offsetY);
                boxCollider2d.size = new Vector2(sizeX, sizeY);
                
            }
            if(vida == 0)
            {
                final.GetComponent<SpriteRenderer>().enabled = true;
                final.GetComponent<BoxCollider2D>().enabled = true;
                canvasVidas.SetActive(false);
                muerto = true;
            }
        }
        else
        {
            Debug.Log("No me baja la vida, vida: " + vida);
        }
    }
}
