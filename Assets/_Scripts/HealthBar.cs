using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Slider _sliderHealth;
    [SerializeField] private Health _health;

    private Transform _lookAtCamera;

    private void Awake()
    {
        _lookAtCamera = Camera.main.transform;
        _canvas.worldCamera = Camera.main;
        _sliderHealth.maxValue = _health.CurrentHealth;
        _sliderHealth.value = _sliderHealth.maxValue; //
    }

    private void Update()
    {
        transform.LookAt(_lookAtCamera);
    }

    public void UpdateSliderValue(int newValue)
    {
        _sliderHealth.value = newValue;
    }
}
