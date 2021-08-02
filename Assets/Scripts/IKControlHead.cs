using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class IKControlHead : MonoBehaviour
{
    [SerializeField] 
    private bool _isActive;

    [SerializeField]
    private Transform _lookObject;


    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {              
        if (_isActive)
        {
            
            _animator.SetLookAtWeight(1);
            _animator.SetLookAtPosition(_lookObject.position);
            
        }
        else 
        {
            _animator.SetLookAtWeight(0);
        }
        
    }
}
