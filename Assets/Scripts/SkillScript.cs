using UnityEngine;

public abstract class SkillScript : MonoBehaviour
{
    [SerializeField] protected string skillName;
    public string SkillName => skillName;
    [SerializeField] Sprite skillIcon;
    public Sprite SkillIcon => skillIcon;
    [SerializeField] protected float skillCooldown = 0f;

    protected int skillLevel = 1;
    protected float cooldownTimer = 0f;

    [SerializeField]AudioClip skillUseSound;

    [SerializeField] AudioClip skillUseErrorSound;

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
        AudioSource audioSource;
        audioSource = GetComponent<AudioSource>();

        if (cooldownTimer > 0f)
        {
            if(skillUseSound != null && audioSource != null)
                audioSource.PlayOneShot(skillUseErrorSound);
            return;
        }
        if(skillUseSound != null && audioSource != null)
            audioSource.PlayOneShot(skillUseSound);
        ActivateSkill();

        cooldownTimer = skillCooldown;
    }

    protected abstract void ActivateSkill();

    public void LevelUpSkill()
    {
        skillLevel++;
    }

    public int GetSkillLevel()
    {
        return skillLevel;
    }
}
