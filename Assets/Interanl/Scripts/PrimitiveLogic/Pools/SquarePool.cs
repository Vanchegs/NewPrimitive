using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.PrimitiveLogic.Pools
{
    public class SquarePool<T> where T : MonoBehaviour
    {
        private T SquarePrefab;
        private Transform SquarePoolContainer;
        private bool autoExpand;

        private List<T> squarePool = new();

        public SquarePool(T prefab, Transform container, int poolSize, bool autoExpand)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));
            this.SquarePrefab = prefab;

            if (container == null)
                throw new NullReferenceException(nameof(container));
            this.SquarePoolContainer = container;

            this.autoExpand = autoExpand;

            InitPool(poolSize);
        }

        private void InitPool(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
                CreateNewObject(false);
        }

        private T CreateNewObject(bool isActiveByDefault)
        {
            T newObject = GameObject.Instantiate(SquarePrefab, SquarePoolContainer);
            newObject.gameObject.SetActive(isActiveByDefault);
            squarePool.Add(newObject);

            return newObject;
        }

        public bool TryGetFree(out T element)
        {
            for (int i = 0; i < squarePool.Count; i++)
            {
                if (!squarePool[i].gameObject.activeInHierarchy)
                {
                    element = squarePool[i];
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void DisableAll()
        {
            foreach (var gameObject in squarePool)
                gameObject.gameObject.SetActive(false);
        }

        public T GetFree()
        {
            if (TryGetFree(out T element))
            {
                element.gameObject.SetActive(true);
                return element;
            }
            else if (autoExpand)
                return CreateNewObject(true);

            throw new Exception("There is no free element in pool");
        }
    }
}