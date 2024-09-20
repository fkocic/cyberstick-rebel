using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.forward, 60 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().SetCheckpoint(transform);
            gameObject.SetActive(false);
        }
    }
}
