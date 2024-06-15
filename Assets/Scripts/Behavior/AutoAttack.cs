using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoAttack : MonoBehaviour
{
    public Image coolTimeImg;
    [SerializeField] private float coolDownDuration = 25;
    [SerializeField] private float autoAttackTime = 10;
    [SerializeField] private float autoAttackInterval = 0.5f;

    private bool isAutoAttacking = false;
    private bool isCoolDown = false;

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

        // 10초 동안 0.5초마다 AttackMonster 실행
        float attackEndTime = Time.deltaTime + autoAttackTime;
        while (Time.deltaTime < attackEndTime)
        {
            GameManager.Instance.Player.attack.AttackMonster();
            yield return new WaitForSeconds(autoAttackInterval);
        }

        // 25초 쿨타임
        yield return new WaitForSeconds(coolDownDuration);

        isAutoAttacking = false;
    }

    private IEnumerator CoolDownCoroutine()
    {
        isCoolDown = true;
        float coolDownInterval = 0.1f;
        float curCoolDownDuration = coolDownDuration;
        coolTimeImg.fillAmount = 1;

        while (curCoolDownDuration >= 0)
        {
            curCoolDownDuration -= coolDownInterval;
            coolTimeImg.fillAmount -= (curCoolDownDuration / coolDownDuration);
            yield return new WaitForSeconds(coolDownInterval);
        }

        isCoolDown = false;

    }
}
