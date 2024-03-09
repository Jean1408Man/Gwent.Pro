using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    private bool IsDragging= false;
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void StartDrag()
    {
        IsDragging = true;
    }
    public void EndDrag()
    {
        IsDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }
}
