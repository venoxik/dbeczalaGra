using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    public GameObject heartObj;
    public GameObject heartParent;
    
    public GameObject heartObj2;
    public GameObject heartParent2;

    public Sprite emptyHeart;

    private GameObject[] playerHearts;
    private GameObject[] hearts;
    private int i;
    private int j;

    public GameObject endPanel;
    public GameObject wonGamePanel;
    
    private void OnEnable()
    {
        EventManager.BossHitEvent += DisableHeart;
        EventManager.PlayerHitEvent += DisableHeartPlayer;
        EventManager.EndGameEvent += EndGame;
        EventManager.WonGameEvent += WonGame;
    }

    private void OnDisable()
    {
        EventManager.BossHitEvent -= DisableHeart;
        EventManager.PlayerHitEvent -= DisableHeartPlayer;
        EventManager.EndGameEvent -= EndGame;
        EventManager.WonGameEvent -= WonGame;
    }

    // Start is called before the first frame update
    void Start()
    {
        //boss
        int iterationCount = GameManager.Instance.bossHearts;
        for (int i = 1; i < iterationCount; i++)
        {
            Instantiate(heartObj, heartParent.transform);
            
        }
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        i = hearts.Length - 1;
       
        //player
        int iterationCount2 = GameManager.Instance.playerHearts;
        for (int i = 1; i < iterationCount2; i++)
        {
            Instantiate(heartObj2, heartParent2.transform);
        }
        playerHearts = GameObject.FindGameObjectsWithTag("PlayerHearts");
        j = playerHearts.Length - 1;
        
        
    }

    void DisableHeart()
    {
        hearts[i].GetComponent<Image>().sprite = emptyHeart;
        i -= 1;
    }
    
    void DisableHeartPlayer()
    {
        playerHearts[j].GetComponent<Image>().sprite = emptyHeart;
        j -= 1;
    }


    void EndGame()
    {
        endPanel.SetActive(true);
    }

    void WonGame()
    {
        wonGamePanel.SetActive(true);
    }

}
