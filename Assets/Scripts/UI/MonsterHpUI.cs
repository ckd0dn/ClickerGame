using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHpUI : MonoBehaviour
{
    public GameObject gameObject;
    public Image hpBar;
    public TextMeshProUGUI hpText;

    private void Awake()
    {
        UIManager.Instance.monsterHpUI = this;
    }

    public void UpdateUI()
    {
        hpBar.fillAmount = GameManager.Instance.Monster.GetCurrentHpPercentage();
        hpText.text = GameManager.Instance.Monster.GetCurrentHp().ToString();
    }
}
