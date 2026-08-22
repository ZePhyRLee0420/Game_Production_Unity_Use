using UnityEngine;

public class ZombieHeaith : MonoBehaviour
{
    [SerializeField]int maxHp = 10;
    int currentHp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHp <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int value)
    {
        currentHp -= value;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
