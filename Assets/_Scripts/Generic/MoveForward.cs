using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;

    void Update()
    {
        transform.position += transform.forward * _movementSpeed * Time.deltaTime;
    }

}
