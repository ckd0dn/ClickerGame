using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float gold;
    public float damage;

    private void Awake()
    {
        GameManager.Instance.Player = this;
    }

}
