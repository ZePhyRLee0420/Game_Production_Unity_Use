using UnityEngine;

public enum StatusUpgradeType
{
    Damage,
    MaxHP,
    MoveSpeed,
    BombRadius,

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
        StatusUpgradeType.BombRadius
    };
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
                playerCombat.bombDamage += 5;
                break;

            case StatusUpgradeType.MoveSpeed:
                playerController.moveSpeed += 0.5f;
                break;

            case StatusUpgradeType.BombRadius:
                playerCombat.explosionRadius += 0.5f;
                break;
        }

        EndUpgrade();
    }
    void OnDestroy()
    {
        if (playerEXP != null)
        {
            playerEXP.OnLevelUp -= StartUpgrade;
        }
    }
}
