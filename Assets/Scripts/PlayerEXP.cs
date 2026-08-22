using UnityEngine;

public class PlayerEXP : MonoBehaviour
{
    float currentEXP = 0;
    public int currentLevel = 1;
    float EXPtoNextLevel = 10;
    PlayerHealth health;
    BombController bomb;
    
    public delegate void LevelUpHandler();
    public event LevelUpHandler OnLevelUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        bomb = GetComponent<BombController>();
        Initiate();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Current EXP = " + currentEXP + " / " + EXPtoNextLevel);
    }
    public void Initiate()
    {
        currentEXP = 0;
        currentLevel = 1;
    }
    public void GainEXP(int exp)
    {
        currentEXP += exp;
        while (currentEXP >= EXPtoNextLevel)
        {
            LevelUp();
        }
    }
    void LevelUp()
    {
        currentEXP -= EXPtoNextLevel;

        currentLevel++;

        health.maxHP += currentLevel * 10;
        health.currentHP += currentLevel * 10;

        bomb.damage += currentLevel * 2;

        EXPtoNextLevel *= 2;

        OnLevelUp?.Invoke();

        Debug.Log("Level = " + currentLevel);
    }

}
