using UnityEngine;

namespace Beatmate.Movement
{
    public class Mover : MonoBehaviour
    {
        public void Move(Vector2 movement)
        {
            Vector2 nextPosition = (Vector2)transform.position + movement;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(nextPosition, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.TryGetComponent(out Mover mover))
                    break;
                if (collider.CompareTag("Board"))
                {
                    transform.position = nextPosition;
                }
            }
        }
    }
}
