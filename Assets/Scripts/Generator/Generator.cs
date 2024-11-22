using System;
using System.Collections.Generic;
using HCC.DataBase;

namespace HCC.Generators

{
    [Serializable]
    public abstract class Generator
    {

        #region Properties
        public HashSet<object> Results { get; set; }
        
        #endregion

        #region Methods
        
        public abstract void Generate(GamePlaySettings gamePlaySettings, Action OnCompleteCallback = null);
        
        #endregion
    }
  
}