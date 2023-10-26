using UnityEngine;
using Random = UnityEngine.Random;

namespace Vanchegs.PrimitiveLogic
{
    public class Primitive : MonoBehaviour
    {
        private const string FloorTag = "Floor";
        
        [SerializeField] private Rigidbody2D primRigidbody2D;

        private bool isFloorTouch = false;
        private CirclePool<Primitive> circlePool;
        private TrianglePool<Primitive> trianglePool;
        private SquarePool<Primitive> squarePool;
        
        public void CircleConstructor<T>(CirclePool<T> circlePool1) where T : MonoBehaviour
        {
            circlePool = circlePool1 as CirclePool<Primitive>;
        }

        public void TriangleConstructor<T>(TrianglePool<T> trianglePool1) where T : MonoBehaviour
        {
            trianglePool = trianglePool1 as TrianglePool<Primitive>;
        }

        public void SquareConstructor<T>(SquarePool<T> squarePool1) where T : MonoBehaviour
        {
            squarePool = squarePool1 as SquarePool<Primitive>;
        }
        
        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (isFloorTouch) return;
            if (!collision2D.gameObject.CompareTag(FloorTag)) return;
            primRigidbody2D.AddForce(new Vector2(Random.Range(-40f, 40f), Random.Range(5f, 7f)));
            isFloorTouch = true;
        }
    }
}
