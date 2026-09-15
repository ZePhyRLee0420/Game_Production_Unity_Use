using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatusUpgradeButton : MonoBehaviour
{
    public StatusUpgradeController upgradeController;
    public StatusUpgradeType upgradeType;

    public TMP_Text buttonText;
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
        switch (upgradeType)
        {
            case StatusUpgradeType.MaxHP:
                buttonText.text = "Max HP +20";
                break;

            case StatusUpgradeType.MoveSpeed:
                buttonText.text = "Move Speed +0.5";
                break;

            case StatusUpgradeType.BombRadius:
                buttonText.text = "Bomb Radius +0.5";
                break;

            case StatusUpgradeType.Damage:
                buttonText.text = "Damage+";
                break;
        }
    }
}
