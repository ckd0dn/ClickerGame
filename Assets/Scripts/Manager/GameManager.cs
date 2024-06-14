using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
        SettingMonster();
    }

    private void SettingMonster()
    {
        float xPosition = 2.7f;
        float yPosition = -1.5f;
        GameObject newMonster = Instantiate(monsterList[0], new Vector3(xPosition, yPosition, 0f), Quaternion.identity);
        Monster = newMonster.GetComponent<Monster>();
    }
}
