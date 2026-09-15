using UnityEngine;

public class PlayerEXP : MonoBehaviour
{
    public float currentEXP = 0;
    public int currentLevel = 1;
    public float EXPtoNextLevel = 10;
    PlayerHealth health;
    PlayerCombat damage;

    StatusUpgradeController statusUpgradeController;
    
    public delegate void LevelUpHandler();
    public event LevelUpHandler OnLevelUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        damage = GetComponent<PlayerCombat>();
        statusUpgradeController = GetComponent<StatusUpgradeController>();
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Initiate()
    {
        currentEXP = 0;
        currentLevel = 1;
        EXPtoNextLevel = 10;
    }
    public void GainEXP(int exp)
    {
        currentEXP += exp;
        Debug.Log("Current EXP = " + currentEXP + " / " + EXPtoNextLevel);
        while (currentEXP >= EXPtoNextLevel)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        currentEXP -= EXPtoNextLevel;

        currentLevel++;

        health.maxHP += 20;
        health.currentHP += 20;

        damage.bombDamage = 10 + ((currentLevel + statusUpgradeController.statusAttackLevel) * (currentLevel + statusUpgradeController.statusAttackLevel));

        EXPtoNextLevel *= 2;

        OnLevelUp?.Invoke();

        Debug.Log("Level = " + currentLevel);
    }

}
