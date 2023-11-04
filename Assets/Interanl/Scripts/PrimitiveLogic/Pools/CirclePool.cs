using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.PrimitiveLogic.Pools
{
    public class CirclePool<T> where T : MonoBehaviour
    {
        private T CirclePrefab;
        private Transform CirclePoolContainer;
        private bool autoExpand;

        private List<T> circlePool = new();

        public CirclePool(T prefab, Transform container, int poolSize, bool autoExpand)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));

            CirclePrefab = prefab;

            if (container == null)
                throw new NullReferenceException(nameof(container));

            CirclePoolContainer = container;

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
            T newObject = GameObject.Instantiate(CirclePrefab, CirclePoolContainer);
            
            newObject.gameObject.SetActive(isActiveByDefault);
            
            circlePool.Add(newObject);

            return newObject;
        }

        public bool TryGetFree(out T element)
        {
            for (int i = 0; i < circlePool.Count; i++)
            {
                if (!circlePool[i].gameObject.activeInHierarchy)
                {
                    element = circlePool[i];
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void DisableAll()
        {
            foreach (var gameObject in circlePool)
                gameObject.gameObject.SetActive(false);
        }

        public T GetFree()
        {
            if (TryGetFree(out T element))
            {
                element.gameObject.SetActive(true);
                return element;
            }

            if (autoExpand)
                return CreateNewObject(true);

            throw new Exception("There is no free element in pool");
        }
    }
}