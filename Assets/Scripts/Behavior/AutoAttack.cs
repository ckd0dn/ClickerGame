using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoAttack : MonoBehaviour
{
    public Image coolTimeImg;
    public TextMeshProUGUI autoAttackTimeText;
    [SerializeField] private float coolDownDuration = 25;
    [SerializeField] private float autoAttackTime = 10;
    [SerializeField] private float autoAttackInterval = 0.5f;

    private bool isAutoAttacking = false;
    private bool isCoolDown = false;

    private void Awake()
    {
        autoAttackTimeText.gameObject.SetActive(false);
    }

    public void StartAutoAttack()
    {
        if (!isAutoAttacking && !isCoolDown)
        {
            StartCoroutine(AutoAttackCoroutine());
        }
    }

    private IEnumerator AutoAttackCoroutine()
    {
        isAutoAttacking = true;
        float remainAutoAttackTime = autoAttackTime;
        // �ڵ����� �����ð� ǥ��
        autoAttackTimeText.gameObject.SetActive(true);
        autoAttackTimeText.text = $"{remainAutoAttackTime}s";

        // 10�� ���� 0.5�ʸ��� AttackMonster ����
        float attackEndTime = Time.time + autoAttackTime;
        while (Time.time < attackEndTime)
        {
            GameManager.Instance.Player.attack.AttackMonster();
            autoAttackTimeText.text = $"{remainAutoAttackTime}s";
            yield return new WaitForSeconds(autoAttackInterval);
            remainAutoAttackTime -= autoAttackInterval;
        }

        autoAttackTimeText.gameObject.SetActive(false);

        // 25�� ��Ÿ��
        StartCoroutine(CoolDownCoroutine());

        // yield return new WaitForSeconds(coolDownDuration);


        isAutoAttacking = false;
    }

    private IEnumerator CoolDownCoroutine()
    {
        isCoolDown = true;
        float coolDownInterval = 0.05f;
        float curCoolDownDuration = coolDownDuration;
        coolTimeImg.fillAmount = 1;

        while (curCoolDownDuration >= 0)
        {
            curCoolDownDuration -= coolDownInterval;
            coolTimeImg.fillAmount -= (coolDownInterval / coolDownDuration);
            yield return new WaitForSeconds(coolDownInterval);
        }

        isCoolDown = false;

    }
}
