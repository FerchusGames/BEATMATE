using UnityEngine;

public class Mover : MonoBehaviour
{
    public void Move(Vector2 movement)
    {
        transform.position += (Vector3)movement;
    }
}
