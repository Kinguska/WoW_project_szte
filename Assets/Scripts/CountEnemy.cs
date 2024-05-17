using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemy : MonoBehaviour
{
    public List<Respawner> respawnableObjectscopy;
    public int enemyCount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        respawnableObjectscopy = GetComponent<RespawnManager>().respawnableObjects;
        enemyCount = 7;
    }
    

    public void DecreaseEnemyCount()
    {
        enemyCount--;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
