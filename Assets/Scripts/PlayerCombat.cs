using UnityEngine;
using System.Collections;

public class PlayerCombat : MonoBehaviour
{
    // Bomb throwing
    public GameObject bombPrefab;
    public Transform throwPoint;
    public float throwForce = 15f;
    public int bombDamage = 10;
    public float explosionRadius = 5f;
    public float throwCooldown = 0.5f;
    float cooldownTimer = 0f;
    PlayerInputHandler inputHandler;

    //twin bomb
    [SerializeField] GameObject twinBombPrefab;
    TwinBombSkill twinBombSkill;

    //mitsumata bomb
    MitsumataSkill mitsumataSkill;

    //overdrive skill
    OverdriveSkill overdriveSkill;

    [SerializeField] int overdriveBombCount = 10;
    [SerializeField] float overdriveInterval = 0.1f;
    bool isBurstFiring = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputHandler = GetComponent<PlayerInputHandler>();

        if (inputHandler != null)
        {
            inputHandler.OnThrow += ThrowBomb;
        }

        twinBombSkill = GetComponent<TwinBombSkill>();
        mitsumataSkill = GetComponent<MitsumataSkill>();
        overdriveSkill = GetComponent<OverdriveSkill>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        //Debug.Log("Damage = " + bombDamage);
    }
    void ThrowBomb()
    {
        if (cooldownTimer > 0f || isBurstFiring)
            return;

        if (bombPrefab == null || throwPoint == null)
            return;

        // Overdrive: fire 10 bombs in one second
        if (overdriveSkill != null && overdriveSkill.IsActive)
        {
            StartCoroutine(OverdriveBurst());
        }
        else
        {
            cooldownTimer = throwCooldown;
            ThrowBombPattern();
        }
    }
    IEnumerator OverdriveBurst()
    {
        isBurstFiring = true;

        // Start the normal throwing cooldown
        cooldownTimer = throwCooldown;

        for (int i = 0; i < overdriveBombCount; i++)
        {
            ThrowBombPattern();

            if (i < overdriveBombCount - 1)
            {
                yield return new WaitForSeconds(overdriveInterval);
            }
        }

        isBurstFiring = false;
    }
    void ThrowBombPattern()
    {   
        GameObject prefabToThrow = bombPrefab;

        //twin bomb skill check
        if (twinBombSkill != null &&
            twinBombSkill.IsActive &&
            twinBombPrefab != null)
        {
            prefabToThrow = twinBombPrefab;
        }

        //mitsumata skill check
        if (mitsumataSkill != null &&
            mitsumataSkill.IsActive)
        {
            float multiplier = mitsumataSkill.DamageMultiplier;

            ThrowSingleBomb(prefabToThrow, -20f, -0.6f, multiplier);
            ThrowSingleBomb(prefabToThrow, 0f, 0f, multiplier);
            ThrowSingleBomb(prefabToThrow, 20f, 0.6f, multiplier);
        }
        else
        {
            ThrowSingleBomb(prefabToThrow, 0f, 0f, 1f);
        }

        //GameObject bomb = Instantiate(prefabToThrow, throwPoint.position, Quaternion.identity);

        //BombController bombController = bomb.GetComponent<BombController>();

        //bombController.damage = bombDamage;

        //bombController.explodeRadius = explosionRadius;

        //TwinBombController twinBombController = bomb.GetComponent<TwinBombController>();

        //if (twinBombController != null && twinBombSkill != null)
        //{
        //    twinBombController.damageMultiplier =
        //        twinBombSkill.DamageMultiplier;
        //}

        //Rigidbody rb = bomb.GetComponent<Rigidbody>();

        //rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }
    void ThrowSingleBomb(GameObject prefab, float angle, float sideOffset, float damageMultiplier)
    {
        Vector3 direction =
            Quaternion.AngleAxis(angle, Vector3.up) *
            throwPoint.forward;

        Vector3 spawnPosition =
            throwPoint.position +
            throwPoint.right * sideOffset;

        GameObject bomb = Instantiate(
            prefab,
            spawnPosition,
            Quaternion.identity
        );

        BombController bombController =
            bomb.GetComponent<BombController>();

        if (bombController != null)
        {
            bombController.damage =
                Mathf.RoundToInt(bombDamage * damageMultiplier);

            bombController.explodeRadius = explosionRadius;
        }

        // Apply Twin Bomb skill level
        TwinBombController twinBombController =
            bomb.GetComponent<TwinBombController>();

        if (twinBombController != null && twinBombSkill != null)
        {
            // Save the throwing direction
            twinBombController.SetThrowDirection(direction);

            // Apply Twin Bomb skill level
            twinBombController.damageMultiplier = twinBombSkill.DamageMultiplier;
        }

        Rigidbody rb = bomb.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(
                direction.normalized * throwForce,
                ForceMode.Impulse
            );
        }
    }
    void OnDisable()
    {
        StopAllCoroutines();
        isBurstFiring = false;
    }
    void OnDestroy()
    {
        if (inputHandler != null)
        {
            inputHandler.OnThrow -= ThrowBomb;
        }
    }
}
