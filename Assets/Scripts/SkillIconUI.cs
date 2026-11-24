using UnityEngine;
using System.Collections.Generic;

public class SkillHUD : MonoBehaviour
{
    [SerializeField] SkillSlotUI[] skillSlots;

    public void RefreshUI(IReadOnlyList<SkillScript> skills, int currentSkillIndex)
    {
        for (int i = 0; i < skillSlots.Length; i++)
        {
            if (i < skills.Count)
            {
                skillSlots[i].Setup(skills[i]);

                skillSlots[i].SetSelected(
                    i == currentSkillIndex);
            }
            else
            {
                skillSlots[i].Clear();
            }
        }
    }
}