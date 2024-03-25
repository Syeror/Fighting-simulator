using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Синглтон экземпляр для доступа к GameManager из других скриптов
    public static GameManager Instance;

    private int _totalEnemies; // Всего врагов на уровне
    private int _killedEnemies; // Сколько врагов уже убито
    public GameObject  GameScreenToWin;

    // Этот метод вызывается при создании объекта
    private void Awake()
    {
        // Если другого GameManager нет, то этот становится основным
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject); // Если уже есть GameManager, удаляем этот
        }
        GameScreenToWin.SetActive(false);
    }

    private void Start()
    {

        // Находим всех врагов на уровне и считаем их
        _totalEnemies = FindObjectsOfType<enemyAI>().Length; // Enemy - это ваш скрипт врага
    }

    // Вызывается, когда враг умирает
    public void OnEnemyKilled()
    {
        _killedEnemies++; // Увеличиваем количество убитых врагов
        CheckVictoryCondition();
    }

    // Проверяем, победили ли мы
    private void CheckVictoryCondition()
    {
        if (_killedEnemies >= _totalEnemies)
        {
            // Если убиты все враги, показываем что игрок победил
            Debug.Log("Победа! Все враги убиты.");
            GameScreenToWin.SetActive(true);
        }
    }
}
