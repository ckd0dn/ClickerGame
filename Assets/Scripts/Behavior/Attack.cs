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
        // ���� �ִϸ��̼� 
        animator.SetTrigger("Attack");

        if (GameManager.Instance.Monster != null && !GameManager.Instance.Monster.isDie)
        {
            // ������ ������ �������ٰ� ���ƿ�
            StartCoroutine(GameManager.Instance.Monster.OnHit());

            // ���Ͱ� ��带 �Ѹ�
            GameManager.Instance.Monster.DropGold(GameManager.Instance.Player.damage);

            // ������ ü���� ����
            GameManager.Instance.Monster.DecreaseHealth(GameManager.Instance.Player.damage);
        }

    }
}
