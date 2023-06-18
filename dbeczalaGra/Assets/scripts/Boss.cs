using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject smallMonster;

    private float targetTime = 2;
    Vector2 dir;
    private float speed;
    public GameObject fireMeteor;

    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        speed = GameManager.Instance.bossSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * (Time.deltaTime * speed));
        
        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            SpawnMonster();
            FireMeteorThrow();
            targetTime = Random.Range(GameManager.Instance.minMonsterSpawn,GameManager.Instance.maxMonsterSpawn);
        }
    }

    void SpawnMonster()
    {
        Instantiate(smallMonster, transform.position, Quaternion.identity);
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.Rotate(0,180,0);
            speed = Random.Range(0.5f, 3);
        }
    }
    
    void FireMeteorThrow()
    {
        Instantiate(fireMeteor, transform.position, Quaternion.Euler(180, -100, 0));
    }
    
}