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

    public void GameOver()
    {
        StartCoroutine(WaitBeforeGameOver());
    }

    private IEnumerator WaitBeforePlay() {
        yield return new WaitForSeconds(1);
        Debug.Log(">> Play!");
        SceneManager.LoadScene(1);
    }

    private IEnumerator WaitBeforeQuit() {
        yield return new WaitForSeconds(1);
        Debug.Log(">> Quit!");
        Application.Quit();
    }

    private IEnumerator WaitBeforeGameOver() {
        yield return new WaitForSeconds(1);
        Debug.Log(">> GameOver!");
        SceneManager.LoadScene(2);
    }
}
