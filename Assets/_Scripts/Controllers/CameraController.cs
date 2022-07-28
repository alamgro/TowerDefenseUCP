using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    
    private CinemachineBasicMultiChannelPerlin _cinemachineNoise;
    private float _noiseAmplitud;
    private float _noiseFrequency;

    private void Awake()
    {
        _cinemachineNoise = _virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        _cinemachineNoise.m_AmplitudeGain = 0f;
        _cinemachineNoise.m_FrequencyGain = 0f;
    }

    public void ShakeCamera(CameraShakeValues cameraShakeValues)
    {
        _noiseAmplitud = cameraShakeValues.NoiseAmplitud;
        _noiseFrequency = cameraShakeValues.NoiseFrequency;
    }

    private void Update()
    {
        if(_noiseAmplitud > 0)
        {
            _cinemachineNoise.m_AmplitudeGain = _noiseAmplitud;
            _noiseAmplitud -= Time.deltaTime;
        }
        else
        {
            _cinemachineNoise.m_AmplitudeGain = 0f;
        }

        if (_noiseFrequency > 0)
        {
            _cinemachineNoise.m_FrequencyGain = _noiseFrequency;
            _noiseFrequency -= Time.deltaTime;
        }
        else
        {
            _cinemachineNoise.m_FrequencyGain = 0f;

        }
    }
}
