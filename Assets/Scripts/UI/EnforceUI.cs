using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnforceUI : MonoBehaviour
{
    public TextMeshProUGUI attackDameText;
    public TextMeshProUGUI attackPriceText;
    public int EnforceAttackPrice;
    public float EnforceAttackDamage;

    private void Awake()
    {
        UIManager.Instance.enforceUI = this;
    }

    public void UpdateUI()
    {
        attackDameText.text = GameManager.Instance.Player.damage.ToString();
        attackPriceText.text = EnforceAttackPrice.ToString() + "G";
    }

    public void LevelUpDamage()
    {
        // ������ ������ ��θ� return
        if (GameManager.Instance.Player.gold < EnforceAttackPrice)
        {
            return;
        }

        // ��ȭ�ϸ鼭 �����
        GameManager.Instance.Player.gold -= EnforceAttackPrice;
        UIManager.Instance.goldUI.UpdateUI();

        // ���� ��ȭ��� 
        int addDamage = (int)Random.Range(EnforceAttackDamage/2, EnforceAttackDamage);
        int addPrice = (int)Random.Range(EnforceAttackPrice/ 2, EnforceAttackPrice);

        GameManager.Instance.Player.damage += addDamage;
        EnforceAttackPrice += addPrice;
        UpdateUI();
       
    }
}
