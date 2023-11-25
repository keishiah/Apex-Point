using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Services
{
    public class Pooler<T> where T : MonoBehaviour
    {
        private T Prefab { get; }
        private Transform Container { get; }
        private List<T> _pool;

        public Pooler(T prefab, int count)
        {
            Container = new GameObject($"{typeof(T)} parent").transform;
            Prefab = prefab;
            Container = Container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            var createdObject = Object.Instantiate(Prefab, Container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }

        private bool HasFreeElement(out T element)
        {
            foreach (var unit in _pool)
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