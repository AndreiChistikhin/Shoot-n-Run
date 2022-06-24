using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private readonly int _mouseSensitivity = 150;
    private float _xRotation;
    private float _yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float _mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float _mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _xRotation -= _mouseY;
        _yRotation += _mouseX;
        _xRotation = Mathf.Clamp(_xRotation, -90, 90);
        transform.localEulerAngles=new Vector3(_xRotation, _yRotation, 0);
    }
}
