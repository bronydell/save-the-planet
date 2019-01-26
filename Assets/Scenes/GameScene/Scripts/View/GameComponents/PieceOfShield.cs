using UnityEngine;

namespace Scenes.GameScene.Scripts.View.GameComponents
{
    public class PieceOfShield : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var movement = collision.gameObject.GetComponent<ProjectileMovement>();

            if (collision.gameObject.CompareTag("SunRay"))
            {
               if (movement != null)
                   movement.DestroyMe(true);
            }
            if (collision.gameObject.CompareTag("Gas"))
            {
                DestroyMe();
                if (movement != null)
                    movement.DestroyMe(true);
                
            }
        }

        private void DestroyMe()
        {
            Destroy(gameObject);
        }
    }
}
