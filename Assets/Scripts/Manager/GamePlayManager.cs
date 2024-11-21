using System;
using System.Collections.Generic;
using System.Linq;
using HCC.Cards;
using HCC.Generators;
using UnityEngine;

namespace HCC.Manager
{
    public abstract class GamePlayManager : MonoBehaviour
    {
        #region Fields
        
        [Header("Game Board Settings")]
        [SerializeReference] private Generator _generator;
        
        private HashSet<Card> _playerCards = new HashSet<Card>();
        
        private Card _selectedFirstCard;
        
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

        private void GetResults()
        {
            Span<object> results = _generator.Results.ToArray();

            foreach (var result in results)
            {
                Card card = (Card)result;

                card.CardClicked += CheckCards;
                
                _playerCards.Add(card);
            }
            
            Debug.Log(_playerCards.Count);
        }

        private void CheckCards(Card card)
        {
            if (_selectedFirstCard == null)
            {
                _selectedFirstCard = card;
                
                return;
            }
            
            bool areMatches = _selectedFirstCard.CardMatch(card.CardType);

            if (areMatches)
            {
                card.Disable();
                _selectedFirstCard.Disable();
                _selectedFirstCard = null;
                
                Debug.Log("Matched");
                
                return;

            }
            
            _selectedFirstCard.RestoreFlipper();
            card.RestoreFlipper();
            _selectedFirstCard = null;
        }
        #endregion
    }


}