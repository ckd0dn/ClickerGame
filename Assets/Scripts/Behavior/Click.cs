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
        // 공격 애니메이션 
        animator.SetTrigger("Attack");

        if(GameManager.Instance.Monster != null && !GameManager.Instance.Monster.isDie)
        {
            // 몬스터의 색상이 빨개졌다가 돌아옴
            StartCoroutine(GameManager.Instance.Monster.OnHit());

            // 몬스터가 골드를 뿌림
            GameManager.Instance.Monster.DropGold(GameManager.Instance.Player.damage);

            // 몬스터의 체력이 감소
            GameManager.Instance.Monster.DecreaseHealth(GameManager.Instance.Player.damage);
        }
       
    }

    private void DefaultClick()
    {
        // 마우스 클릭 위치를 가져옴
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        // 월드 좌표로 변환
        Vector3 worldPosition = GetWorldPositionFromScreen(mousePosition);

        UIManager.Instance.clickParticle.EffectPlay(worldPosition);
    }

    private Vector3 GetWorldPositionFromScreen(Vector2 screenPosition)
    {
        // 스크린 좌표를 월드 좌표로 변환
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, mainCamera.nearClipPlane));
        return worldPosition;

    }
}
