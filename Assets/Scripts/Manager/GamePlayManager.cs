using HCC.Addressables;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HCC.Manager
{
    public abstract class GamePlayManager : MonoBehaviour
    {
        #region Fields
        [Header("Game Board Size")]
        [SerializeField] private int _height;
        [SerializeField] private int _width;
        [SerializeField] private Transform _boardContentParent;
        
        [SerializeField] private AssetReferenceGameObject _linePrefab;
        [SerializeField] private AssetReferenceGameObject _cardPrefab;
        
        #endregion

        #region Properties

        #endregion

        #region Functions

        // Start is called before the first frame update
        public virtual void Start()
        {
            CreateGameBoard();
        }

        #endregion

        #region Methods

        protected virtual void CreateGameBoard()
        {

            for (int i = 0; i < _height; i++)
            {
                
                AssetLoader.LoadAddresablePrefab(_linePrefab, (lineObject) =>
                {
                    var prefab = lineObject as GameObject;
                    
                    if (prefab == null) return;

                    prefab.transform.SetParent(_boardContentParent);
                    
                    CreateCardInLine(prefab.transform);
                    
                });
                
            }
            
            
        }

        private void CreateCardInLine(Transform cardParent)
        {
            for (int i = 0; i < _width; i++)
            {
                AssetLoader.LoadAddresablePrefab(_cardPrefab, (createdObj) =>
                {
                    var prefab = createdObj as GameObject;

                    if (prefab == null) return;
                    
                    prefab.transform.SetParent(cardParent);
                    
                });
                
            }
            
        }
        #endregion
    }
}