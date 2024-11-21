
using HCC.Enums;

namespace HCC.Structs
{
    public struct SettingData
    {
        #region Fields
        
        private BoardSize _size;
        private int _valueMultiplier;
        private int _valuePoints;
        private int _valueTurns;
        
        #endregion
        
        #region Properties
        
        public BoardSize Size => _size;
        
        #endregion
        
        #region Indexers

        public int this[SaveDataNames names]
        {
            get
            {
                switch (names)
                {
                    case SaveDataNames.GameBoardSize:
                        return _size.Length;
                    case SaveDataNames.Multiplier:
                        return _valueMultiplier;
                    case SaveDataNames.Points:
                        return _valuePoints;
                    case SaveDataNames.Turns:
                        return _valueTurns;
                    default: return -1;
                }
                
            }
        }
        
        #endregion
   
        #region Methods 
        public SettingData(BoardSize size, int valueMultiplie = 0, int valuePoints = 0, int valueTurns = 0)
        {
            _size = size;
            _valueMultiplier = valueMultiplie;
            _valuePoints = valuePoints;
            _valueTurns = valueTurns;
        }
        
        #endregion


    }
}