
using HCC.Manager;
using UnityEngine;
using Zenject;

namespace HCC.Zenject
{
    public class GameManagerInstaller : MonoInstaller
    {
        #region Fields
        
        [SerializeField] private GamePlayManager _gamePlayManager;
        [SerializeField] private Counter _multiplierCounter;
        [SerializeField] private Counter _scoreCounter;
        [SerializeField] private Counter _turnsCounter;
        
        #endregion

        #region Properties

        #endregion

        #region Functions


        #endregion

        #region Methods

        public override void InstallBindings()
        {
            Container.Bind<Counter>().WithId("Multiplier").FromInstance(_multiplierCounter).AsCached();
            Container.Bind<Counter>().WithId("Score").FromInstance(_scoreCounter).AsCached();
            Container.Bind<Counter>().WithId("Turns").FromInstance(_turnsCounter).AsCached();
            
            Container.Bind<GamePlayManager>().FromInstance(_gamePlayManager).AsSingle();
            
        }

        #endregion
    }
}