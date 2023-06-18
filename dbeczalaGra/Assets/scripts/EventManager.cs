using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action BossHitEvent;
    public static Action EndGameEvent;
    public static Action PlayerHitEvent;
    public static Action WonGameEvent;

    public static void BossHit()
    {
        BossHitEvent?.Invoke();
    }
    
    public static void PlayerHit()
    {
        PlayerHitEvent?.Invoke();
    }
    
    

    public static void EndGame()
    {
        EndGameEvent?.Invoke();
    }

    public static void WonGame()
    {
        WonGameEvent?.Invoke();
    }

}