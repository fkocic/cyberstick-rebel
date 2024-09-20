using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpableObjectBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerMovement>().EmergencyJump();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JumpTrigger"))
        {
            other.gameObject.GetComponent<JumpTrigger>().isGrounded = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("JumpTrigger"))
        {
            other.gameObject.GetComponent<JumpTrigger>().isGrounded = false;
        }
    }
}
