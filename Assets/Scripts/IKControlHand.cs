
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControlHand : MonoBehaviour
{
    [SerializeField]
    private bool _isActive;

    [SerializeField]
    private Transform _pointHandObject;

    [SerializeField]
    private Transform _pointHandObjectL;

    [SerializeField]
    private float _valueWeight;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (_isActive)
        {
            
            ChangeWeightRightHand(_valueWeight);

            _animator.SetIKPosition(AvatarIKGoal.RightHand, _pointHandObject.position);
            _animator.SetIKRotation(AvatarIKGoal.RightHand, _pointHandObject.rotation);

            ChangeWeightLeftHand(_valueWeight);

            _animator.SetIKPosition(AvatarIKGoal.LeftHand, _pointHandObjectL.position);
            _animator.SetIKRotation(AvatarIKGoal.LeftHand, _pointHandObjectL.rotation);
            
        }
        else
        {
            ChangeWeightRightHand(0);

            ChangeWeightLeftHand(0);
        }        
    }

    private void ChangeWeightRightHand(float value)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.RightHand,value);
        _animator.SetIKRotationWeight(AvatarIKGoal.RightHand, value);
    }

    private void ChangeWeightLeftHand(float value)
    {
        _animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,value);
        _animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, value);
    }
}
