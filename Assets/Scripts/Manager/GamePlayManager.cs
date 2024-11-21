using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using HCC.Audio;
using HCC.Cards;
using HCC.Enums;
using HCC.Generators;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace HCC.Manager
{
    public abstract class GamePlayManager : MonoBehaviour
    {
        #region Fields
        
        [Header("Game Board Settings")]
        [SerializeReference] private Generator _generator;
        
        
        [SerializeReference] private Counter _multiplierCounter;
        [SerializeReference] private Counter _scoreCounter;
        [SerializeReference] private Counter _TurnsCounter;
        
        private HashSet<Card> _playerCards = new HashSet<Card>();
        
        private Card _selectedFirstCard;
        
        [Inject]
        private AudioPlayer _audioPlayer;
        
        #endregion

        #region Properties

        #endregion

        #region Functions

        // Start is called before the first frame update
        public virtual void Start()
        {
            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            _generator.Generate(GetResults);
        }

        #endregion

        #region Methods

        [Button]
        private void check()
        {
            Debug.Log(_audioPlayer != null);
        }

        private void GetResults()
        {
            Span<object> results = _generator.Results.ToArray();

            foreach (var result in results)
            {
                AssignToCard((Card)result);
            }

            _ = WaitToRestore();
            
        }

        private void AssignToCard(Card card)
        {
            card.CardClickedCompleteCallback += CheckCards;
                
            card.CardClicked += () => _audioPlayer.Play(AudioGameType.Flipping);
                
            _playerCards.Add(card);
            
        }

        private void CheckCards(Card card)
        {
            if (_selectedFirstCard == null)
            {
                _selectedFirstCard = card;
                
                return;
            }
            
            bool areMatches = _selectedFirstCard.CardMatch(card.CardType);
            
            _TurnsCounter.ChangeCounter(1);

            if (areMatches)
            {
                _audioPlayer.Play(AudioGameType.Match);

                card.Disable();
                _selectedFirstCard.Disable();
                
                _playerCards.Remove(card);
                _playerCards.Remove(_selectedFirstCard);
                
                _selectedFirstCard = null;
                
                _scoreCounter.ChangeCounter(1 * _multiplierCounter.GetActualPoints());
                _multiplierCounter.ChangeCounter(1);

                if (_playerCards.Count == 0)
                {
                    _audioPlayer.Play(AudioGameType.GameOver);
                }

                return;

            }
            
            _multiplierCounter.ResetCounter();
            
            _selectedFirstCard.RestoreFlipper();
            card.RestoreFlipper();
            _selectedFirstCard = null;
            
            _audioPlayer.Play(AudioGameType.Mismatch);
        }



        private async UniTaskVoid WaitToRestore()
        {
            await UniTask.WaitForSeconds(2f);

            foreach (var card in _playerCards)
            {
                card.RestoreFlipper();
            }

        }
        #endregion
    }


}