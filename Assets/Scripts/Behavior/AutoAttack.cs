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
        // 자동공격 남은시간 표시
        autoAttackTimeText.gameObject.SetActive(true);
        autoAttackTimeText.text = $"{remainAutoAttackTime}s";

        // 10초 동안 0.5초마다 AttackMonster 실행
        float attackEndTime = Time.time + autoAttackTime;
        while (Time.time < attackEndTime)
        {
            GameManager.Instance.Player.attack.AttackMonster();
            autoAttackTimeText.text = $"{remainAutoAttackTime}s";
            yield return new WaitForSeconds(autoAttackInterval);
            remainAutoAttackTime -= autoAttackInterval;
        }

        autoAttackTimeText.gameObject.SetActive(false);

        // 25초 쿨타임
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
