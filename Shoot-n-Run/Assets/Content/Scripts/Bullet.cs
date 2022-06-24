using System;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private GameObject _bulletParticles;

    private Camera _camera;
    private Vector3 _shootingDirection;
    private Action<Bullet> _destroyBulletAction;

    private void Awake()
    {
        _camera = Camera.main;
    }

    public void InitShooting(Action<Bullet> destroyBulletAction)
    {
        _destroyBulletAction = destroyBulletAction;
    }

    public void ShootBulletWithoutRaycast()
    {
        _rb.AddForce(_camera.transform.forward, ForceMode.Impulse);
        StartCoroutine(DestroyBulletTimer());
    }

    public void ShootRaycastBullet(Vector3 direction)
    {
        _shootingDirection = direction;
        _rb.AddForceAtPosition(direction.normalized, transform.position, ForceMode.Impulse);
        StartCoroutine(DestroyBulletTimer());
    }

    private IEnumerator DestroyBulletTimer()
    {
        yield return new WaitForSeconds(3);
        if (gameObject.activeSelf)
            _destroyBulletAction(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
            return;
        if (other.TryGetComponent(out PlayerShooting player))
        {
            player.ThrowBack(_shootingDirection);
            StopCoroutine(DestroyBulletTimer());
            _destroyBulletAction(this);
            return;
        }

        GameObject partice=Instantiate(_bulletParticles, transform.position, 
            Quaternion.LookRotation(-_shootingDirection));
        Destroy(partice, 2);
        if(other.TryGetComponent(out EnemyView enemy))
        {
            enemy.DamageEnemy();
            Debug.Log("Enemy Shot");
        }
        StopCoroutine(DestroyBulletTimer());
        _destroyBulletAction(this);
    }
}
