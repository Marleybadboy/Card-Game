
using HCC.Audio;
using HCC.DataBase;
using HCC.Enums;
using HCC.Generators;
using UnityEngine;
using Zenject;

namespace HCC.Manager
{
    public abstract class GamePlayManager : MonoBehaviour
    {
        #region Fields
        
        [Header("Game Board Settings")]
        [SerializeReference] private Generator _generator;
        [SerializeField] private GamePlaySettings _settings;
        
        
        [Inject(Id = "Multiplier")]
        private Counter _multiplierCounter;

        [Inject(Id = "Score")]
        private Counter _scoreCounter;

        [Inject(Id = "Turns")]
        private Counter _turnsCounter;

        [Inject]
        private AudioPlayer _audioPlayer;
        
        #endregion

        #region Properties
        protected AudioPlayer AudioPlayer => _audioPlayer;
        protected Generator Generator => _generator;
        
        #endregion
        
        #region Indexer

        protected Counter this[SaveDataNames names]
        {
            get
            {
                switch (names)
                {
                    case SaveDataNames.Multiplier:
                        return _multiplierCounter;
                    case SaveDataNames.Points:
                        return _scoreCounter;
                    case SaveDataNames.Turns:
                        return _turnsCounter;
                    
                    default: return _scoreCounter;
                }
            }
        }
        
        #endregion

        #region Functions
        
        public virtual void Start()
        {
            CreateGameBoard();
        }

        protected virtual void CreateGameBoard()
        {
            _generator.Generate(_settings,GetResults);

            var data = _settings.SettingData;

            _multiplierCounter.ChangeCounter(data[SaveDataNames.Multiplier]);
            _scoreCounter.ChangeCounter(data[SaveDataNames.Points]);
            _turnsCounter.ChangeCounter(data[SaveDataNames.Turns]);
        }

        #endregion

        #region Methods

        protected abstract void GetResults();
        protected abstract void Win();

        #endregion

    }


}