using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly int _speed = 5;

    private void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (move == Vector3.zero)
            return;
        move = transform.TransformDirection(move);
        transform.position += move * (_speed * Time.deltaTime);
    }
}