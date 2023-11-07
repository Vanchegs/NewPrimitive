// **************************************************************** //
//
//   Copyright (c) Vanchegs and RimuruDev. All rights reserved.
//   Project: Primitime 2023
//   Contact: 
//         Vanchegs
//           - GitHub:   https://github.com/Vanchegs
//           - Gmail:    manshin9300@gmail.com
//         RimuruDev
//          - Gmail:    rimuru.dev@gmail.com
//          - LinkedIn: https://www.linkedin.com/in/rimuru/
//
// **************************************************************** //

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Vanchegs.Interanl.Scripts.PrimitiveLogic.Pools
{
    public class TrianglePool<T> where T : MonoBehaviour
    {
        private T TrianglePrefab;
        private Transform TrianglePoolContainer;
        private bool autoExpand;

        private List<T> trianglePool = new();

        public TrianglePool(T prefab, Transform container, int poolSize, bool autoExpand)
        {
            if (prefab == null)
                throw new NullReferenceException(nameof(prefab));
            this.TrianglePrefab = prefab;

            if (container == null)
                throw new NullReferenceException(nameof(container));
            this.TrianglePoolContainer = container;

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
            T newObject = GameObject.Instantiate(TrianglePrefab, TrianglePoolContainer);
            newObject.gameObject.SetActive(isActiveByDefault);
            trianglePool.Add(newObject);

            return newObject;
        }

        public bool TryGetFree(out T element)
        {
            for (int i = 0; i < trianglePool.Count; i++)
            {
                if (!trianglePool[i].gameObject.activeInHierarchy)
                {
                    element = trianglePool[i];
                    return true;
                }
            }

            element = null;
            return false;
        }

        public void DisableAll()
        {
            foreach (var gameObject in trianglePool)
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