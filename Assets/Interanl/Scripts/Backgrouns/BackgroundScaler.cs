using UnityEngine;

namespace Vanchegs.Interanl.Scripts.Backgrouns
{
    public sealed class BackgroundScaler : MonoBehaviour
    {
        [SerializeField] private Camera cameraRenderer;
        private SpriteRenderer backgroundSpriteRenderer;

        private void Awake() =>
            backgroundSpriteRenderer = GetComponent<SpriteRenderer>();

        private void Start() =>
            ScaleBackground();

        private void LateUpdate() =>
            ScaleBackground();

        private void ScaleBackground()
        {
            var targetHeight = cameraRenderer.orthographicSize * 2;
            var targetWidth = targetHeight * Screen.width / Screen.height;

            var backgroundSize = backgroundSpriteRenderer.sprite.bounds.size;
            var targetScale = Vector3.one;
            var widthRatio = targetWidth / backgroundSize.x;
            var heightRatio = targetHeight / backgroundSize.y;

            if (widthRatio > heightRatio)
                targetScale *= widthRatio;
            else
                targetScale *= heightRatio;

            transform.localScale = targetScale;
        }
    }
}
