using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D myCollider;
    public TouchController myTouch;
    public GameObject knife;
    public GameObject superKnife;
    private int knifeThrowCount; // Licznik rzutów nożem
    private float knifeThrowCooldown = 1f; // Czas opóźnienia między rzutami
    private float currentCooldownTimer = 0f; // Aktualny licznik czasu

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        knifeThrowCount = 0; // Inicjalizacja licznika na 0
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldownTimer > 0f)
        {
            currentCooldownTimer -= Time.deltaTime; // Odejmowanie czasu od licznika
        }

        if (Input.touchCount > 0)
        {
            if (myCollider == Physics2D.OverlapPoint(myTouch.endPos) && Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (currentCooldownTimer <= 0f) // Sprawdzenie, czy upłynął czas cooldownu
                {
                    KnifeThrow();
                    knifeThrowCount++; // Inkrementacja licznika po każdym rzucie nożem

                    if (knifeThrowCount >= 5) // Sprawdzenie, czy liczba rzutów nożem jest większa lub równa 5
                    {
                        CriticalKnifeThrow();
                        knifeThrowCount = 0; // Zresetowanie licznika
                    }

                    currentCooldownTimer = knifeThrowCooldown; // Ustawienie czasu opóźnienia
                }
            }
        }
    }

    void KnifeThrow()
    {
        Instantiate(knife, transform.position + new Vector3(0, 1), Quaternion.Euler(0, 0, 0));
    }

    void CriticalKnifeThrow()
    {
        Instantiate(superKnife, transform.position + new Vector3(0, 1), Quaternion.Euler(0, 0, 0));
    }
}