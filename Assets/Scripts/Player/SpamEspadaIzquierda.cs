using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamEspadaIzquierda : MonoBehaviour
{
	public float velocidad = 20f;
	public Rigidbody2D rb;

	private void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start()
	{

		rb.velocity = transform.up * velocidad;
	}

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if(collision.transform.tag == "Jefes")
	//	{
	//		Destroy(gameObject);
	//	}
	//}
}
