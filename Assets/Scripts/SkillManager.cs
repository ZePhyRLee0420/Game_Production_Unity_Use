using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    //all skills 
    [SerializeField] private List<SkillScript> allSkills = new();

    //skill aquired by player
    private List<SkillScript> skills = new();
    private int currentSkillIndex = 0;

    PlayerInputHandler inputHandler;

    void Awake()
    {
        inputHandler = GetComponent<PlayerInputHandler>();
    }

    void Start()
    {
        ShowCurrentSkill();
    }

    void OnEnable()
    {
        if (inputHandler == null)
            return;

        inputHandler.OnUseSkill += UseCurrentSkill;
        inputHandler.OnNextSkill += NextSkill;
        inputHandler.OnPreviousSkill += PreviousSkill;
    }

    void OnDisable()
    {
        if (inputHandler == null)
            return;

        inputHandler.OnUseSkill -= UseCurrentSkill;
        inputHandler.OnNextSkill -= NextSkill;
        inputHandler.OnPreviousSkill -= PreviousSkill;
    }
    public void UseCurrentSkill()
    {
        if (skills.Count == 0)
            return;
        skills[currentSkillIndex].TryToUseSkill();
    }
    public void NextSkill()
    {
        if(skills.Count == 0)
            return;
        currentSkillIndex = (currentSkillIndex + 1) % skills.Count;
        ShowCurrentSkill();
    }
    public void PreviousSkill()
    {
        if (skills.Count == 0)
            return;
        currentSkillIndex = (currentSkillIndex - 1 + skills.Count) % skills.Count;
        ShowCurrentSkill();
    }
    public void AddSkill(SkillScript newSkill)
    {
        if (newSkill == null)
        {
            return;
        }

        if (skills.Contains(newSkill))
        {
            newSkill.LevelUpSkill();
            Debug.Log(newSkill.SkillName + " Level Up! Lv." + newSkill.GetSkillLevel());
            return;
        }

        skills.Add(newSkill);

        Debug.Log("Skill Unlocked: " + newSkill.SkillName);

        ShowCurrentSkill();
    }
    public bool HasSkill(SkillScript skill)
    {
        return skills.Contains(skill);
    }
    public List<SkillScript> GetRandomSkills(int count)
    {
        List<SkillScript> pool = new(allSkills);
        List<SkillScript> result = new();

        while (result.Count < count && pool.Count > 0)
        {
            int index = Random.Range(0, pool.Count);

            result.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return result;
    }
    void ShowCurrentSkill()
    {
        if (skills.Count == 0)
            return;

        Debug.Log("Current Skill: " + skills[currentSkillIndex].SkillName);
    }
}
