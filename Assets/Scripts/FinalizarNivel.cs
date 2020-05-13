using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalizarNivel : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(animacionGuardando());
    }
    public IEnumerator animacionGuardando()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu Niveles");
    }
}
