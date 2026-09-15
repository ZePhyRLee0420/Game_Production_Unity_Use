using UnityEngine;
using TMPro;

public class PlayerLevelUI : MonoBehaviour
{
    public PlayerEXP playerEXP;
    public TMP_Text levelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Level: " + playerEXP.currentLevel;
    }
}
