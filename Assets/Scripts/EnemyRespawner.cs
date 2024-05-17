using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawner : Respawner
{
    public int originalLife;
    private Animator animator;
    public CountEnemy countEnemy;
    private GameObject bigEnemy;
    
    
    void Awake()
    {
        bigEnemy = GameObject.FindGameObjectWithTag("BigEnemy"); 
    }
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        originalLife = GetComponent<EnemyDestroy>().life;
        animator = this.GetComponent<Animator>();
        countEnemy = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CountEnemy>();
    }

    private void FixedUpdate()
    {
        
    }

    public override void Respawn()
    {
        base.Respawn();
        GetComponent<EnemyDestroy>().life = originalLife;
        transform.position = originalPosition;
        animator.SetBool("isDead", false);
        countEnemy.enemyCount = 7;
    }

    // Update is called once per frame
    void Update()
    {
        if (countEnemy.enemyCount == 2)
        {
            bigEnemy.SetActive(true);
            countEnemy.enemyCount = 1;
        }
        else if (countEnemy.enemyCount > 2)
        {
            bigEnemy.SetActive(false);
        }
    }
}
