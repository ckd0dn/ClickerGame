using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gold;
    public float damage;
    public Attack attack;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        attack = GetComponent<Attack>();
    }

}
