using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public BigInteger gold;
    public float damage;
    public Attack attack;

    private void Awake()
    {
        GameManager.Instance.Player = this;
        attack = GetComponent<Attack>();
    }

}
