using System;
using System.Collections.Generic;
using System.Linq;
using HCC.Addressables;
using HCC.Cards;
using HCC.DataBase;
using HCC.Interfaces;
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
        
        public abstract void Generate();
        
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
        
        
        [BoxGroup("Flipper Type")]
        [SerializeReference] private IFlipper _flipper;
        
        public List<CardType> _cardTypes2 = new List<CardType>();
        
        #endregion

        #region Methods

        [Button("Flipper Type")]
        private void Shuffle()
        {
            var shuffle =  new ShuffleDeck<CardType>(_size.Length, _cardTypes);
            
            shuffle.Execute();
            
            _cardTypes2 = shuffle.Result;
            
        }

        public override void Generate()
        {
            Results = new HashSet<object>();
            
            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            var shuffle =  new ShuffleDeck<CardType>(_size.Length, _cardTypes);
            
            shuffle.Execute();
           
            _cardTypes2= shuffle.Result;
            
            var result = shuffle.Result;
            
            Debug.Log(_cardTypes2.Count);
            
            
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

                });
                
            }
        }
        

        #endregion

    }
}