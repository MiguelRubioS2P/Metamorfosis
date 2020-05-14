using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarNivel : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animacionGuardando();
    }
    public IEnumerator animacionGuardando()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu Niveles");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("saltando", true);
        }
    }
}
