using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillSlotUI : MonoBehaviour
{
    [SerializeField] Image iconImage;
    [SerializeField] TMP_Text levelText;
    [SerializeField] Image backgroundImage;

    [SerializeField] Image cooldownImage;

    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color selectedColor = Color.yellow;
    private SkillScript currentSkill;
    void Awake()
    {
        Clear();
    }
    void Update()
    {
        if (currentSkill != null)
        {
            cooldownImage.fillAmount =
                currentSkill.GetCooldownRatio();
        }
    }
    public void Setup(SkillScript skill)
    {
        currentSkill = skill;
        cooldownImage.enabled = true;
        cooldownImage.fillAmount = skill.GetCooldownRatio();

        iconImage.enabled = true;
        levelText.enabled = true;

        iconImage.sprite = skill.SkillIcon;
        levelText.text = "Lv." + skill.GetSkillLevel();
    }

    public void Clear()
    {
        currentSkill = null;
        cooldownImage.enabled = false;
        cooldownImage.fillAmount = 0f;

        iconImage.enabled = false;
        levelText.enabled = false;

        SetSelected(false);
    }

    public void SetSelected(bool isSelected)
    {
        if (isSelected)
        {
            backgroundImage.color = selectedColor;
        }
        else
        {
            backgroundImage.color = normalColor;
        }
    }
}