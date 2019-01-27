using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScreen : MonoBehaviour
{
    [SerializeField]
    private Animator deathAnimator;

    public void RestartScene()
    {
        var loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    public void ShowDeathAnimation()
    {
        deathAnimator.SetBool("ShouldShow", true);
    }
}
