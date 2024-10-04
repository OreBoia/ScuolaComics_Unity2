using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScale : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float _gravity;

    private CheckGround _checkGround;

    void Awake()
    {
        _checkGround = GetComponent<CheckGround>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        GravityScaleApply();
    }

    private void GravityScaleApply()
    {
        if(!_checkGround.isGrounded)
            _rigidBody.AddForce(Vector3.down * _gravity, ForceMode.Acceleration);
    }
}
