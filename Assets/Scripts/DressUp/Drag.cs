using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemType; // Set this to "Hair", "Shirt", etc.

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform originalParent;
    private Vector3 originalPosition;
    private SFX_Script sfxScript;

    [HideInInspector] public bool isEquipped = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent;
        originalPosition = transform.localPosition;

        sfxScript = Object.FindFirstObjectByType<SFX_Script>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;

        if (tag == "Israel" && sfxScript != null)
        {
            sfxScript.PlaySFX(2);
        }
        else
        {
            sfxScript?.PlaySFX(0);
        }

        if (isEquipped)
        {
            CharacterClothes theGuy = Object.FindFirstObjectByType<CharacterClothes>();
            if (theGuy != null) theGuy.UnregisterItem(itemType);
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

        bool landedOnTarget = false;
        if (objectUnderMouse != null)
        {
            if (objectUnderMouse.GetComponent<CharacterClothes>() != null ||
                objectUnderMouse.GetComponent<Drag>() != null)
            {
                landedOnTarget = true;
            }
        }

        if (landedOnTarget)
        {
            CharacterClothes theGuy = Object.FindFirstObjectByType<CharacterClothes>();
            if (theGuy != null)
            {
                theGuy.OnDropManual(this);
            }
        }
        else
        {
            ReturnToOriginalParent();
        }
    }

    public void EquipToCharacter(Transform characterTransform)
    {
        isEquipped = true;

        Vector3 currentScreenPos = transform.position;

        transform.SetParent(characterTransform);

        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

        transform.position = currentScreenPos;
    }

    public void ReturnToOriginalParent()
    {
        isEquipped = false;
        transform.SetParent(originalParent);
        transform.localPosition = originalPosition;
    }
}