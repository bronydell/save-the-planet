using System;
using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class Shield : MonoBehaviour
    {
        [SerializeField]
        private GameObject pieceOfShield;

        private SpriteRenderer pieceOfShieldRenderer;

        public float Radius = 5;

        private void Awake()
        {
            pieceOfShieldRenderer = pieceOfShield.GetComponent<SpriteRenderer>();
        }
   
        public void GenerateShield()
        {
            /*var height = pieceOfShieldRenderer.sprite.rect.height * pieceOfShield.transform.localScale.y;
            var width = pieceOfShieldRenderer.sprite.rect.width * pieceOfShield.transform.localScale.x;
            var radius = Mathf.Sqrt(height * height + width * width);
            var angle = Mathf.Acos((2 * radius * radius - width * width) / (2 * radius * radius));*/
            var width = pieceOfShieldRenderer.bounds.size.x;// * pieceOfShield.transform.localScale.x;
            var r = Radius + pieceOfShieldRenderer.bounds.size.y;
            var angle = /*2 * Mathf.PI / 360;*/ Mathf.Acos((2 * r * r - width * width) / (2 * r * r));
            pieceOfShieldRenderer.transform.position = new Vector2(0, Radius);

            PieceOfShield prev = null, first = null, last = null;
            for (var i = 0; i < 2 * Mathf.PI / angle; i++)
            {
                var piece = Instantiate(pieceOfShield, transform).transform;
                piece.GetComponent<PieceOfShield>().prev = prev;
                if (prev != null)
                    prev.next = piece.GetComponent<PieceOfShield>();
                prev = piece.GetComponent<PieceOfShield>();
                if (first == null)
                    first = piece.GetComponent<PieceOfShield>();
                last = piece.GetComponent<PieceOfShield>();
                piece.position = new Vector2(0, Radius);
                piece.RotateAround(transform.position, new Vector3(0, 0, 1), Mathf.Rad2Deg * i * angle);
            }
            first.prev = last;
            last.next = prev;

            //Radius = radius;
        }
    }
}
