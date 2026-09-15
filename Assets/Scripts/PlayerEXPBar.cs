using UnityEngine;
using UnityEngine.UI;

public class PlayerEXPBar : MonoBehaviour
{
    public PlayerEXP playerEXP;
    public Slider expSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        expSlider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEXPBar();
    }
    void UpdateEXPBar()
    {
        expSlider.maxValue = playerEXP.EXPtoNextLevel;
        expSlider.value = playerEXP.currentEXP;

        Debug.Log(
            "EXP Bar: " +
            expSlider.value +
            " / " +
            expSlider.maxValue);
    }
}
