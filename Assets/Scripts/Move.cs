using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float _speed = 5.0f; // �������� ���������.
    public float _jumpSpeed = 8.0f; // �������� ������ ���������.
    public float _gravity = 20.0f; // ���������� ����������.
    private Vector3 _moveDir = Vector3.zero; // ���������� ����������� �������� ���������.
    private CharacterController _controller; // ���������� ���������� ��������� CharacterController.

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
