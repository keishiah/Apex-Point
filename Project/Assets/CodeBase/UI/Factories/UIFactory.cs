using CodeBase.Infrastructure;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CodeBase.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;

        public GameObject CreateUiRoot()
        {
            GameObject uiRoot =
                Object.Instantiate(Resources.Load(InfrastructureAssetPath.UiRootPrefabPath)) as GameObject;
            _uiRoot = uiRoot.transform;
            return uiRoot;
        }

        public GameObject CreateRestartButton()
        {
            GameObject restartButton =
                Object.Instantiate(Resources.Load(InfrastructureAssetPath.RestartButtonPrefabPath), _uiRoot) as
                    GameObject;
            return restartButton;
        }


        public void Cleanup()
        {
        }
    }
}