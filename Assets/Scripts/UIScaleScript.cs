
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonScale : MonoBehaviour,
    ISelectHandler, IDeselectHandler,
    IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] float selectedScale = 1.15f;
    [SerializeField] float scaleSpeed = 10f;

    [SerializeField] bool moveWhenSelected = false;
    [SerializeField] Vector2 selectedOffset = new Vector2(0f, 20f);

    RectTransform rectTransform;
    Vector3 originalScale;
    Vector2 originalPosition;

    bool isSelected = false;
    bool isHovered = false;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        originalScale = rectTransform.localScale;
        originalPosition = rectTransform.anchoredPosition;
    }

    void OnEnable()
    {
        CheckSelection();
    }

    void Update()
    {
        CheckSelection();

        Vector3 targetScale;
        Vector2 targetPosition;

        if (isSelected || isHovered)
        {
            targetScale = originalScale * selectedScale;

            if (moveWhenSelected)
            {
                targetPosition = originalPosition + selectedOffset;
            }
            else
            {
                targetPosition = originalPosition;
            }
        }
        else
        {
            targetScale = originalScale;
            targetPosition = originalPosition;
        }

        rectTransform.localScale = Vector3.Lerp(
            rectTransform.localScale,
            targetScale,
            Time.unscaledDeltaTime * scaleSpeed
        );

        rectTransform.anchoredPosition = Vector2.Lerp(
            rectTransform.anchoredPosition,
            targetPosition,
            Time.unscaledDeltaTime * scaleSpeed
        );
    }

    void CheckSelection()
    {
        if (EventSystem.current != null)
        {
            isSelected =
                EventSystem.current.currentSelectedGameObject == gameObject;
        }
        else
        {
            isSelected = false;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        isSelected = true;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        isSelected = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }

    void OnDisable()
    {
        isSelected = false;
        isHovered = false;

        if (rectTransform != null)
        {
            rectTransform.localScale = originalScale;
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
