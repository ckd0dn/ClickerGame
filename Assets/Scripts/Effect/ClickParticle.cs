using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;

    private void Awake()
    {
       UIManager.Instance.clickParticle = this;
    }


    public void EffectPlay(Vector3 mousePostion)
    {
        particleSystem.transform.position = mousePostion;
        particleSystem.Play();
    }
}
