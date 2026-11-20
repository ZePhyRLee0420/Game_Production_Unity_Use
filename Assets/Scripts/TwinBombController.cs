using UnityEngine;

public class TwinBombController : BombController
{
    [SerializeField] GameObject smallBombPrefab;

    [SerializeField] float splitForce = 5f;
    public float damageMultiplier = 0.4f;
    [SerializeField] float radiusMultiplier = 0.5f;

    private Vector3 splitRight = Vector3.right;

    public void SetThrowDirection(Vector3 direction)
    {
        // Ignore vertical direction
        Vector3 forward = Vector3.ProjectOnPlane(direction, Vector3.up);

        if (forward.sqrMagnitude > 0.001f)
        {
            // Calculate the right direction of the throw
            splitRight = Vector3.Cross(
                Vector3.up,
                forward.normalized
            );
        }
    }

    public override void Explode()
    {
        if (hasExploded)
            return;

        // Split based on the original throwing direction
        SpawnSmallBomb(-splitRight);
        SpawnSmallBomb(splitRight);

        // then execute normal explosion
        base.Explode();
    }
    void SpawnSmallBomb(Vector3 direction)
    {
        if (smallBombPrefab == null)
            return;

        // Calculate the spawn position for the small bomb
        Vector3 spawnPosition =
            transform.position +
            Vector3.up * 1f +
            direction * 0.5f;

        GameObject smallBomb = Instantiate(
            smallBombPrefab,
            spawnPosition,
            Quaternion.identity
        );

        // Set the damage and radius of the small bomb
        BombController bomb = smallBomb.GetComponent<BombController>();

        if (bomb != null)
        {
            bomb.damage = Mathf.RoundToInt(
                damage * damageMultiplier
            );

            bomb.explodeRadius =
                explodeRadius * radiusMultiplier;
        }

        // Apply force to the small bomb to make it move away from the original bomb
        Rigidbody rb = smallBomb.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 launchDirection =
                (direction + Vector3.up * 0.6f).normalized;

            rb.AddForce(
                launchDirection * splitForce,
                ForceMode.Impulse
            );
        }
    }
}
