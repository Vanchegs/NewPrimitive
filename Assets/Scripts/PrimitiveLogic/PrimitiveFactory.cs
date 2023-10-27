using UnityEngine;
using Random = UnityEngine.Random;

namespace Vanchegs.PrimitiveLogic
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
        
        //[SerializeField] private ScoreCounter scoreCounter;

        private void Start()
        {
            var transform1 = transform;
            circlePool = new CirclePool<Primitive>(circlePrefab, transform1, poolCount, autoExpand);
            trianglePool = new TrianglePool<Primitive>(trianglePrefab, transform1, poolCount, autoExpand);
            squarePool = new SquarePool<Primitive>(squarePrefab, transform1, poolCount, autoExpand);
        }

        private void OffPrimitives()
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

        private void OnEnable() => EventPack.OnClickScreen += SpawnPrimitive;
        
        private void OnDisable() => EventPack.OnClickScreen -= SpawnPrimitive;

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