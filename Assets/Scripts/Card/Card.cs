using HCC.DataBase;
using HCC.Structs;
using UnityEngine;

namespace HCC.Cards
{
    public class Card : MonoBehaviour
    {
        #region Fields
        
        [SerializeField] private CardData _cardData;
        
        private CardType _cardType;
        
        #endregion

        #region Properties

        #endregion

        #region Functions

        // Start is called before the first frame update
        void Start()
        {

        }

        #endregion

        #region Methods

        public void Initialize(CardData cardData)
        {
            
            
        }
        #endregion
    }
}