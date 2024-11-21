
using UnityEngine;
using UnityEngine.UI;

namespace HCC.LoadSceneButton
{

    public class SceneChangeButton : Button
    {
        #region Fields

        public string sceneNameToLoad;

        #endregion

        #region Properties

        #endregion

        #region Functions

        protected override void Start()
        {
            base.Start();

            onClick.AddListener(LoadScene);
        }

        #endregion

        #region Methods

        private void LoadScene()
        {
            //SceneManager.LoadSceneAsync(sceneNameToLoad);

            Debug.Log("Loading scene " + sceneNameToLoad);
        }

        #endregion
    }
}