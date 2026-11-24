using UnityEngine;
using System.Collections.Generic;

public class UpgradeIconManager : MonoBehaviour
{
    [SerializeField] UpgradeIconUI iconPrefab;
    [SerializeField] Transform iconContainer;
    Dictionary<string, UpgradeIconUI> icons = new Dictionary<string, UpgradeIconUI>();

    Dictionary<string, int> levels = new Dictionary<string, int>();
    //[SerializeField] Sprite testIcon;

    //void Start()
    //{
    //    AddUpgrade("HP", testIcon);
    //    AddUpgrade("HP", testIcon);
    //    AddUpgrade("Speed", testIcon);
    //}
    public void AddUpgrade(string upgradeID, Sprite icon)
    {
        if (icons.ContainsKey(upgradeID))
        {
            levels[upgradeID]++;

            icons[upgradeID].UpdateLevel(levels[upgradeID]);
        }
        else
        {
            UpgradeIconUI newIcon = Instantiate(iconPrefab, iconContainer);

            newIcon.Setup(icon, 1);

            icons.Add(upgradeID, newIcon);
            levels.Add(upgradeID, 1);
        }
    }
    public IReadOnlyDictionary<string, UpgradeIconUI> GetIcons()
    {
        return icons;
    }

    public int GetUpgradeLevel(string upgradeID)
    {
        return levels[upgradeID];
    }
}
