using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("References")]
    public RectTransform panelHolder;
    public RectTransform initialPanel;

    [Header("Settings")]
    public float moveDuration = 0.5f;

    private Stack<RectTransform> history = new Stack<RectTransform>();
    private Coroutine activeMoveRoutine;

    void Start()
    {
        if (initialPanel != null)
        {
            panelHolder.anchoredPosition = -initialPanel.anchoredPosition;
            history.Push(initialPanel);
        }
    }

    public void GoToPanel(RectTransform targetPanel)
    {
        history.Push(targetPanel);
        MoveContainer(-targetPanel.anchoredPosition);
    }

    public void GoBack()
    {
        if (history.Count <= 1) return;

        history.Pop();
        RectTransform previousPanel = history.Peek();

        MoveContainer(-previousPanel.anchoredPosition);
    }

    private void MoveContainer(Vector2 targetPos)
    {

        if (activeMoveRoutine != null)
            StopCoroutine(activeMoveRoutine);

        activeMoveRoutine = StartCoroutine(SmoothMove(targetPos));
    }

    private IEnumerator SmoothMove(Vector2 targetPos)
    {
        Vector2 startPos = panelHolder.anchoredPosition;
        float elapsed = 0;

        while (elapsed < moveDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / moveDuration;
            float easeOut = 1 - (1 - t) * (1 - t);

            panelHolder.anchoredPosition = Vector2.Lerp(startPos, targetPos, easeOut);
            yield return null;
        }

        panelHolder.anchoredPosition = targetPos;
        activeMoveRoutine = null;
    }
}