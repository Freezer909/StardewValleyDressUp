using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemType;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Vector3 originalPosition;

    [HideInInspector] public bool isEquipped = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent;
        originalPosition = transform.localPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

        if (isEquipped)
        {
            GetComponentInParent<CharacterClothes>().UnregisterItem(itemType);
        }

        transform.SetParent(GetComponentInParent<Canvas>().transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;

        GameObject objectUnderMouse = eventData.pointerEnter;
        bool landedOnGuy = objectUnderMouse != null && objectUnderMouse.GetComponent < CharacterClothes>() != null;

        if (!landedOnGuy)
        {
            ReturnToOriginalParent();
        }
    }

    public void EquipToCharacter(Transform characterTransform)
    {
        isEquipped = true;
        transform.SetParent(characterTransform);
    }

    public void ReturnToOriginalParent()
    {
        isEquipped = false;
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;
    }
}