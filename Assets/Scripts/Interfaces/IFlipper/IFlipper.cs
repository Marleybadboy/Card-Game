
using System;
using DG.Tweening;
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
        public void Flip(Action callback = null);
        public void Restore();

        #endregion
    }
}