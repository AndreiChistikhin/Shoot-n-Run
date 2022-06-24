using UnityEngine;

public class SetUp : MonoBehaviour
{
    [SerializeField] private EnemyView[] _enemies;
    private EnemyPresenter[] _presenters;

    private void Awake()
    {
        _presenters = new EnemyPresenter[_enemies.Length];
        for(int i=0;i<_enemies.Length;i++)
        {
            _presenters[i] = new EnemyPresenter(_enemies[i], new EnemyModel());
        }
    }

    private void OnEnable()
    {
        foreach(var enemyPresenter in _presenters)
        {
            enemyPresenter.Enable();
        }
    }

    private void OnDisable()
    {
        foreach (var enemyPresenter in _presenters)
        {
            enemyPresenter.Disable();
        }
    }
}
