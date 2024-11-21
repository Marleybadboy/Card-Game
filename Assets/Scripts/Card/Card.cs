
using HCC.DataBase;
using HCC.Interfaces;
using HCC.Structs;
using UnityEngine;

namespace HCC.Cards
{
    public class Card : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private CardData _cardData;
        
        [SerializeField] private CardType _cardType;
        private IFlipper _flliperType;
        
        #endregion

        #region Properties

        #endregion

        #region Functions

        private void OnDestroy()
        {
            _cardData.CardButton.onClick.RemoveAllListeners();
        }

        #endregion

        #region Methods

        public bool CardMatch(CardType type)
        {
            return _cardType == type;
        }

        public void Initialize(CardType cardType, IFlipper flipper)
        {
            _cardType = cardType;
            _flliperType = flipper;
            
            AssignFlipper();
            
        }

        public void RestoreFlipper()
        {
            _flliperType.Restore();
        }

        private void AssignFlipper()
        {
            _flliperType.Initialize(_cardData.CardFront, _cardData.CardBack);
            
            _cardData.CardButton.onClick.AddListener(_flliperType.Flip);
        }
        
        #endregion
    }
}