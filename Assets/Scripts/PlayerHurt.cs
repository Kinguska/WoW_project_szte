using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurt : MonoBehaviour
{
    public int life = 1;
    
    public Transform fallDeathPosition;
    private Animator animator;
    public ScoreManager scoreManager;
   
    // Start is called before the first frame update
    public void Start()
    {
        animator = this.GetComponent<Animator>();
        scoreManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ScoreManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            
            if (life <= 0)
            {
                animator.SetBool("isDead", true);
                scoreManager.ScoreReset();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < fallDeathPosition.position.y)
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>().Reset();
        }
    }
}
