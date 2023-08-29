using UnityEngine;

public class Attack : MonoBehaviour
{
    public float maxAttackDistance = 1.5f;
    public float damage = 25f;


    public void Fire(Vector2 ShootPos)
    {
        Ray2D ray = new Ray2D(ShootPos, Vector2.zero);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null)
        {
            // The ray hit an object
            GameObject hitObject = hit.collider.gameObject;
            hitObject.GetComponent<Health>().currentHealth = hitObject.GetComponent<Health>().currentHealth - damage;

            // Do something with the hitObject and hitPoint
            Debug.Log("Hit object: " + hitObject.name);
        }
    }
}
