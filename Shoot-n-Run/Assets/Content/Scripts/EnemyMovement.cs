using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Vector3 _movementDirection;

    private void Start()
    {
        _movementDirection = Vector3.forward;
    }

    private void Update()
    {
        if (_speed == 0)
            return;
        transform.localPosition += _movementDirection * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet)|| other.TryGetComponent(out PlayerMovement player))
            return;
        _movementDirection *= -1;
    }
}
