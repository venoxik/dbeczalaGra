using UnityEngine;

public class FireMeteor : MonoBehaviour

{
    private Vector2 dir = Vector2.up;
    private float speed = 2;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * (Time.deltaTime * speed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventManager.PlayerHitEvent();
            Destroy(gameObject);
        }
    }

    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
