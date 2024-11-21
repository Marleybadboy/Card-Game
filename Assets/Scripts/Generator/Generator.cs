using System;
using System.Collections.Generic;
using HCC.Addressables;
using HCC.Cards;
using HCC.DataBase;
using HCC.Structs;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HCC.Generators

{
    [Serializable]
    public abstract class Generator
    {

        #region Properties
        public HashSet<object> Results { get; set; }
        
        #endregion

        #region Methods
        
        public abstract void Generate(Action OnCompleteCallback = null);
        
        #endregion
    }

    public class GameBoardGenerator : Generator
    {
        #region Fields
        
        [BoxGroup("Board Size")]
        [SerializeField] private BoardSize _size;
        
        [BoxGroup("Game Board")]
        [SerializeField] private Transform _boardContentParent;
        [BoxGroup("Game Board")]
        [SerializeField] private AssetReferenceGameObject _linePrefab;
        [BoxGroup("Game Board")]
        [SerializeField] private AssetReferenceGameObject _cardPrefab;
        [BoxGroup("Game Board")]
        [SerializeField] private CardType[] _cardTypes;
        

        private Action _onCompleteCallback;
        
        
        #endregion

        #region Methods

        public override void Generate(Action onCompleteCallback = null)
        {
            Results = new HashSet<object>();
            
            _onCompleteCallback = onCompleteCallback;
            
            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            var shuffle =  new ShuffleDeck<CardType>(_size.Length, _cardTypes);
            
            shuffle.Execute();
            
            var result = shuffle.Result;
            
            for (int i = 0; i < _size.Height; i++)
            {
                var rowIndex = i;
                
                AssetLoader.LoadAddresablePrefab(_linePrefab, (lineObject) =>
                {
                    var prefab = lineObject as GameObject;
                    
                    if (prefab == null) return;

                    prefab.transform.SetParent(_boardContentParent);
                    
                    CreateCardInLine(prefab.transform, rowIndex, result.ToArray());
                    
                });
            }

        }

        private void CreateCardInLine(Transform prefabTransform, int rowIndex, CardType[] cardTypes)
        {
            for (int i = 0; i < _size.Width; i++)
            {
                var columngIndex = i;
                
                AssetLoader.LoadAddresablePrefab(_cardPrefab, (createdObj) =>
                {
                    var prefab = createdObj as GameObject;

                    if (prefab == null) return;
                    
                    prefab.transform.SetParent(prefabTransform);

                    var card = prefab.GetComponent<Card>() ?? prefab.AddComponent<Card>();
                    
                    Results.Add(card);

                    card.Initialize(cardTypes[rowIndex * _size.Height + columngIndex], new CardFlipper());

                    if (rowIndex * _size.Height + columngIndex + 1 >= _size.Length)
                    {
                        _onCompleteCallback?.Invoke();
                    }

                });
                
            }
        }
        

        #endregion

    }
}