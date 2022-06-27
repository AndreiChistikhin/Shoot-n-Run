using UnityEngine.Pool;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _barrel;
    [SerializeField] private Bullet _bulletPrefab;

    private readonly int _reloadTimeAmount = 500;
    protected bool _canShoot = true;

    public Transform Barrel => _barrel;
    public ObjectPool<Bullet> BulletPool { get; private set; }

    private void Start()
    {
        BulletPool = new ObjectPool<Bullet>(CreateBullet, GetBullet, ReleaseBullet);
    }

    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.InitShooting(DestroyBullet);
        return bullet;
    }

    private void GetBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(true);
    }

    private void ReleaseBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void DestroyBullet(Bullet bullet)
    {
        Rigidbody bulletRB = bullet.gameObject.GetComponent<Rigidbody>();
        bulletRB.velocity = Vector3.zero;
        bulletRB.angularVelocity = Vector3.zero;
        BulletPool.Release(bullet);
    }

    public async UniTask ReloadTime()
    {
        await UniTask.Delay(_reloadTimeAmount);
        _canShoot = true;
    }
}