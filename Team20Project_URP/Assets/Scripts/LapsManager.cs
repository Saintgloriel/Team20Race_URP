using UnityEngine;

public class LapsManager : MonoBehaviour
{
    private GameController gameController;

    private int currentCheckpointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        currentCheckpointIndex = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        CheckCheckpoint(other);
    }

    /// <summary>
    /// Проверяет пройден ли круг и начисляет очки за успешное прохождение
    /// </summary>
    /// <param name="other">Коллайдер триггер с которым проверяется столкновение</param>
    private void CheckCheckpoint(Collider other)
    {
        int contactedColliderIndex = GetCheckpointIndex(other);

        if (currentCheckpointIndex < contactedColliderIndex)
        {
            currentCheckpointIndex = contactedColliderIndex;
        }
        else if (contactedColliderIndex == 0 &&
                 currentCheckpointIndex == gameController.P1Checkpoints.Length - 1)
        {
            currentCheckpointIndex = contactedColliderIndex;
            AddScores();
        }
    }

    /// <summary>
    /// Возвращает индекс чекпоинта с которым произошло столкновение
    /// </summary>
    /// <param name="other">Коллайдер триггер с которым проверяется столкновение</param>
    /// <returns></returns>
    private int GetCheckpointIndex(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            for (int i = 0; i < gameController.P1Checkpoints.Length; i++)
            {
                if (gameController.P1Checkpoints[i].name == other.gameObject.name)
                {
                    return i;
                }
            }
        }

        if (gameObject.tag == "Player2")
        {
            for (int i = 0; i < gameController.P2Checkpoints.Length; i++)
            {
                if (gameController.P2Checkpoints[i].name == other.gameObject.name)
                {
                    return i;
                }
            }
        }
        return 0;

    }

    /// <summary>
    /// Начисляет очки за прошедший круг
    /// </summary>
    private void AddScores()
    {
        if (gameObject.tag == "Player")
        {
            if (gameController.P1Scores < gameController.GoalScores)
            {
                gameController.P1Scores += gameController.PointsPerLap;
            }
            else
            {
                gameController.P1Scores = gameController.GoalScores;
            }
        }

        if (gameObject.tag == "Player2")
        {
            if (gameController.P2Scores < gameController.GoalScores)
            {
                gameController.P2Scores += gameController.PointsPerLap;
            }
            else
            {
                gameController.P2Scores = gameController.GoalScores;
            }
        }
    }
}
