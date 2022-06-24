using UnityEngine;
using System;

public class EnemyModel
{
    private int _health=3;

    public event Action EnemyDied;

    public void DamageEnemy()
    {
        _health--;
        if (_health <= 0)
            EnemyDied?.Invoke();
    }
}
