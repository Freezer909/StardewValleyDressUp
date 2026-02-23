using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public RectTransform characterRect;

    public Slider garumsSlider;
    public Slider platumsSlider;

    private Vector2 sakumaIzmers;

    void Start()
    {
        sakumaIzmers = characterRect.sizeDelta;

        garumsSlider.onValueChanged.AddListener(MainitGarumu);
        platumsSlider.onValueChanged.AddListener(MainitPlatumu);
    }

    void MainitGarumu(float vertiba)
    {
        characterRect.sizeDelta = new Vector2(characterRect.sizeDelta.x, vertiba);
    }

    void MainitPlatumu(float vertiba)
    {
        characterRect.sizeDelta = new Vector2(vertiba, characterRect.sizeDelta.y);
    }
}