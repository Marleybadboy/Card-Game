
using UnityEngine;

namespace HCC.Interfaces
{
    public interface IFlipper
    {
        #region Fields
        #endregion

        #region Properties
        #endregion

        #region Functions
        #endregion

        #region Methods

        public void Initialize(GameObject cardFront, GameObject cardBack);
        public void Flip();
        public void Restore();

        #endregion
    }
}