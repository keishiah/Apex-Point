using CodeBase.UI.HUD;
using UnityEngine;

namespace CodeBase.Infrastructure.Factories
{
    public interface IGameFactory
    {
        void Cleanup();
        GameObject CreateTank(Vector3 position);
        GameObject CreateParent();
    }
}