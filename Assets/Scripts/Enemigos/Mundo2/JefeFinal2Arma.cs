using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal2Arma : MonoBehaviour
{
	public Vector3 attackOffset;
	public float attackRange = 2f;
	public LayerMask attackMask;

	private GameManager gameManager;

	public void Attack()
	{
		gameManager = FindObjectOfType<GameManager>();

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			Debug.Log("Ataque");
			gameManager.PerderVida();
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
