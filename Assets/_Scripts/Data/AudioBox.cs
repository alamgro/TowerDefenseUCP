using UnityEngine;
using System;

[CreateAssetMenu(fileName = "AudioBox", menuName = "ScriptableObjects/Create Audio Box")]

public class AudioBox : ScriptableObject
{
    [Serializable]
    public struct AudioParameters
    {
        public string AudioName;
        public float Volume;
        public float Pitch;
        public float StartDelay;
        public bool Loop;
        public AudioClip[] AudioClips;
    }

    public AudioParameters[] Audios;
}
