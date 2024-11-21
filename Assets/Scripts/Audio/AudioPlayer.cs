using HCC.Addressables;
using HCC.Enums;
using HCC.Structs;
using UnityEngine;

namespace HCC.Audio

{
    public class AudioPlayer
    {
        #region Fields
        
        private AudioData[] _audioData;
        private AudioSource _audioSource;
        
        #endregion

        #region Properties

        #endregion

        #region Methods

        public AudioPlayer(AudioData[] audioData, AudioSource audioSource)
        {
            _audioData = audioData;
            _audioSource = audioSource;
            
            Debug.Log(_audioData.Length);
            Debug.Log(_audioSource != null);
        }

        public void Play(AudioGameType audioType)
        {
            if(!GetAudioData(audioType, out AudioData audioData)) return;

            AssetLoader.LoadAddressable<AssetReferenceAudioClip, AudioClip>(audioData.AudioClipRef, PlayAudioSource);
            
        }

        private void PlayAudioSource(AudioClip clip)
        {
            _audioSource.clip = clip;
            _audioSource.Play();
        }

        private bool GetAudioData(AudioGameType audioType, out AudioData audioData)
        {
            for (int i = 0; i < _audioData.Length; i++)
            {
                if (_audioData[i].AudioType == audioType)
                {
                    audioData = _audioData[i];
                    return true;
                }
            }
            
            audioData = default(AudioData);
            return false;
        }

        #endregion
    }
}