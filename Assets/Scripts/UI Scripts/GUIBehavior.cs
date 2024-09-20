using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIBehavior : MonoBehaviour
{
    [SerializeField] Image trashBar;
    public TextMeshProUGUI toolTipText;

    private void Start()
    {
        SetTrashBarFillAmount(0);   
    }

    public void SetTrashBarFillAmount(float fillAmount)
    {
        float tmp = (float)(fillAmount / 10);
        trashBar.fillAmount = tmp;
    }

    public void ShowToolTip(string text)
    {
        toolTipText.text = text;
        toolTipText.gameObject.SetActive(true);
    }

    public void HideToolTip()
    {
        toolTipText.text = "";
        toolTipText.gameObject.SetActive(false);
    }
}
