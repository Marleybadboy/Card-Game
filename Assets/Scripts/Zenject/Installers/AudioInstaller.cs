using HCC.Audio;
using HCC.Structs;
using UnityEngine;
using Zenject;

namespace HCC.Zenject
{

    public class AudioInstaller : MonoInstaller
    {
        #region Fields
        
        [SerializeField] private AudioData[] _audioData;
        [SerializeField] private AudioSource _audioSource;
        
        #endregion

        #region Properties

        #endregion

        #region Functions


        #endregion

        #region Methods

        public override void InstallBindings()
        {
            Container.Bind<AudioData[]>().FromInstance(_audioData).AsSingle();


            Container.Bind<AudioSource>().FromInstance(_audioSource).AsSingle();


            Container.Bind<AudioPlayer>().AsSingle();

        }
        #endregion
    }
}