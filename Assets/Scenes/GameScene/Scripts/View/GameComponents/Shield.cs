using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class Shield : MonoBehaviour
    {
        [SerializeField]
        private GameObject pieceOfShield;

        private SpriteRenderer pieceOfShieldRenderer;

        public float Radius;

        private void Start()
        {
            pieceOfShieldRenderer = pieceOfShield.GetComponent<SpriteRenderer>();
            GenerateShield();
        }
   
        private void GenerateShield()
        {
            var height = pieceOfShieldRenderer.sprite.rect.height * pieceOfShield.transform.localScale.y;
            var width = pieceOfShieldRenderer.sprite.rect.width * pieceOfShield.transform.localScale.x;
            var radius = Mathf.Sqrt(height * height + width * width);
            var angle = Mathf.Acos((2 * radius * radius - width * width) / (2 * radius * radius));

            for (var i = 0; i < 2 * Mathf.PI / angle; i++)
            {
                var piece = Instantiate(pieceOfShield, transform).transform;
                piece.position = transform.position;
                piece.Rotate(new Vector3(0, 0, Mathf.Rad2Deg * i * angle));
            }

            Radius = radius;
        }
    }
}
