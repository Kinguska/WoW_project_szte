using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<Respawner> respawnableObjects;
    
    // Start is called before the first frame update
    void Awake()
    {
        respawnableObjects = new List<Respawner>();
    }

    public void Reset()
    {
        foreach (Respawner respawnableObject in respawnableObjects)
        {
            respawnableObject.Respawn();
        }
    }
    
    public void Register(Respawner respawnableObject)
    {
        respawnableObjects.Add(respawnableObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
