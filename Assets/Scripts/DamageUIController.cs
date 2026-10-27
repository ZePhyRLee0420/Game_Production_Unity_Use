using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class DamageUIController : MonoBehaviour
{
    Transform mainCameraTransform;

    TMP_Text damageText;

    float moveSpeed = 0.4f;

    float fadeOutSpeed = 1f;
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCameraTransform = Camera.main.transform;

        damageText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //uiをカメラに向ける
        transform.LookAt(mainCameraTransform);
        transform.Rotate(0, 180, 0);

        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        damageText.color = Color.Lerp(damageText.color, new Color(1f, 0f, 0f, 0f), fadeOutSpeed * Time.deltaTime);

        damageText.text = damage.ToString();
    }
}
