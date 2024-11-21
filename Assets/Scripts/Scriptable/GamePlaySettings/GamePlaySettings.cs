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
        
        #endregion

        #region Properties
        
        public BoardSize Size => _size;
        
        #endregion

        #region Functions

        #endregion

        #region Methods

        #endregion
    }
}