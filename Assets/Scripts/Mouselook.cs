using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera - Control/Mouselook")]
public class Mouselook : MonoBehaviour
{
    public enum RotationAxes //���������� ������ ��� ��������� ���� ��������.
    {
        XandY = 0,
        X = 1,
        Y = 2
    }

    public RotationAxes _axes = RotationAxes.XandY; // ������������� ��� �������� �� ���������.
    public float _rotationSpeedHor = 5.0f; // �������� ������� ���� ��� ������� �� �����������
    public float _rotationSpeedVer = 5.0f; // � ���������.

    public float minimumX = 360.0f; //���������� ������������ � ������������� ���� �������� �� ��� �.
    public float maximumX = -360.0f;

    public float minimumY = 360.0f; //���������� ������������ � ������������� ���� �������� �� ��� Y.
    public float maximumY = -360.0f;

    public float _rotationX = 0; // ���������� ������������ ������� ���� ��������.
    public float _rotationY = 0;

    Quaternion _originalRotation; // ���������� ���������� ��� �������� Quaternion.
       

    private void Start()
    {
        if (GetComponent<Rigidbody>())
        {
            GetComponent<Rigidbody>().freezeRotation = true;           
        }
        _originalRotation = transform.localRotation;
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360.0f) angle += 360.0f;
        if (angle > 360.0f) angle -= 360.0f;
        return Mathf.Clamp(angle, min, max);
    }
    private void Update()
    {
        // �������� ��� ��������
        if (_axes == RotationAxes.XandY)
        {
            _rotationX += Input.GetAxis("Mouse X") * _rotationSpeedHor;
            _rotationY += Input.GetAxis("Mouse Y") * _rotationSpeedVer;

            _rotationX = ClampAngle(_rotationX, minimumX, maximumX);
            _rotationY = ClampAngle(_rotationY, minimumY, maximumY);

            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
            transform.localRotation = _originalRotation * xQuaternion * yQuaternion;
        }

        else if (_axes == RotationAxes.X)
        {
            _rotationX += Input.GetAxis("Mouse X") * _rotationSpeedHor;
            _rotationX = ClampAngle(_rotationX, minimumX, maximumX);
            Quaternion xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);
            transform.localRotation = _originalRotation * xQuaternion;
        }

        else if (_axes == RotationAxes.Y)
        {
            _rotationY += Input.GetAxis("Mouse Y") * _rotationSpeedVer;
            _rotationY = ClampAngle(_rotationY, minimumY, maximumY);
            Quaternion yQuaternion = Quaternion.AngleAxis(_rotationY, -Vector3.right);
            transform.localRotation = _originalRotation * yQuaternion;
        }
    }
}
