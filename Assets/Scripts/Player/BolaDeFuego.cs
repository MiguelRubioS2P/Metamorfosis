using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFuego : MonoBehaviour
{
	public float velocidad = 20f;
	public Rigidbody2D rb;

	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	
	void Start()
	{
		rb.velocity = transform.right * velocidad;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if(collision.transform.name == "Jefe Final 2")
		{
			collision.GetComponent<JefeFinal2>().RecibirDaño(2);
			Destroy(gameObject);
		}else if(collision.transform.tag == "Ataque")
		{
			collision.GetComponent<Pinchos>().RecibirDaño(2);
			Destroy(gameObject);
		}
		else if (collision.transform.tag == "Jefes")
		{
			collision.GetComponent<Jefe1>().RecibirDaño();
			collision.GetComponent<Jefe1>().RecibirDaño();
			Destroy(gameObject);
		}
		else if (collision.transform.tag == "jefefinal3")
		{
			collision.GetComponent<JefeFinal3>().RecibirDaño(2);
			Destroy(gameObject);
		}
		else 
		{
			Destroy(gameObject, 2f);
		}
		
	}
}
