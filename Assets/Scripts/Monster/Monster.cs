using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Monster : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private float maxGold;
    [SerializeField] private float currentGold;
    private Animator animator;

    public GameObject Idle;
    public GameObject Hit;

    private Coroutine hitCoroutine;
    private Coroutine dieCoroutine;


    private void Awake()
    {
        GameManager.Instance.Monster = this;
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        currentGold = maxGold;

        UIManager.Instance.monsterHpUI.UpdateUI();
    }

    public void DecreaseHealth(float damage)
    {
        currentHealth -= damage;

        UIManager.Instance.monsterHpUI.UpdateUI();

        // 죽음
        
        if (currentHealth <= 0)
        {
            Die();
        }

    }

    public void DropGold(float damage)
    {
        // 데미지에 최대 체력을 나눈 만큼의 비율로 골드를 드랍
        float dropGold = Mathf.Floor((maxGold * (damage / maxHealth)));
        currentGold -= dropGold;
        // 플레이어 골드 추가
        GameManager.Instance.Player.gold += dropGold;
        // Gold UI 업데이트
        UIManager.Instance.goldUI.UpdateUI();
    }

    public void ChangeMonster()
    {

    }

    public IEnumerator OnHit()
    {
        Idle.SetActive(false);
        Hit.SetActive(true);

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f);

        Idle.SetActive(true);
        Hit.SetActive(false);

        yield return null;

    }

    public void ReSetColor()
    {
        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.color = Color.white;
        }
    }

    private void Die()
    {
        StartCoroutine(DieCoroutine());
    }

    private IEnumerator DieCoroutine()
    {
        float colorA = 1f;
        float decreaseA = 0.05f;

        while (colorA > 0)
        {
            colorA -= decreaseA;
            foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
            {
                Color color = renderer.color;
                color.a = colorA;
                renderer.color = color;
            }
            yield return new WaitForSeconds(decreaseA);
        }   

        gameObject.SetActive(false);
    }

    public float GetCurrentHp()
    {
        return currentHealth;
    }

    public float GetCurrentHpPercentage()
    {
        return currentHealth / maxHealth;
    }




}
