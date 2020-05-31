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
		Destroy(gameObject, 2f);
	}
}
