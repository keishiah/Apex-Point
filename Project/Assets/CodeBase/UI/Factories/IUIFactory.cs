using UnityEngine;

namespace CodeBase.UI.Factories
{
    public interface IUIFactory
    {
        void Cleanup();
        GameObject CreateUiRoot();
        GameObject CreateRestartButton();
    }
}