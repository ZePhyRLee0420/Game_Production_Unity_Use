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
    public BombController bombController;
    //public GameObject upgradePanel;
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
        bombController = GetComponent<BombController>();
        //playerEXP.OnLevelUp += StartUpgrade;
        //upgradePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void StartUpgrade()
    {
        Time.timeScale = 0f;

        //upgradePanel.SetActive(true);
    }
    void EndUpgrade()
    {
        //upgradePanel.SetActive(false);

        Time.timeScale = 1f;
    }
    public void ApplyUpgrade(StatusUpgradeType upgrade)
    {
        switch (upgrade)
        {
            case StatusUpgradeType.MaxHP:
                playerHealth.maxHP += 20;
                break;

            case StatusUpgradeType.MoveSpeed:
                playerController.moveSpeed += 0.5f;
                break;

            case StatusUpgradeType.BombRadius:
                bombController.explosionRadius += 0.5f;
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
