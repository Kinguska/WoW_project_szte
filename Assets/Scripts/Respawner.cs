using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Vector3 originalPosition;
    
    private RespawnManager respawnManager;
    
    private bool originalActive;
    
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        originalPosition = transform.position;
        originalActive = gameObject.activeSelf;
        respawnManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<RespawnManager>();
        respawnManager.Register(this);
    }
    
    
    public virtual void Respawn()
    {
        transform.position = originalPosition;
        gameObject.SetActive(originalActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
