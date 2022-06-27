using Cysharp.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyShooting : Shooting
{
    [SerializeField] private Transform _player;

    private void FixedUpdate()
    {
        transform.LookAt(_player);
        if (!_canShoot)
            return;
        Vector3 direction = _player.position - transform.position;
        Ray rayTowardsPlayer = new Ray(transform.position, direction);
        RaycastHit hit;
        Physics.Raycast(rayTowardsPlayer, out hit);
        bool playerHit = hit.collider.TryGetComponent(out PlayerAim player);
        if (!playerHit)
            return;
        Bullet bullet = BulletPool.Get();
        bullet.transform.position = Barrel.position;
        bullet.ShootRaycastBullet(RandomizeEnemyShot(direction));
        _canShoot = false;
        ReloadTime().Forget();
    }

    private Vector3 RandomizeEnemyShot(Vector3 perfectShot)
    {
        float xRandomOffset = Random.Range(-1, 1);
        float yRandomOffset = Random.Range(-1, 1);
        float zRandomOffset = Random.Range(-1, 1);
        Vector3 notPefectShot = perfectShot + new Vector3(xRandomOffset, yRandomOffset, zRandomOffset);
        return notPefectShot;
    }
}