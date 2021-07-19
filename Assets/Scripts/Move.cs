using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float _speed; // �������� ���������.
    public float _runSpeed = 8.0f; // �������� ����.
    public float _walkSpeed = 4.0f; // �������� ������.
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
            _speed = _walkSpeed;
            _moveDir *= _speed;            
        }

        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
        {
            _moveDir.y = _jumpSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded && Energy.energyLenghth > 0)
        {
            _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveDir = transform.TransformDirection(_moveDir);
            _speed = _runSpeed;
            _moveDir *= _speed;            

            if (Energy.energyLenghth > 0)
                Energy.energyLenghth -= 25.0f * Time.deltaTime;
            else
                Energy.energyLenghth = 0;
        }

        if (_speed == _walkSpeed && Energy.energyLenghth < 200)
        {
            Energy.energyLenghth += 25.0f * Time.deltaTime;
        }
        
        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);
    }


}
