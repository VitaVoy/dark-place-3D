using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera - Control/Mouselook")]
public class Mouselook : MonoBehaviour
{
    public enum RotationAxes //выпадающий список для настройки осей вращения.
    {
        XandY = 0,
        X = 1,
        Y = 2
    }

    public RotationAxes _axes = RotationAxes.XandY; // устанавливаем ось вращения по умолчанию.
    public float _rotationSpeedHor = 5.0f; // скорость реакции мыши при вращени по горизонтали
    public float _rotationSpeedVer = 5.0f; // и вертикали.

    public float minimumX = 360.0f; //переменные минимального и максимального угла вращения по оси Х.
    public float maximumX = -360.0f;

    public float minimumY = 360.0f; //переменные минимального и максимального угла вращения по оси Y.
    public float maximumY = -360.0f;

    public float _rotationX = 0; // переменные определяющие текущий угол вращения.
    public float _rotationY = 0;

    Quaternion _originalRotation; // переменная содержащая тип вращения Quaternion.
       

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
        // Проверим ось движения
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
