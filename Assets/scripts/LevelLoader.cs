using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadInstructions()
    {
        StartCoroutine(LoadLevelInstructions());
    }
    IEnumerator LoadLevelInstructions()
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(5);
    }

    public void LoadStart()
    {
        StartCoroutine(LoadLevelStart());
    }
    IEnumerator LoadLevelStart()
    {
        //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);

        //load scene
        SceneManager.LoadScene(1);
    }
}
