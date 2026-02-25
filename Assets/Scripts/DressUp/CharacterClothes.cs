using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterClothes : MonoBehaviour, IDropHandler
{
    private Dictionary<string, Drag> equippedItems = new Dictionary<string, Drag>();

    public void OnDrop(PointerEventData eventData)
    {
        Drag draggedItem = eventData.pointerDrag.GetComponent<Drag>();
        if (draggedItem != null)
        {
            HandleEquip(draggedItem);
        }
    }

    public void OnDropManual(Drag draggedItem)
    {
        HandleEquip(draggedItem);
    }

    private void HandleEquip(Drag draggedItem)
    {
        string type = draggedItem.itemType;

        if (equippedItems.ContainsKey(type) && equippedItems[type] != draggedItem)
        {
            equippedItems[type].ReturnToOriginalParent();
        }

        equippedItems[type] = draggedItem;

        draggedItem.EquipToCharacter(this.transform);
    }

    public void UnregisterItem(string type)
    {
        if (equippedItems.ContainsKey(type))
        {
            equippedItems.Remove(type);
        }
    }
}