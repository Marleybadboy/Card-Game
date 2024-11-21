using System.Collections.Generic;
using HCC.DataBase;
using HCC.Generators;
using HCC.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace HCC.Manager
{
    public abstract class GamePlayManager : MonoBehaviour
    {
        #region Fields
        
        [Header("Game Board Settings")]
        [SerializeReference] private Generator _generator;
        
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

        private void CreateGameBoard()
        {
            _generator.Generate();
        }

        #endregion

        #region Methods
        
        #endregion
    }


}