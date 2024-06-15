using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Click : MonoBehaviour
{
    private PlayerController playerController;
    private Animator animator;
    private Camera mainCamera;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }
    void Start()
    {
        playerController.OnAttackEvent += Attack;
        playerController.OnClickEvent += DefaultClick;
    }

    private void Attack()
    {
        // ���� �ִϸ��̼� 
        animator.SetTrigger("Attack");

        if(GameManager.Instance.Monster != null && !GameManager.Instance.Monster.isDie)
        {
            // ������ ������ �������ٰ� ���ƿ�
            StartCoroutine(GameManager.Instance.Monster.OnHit());

            // ���Ͱ� ��带 �Ѹ�
            GameManager.Instance.Monster.DropGold(GameManager.Instance.Player.damage);

            // ������ ü���� ����
            GameManager.Instance.Monster.DecreaseHealth(GameManager.Instance.Player.damage);
        }
       
    }

    private void DefaultClick()
    {
        // ���콺 Ŭ�� ��ġ�� ������
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // ���� ��ǥ�� ��ȯ
        Vector3 worldPosition = GetWorldPositionFromScreen(mousePosition);

        UIManager.Instance.clickParticle.EffectPlay(worldPosition);
    }

    private Vector3 GetWorldPositionFromScreen(Vector2 screenPosition)
    {
        // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane));
        return worldPosition;

    }
}
