using ScottGarland;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public GameObject gameObject;
    public Image Icon;
    public TextMeshProUGUI text;

    private void Awake()
    {
        UIManager.Instance.goldUI = this;
    }

    public void UpdateUI()
    {
        BigIntegerText bigInteger = new BigIntegerText();
        text.text = bigInteger.ToStringBigInteger(GameManager.Instance.Player.gold);
    }
}
