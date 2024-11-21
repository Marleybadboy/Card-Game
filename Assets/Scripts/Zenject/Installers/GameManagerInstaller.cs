
using HCC.Manager;
using UnityEngine;
using Zenject;

namespace HCC.Zenject
{
    public class GameManagerInstaller : MonoInstaller
    {
        #region Fields
        [SerializeField] private GamePlayManager _gamePlayManager;
        #endregion

        #region Properties

        #endregion

        #region Functions


        #endregion

        #region Methods

        public override void InstallBindings()
        {
            Container.Bind<GamePlayManager>().FromInstance(_gamePlayManager).AsSingle();
            
        }

        #endregion
    }
}