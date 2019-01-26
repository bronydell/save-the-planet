using UnityEngine;
using System.Collections;

public class PieceOfShield : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SunRay"))
        {
            OnDestroy();
            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        // TODO
    }
}
