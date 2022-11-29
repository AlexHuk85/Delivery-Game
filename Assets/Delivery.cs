using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage = false; 
    [SerializeField] float timer = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 notPackageColor = new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer;
    
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        // If thing is package
        // print " package picked up"
        
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, timer);
            spriteRenderer.color = hasPackageColor;
        }

        if (other.tag == "Target" && hasPackage)
        {
            Debug.Log("Delivered package");
            hasPackage = false;
            spriteRenderer.color = notPackageColor;
        }
    }
}
