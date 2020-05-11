using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TranscionMenus : MonoBehaviour
{
    public Animator animator;

    public IEnumerator cambioEscena(string escena)
    {
        animator.SetTrigger("start");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(escena);
    }
}
