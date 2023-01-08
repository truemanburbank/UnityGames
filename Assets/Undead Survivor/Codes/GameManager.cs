using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public PoolManager pool;
    public Player player;

    void Awake()
    {
        instance = this;    
    }

    void Update()
    {
        gameTime += Time.deltaTime; // deltaTime: 한 프레임이 소비한 시간

        if(gameTime > maxGameTime)
        {
            gameTime = maxGameTime;
        }
    }
}
