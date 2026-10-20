using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<SkillScript> skills = new();

    private int currentSkillIndex = 0;

    public void UseCurrentSkill()
    {
        if(skills.Count == 0)
            return;
        skills[currentSkillIndex].TryToUseSkill();
    }
    public void NextSkill()
    {
        if(skills.Count == 0)
            return;
        currentSkillIndex = (currentSkillIndex + 1) % skills.Count;
    }
    public void PreviousSkill()
    {
        if (skills.Count == 0)
            return;
        currentSkillIndex = (currentSkillIndex - 1 + skills.Count) % skills.Count;
    }
    public void AddSkill(SkillScript newSkill)
    {
        if (newSkill == null || skills.Contains(newSkill))
        {
            return;
        }
        skills.Add(newSkill);
    }
}
