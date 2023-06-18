using UnityEngine;

public class CriticalKnife : MonoBehaviour
{
    private Vector2 dir = Vector2.up;
    private float speed = 3;
    
    void Update()
    {
        transform.Translate(dir * (Time.deltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
        }
        
        if (collision.CompareTag("Boss"))
        {
            EventManager.BossHit();
        }
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}