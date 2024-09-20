using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipBeahvior : MonoBehaviour
{
    [SerializeField] GUIBehavior gui;
    [TextArea(10, 14)]
    [SerializeField] string message = "";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gui.ShowToolTip(message);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gui.HideToolTip();
        }
    }
}
