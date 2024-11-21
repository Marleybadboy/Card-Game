using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace HCC.Structs
{
    [Serializable]
    public struct CardData
    {
        #region Fields
        
        [BoxGroup("Card UI Data")]
        [SerializeField] private Button _cardButton;
        
        [BoxGroup("Card UI Data")]
        [SerializeField] private GameObject _cardBack;
        
        [BoxGroup("Card UI Data")]
        [SerializeField] private GameObject _cardFront;
        
        [BoxGroup("Card UI Data")]
        [SerializeField] private Image _cardIcon;

        #endregion

        #region Properties
        
        public Button CardButton => _cardButton;
        public GameObject CardBack => _cardBack;
        public GameObject CardFront => _cardFront;
        public Image CardIcon => _cardIcon;
        
        #endregion

        #region Functions

        #endregion

        #region Methods

        #endregion
    }
}