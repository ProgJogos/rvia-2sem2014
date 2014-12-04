using UnityEngine;
using System.Collections;

public class AreaUtil : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D outro)
    {
        if (outro.gameObject.CompareTag("Boid"))
        {
            if (outro.transform.position.y > collider2D.bounds.max.y)
            {
                outro.transform.Translate(
                    0, -collider2D.bounds.size.y * 0.95f, 0,
                    Space.World);
            } else if (outro.transform.position.y < collider2D.bounds.min.y)
            {
                outro.transform.Translate(
                    0, collider2D.bounds.size.y * 0.95f, 0,
                    Space.World);
            }

            if (outro.transform.position.x < collider2D.bounds.min.x)
            {
                outro.transform.Translate(
                    collider2D.bounds.size.x * 0.95f, 0, 0,
                    Space.World);
            } else if (outro.transform.position.x > collider2D.bounds.max.x)
            {
                outro.transform.Translate(
                    -collider2D.bounds.size.x * 0.95f, 0, 0,
                    Space.World);
            }

        }
    }
}
