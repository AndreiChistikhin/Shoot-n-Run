using Cysharp.Threading.Tasks;
using UnityEngine;
using System;

public class PlayerShooting : Shooting
{
    [SerializeField] private Rigidbody _rb;

    private Camera _camera;
    private Collider _previousRaycastCollider;

    public static event Action<Collider> RaycastColliderChanged;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        if ((hit.collider == null && _previousRaycastCollider != null) ||
            hit.collider != null && !hit.collider.Equals(_previousRaycastCollider))
        {
            RaycastColliderChanged?.Invoke(hit.collider);
            _previousRaycastCollider = hit.collider;
        }

        if (!(Input.GetMouseButtonDown(0) && _canShoot))
            return;
        Shoot(hit);
    }

    private void Shoot(RaycastHit hit)
    {
        Bullet bullet = BulletPool.Get();
        bullet.transform.position = Barrel.position;
        _canShoot = false;
        ReloadTime().Forget();
        Debug.Log("Player Shoot");
        if (hit.collider == null)
        {
            bullet.ShootBulletWithoutRaycast();
            return;
        }

        Vector3 direction = hit.point - transform.position;
        bullet.ShootRaycastBullet(direction);
    }

    public void ThrowBack(Vector3 direction)
    {
        _rb.AddForce(direction, ForceMode.Impulse);
    }
}