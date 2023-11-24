using CodeBase.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Factories
{
    public class GameFactory : IGameFactory, IInitializable
    {
        private const string HeroPrefabPath = "Gameobjects/Tank";
        private readonly IStaticDataService staticDataService;
        private readonly DiContainer diContainer;

        private Transform gameObjectsParent;
        private GameObject tank;

        public GameFactory(IStaticDataService staticDataService, DiContainer diContainer)
        {
            this.staticDataService = staticDataService;
            this.diContainer = diContainer;
        }

        public GameObject CreateParent()
        {
            return new GameObject("GameObjectsParent");
        }

        public GameObject CreateTank(Vector3 position)
        {
            GameObject tank = diContainer.InstantiatePrefabResource(HeroPrefabPath);
            tank.transform.SetPositionAndRotation(position, Quaternion.Euler(90, -90, 90));
            return tank;
        }

        // public GameObject CreateEnemy()
        // {
        //     
        // }

        public void Cleanup()
        {
        }

        public void Initialize()
        {
        }
    }
}