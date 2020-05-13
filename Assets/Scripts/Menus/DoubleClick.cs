using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DoubleClick : MonoBehaviour, IPointerClickHandler
{
    private MenuGuardado menuGuardadoScript;

    private void Awake()
    {
        menuGuardadoScript = FindObjectOfType<MenuGuardado>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            Debug.Log("double click");
            menuGuardadoScript.OnIrMenuNiveles();
        }
    }
}
