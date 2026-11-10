using UnityEngine;

public class GameStartSkillScript : MonoBehaviour
{
    [SerializeField] GameObject skillSelectionPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skillSelectionPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
