using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    public int life = 2;
    private Animator animator;
    public CountEnemy countEnemy;
    public ScoreManager scoreManager;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        countEnemy = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CountEnemy>();
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            collision.gameObject.SetActive(false);
            life--;
            
            if (life <= 0)
            {
                animator.SetBool("isDead", true);
                countEnemy.DecreaseEnemyCount();
                if (animator.gameObject.CompareTag("BigEnemy"))
                {
                    scoreManager.IncreaseScore(500);
                }
                else
                {
                    scoreManager.IncreaseScore(100);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
