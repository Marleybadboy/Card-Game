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

    public class GameBoardGenerator : Generator
    {
        #region Fields

        [BoxGroup("Game Board")] [SerializeField]
        private Transform _boardContentParent;

        [BoxGroup("Game Board")] [SerializeField]
        private AssetReferenceGameObject _linePrefab;

        [BoxGroup("Game Board")] [SerializeField]
        private AssetReferenceGameObject _cardPrefab;

        [BoxGroup("Game Board")] [SerializeField]
        private CardType[] _cardTypes;

        private BoardSize _size;
        private Action _onCompleteCallback;
        private CardType[,] _cards;
        private int _correctValueIndex;

        #endregion

        #region Methods

        public override void Generate(GamePlaySettings gamePlaySettings, Action onCompleteCallback = null)
        {
            _size = gamePlaySettings.SettingData.Size;

            Results = new HashSet<object>();

            _onCompleteCallback = onCompleteCallback;

            CreateGameBoard();
        }

        private void CreateGameBoard()
        {
            var shuffle = new ShuffleDeck<CardType>(_size.Length, _cardTypes);

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


                    card.Initialize(cardTypes[rowIndex * _size.Width + columngIndex], new CardFlipper());

                    if (rowIndex * _size.Width + columngIndex + 1 >= _size.Length)
                    {
                        _onCompleteCallback?.Invoke();
                    }

                });

            }
        }

        #endregion

    }
}