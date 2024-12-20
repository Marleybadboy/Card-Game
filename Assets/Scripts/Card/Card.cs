
using System;
using DG.Tweening;
using HCC.Addressables;
using HCC.DataBase;
using HCC.Interfaces;
using HCC.Structs;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HCC.Cards
{
    public class Card : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private CardData _cardData;
        
        private CardType _cardType;
        private IFlipper _flliperType;
        
        private Action<Card> _cardActionCallback;
        private Action _cardClicked;
        
        #endregion

        #region Properties
        public event Action<Card> CardClickedCompleteCallback
        {
            add => _cardActionCallback += value;
            remove => _cardActionCallback -= value;
        }
        
        public event Action CardClicked
        {
            add => _cardClicked += value;
            remove => _cardClicked -= value;
        }
        
        private bool ActiveSides { set { _cardData.CardFront.SetActive(value); _cardData.CardBack.SetActive(value); } }
        
        public CardType CardType => _cardType;
        
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

        public void Disable()
        {
            _cardData.CardButton.interactable = false;
            ActiveSides = false;
            
            Destroy(_cardData.CardBack);
            Destroy(_cardData.CardFront);
            
            
        }

        public void Initialize(CardType cardType, IFlipper flipper)
        {
            _cardType = cardType;
            _flliperType = flipper;
            
            LoadIcon();
            AssignFlipper();
            
        }

        private void LoadIcon()
        {
            AssetLoader.LoadAddressable<AssetReferenceSprite,Sprite>(_cardType.CardTypeIcon, (sprite) =>
            {
                _cardData.CardIcon.sprite = sprite;
            });
        }

        public void RestoreFlipper()
        {
            _flliperType.Restore();
        }

        private void AssignFlipper()
        {
            _flliperType.Initialize(_cardData.CardFront, _cardData.CardBack);
            
            _cardData.CardButton.onClick.AddListener(() =>
            {
                _flliperType.Flip(() => { _cardActionCallback?.Invoke(this); });
                
                _cardClicked?.Invoke();

            });
        }
        
        #endregion
    }
}