using UnityEngine;

public class OverdriveSkill : SkillScript
{
    [SerializeField] float baseDuration = 5f;

    float durationTimer = 0f;

    public bool IsActive { get; private set; } = false;

    public float Duration
    {
        get
        {
            return baseDuration + skillLevel * 1f;
        }
    }
    protected override void ActivateSkill()
    {
        IsActive = true;
        durationTimer = Duration;
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
