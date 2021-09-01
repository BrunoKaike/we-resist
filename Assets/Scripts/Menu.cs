using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(WaitBeforePlay());
    }

    public void QuitGame()
    {
        StartCoroutine(WaitBeforeQuit());
    }

    private IEnumerator WaitBeforePlay() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator WaitBeforeQuit() {
        yield return new WaitForSeconds(1);
        Debug.Log(">> Quit!");
        Application.Quit();
    }
}
