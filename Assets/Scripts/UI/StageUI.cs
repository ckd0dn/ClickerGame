using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    public TextMeshProUGUI stageNumText;

    private void Awake()
    {
        UIManager.Instance.stageUI = this;
    }

    public void UpdateUI()
    {
        stageNumText.text = GameManager.Instance.stageIdx.ToString();
    }
}
