using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action OnAttackEvent;
    public event Action OnClickEvent;

    protected void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    protected void CallClickEvent()
    {
        OnClickEvent?.Invoke();
    }
}

