using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _pivotRotationSpeed;
    [SerializeField] private float _offsetY;

    void Update()
    {
        if (_target == null)
            return;

        //Calculate direction
        Vector3 direction = _target.position - transform.position;
        direction.y += _offsetY;

        Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _pivotRotationSpeed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void LoseTarget()
    {
        _target = null;
    }
}
