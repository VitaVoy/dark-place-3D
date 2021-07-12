using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float _speed = 5.0f; // Скорость персонажа.
    public float _jumpSpeed = 8.0f; // Скорость прыжка персонажа.
    public float _gravity = 20.0f; // Переменная гравитации.
    private Vector3 _moveDir = Vector3.zero; // Переменная направления движения персонажа.
    private CharacterController _controller; // Переменная содержащая компонент CharacterController.

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (_controller.isGrounded)
        {
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDir = transform.TransformDirection(_moveDir);
            _moveDir *= _speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
        {
            _moveDir.y = _jumpSpeed;
        }

        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);
    }


}
