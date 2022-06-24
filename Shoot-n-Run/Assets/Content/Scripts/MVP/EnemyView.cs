using System;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public static event Action<EnemyView> EnemyDied;
    public event Action EnemyHit;

    public void DamageEnemy()
    {
        EnemyHit?.Invoke();
    }

    public void DestroyEnemy()
    {
        EnemyDied?.Invoke(this);
        Destroy(gameObject);
    }
}
