using UnityEngine;
using Random = UnityEngine.Random;

public class SmallMonster : MonoBehaviour
{
    Vector2 dir;
    private float distance = 0.8f;
    private float speed;
    private float targetTime;
    public GameObject knife;
    


    // Start is called before the first frame update
    void Start()
    {
        dir = transform.right;
        speed = GameManager.Instance.smallMonsterSpeed;
        targetTime = Random.Range(GameManager.Instance.minKnifeRate, GameManager.Instance.maxKnifeRate);
    }

    // Update is called once per frame
    void Update()
    {
        //Translate
        transform.Translate(dir * (Time.deltaTime * speed));

        targetTime -= Time.deltaTime;
        if (targetTime <= 0)
        {
            KnifeThrow();
            targetTime = Random.Range(GameManager.Instance.minKnifeRate, GameManager.Instance.maxKnifeRate);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.position += Vector3.down * distance;
            transform.Rotate(0,180,0);
        }
        
        if (collision.CompareTag("Player"))
        {
            EventManager.PlayerHitEvent();
            Destroy(gameObject);
        }
    }
    
    
    

    void KnifeThrow()
    {
        Instantiate(knife, transform.position, Quaternion.Euler(-180, 0, 0));
    }
    
    
    
    
}