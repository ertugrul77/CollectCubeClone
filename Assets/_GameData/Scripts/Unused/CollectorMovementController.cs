using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorMovementController : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float speedMultiplier2;
    
    private Quaternion targetRotation;
    private float _speed;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ApplyRotation();
        ApplyMovementByTranslating();
    }
    
    
    private void ApplyRotation()
    {

            targetRotation = Quaternion.LookRotation(InputManagerOld.Instance.lookForward, Vector3.up);
            transform.rotation= Quaternion.Lerp(transform.rotation, targetRotation, speedMultiplier2 * Time.deltaTime);

    }
    
    private void ApplyMovementByTranslating()
    {
        CalculateSpeed();
        rb.MovePosition(rb.position + InputManagerOld.Instance.lookForward * speedMultiplier * Time.deltaTime);
        //transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void CalculateSpeed()
    {
        var magnitude = InputManagerOld.Instance.magnitude;
        _speed = magnitude * speedMultiplier;
    }
}
