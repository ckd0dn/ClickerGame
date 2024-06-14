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

    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
