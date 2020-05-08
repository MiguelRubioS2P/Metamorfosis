using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuerza : MonoBehaviour
{
    public GameObject bola;
    public float fuerza;
    public float tiempo;
    private void Awake()
    {
        StartCoroutine(Fuerzas());
    }

    IEnumerator Fuerzas()
    {
        bola.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerza, 0), ForceMode2D.Impulse);
        yield return new WaitForSeconds(tiempo);
        StartCoroutine(Fuerzas());
    }
}
