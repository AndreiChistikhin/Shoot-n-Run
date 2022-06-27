public class EnemyPresenter
{
    private EnemyView _view;
    private EnemyModel _model;

    public EnemyPresenter(EnemyView view, EnemyModel model)
    {
        _view = view;
        _model = model;
    }

    public void Enable()
    {
        _view.EnemyHit += _model.DamageEnemy;
        _model.EnemyDied += _view.DestroyEnemy;
    }

    public void Disable()
    {
        _view.EnemyHit -= _model.DamageEnemy;
        _model.EnemyDied -= _view.DestroyEnemy;
    }
}