using System.Collections;
using System.Numerics;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            if (value <= 0)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth = value;
            }
        }
    }


    [SerializeField] private float maxGold;
    [SerializeField] private BigInteger currentGold;
    public string name;
    public bool isDie = false;

    public GameObject Idle;
    public GameObject Hit;



    private void Awake()
    {
        // GameManager.Instance.Monster = this;
    }

    private void Start()
    {
        SetMonsterData();

        UIManager.Instance.monsterHpUI.UpdateUI();
    }

    public void SetMonsterData()
    {
        int stageIdx = GameManager.Instance.stageIdx;
        float stagePower = GameManager.Instance.stagePower;

        CurrentHealth = maxHealth + (maxHealth * (stageIdx-1) * stagePower);
        currentGold = (long)(maxGold + (maxGold * (stageIdx - 1) * stagePower));
    }

    public void DecreaseHealth(float damage)
    {
        CurrentHealth -= damage;

        UIManager.Instance.monsterHpUI.UpdateUI();

        // ����
        
        if (CurrentHealth <= 0)
        {
            Die();
        }

    }

    public void DropGold(float damage)
    {
        // �������� �ִ� ü���� ���� ��ŭ�� ������ ��带 ���
        BigInteger dropGold = (long)Mathf.Floor((maxGold * (damage / maxHealth)));
        currentGold -= dropGold;
        // �÷��̾� ��� �߰�
        GameManager.Instance.Player.gold += dropGold;
        // Gold UI ������Ʈ
        UIManager.Instance.goldUI.UpdateUI();
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
        isDie = true;
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
        // ���� �ı�
        Destroy(gameObject);
        // ������ ���� ���� ��ȯ
        GameManager.Instance.NextMonster();
    }

    public float GetCurrentHp()
    {
        return CurrentHealth;
    }

    public float GetCurrentHpPercentage()
    {
        return CurrentHealth / maxHealth;
    }




}
