using UnityEngine;

namespace Scenes.GameScene.Scripts.View
{
    public class GasMovement : ProjectileMovement
    {
        private void FixedUpdate()
        {
            Rb.velocity = transform.up * speed * Time.fixedDeltaTime * -1;
        }
    }
}
