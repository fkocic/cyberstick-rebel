using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTrashManager : MonoBehaviour
{
    [SerializeField] List<GameObject> trashList = new List<GameObject>();
    [SerializeField] GUIBehavior trashGUI;
    private int currentTrashIndex = 0;


    public void AddTrash()
    {
        trashList[currentTrashIndex].SetActive(true);
        currentTrashIndex++;
        trashGUI.SetTrashBarFillAmount(currentTrashIndex);
    }

    public void RemoveTrash()
    {
        trashList[currentTrashIndex].SetActive(false);
        currentTrashIndex--;
        trashGUI.SetTrashBarFillAmount(currentTrashIndex);
    }

    public void RemoveAllTrash()
    {
        foreach (GameObject trash in trashList)
        {
            trash.SetActive(false);
        }
        currentTrashIndex = 0;
        trashGUI.SetTrashBarFillAmount(currentTrashIndex);
    }
}
