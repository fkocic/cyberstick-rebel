using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBehavior : MonoBehaviour
{
    [SerializeField] GameManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            manager.ChangeScene();
        }
    }
}
