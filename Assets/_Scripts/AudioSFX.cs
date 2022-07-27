using System;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "AudioSFX", menuName = "ScriptableObjects/Create Audio SFX")]
public class AudioSFX : ScriptableObject
{

    [Serializable]
    public struct AudioParametersStruct
    {
        public string AudioName;
        public float Volume;
        public float Pitch;
        public float StartDelay;
        public bool Loop;
        public AudioClip[] AudioClips;
    }

    private AudioSource _audioSource;
    private GameObject _sourceGO;
    public AudioParametersStruct AudioParameters;

    public void PlayAudio()
    {
        if(_sourceGO == null)
        {
            _sourceGO = new GameObject($"AudioPlayer | {AudioParameters.AudioName}");
            _sourceGO.AddComponent<AudioSource>();
            _audioSource = _sourceGO.GetComponent<AudioSource>();
        }
        
        _audioSource.clip = AudioParameters.AudioClips[Random.Range(0, AudioParameters.AudioClips.Length)];
        _audioSource.volume = AudioParameters.Volume;
        _audioSource.pitch = AudioParameters.Pitch;
        _audioSource.loop = AudioParameters.Loop;
        _audioSource.PlayDelayed(AudioParameters.StartDelay);
    }
}
