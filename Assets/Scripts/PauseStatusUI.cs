using UnityEngine;
using TMPro;

public class PauseStatusUI : MonoBehaviour
{
    //Game data
    [SerializeField] PlayerEXP playerEXP;
    [SerializeField] Timer timer;
    [SerializeField] SkillManager skillManager;
    [SerializeField] UpgradeIconManager upgradeIconManager;

    //Text UI
    [SerializeField] TMP_Text levelText;
    [SerializeField] TMP_Text timeText;

    //Icon UI
    [SerializeField] UpgradeIconUI iconPrefab;
    [SerializeField] Transform skillIconContainer;
    [SerializeField] Transform upgradeIconContainer;


    void OnEnable()
    {
        UpdateLevel();
        UpdateTime();
        UpdateSkillIcons();
        UpdateUpgradeIcons();
    }

    void UpdateLevel()
    {
        levelText.text = playerEXP.currentLevel.ToString();
    }

    void UpdateTime()
    {
        timeText.text = timer.time.ToString("F0");
    }
    void UpdateSkillIcons()
    {
        ClearIcons(skillIconContainer);

        foreach (SkillScript skill in skillManager.GetOwnedSkills())
        {
            UpgradeIconUI newIcon = Instantiate(iconPrefab, skillIconContainer);

            newIcon.Setup(skill.SkillIcon, skill.GetSkillLevel()
            );
        }
    }
    void UpdateUpgradeIcons()
    {
        ClearIcons(upgradeIconContainer);

        foreach (var upgrade in upgradeIconManager.GetIcons())
        {
            UpgradeIconUI newIcon = Instantiate(iconPrefab, upgradeIconContainer);

            Sprite icon = upgrade.Value.GetIcon();

            int level = upgradeIconManager.GetUpgradeLevel(upgrade.Key);

            newIcon.Setup(icon, level);
        }
    }
    void ClearIcons(Transform container)
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
    }
}