namespace TVB.Game
{
    using UnityEngine;
    using UnityEditor.Build;
    using UnityEditor.Build.Reporting;


    class GamePostprocessor : IProcessSceneWithReport
    {
        int IOrderedCallback.callbackOrder { get { return 0; } }

        void IProcessSceneWithReport.OnProcessScene(UnityEngine.SceneManagement.Scene scene, BuildReport report)
        {
        }
    }
}