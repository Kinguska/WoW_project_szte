using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveByTime : MonoBehaviour
{
    public float timeLimit = 1.5f;
    public float timeEllapsed = 0.0f;
    
    void OnEnable()
    {
        timeEllapsed = 0.0f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeEllapsed += Time.deltaTime;
        
        if (timeEllapsed > timeLimit)
        {
            gameObject.SetActive(false);
        }
    }
}
