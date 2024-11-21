using System;
using HCC.Enums;
using HCC.Interfaces;
using HCC.SaveSystem;
using UnityEngine;

namespace HCC.Structs
{
    [Serializable]
    public class SaveData
    {
        #region Fields
        
        [SerializeField] private SaveDataNames _saveDataName;
        [SerializeField] private MonoBehaviour _saveComponent;
        
        #endregion

        #region Properties
        private ISave SaveComponent => _saveComponent.GetComponent<ISave>();
        
        #endregion

        #region Methods

        public void Save()
        {
            if(SaveComponent == null) return;
            
            SaveUtilites.Save(_saveDataName, SaveComponent.GetSaveValue());
        }
        
        
        #endregion
    }
}