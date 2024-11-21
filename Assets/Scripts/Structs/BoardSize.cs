using System;
using UnityEngine;

namespace HCC.Structs
{
    [Serializable]
    public struct BoardSize 
    {
        #region Fields
        
        [SerializeField] private int _height;
        [SerializeField] private int _width;   
        
        #endregion

        #region Properties
        
        public int Height => _height;
        public int Width => _width;
        public int Length => _height * _width;

        #endregion
        
        #region Methods

        public BoardSize(int lengthValue, int valueDivider)
        {
            _height = lengthValue/valueDivider;
            _width = lengthValue/valueDivider;
        }
        
        #endregion
    }
}