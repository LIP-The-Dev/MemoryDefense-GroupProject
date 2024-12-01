using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : VirenBehaviour
{
    void Start()
    {
        base.Start();
        
        this.Speed = 3;
        this.Lives = 5;
        this.Damage = 20;
    }

    void Update()
    {
        base.Update();
    }

    public override void ResetLives()
    {
        this.Lives = 5;
    }

    public override void ResetSpeed()
    {
        this.Speed = 3;
    }

    public override void ResetDamage()
    {
        this.Damage = 3;
    }
}