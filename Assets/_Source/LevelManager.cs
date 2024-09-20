using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager main;

    public static GameState CurrentGameState;
    public Transform startPoint;
    public Transform[] path;

    public int Money;

    private void Awake()
    {
        main = this;
    }
    private void Start()
    {
        Money = 100;
        CurrentGameState = GameState.InGame;
    }
    public void IncreaseMoney(int amount)
    {
        Money += amount;
    }
    public bool SpendMoney(int amount)
    {
        if(amount <= Money)
        {
            Money -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}
public enum GameState { InGame, Lose, Win}
