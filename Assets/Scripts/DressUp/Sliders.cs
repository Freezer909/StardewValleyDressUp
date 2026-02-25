using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    public RectTransform characterRect;
    public RectTransform[] Clothes;    

    public Slider garumsSlider;
    public Slider platumsSlider;

    public Slider garumsSliderApgerbs;
    public Slider platumsSliderApgerbs;

    private Vector2 sakumaIzmers;

    void Start()
    {
        sakumaIzmers = characterRect.sizeDelta;

        garumsSlider.onValueChanged.AddListener(MainitCilvekaGarumu);
        platumsSlider.onValueChanged.AddListener(MainitCilvekaPlatumu);

        garumsSliderApgerbs.onValueChanged.AddListener(MainitApgerbaGarumu);
        platumsSliderApgerbs.onValueChanged.AddListener(MainitApgerbaPlatumu);

        foreach (RectTransform item in Clothes)
        {
            if (item != null) item.sizeDelta = sakumaIzmers;
        }
    }

    void MainitCilvekaGarumu(float vertiba)
    {
        characterRect.sizeDelta = new Vector2(characterRect.sizeDelta.x, vertiba);
    }

    void MainitCilvekaPlatumu(float vertiba)
    {
        characterRect.sizeDelta = new Vector2(vertiba, characterRect.sizeDelta.y);
    }

    void MainitApgerbaGarumu(float vertiba)
    {
        foreach (RectTransform item in Clothes)
        {
            if (item != null)
                item.sizeDelta = new Vector2(item.sizeDelta.x, vertiba);
        }
    }

    void MainitApgerbaPlatumu(float vertiba)
    {
        foreach (RectTransform item in Clothes)
        {
            if (item != null)
                item.sizeDelta = new Vector2(vertiba, item.sizeDelta.y);
        }
    }
}