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
            _height = 0;
            _width = 0;
            
            _height =  FindDivider(lengthValue);
            _width = lengthValue / _height > 2 ? lengthValue / _height : 1;
            
            Debug.Log($"length: {lengthValue}, width: {_width}, height: {_height}");
            
        }

        private int FindDivider(int lengthValue)
        {
            int divider = 0;
            
            if(lengthValue <= 2) return 1;

            for (int i = 2; i < lengthValue/2; i++)
            {
                if (lengthValue % i == 0)
                {
                    divider = i;
                }
            }
            return divider;
        }
        
        #endregion
    }
}