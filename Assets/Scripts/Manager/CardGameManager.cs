using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using HCC.Cards;
using HCC.Enums;
using HCC.Interfaces;

namespace HCC.Manager
{
    public class CardGameManager : GamePlayManager, ISave
    {
        #region Fields

        private HashSet<Card> _playerCards = new HashSet<Card>();
        private Card _selectedFirstCard;
        
        #endregion

        #region Methods
        protected override void GetResults()
        {
                Span<object> results = Generator.Results.ToArray();

                foreach (var result in results)
                {
                    AssignToCard((Card)result);
                }

                _ = WaitToRestore();
        }

        protected override void Win()
        {
            if (_playerCards.Count == 0)
            {
                AudioPlayer.Play(AudioGameType.GameOver);
            }
        }

        private void AssignToCard(Card card)
        {
            card.CardClickedCompleteCallback += CheckCards;
                
            card.CardClicked += () => AudioPlayer.Play(AudioGameType.Flipping);
                
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
            
            this[SaveDataNames.Turns].ChangeCounter(1);

            if (areMatches)
            {
                Match(card);
                
                return;
            }
            
            Reset(card);
        }

        private void Match(Card card)
        {
            AudioPlayer.Play(AudioGameType.Match);

            card.Disable();
            _selectedFirstCard.Disable();
                
            _playerCards.Remove(card);
            _playerCards.Remove(_selectedFirstCard);
                
            _selectedFirstCard = null;
            
            CheckScores();
            Win();
        }

        private void CheckScores()
        {
            var multiplier = this[SaveDataNames.Multiplier].GetActualPoints() > 0 ? this[SaveDataNames.Multiplier].GetActualPoints() : 1;
            
            this[SaveDataNames.Points].ChangeCounter(1 * multiplier);
            this[SaveDataNames.Multiplier].ChangeCounter(1);
            
        }

        private void Reset(Card card)
        {
            this[SaveDataNames.Multiplier].ResetCounter();
            
            _selectedFirstCard.RestoreFlipper();
            card.RestoreFlipper();
            _selectedFirstCard = null;
            
            AudioPlayer.Play(AudioGameType.Mismatch);
        }


        private async UniTaskVoid WaitToRestore()
        {
            await UniTask.WaitForSeconds(2f);

            foreach (var card in _playerCards)
            {
                card.RestoreFlipper();
            }

        }

        public int GetSaveValue()
        {
            return _playerCards.Count;
        }

        #endregion

      
    }
}