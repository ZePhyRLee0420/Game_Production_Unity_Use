using UnityEngine;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    [SerializeField] private List<SkillScript> skills = new();

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
        if (newSkill == null || skills.Contains(newSkill))
        {
            return;
        }
        skills.Add(newSkill);
    }
    void ShowCurrentSkill()
    {
        if (skills.Count == 0)
            return;

        Debug.Log("Current Skill: " + skills[currentSkillIndex].SkillName);
    }
}
