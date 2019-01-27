using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI highScoreText;
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

    public void SetScore(int score)
    {
        scoreText.SetText($"Score: {score}");
    }

    public void SetHighScore(int score)
    {
        highScoreText.SetText($"High Score: {score}");
    }
}
