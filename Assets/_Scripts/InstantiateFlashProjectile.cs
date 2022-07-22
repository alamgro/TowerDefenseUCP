using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFlashProjectile : MonoBehaviour
{
    [SerializeField] private GameObject _prefabFlashProjectile;

    public void Spawn()
    {
        Instantiate(_prefabFlashProjectile, transform.position, Quaternion.identity);
    }
}
