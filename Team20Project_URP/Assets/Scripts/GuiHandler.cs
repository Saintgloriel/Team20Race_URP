using UnityEngine;
using UnityEngine.UI;

public class GuiHandler : MonoBehaviour
{
    [SerializeField] private Text p1ScoreText = null;// Счетчик очков для игрока 1
    [SerializeField] private Text p2ScoreText = null;// Счетчик очков для игрока 2

    [SerializeField] private Text p1MineCounterText = null;// Сергею! Счетчик мин для игрока 1
    [SerializeField] private Text p2MineCounterText = null;// Сергею! Счетчик мин для игрока 2

    [SerializeField] private GameObject p1CounterDisabled = null;// Сергею! Родительский объект с подложкой и текстом для состояния перезарядки мины для игрока 1
    [SerializeField] private GameObject p2CounterDisabled = null;// Сергею! Родительский объект с подложкой и текстом для состояния перезарядки мины для игрока 1

    [SerializeField] private Text p1MineCooldownCounterText = null;// Сергею! Счетчик перезарядки мины для игрока 1
    [SerializeField] private Text p2MineCooldownCounterText = null;// Сергею! Счетчик перезарядки мины для игрока 2

    [SerializeField] private GameObject winGamePopup = null;// Ссылка на попап победы на уровне
    [SerializeField] private Text winText = null;// Ссылка на компонент Text в попапе победы

    private GameController gameController = null;// Ссылка на компонент GameController

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();

        p1ScoreText.text = gameController.P1Scores.ToString();
        p2ScoreText.text = gameController.P2Scores.ToString();

        p1CounterDisabled.SetActive(false);
        p2CounterDisabled.SetActive(false);

        p1MineCounterText.text = "5";// Сергею! Тут заменить на корректную переменную таймера мины
        p2MineCounterText.text = "5";// Сергею! Тут заменить на корректную переменную таймера мины

        gameController.OnP1GameWin += GameController_OnP1GameWin;// Подписываемся на событие OnP1GameWin
        gameController.OnP2GameWin += GameController_OnP2GameWin;// Подписываемся на событие OnP2GameWin
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayersScores();
        UpdateMinesCounters();
    }

    private void UpdatePlayersScores()
    {
        p1ScoreText.text = gameController.P1Scores.ToString();
        p2ScoreText.text = gameController.P2Scores.ToString();
    }

    /// <summary>
    /// Обновляет счетчик количества мин у игрока
    /// </summary>
    private void UpdateMinesCounters()
    {
        // Тут добавить логику уменьшающую количество мин после использования
        p1MineCounterText.text = "5";// Сергею! Тут заменить на корректную переменную таймера мины
        p2MineCounterText.text = "5";// Сергею! Тут заменить на корректную переменную таймера мины
    }

    // Обработка события OnP1GameWin
    private void GameController_OnP1GameWin(object sender, System.EventArgs e)
    {
        winText.text = $"Победил Игрок 1!\nОн первым набрал {gameController.GoalScores} очков!";
        winGamePopup.SetActive(true);
        gameController.OnP1GameWin -= GameController_OnP1GameWin;// Отписываемся от события OnP1GameWin
    }

    // Обработка события OnP2GameWin
    private void GameController_OnP2GameWin(object sender, System.EventArgs e)
    {
        winText.text = $"Победил Игрок 2!\nОн первым набрал {gameController.GoalScores} очков!";
        winGamePopup.SetActive(true);
        gameController.OnP2GameWin -= GameController_OnP2GameWin;// Отписываемся от события OnP2GameWin
    }
}
