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

using UnityEngine;
using Vanchegs.Interanl.Scripts.EventSystem;
using Vanchegs.Interanl.Scripts.PrimitiveLogic.Pools;
using Vanchegs.Interanl.Scripts.PrimitiveLogic.View;
using Random = UnityEngine.Random;

namespace Vanchegs.Interanl.Scripts.PrimitiveLogic.Factorys
{
    public class PrimitiveFactory : MonoBehaviour
    {
        [SerializeField] private int spawnPointY;
        [SerializeField] private Primitive circlePrefab;
        [SerializeField] private Primitive trianglePrefab;
        [SerializeField] private Primitive squarePrefab;
        [SerializeField] private int poolCount = 20;
        [SerializeField] private bool autoExpand;

        private CirclePool<Primitive> circlePool;
        private TrianglePool<Primitive> trianglePool;
        private SquarePool<Primitive> squarePool;

        private void Start()
        {
            var cacheTransform = transform;
            
            circlePool = new CirclePool<Primitive>(circlePrefab, cacheTransform, poolCount, autoExpand);
            trianglePool = new TrianglePool<Primitive>(trianglePrefab, cacheTransform, poolCount, autoExpand);
            squarePool = new SquarePool<Primitive>(squarePrefab, cacheTransform, poolCount, autoExpand);
        }

        private void OnEnable() =>
            EventPack.OnClickScreen += SpawnPrimitive;

        private void OnDisable() =>
            EventPack.OnClickScreen -= SpawnPrimitive;

        public void OffPrimitives()
        {
            circlePool.DisableAll();
            squarePool.DisableAll();
            trianglePool.DisableAll();
        }

        private void SpawnPrimitive()
        {
            var randomPool = Random.Range(0, 3);

            switch (randomPool)
            {
                case 0:
                    CreateNewCircle();
                    break;
                case 1:
                    CreateNewTriangle();
                    break;
                case 2:
                    CreateNewSquare();
                    break;
            }
        }

        private void CreateNewCircle()
        {
            var newPosition = new Vector3(Random.Range(-5f, 5f), spawnPointY);

            var primitive = circlePool.GetFree();

            if (primitive == null)
                return;

            primitive.gameObject.SetActive(true);
            primitive.transform.position = newPosition;
            primitive.transform.SetParent(transform);
        }

        private void CreateNewTriangle()
        {
            var newPosition = new Vector3(Random.Range(-5f, 5f), spawnPointY);

            var primitive = trianglePool.GetFree();

            if (primitive == null)
                return;

            primitive.gameObject.SetActive(true);
            primitive.transform.position = newPosition;
            primitive.transform.SetParent(transform);
        }

        private void CreateNewSquare()
        {
            var newPosition = new Vector3(Random.Range(-6f, 6f), spawnPointY);

            var primitive = squarePool.GetFree();

            if (primitive == null)
                return;

            primitive.gameObject.SetActive(true);
            primitive.transform.position = newPosition;
            primitive.transform.SetParent(transform);
        }
    }
}