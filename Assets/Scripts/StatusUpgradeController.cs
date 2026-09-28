using UnityEngine;

public enum StatusUpgradeType
{
    Damage,
    MaxHP,
    MoveSpeed,
    BombRadius,
    //SkillCooldown,
    EXPBoost,
    Heal,

}
public class StatusUpgradeController : MonoBehaviour
{
    public PlayerEXP playerEXP;
    public PlayerController playerController;
    public PlayerHealth playerHealth;
    public PlayerCombat playerCombat;
    public PlayerInputHandler inputHandler;
    public PlayerCameraController cameraController;
    public GameObject upgradePanel;
    public StatusUpgradeButton[] upgradeButtons;
    StatusUpgradeType[] allUpgrades =
    {
        StatusUpgradeType.MaxHP,
        StatusUpgradeType.MoveSpeed,
        StatusUpgradeType.BombRadius,
        StatusUpgradeType.Damage,
        //StatusUpgradeType.SkillCooldown,
        StatusUpgradeType.EXPBoost,
        StatusUpgradeType.Heal,
    };

    public int statusAttackLevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerEXP = GetComponent<PlayerEXP>();
        playerController = GetComponent<PlayerController>();
        playerHealth = GetComponent<PlayerHealth>();
        playerCombat = GetComponent<PlayerCombat>();
        inputHandler = GetComponent<PlayerInputHandler>();
        cameraController = GetComponent<PlayerCameraController>();

        playerEXP.OnLevelUp += StartUpgrade;
        upgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartUpgrade()
    {
        Time.timeScale = 0f;

        inputHandler.inputEnabled = false;
        cameraController.inputEnabled = false;

        RandomUpgrade();

        upgradePanel.SetActive(true);
    }
    void EndUpgrade()
    {
        upgradePanel.SetActive(false);

        inputHandler.inputEnabled = true;
        cameraController.inputEnabled = true;

        Time.timeScale = 1f;
    }
    public void ApplyUpgrade(StatusUpgradeType upgrade)
    {
        switch (upgrade)
        {
            case StatusUpgradeType.MaxHP:
                playerHealth.maxHP += 20;
                break;

            case StatusUpgradeType.Damage:
                statusAttackLevel++;
                playerCombat.bombDamage = 10 + ((playerEXP.currentLevel + statusAttackLevel) * (playerEXP.currentLevel + statusAttackLevel));
                break;

            case StatusUpgradeType.MoveSpeed:
                playerController.moveSpeed += 0.35f;
                break;

            case StatusUpgradeType.BombRadius:
                playerCombat.explosionRadius += 1f;
                break;

            //case StatusUpgradeType.SkillCooldown:
            //    playerCombat.skillCooldown -= 0.5f;
            //    break;

            case StatusUpgradeType.EXPBoost:
                playerEXP.EXPMultiplier *= 1.1f;
                break;

            case StatusUpgradeType.Heal:
                playerHealth.currentHP += 50;
                if(playerHealth.currentHP > playerHealth.maxHP)
                {
                    playerHealth.currentHP = playerHealth.maxHP;
                }
                break;
        }

        EndUpgrade();
    }

    void RandomUpgrade()
    {
        for (int i = 0; i < allUpgrades.Length; i++)
        {
            int randomIndex = Random.Range(i, allUpgrades.Length);

            StatusUpgradeType temp = allUpgrades[i];
            allUpgrades[i] = allUpgrades[randomIndex];
            allUpgrades[randomIndex] = temp;
        }

        for (int i = 0; i < upgradeButtons.Length; i++)
        {
            upgradeButtons[i].SetUpgrade(allUpgrades[i]);
        }
    }
    void OnDestroy()
    {
        if (playerEXP != null)
        {
            playerEXP.OnLevelUp -= StartUpgrade;
        }
    }
}
