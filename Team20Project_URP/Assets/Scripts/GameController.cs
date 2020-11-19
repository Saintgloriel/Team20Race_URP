using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] p1Checkpoints = null;
    /// <summary>
    /// Массив чекпоинтов для игрока 1
    /// </summary>
    public GameObject[] P1Checkpoints { get { return p1Checkpoints; } }

    [SerializeField] private GameObject[] p2Checkpoints = null;
    /// <summary>
    /// Массив чекпоинтов для игрока 2
    /// </summary>
    public GameObject[] P2Checkpoints { get { return p2Checkpoints; } }

    private int p1Scores = 0;
    /// <summary>
    /// Текущее количество игрока 1
    /// </summary>
    public int P1Scores { get { return p1Scores; } set { p1Scores = value; } }

    private int p2Scores = 0;
    /// <summary>
    /// Текущее количество игрока 2
    /// </summary>
    public int P2Scores { get { return p2Scores; } set { p2Scores = value; } }

    [SerializeField] private int pointsPerLap = 2;
    /// <summary>
    /// Количество очкоз выдаваемое за прохождение круга
    /// </summary>
    public int PointsPerLap { get { return pointsPerLap; } }

    private int goalScores = 10;
    /// <summary>
    /// Количество очков, необходимое для победы в гонке
    /// </summary>
    public int GoalScores { get { return goalScores; } }

    private bool isGamePaused = false;// Находится ли игра на паузе

    public event EventHandler OnP1GameWin;// Событие на победу игрока
    public event EventHandler OnP2GameWin;// Событие на победу игрока

    private void Start()
    {
        Time.timeScale = 1;// Костылик
    }

    // Update is called once per frame
    private void Update()
    {
        CheckWinner();
    }

    /// <summary>
    /// Проверяет есть ли победитель
    /// </summary>
    private void CheckWinner()
    {
        if (p1Scores >= goalScores)
        {
            PauseGame();
            OnP1GameWin?.Invoke(this, EventArgs.Empty);
        }

        if (p2Scores >= goalScores)
        {
            PauseGame();
            OnP2GameWin?.Invoke(this,EventArgs.Empty);
        }
    }

    /// <summary>
    /// Ставит игру на паузу
    /// </summary>
    private void PauseGame()
    {
        if (!isGamePaused)
        {
            isGamePaused = true;
            Time.timeScale = 0;
        }
    }

    /// <summary>
    /// Снимает игру с паузы
    /// </summary>
    private void ResumeGame()
    {
        if (isGamePaused)
        {
            isGamePaused = false;
            Time.timeScale = 1;
            Debug.Log("Resumed");
        }
    }
}
