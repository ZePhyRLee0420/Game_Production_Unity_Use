using UnityEngine;

public class SkillPanelActivate : MonoBehaviour
{
    public bool skillPanelActiveFlag = false;

    [SerializeField] GameObject UpgradePanel;
    [SerializeField] GameObject SkillPanel;

    bool ok = false;

    float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(skillPanelActiveFlag == true)
        {
            if(UpgradePanel.activeSelf == true)
            {
                time = 0;
            }

            else
            {
                time += Time.deltaTime;
            }
        }

        if(skillPanelActiveFlag == true && time >= 0.1f)
        {
            SkillPanel.SetActive(true);
            skillPanelActiveFlag = false;
        }
    }
}
