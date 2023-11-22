using UnityEngine;
using Random = UnityEngine.Random;

namespace Vanchegs.Interanl.Scripts.PrimitiveLogic.View
{
    public sealed class Primitive : MonoBehaviour
    {
        private const string FloorTag = "Floor";

        [SerializeField] private Rigidbody2D primRigidbody2D;

        private bool isFloorTouch;

        private void OnCollisionEnter2D(Collision2D collision2D)
        {
            if (isFloorTouch)
                return;

            if (!collision2D.gameObject.CompareTag(FloorTag))
                return;

            primRigidbody2D.AddForce(new Vector2(Random.Range(-40f, 40f), Random.Range(5f, 7f)));

            isFloorTouch = true;
        }
    }
}