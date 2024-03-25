using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �������� ��������� ��� ������� � GameManager �� ������ ��������
    public static GameManager Instance;

    private int _totalEnemies; // ����� ������ �� ������
    private int _killedEnemies; // ������� ������ ��� �����
    public GameObject  GameScreenToWin;

    // ���� ����� ���������� ��� �������� �������
    private void Awake()
    {
        // ���� ������� GameManager ���, �� ���� ���������� ��������
        if (Instance == null)
        {
            Instance = this;
           
        }
        else
        {
            Destroy(gameObject); // ���� ��� ���� GameManager, ������� ����
        }
        GameScreenToWin.SetActive(false);
    }

    private void Start()
    {

        // ������� ���� ������ �� ������ � ������� ��
        _totalEnemies = FindObjectsOfType<enemyAI>().Length; // Enemy - ��� ��� ������ �����
    }

    // ����������, ����� ���� �������
    public void OnEnemyKilled()
    {
        _killedEnemies++; // ����������� ���������� ������ ������
        CheckVictoryCondition();
    }

    // ���������, �������� �� ��
    private void CheckVictoryCondition()
    {
        if (_killedEnemies >= _totalEnemies)
        {
            // ���� ����� ��� �����, ���������� ��� ����� �������
            Debug.Log("������! ��� ����� �����.");
            GameScreenToWin.SetActive(true);
        }
    }
}
