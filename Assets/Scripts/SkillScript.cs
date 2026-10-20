using UnityEngine;

public abstract class SkillScript : MonoBehaviour
{
    [SerializeField] protected string skillName;
    [SerializeField] protected float skillCooldown = 0f;

    protected int skillLevel = 1;
    protected float cooldownTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if(cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void TryToUseSkill()
    {
        if (cooldownTimer > 0f)
        {
            return;
        }

        ActivateSkill();

        cooldownTimer = skillCooldown;
    }

    protected abstract void ActivateSkill();
}
