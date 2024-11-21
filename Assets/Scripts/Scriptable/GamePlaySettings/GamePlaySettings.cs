using HCC.Enums;
using HCC.SaveSystem;
using HCC.Structs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace HCC.DataBase
{
    [CreateAssetMenu(fileName = "GamePlaySettings", menuName = "DataBase/Settings/GamePlaySettings")]
    public class GamePlaySettings : ScriptableObject
    {
        #region Fields
        
        [BoxGroup("Board Size")]
        [SerializeField] private BoardSize _size;
        
        private SettingData _settingData;
        
        #endregion

        #region Properties
        public SettingData SettingData => _settingData;
        
        #endregion
        

        #region Methods

        public void LoadDefault() => _settingData = GetDefaultData();
        public void LoadSaveSettings() => _settingData = GetLoadData();

        private SettingData GetDefaultData()
        {
            return new SettingData(_size);
        }

        private SettingData GetLoadData()
        {
            BoardSize size = new BoardSize(SaveUtilites.Load(SaveDataNames.GameBoardSize),2);
            int multiplayer = SaveUtilites.Load(SaveDataNames.Multiplier);
            int points = SaveUtilites.Load(SaveDataNames.Points);
            int turns = SaveUtilites.Load(SaveDataNames.Turns);
            
            return new SettingData(size, multiplayer, points, turns);
        }
        
        #endregion
        
      
    }
}