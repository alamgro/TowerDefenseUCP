using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] private GameObject _prefabObjectToCreate;
    [Range(0f, 1f)]
    [SerializeField] private float _chanceToCreateObject = 1f;

    public void Spawn()
    {
        if(Random.value < _chanceToCreateObject)
        {
            Instantiate(_prefabObjectToCreate, transform.position, Quaternion.identity);
        }
    }
}
