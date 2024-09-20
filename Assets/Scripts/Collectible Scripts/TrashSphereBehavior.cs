using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSphereBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<TrashBehavior>().StartFollowingPlayer(other.gameObject.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<TrashBehavior>().StopFollowingPlayer();
        }
    }
}
