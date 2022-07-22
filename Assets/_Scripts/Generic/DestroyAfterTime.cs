using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    private void Start()
    {
        Destroy(gameObject, _destroyDelay);
    }

}
