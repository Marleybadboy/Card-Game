using UnityEngine;
using UnityEngine.AddressableAssets;


namespace HCC.DataBase
{
    [CreateAssetMenu(fileName = "CardType", menuName = "DataBase/CardType")]
    public class CardType : ScriptableObject
    {
        #region Fields
        
        [Header("Card Type")]
        [SerializeField] private string _cardTypeName;
        [SerializeField] private AssetReferenceSprite _cardTypeIcon;

        #endregion

        #region Properties
        
        public string CardTypeName => _cardTypeName;
        public AssetReferenceSprite CardTypeIcon => _cardTypeIcon;

        #endregion

        #region Functions

        #endregion

        #region Methods

        #endregion
    }
}