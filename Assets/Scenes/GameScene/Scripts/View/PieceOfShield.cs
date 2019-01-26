using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class PieceOfShield : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("SunRay"))
            {
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.CompareTag("Gas"))
            {
                OnDestroy();
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            // TODO
        }
    }
}
