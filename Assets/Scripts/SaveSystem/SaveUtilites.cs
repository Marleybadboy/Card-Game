using HCC.Enums;
using UnityEngine;

namespace HCC.SaveSystem
{

    public static class SaveUtilites
    {
        #region Methods

        public static void Save(SaveDataNames name, int value)
        {
            PlayerPrefs.SetInt(name.ToString(), value);
            PlayerPrefs.Save();
        }

        public static int Load(SaveDataNames name)
        {
            return PlayerPrefs.GetInt(name.ToString());
        }
        #endregion
    }
}