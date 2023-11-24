using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Services
{
    public class Pooler<T> where T : MonoBehaviour
    {
        public T prefab { get; }
        public Transform container { get; }
        public List<T> pool;

        public Pooler(T prefab, int count, Transform container)
        {
            this.prefab = prefab;
            this.container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(prefab, container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            pool.Add(createdObject);
            return createdObject;
        }

        public bool HasFreeElement(out T element)
        {
            foreach (var unit in pool)
            {
                if (!unit.gameObject.activeInHierarchy)
                {
                    element = unit;
                    unit.gameObject.SetActive(true);
                    return true;
                }
            }

            element = null;
            return false;
        }

        public T GetFreeElement()
        {
            if (HasFreeElement(out var element))
                return element;

            return CreateObject(true);
        }

    }
}