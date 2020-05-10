using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeFinal2 : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;

    public void LookAtPlayer()
    {
        

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            isFlipped = false;
        }else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
            isFlipped = true;
        }
    }
}
