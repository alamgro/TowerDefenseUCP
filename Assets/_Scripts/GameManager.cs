using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Range(0f, 15f)]
    [SerializeField] private float _gameTimeScale = 1f;

    void Start()
    {
        
    }


    void Update()
    {
        Time.timeScale = _gameTimeScale;
    }
}
