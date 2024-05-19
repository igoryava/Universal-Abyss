using System;
using UnityEngine;

public class PatrollerEnemyHealth : Health
{
    [SerializeField] private GameObject _enemyParent;

    public override void Death()
    {
        base.Death();
    }

    public void DeathAnimationEnd()
    {
        Destroy(_enemyParent);
    }
}
