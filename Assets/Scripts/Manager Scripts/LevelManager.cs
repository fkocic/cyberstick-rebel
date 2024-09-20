using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] List<GameObject> trashList = new List<GameObject>();
    [SerializeField] List<GameObject> checkpointList = new List<GameObject>();

    public void ResetLevel()
    {
        ResetCheckpoints();
        ResetTrash();
    }

    public void ResetTrash()
    {
        foreach (GameObject trash in trashList)
        {
            trash.SetActive(true);
            trash.GetComponent<TrashBehavior>().ReturnToStartingPosition();
        }
    }

    public void ResetCheckpoints()
    {
        foreach (GameObject checkpoint in checkpointList)
        {
            checkpoint.SetActive(true);
        }
    }
}
