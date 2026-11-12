using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillSelectScript : MonoBehaviour
{
    [SerializeField] SkillManager skillManager;
    [SerializeField] Button[] skillButtons;

    [SerializeField] PlayerInputHandler inputHandler;
    List<SkillScript> offeredSkills = new();
    public GameObject upgradePanel;

    bool isSelecting = false;

    //セットするスキル札の画像
    [SerializeField] Sprite TwinBombImage;
    [SerializeField] Sprite OverDriveImage;
    [SerializeField] Sprite TridentImage;

    void OnEnable()
    {
        Debug.Log("SkillSelect OnEnable!");
        ShowSkillSelection();
    }
    //void Update()
    //{
    //    Debug.Log("Time Scale: " + Time.timeScale);
    //}

    public void ShowSkillSelection()
    {
        if (isSelecting)
            return;

        if(skillManager == null)
            return;

        offeredSkills = skillManager.GetRandomSkills(3);

        if (offeredSkills.Count == 0)
            return;

        isSelecting = true;

        Time.timeScale = 0f;

        if (inputHandler != null)
        {
            inputHandler.DisablePlayerInput();
        }
   

        for (int i = 0; i < skillButtons.Length; i++)
        {
            int index = i;
            Button button = skillButtons[i];

            button.onClick.RemoveAllListeners();

            if (i >= offeredSkills.Count)
            {
                button.gameObject.SetActive(false);
                continue;
            }

            button.gameObject.SetActive(true);

            SkillScript skill = offeredSkills[i];


            //ここから変更あり
            //ボタンに選ぶスキル札の画像を反映させる処理
            Image image = button.GetComponent<Image>();

            if(skill.SkillName == "Twin Bomb")
            {
                image.sprite = TwinBombImage;
            }

            else if(skill.SkillName == "Overdrive")
            {
                image.sprite = OverDriveImage;
            }

            else if (skill.SkillName == "Trident")
            {
                image.sprite = TridentImage;
            }
            //ここまで変更した

            int nextLevel = skillManager.HasSkill(skill) ? skill.GetSkillLevel() + 1 : 1;

            TMP_Text text = button.GetComponentInChildren<TMP_Text>();

            if (text != null)
            {
                //変更前
                //text.text = skill.SkillName + "\nLv." + nextLevel;

                //変更後
                text.text = "Lv." + nextLevel;
            }

            button.onClick.AddListener(() => SelectSkill(index));
        }

        // Select the first button for keyboard navigation
        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(skillButtons[0].gameObject);
        }
    }
    void SelectSkill(int index)
    {
        if (!isSelecting)
            return;

        if (index < 0 || index >= offeredSkills.Count)
            return;

        skillManager.AddSkill(offeredSkills[index]);

        isSelecting = false;

        if (EventSystem.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        if(upgradePanel.activeSelf)
        {
            return;
        }
        else if(!upgradePanel.activeSelf)
        {
            inputHandler.EnablePlayerInput();
            //inputHandler.inputEnabled = true;
            //cameraController.inputEnabled = true;
            Time.timeScale = 1f;
        }

        gameObject.SetActive(false);
    }
}
