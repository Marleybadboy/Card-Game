
using HCC.Structs;
using UnityEngine;

namespace HCC.SaveSystem
{
    public class SaveComponent : MonoBehaviour
    {
        #region Fields

        [SerializeField] private SaveData[] _saveData;
        #endregion

        #region Properties

        #endregion

        #region Functions

        // Start is called before the first frame update
        void Start()
        {

        }

        #endregion

        #region Methods

        public void SaveAllData()
        {
            if(_saveData == null) return;

            for (int i = 0; i < _saveData.Length; i++)
            {
                _saveData[i].Save();
            }
        }
        #endregion
    }
}