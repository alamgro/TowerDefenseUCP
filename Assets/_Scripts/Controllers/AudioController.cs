using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioBox _audioBox;
    [SerializeField] private AudioSource[] _audioChannels;

    private void Start()
    {
        PlayAudio("GameMusic");
    }

    public void PlayAudio(string audioName)
    {
        foreach (var channel in _audioChannels)
        {
            //Check if there is a free channel
            if(channel.clip == null)
            {
                //Play
                foreach (var audio in _audioBox.Audios)
                {
                    if (audio.AudioName.Equals(audioName))
                    {
                        channel.clip = audio.AudioClips[0]; //Extract clip from audio box
                        channel.volume = audio.Volume;
                        channel.pitch = audio.Pitch;
                        channel.loop = audio.Loop;
                        channel.PlayDelayed(audio.StartDelay);
                        StartCoroutine(ReleaseAudioChannel(channel));
                        break;
                    }
                }
                break;
            }
        }
    }

    private IEnumerator ReleaseAudioChannel(AudioSource channelToRelease)
    {
        yield return new WaitUntil(() => !channelToRelease.isPlaying);
        channelToRelease.clip = null;
    }
}
