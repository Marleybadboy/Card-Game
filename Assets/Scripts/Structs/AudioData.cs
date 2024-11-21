
using System;
using HCC.Addressables;
using HCC.Enums;
using UnityEngine;

namespace HCC.Structs
{
    [Serializable]
    public struct AudioData
    {
        #region Fields

        [SerializeField] private AudioGameType _audioType;
        [SerializeField] private AssetReferenceAudioClip _audioClip;

        #endregion

        #region Properties
        
        public AudioGameType AudioType => _audioType;
        public AssetReferenceAudioClip AudioClipRef => _audioClip;

        #endregion
    }
}