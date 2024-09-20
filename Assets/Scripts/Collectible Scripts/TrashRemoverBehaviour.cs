using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRemoverBehaviour : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.Instance.PlayWoosh();
            other.gameObject.GetComponent<PlayerTrashManager>().RemoveAllTrash();
            levelManager.ResetTrash();
            other.GetComponent<PlayerMovement>().ResetJumpHeight();
            other.GetComponent<PlayerMovement>().ResetJumpLevel();
        }
    }
}
