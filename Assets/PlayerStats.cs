using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;
    public static int Lives;
    public int StartLives = 20;

    private void Start()
    {
        Money = startMoney;
        Lives = StartLives;
    }
}
