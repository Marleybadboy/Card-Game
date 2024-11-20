using System.Collections.Generic;
using HCC.Addressables;
using HCC.DataBase;
using HCC.Interfaces;
using HCC.Structs;
using Sirenix.OdinInspector;
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
        
        [SerializeField] private CardType[] _cardTypes;
        
        private HashSet<IFlipper> _flippers = new HashSet<IFlipper>();
        
        public List<CardType> _typesEx = new List<CardType>();
        
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

        [Button("GenerATE")]
        private void GenerateGameBoard()
        {
           var shuffle =  new ShuffleDeck<CardType>(_width * _height, _cardTypes);
            
           shuffle.Execute();
           
           _typesEx = shuffle.Result;
            
        }


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

                    var flipper = prefab.GetComponent<IFlipper>() ?? prefab.AddComponent<CardFlipper>();
                    
                    _flippers.Add(flipper);

                });
                
            }
            
        }

        private void ReMapCardDeck()
        {

            
        }
        #endregion
    }


}