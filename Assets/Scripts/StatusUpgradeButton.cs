using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUpgradeButton : MonoBehaviour
{
    public StatusUpgradeController upgradeController;
    public StatusUpgradeType upgradeType;
    public TMP_Text buttonText;

    [SerializeField]Sprite maxHpSprite;
    [SerializeField] Sprite moveSpeedSprite;
    [SerializeField] Sprite bomRadiusSprite;
    [SerializeField] Sprite damageSprite;
    [SerializeField] Sprite expBoostSprite;
    [SerializeField] Sprite healSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ChooseUpgrade);

        UpdateText();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void ChooseUpgrade()
    {
        upgradeController.ApplyUpgrade(upgradeType);
    }
    public void SetUpgrade(StatusUpgradeType type)
    {
        upgradeType = type;

        UpdateText();
    }
    void UpdateText()
    {
        Image image = GetComponent<Image>();

        switch (upgradeType)
        {

            case StatusUpgradeType.MaxHP:
                //buttonText.text = "Max HP UP";
                image.sprite = maxHpSprite;
                break;

            case StatusUpgradeType.MoveSpeed:
                //buttonText.text = "Move Speed UP";
                image.sprite = moveSpeedSprite;
                break;

            case StatusUpgradeType.BombRadius:
                //buttonText.text = "Bomb Radius UP";
                image.sprite = bomRadiusSprite;
                break;

            case StatusUpgradeType.Damage:
                //buttonText.text = "Damage UP";
                image.sprite = damageSprite;
                break;

            case StatusUpgradeType.EXPBoost:
                //buttonText.text = "EXP Gain UP";
                image.sprite = expBoostSprite;
                break;

            case StatusUpgradeType.Heal:
                //buttonText.text = "Heal 50 HP";
                image.sprite = healSprite;
                break;
        }
    }
}
