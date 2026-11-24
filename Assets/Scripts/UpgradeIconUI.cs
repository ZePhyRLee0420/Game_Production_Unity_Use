using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeIconUI : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TMP_Text levelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup(Sprite icon, int level)
    {
        iconImage.sprite = icon;
        UpdateLevel(level);
    }
    public void UpdateLevel(int level)
    {
        levelText.text = "Lv." + level;
    }
    public Sprite GetIcon()
    {
        return iconImage.sprite;
    }
}
