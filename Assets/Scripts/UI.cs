using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public CanvasGroup StartGameCanvasGroup;
    public CanvasGroup WaveWarningCanvasGroup;
    public CanvasGroup DragonWarningCanvasGroup;
    public CanvasGroup GameOverCanvasGroup;
    public CanvasGroup PauseCanvasGroup;
    public Text LevelText;
    public Text LivesText;
    public GameLogic GameLogic;
    public Image ObjectiveColor;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetGame()
    {
        StartGameCanvasGroup.alpha = 1;
        WaveWarningCanvasGroup.alpha = 0;
        DragonWarningCanvasGroup.alpha = 0;
        GameOverCanvasGroup.alpha = 0;
        PauseCanvasGroup.alpha = 0;
    }

    public void StartGame()
    {
        StartGameCanvasGroup.alpha = 0;
    }

    public void PauseGame()
    {
        PauseCanvasGroup.alpha = 1;
    }

    public void Restart()
    {
        ResetGame();
    }

    public void GameOverScreen()
    {
        GameOverCanvasGroup.alpha = 1;
    }

    public void Quit()
    {
        ResetGame();
    }

    public void UpdateObjective()
    {

    }

    public void UpdateLivesUI(int lives)
    {
        LivesText.text = "Lives: " + lives;
    }

    public void UpdateLevelUI(int level)
    {
        level = GameLogic.UpdateLevel();
        LevelText.text = "Level: " + level;
    }
}
