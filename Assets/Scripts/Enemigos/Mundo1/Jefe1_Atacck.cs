using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe1_Atacck : MonoBehaviour
{
    [SerializeField] GameObject laser;

    public void Atacar()
    {
        Instantiate(laser, transform.position, Quaternion.identity);
    }
}
