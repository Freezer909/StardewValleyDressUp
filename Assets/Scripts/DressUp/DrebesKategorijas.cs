using UnityEngine;

public class DrebesKategorijas : MonoBehaviour
{

    public GameObject[] pages;

    public void ShowPage(int pageIndex)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            pages[i].SetActive(false);
        }

        if (pageIndex >= 0 && pageIndex < pages.Length)
        {
            pages[pageIndex].SetActive(true);
        }
    }
}
