#if UNITY_EDITOR
using UnityEditor;

namespace HCC.LoadSceneButton
{
    [CustomEditor(typeof(SceneChangeButton))]
    public class SceneChangeButtonEditor : Editor
    {
        #region Functions

        public override void OnInspectorGUI()
        {
            SceneChangeButton changeButton = (SceneChangeButton)target;

            changeButton.sceneNameToLoad = EditorGUILayout.TextField(changeButton.sceneNameToLoad);

            DrawDefaultInspector();

        }

        #endregion

    }
}
#endif