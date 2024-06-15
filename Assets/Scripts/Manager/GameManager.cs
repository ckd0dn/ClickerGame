using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{
    public Player _player;
    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    public Monster _monster;
    public Monster Monster
    {
        get { return _monster; }
        set { _monster = value; }
    }

    [SerializeField] private GameObject[] monsterList;

    private int currentMonsterIdx = 0;
    private float monsterXPosition = 2.7f;
    private float monsterYPosition = -1.5f;

    public int stageIdx = 1;
    public float stagePower = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        SettingMonster();
        SettingUI();
    }

    private void SettingUI()
    {
        UIManager.Instance.stageUI.UpdateUI();
        UIManager.Instance.enforceUI.UpdateUI();
    }

    private void SettingMonster()
    {
        GameObject newMonster = Instantiate(monsterList[currentMonsterIdx], new Vector3(monsterXPosition, monsterYPosition, 0f), Quaternion.identity);
        Monster = newMonster.GetComponent<Monster>();
        Monster.SetMonsterData();
    }

    public void NextMonster()
    {
        currentMonsterIdx++;
        
        if( currentMonsterIdx >= monsterList.Length ) 
        {
            // 몬스터 첫번째 부터 + 다음 스테이지
            currentMonsterIdx = 0;
            NextStage();
        }

        SettingMonster();
    }

    public void NextStage()
    {
        stageIdx++;
        UIManager.Instance.stageUI.UpdateUI();
        UIManager.Instance.enforceUI.EnforceAttackDamage++;
    }
}
