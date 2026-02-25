using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        StartCoroutine(LoadWithDelay(sceneName));
    }

    public IEnumerator LoadWithDelay(string sceneName)
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}