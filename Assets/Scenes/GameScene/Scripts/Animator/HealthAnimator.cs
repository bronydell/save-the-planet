using UnityEngine;

namespace Scenes.GameScene.Scripts.Animator
{
    public class HealthAnimator : MonoBehaviour
    {
        private UnityEngine.Animator statusAnimator;

        // Start is called before the first frame update
        private void Start()
        {
            statusAnimator = GetComponent<UnityEngine.Animator>();
        }

        public void SetHealth(int health)
        {
            statusAnimator.SetInteger("health", health);
        }
    }
}
