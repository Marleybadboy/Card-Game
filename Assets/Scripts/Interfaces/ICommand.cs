using UnityEngine;

namespace HCC.Interfaces
{
    public interface ICommand
    {
        #region Properties

        public object[] Result { get; set; }
        
        #endregion

        #region Methods

        public void Execute();

        #endregion
    }
}