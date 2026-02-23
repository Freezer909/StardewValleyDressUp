using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{

    public GameObject CharacterImage;
    public Sprite[] CharacterSprites;

    public void ChangeCharacterImage(int index)
    {
        CharacterImage.GetComponent<Image>().sprite = CharacterSprites[index];
    }
}
