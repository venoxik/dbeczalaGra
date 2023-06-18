using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public float bossSpeed = 0.5f;
    
    public float smallMonsterSpeed = 1;
    public int minMonsterSpawn = 2;
    public int maxMonsterSpawn = 6;
    public int minKnifeRate = 2;
    public int maxKnifeRate = 6;
    public int bossHearts = 3;
    public int playerHearts = 3;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        EventManager.BossHitEvent += BossCondition;
        EventManager.PlayerHitEvent += PlayerCondition;
    }

    private void OnDisable()
    {
        EventManager.BossHitEvent -= BossCondition;
        EventManager.PlayerHitEvent -= PlayerCondition;
    }

    public void BossCondition()
    {

        bossHearts--;
        if (bossHearts == 0)
        {
            EventManager.WonGameEvent();
            Time.timeScale = 0;
        }
    }

    public void PlayerCondition()
    {
        playerHearts--;
        if (playerHearts == 0)
        {
            EventManager.EndGame();
            Time.timeScale = 0;
        }
    }
    

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
