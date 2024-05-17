using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawner : Respawner
{
    public int originalLife;
    private Animator animator;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        var playerHurt = GetComponent<PlayerHurt>();
        playerHurt.Start();
        originalLife = playerHurt.life;
        
        animator = this.GetComponent<Animator>();
    }
    
    public override void Respawn()
    {
        base.Respawn();
        GetComponent<PlayerHurt>().life = originalLife;
        transform.position = originalPosition;
        animator.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
