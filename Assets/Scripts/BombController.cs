using UnityEngine;

public class BombController : MonoBehaviour
{
    public float explodeTime = 3f;
    //public GameObject explosionEffect;
    public float explodeRadius;
    public float explosionForce = 10f;

    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Explode", explodeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        //Instantiate(explosionEffect,transform.position,Quaternion.identity);

        Collider[] hits = Physics.OverlapSphere(transform.position, explodeRadius);

        foreach (Collider hit in hits)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(
                    explosionForce,
                    transform.position,
                    explodeRadius
                );
            }

            ZombieHeaith enemy = hit.GetComponent<ZombieHeaith>();

            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        Destroy(gameObject);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Floor"))
        {
            Explode();
        }
    }
}
