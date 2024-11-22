
using HCC.DataBase;
using HCC.SaveSystem;
using UnityEngine;


namespace HCC.SceneLoader
{

    public class SettingSceneLoader : MonoBehaviour
    {
        #region Fields
        [SerializeField] private GamePlaySettings _gamePlaySettings;
        [SerializeField] private string _sceneName;
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

        public void LoadGame()
        {
            if(!SaveUtilites.Exists()) return;
            
            _gamePlaySettings.LoadSaveSettings();
            
            LoadScene();
        }

        public void NewGame()
        {
            _gamePlaySettings.LoadDefault();
            
            LoadScene();
        }

        public void ClearSave()
        {
            SaveUtilites.Clear();
        }

        private void LoadScene()
        {
            UnityEngine.AddressableAssets.Addressables.LoadSceneAsync(_sceneName);
        }
        #endregion
    }
}