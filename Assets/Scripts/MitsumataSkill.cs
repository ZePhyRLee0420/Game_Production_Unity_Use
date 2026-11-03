using UnityEngine;

public class MitsumataSkill : SkillScript
{
    [SerializeField] float duration = 8f;
    float durationTimer = 0f;
    public bool IsActive { get; private set; } = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public float DamageMultiplier
    {
        get
        {
            return 0.75f + skillLevel * 0.05f;
        }
    }

    protected override void ActivateSkill()
    {
        IsActive = true;
        durationTimer = duration;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (!IsActive)
            return;

        durationTimer -= Time.deltaTime;

        if (durationTimer <= 0f)
        {
            IsActive = false;
            durationTimer = 0f;
        }
    }
    void OnDisable()
    {
        IsActive = false;
        durationTimer = 0f;
    }
}
