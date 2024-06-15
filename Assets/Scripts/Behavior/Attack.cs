using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void AttackMonster()
    {
        // 공격 애니메이션 
        animator.SetTrigger("Attack");

        if (GameManager.Instance.Monster != null && !GameManager.Instance.Monster.isDie)
        {
            // 몬스터의 색상이 빨개졌다가 돌아옴
            StartCoroutine(GameManager.Instance.Monster.OnHit());

            // 몬스터가 골드를 뿌림
            GameManager.Instance.Monster.DropGold(GameManager.Instance.Player.damage);

            // 몬스터의 체력이 감소
            GameManager.Instance.Monster.DecreaseHealth(GameManager.Instance.Player.damage);
        }

    }
}
