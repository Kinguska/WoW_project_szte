using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public Rigidbody2D weaponProto = null;
    public float throwSpeed = 30.0f;
    public Transform firePoint = null;
    public int itemPoolSize = 20;
    public List<Rigidbody2D> itemPoolRight;
    public List<Rigidbody2D> itemPoolLeft;
    public List<Rigidbody2D> itemPoolUp;
    public List<Rigidbody2D> itemPoolDown;
    
    // Start is called before the first frame update
    void Start()
    {
        itemPoolRight = new List<Rigidbody2D>();
        
        for (int i = 0; i < itemPoolSize; i++)
        {
            Rigidbody2D itemCloneRight = Instantiate(weaponProto);
            itemCloneRight.gameObject.SetActive(false);
            itemPoolRight.Add(itemCloneRight);
        }
        
        itemPoolLeft = new List<Rigidbody2D>();
        
        for (int i = 0; i < itemPoolSize; i++)
        {
            Rigidbody2D itemClone = Instantiate(weaponProto, firePoint.position, Quaternion.Euler(0, 0, 180));
            //Rigidbody2D itemClone = Instantiate(weaponProto);
            itemClone.gameObject.SetActive(false);
            itemPoolLeft.Add(itemClone);
        }
        
        itemPoolUp = new List<Rigidbody2D>();
        
        for (int i = 0; i < itemPoolSize; i++)
        {
            Rigidbody2D itemClone = Instantiate(weaponProto, firePoint.position, Quaternion.Euler(0, 0, 90));
            //Rigidbody2D itemClone = Instantiate(weaponProto);
            itemClone.gameObject.SetActive(false);
            itemPoolUp.Add(itemClone);
        }
        
        itemPoolDown = new List<Rigidbody2D>();
        
        for (int i = 0; i < itemPoolSize; i++)
        {
            Rigidbody2D itemClone = Instantiate(weaponProto, firePoint.position, Quaternion.Euler(0, 0, 270));
            //Rigidbody2D itemClone = Instantiate(weaponProto);
            itemClone.gameObject.SetActive(false);
            itemPoolDown.Add(itemClone);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowWeapon();
        }
    }
    
    public void ThrowWeapon()
    {
        Vector3 forceRight = new Vector3(throwSpeed,0, 0);
        Vector3 forceUp = new Vector3(0, throwSpeed, 0);
        
        
        //itemClone.AddForce(force, ForceMode2D.Force);
        
        if (GetComponent<Character_movement>().facingRight)
        {
            Rigidbody2D itemCloneRight = GetItemFromPoolRight();
            itemCloneRight.transform.position = firePoint.position;
            itemCloneRight.gameObject.SetActive(true);
            
            itemCloneRight.AddForce(forceRight, ForceMode2D.Force);
        }
        
        else if (GetComponent<Character_movement>().FacingLeft)
        {
            Rigidbody2D itemCloneLeft = GetItemFromPoolLeft();
            itemCloneLeft.transform.position = firePoint.position;
            itemCloneLeft.gameObject.SetActive(true);
            
            itemCloneLeft.AddForce(-forceRight, ForceMode2D.Force);
        }
        
        else if (GetComponent<Character_movement>().FacingUpRight || GetComponent<Character_movement>().FacingUpLeft)
        {
            Rigidbody2D itemCloneUp = GetItemFromPoolUp();
            itemCloneUp.transform.position = firePoint.position;
            itemCloneUp.gameObject.SetActive(true);
            
            itemCloneUp.AddForce(forceUp, ForceMode2D.Force);
        }
        
        else if (GetComponent<Character_movement>().FacingDownRight || GetComponent<Character_movement>().FacingDownLeft)
        {
            Rigidbody2D itemCloneDown = GetItemFromPoolDown();
            itemCloneDown.transform.position = firePoint.position;
            itemCloneDown.gameObject.SetActive(true);
            
            itemCloneDown.AddForce(-forceUp, ForceMode2D.Force);
        }   
        
    }
    
    private Rigidbody2D GetItemFromPoolRight()
    {
        foreach (Rigidbody2D item in itemPoolRight)
        {
            if (!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
    
    private Rigidbody2D GetItemFromPoolLeft()
    {
        foreach (Rigidbody2D item in itemPoolLeft)
        {
            if (!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
    
    private Rigidbody2D GetItemFromPoolUp()
    {
        foreach (Rigidbody2D item in itemPoolUp)
        {
            if (!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
    
    private Rigidbody2D GetItemFromPoolDown()
    {
        foreach (Rigidbody2D item in itemPoolDown)
        {
            if (!item.gameObject.activeSelf)
            {
                return item;
            }
        }

        return null;
    }
}
