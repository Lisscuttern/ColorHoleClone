using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetComponent : MonoBehaviour
{
    #region Private Fields
    
    private Vector3 startPos;
    private Vector3 dist;
    
    #endregion
    
    void Start()
    {
        
        
    }
    
    void Update()
    {
    }
    
    
    void OnMouseDown()
    {
        startPos = Camera.main.WorldToScreenPoint(transform.position);
        dist = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, startPos.y, Input.mousePosition.z));
    }

    void OnMouseDrag()
    {
        Vector3 lastPos = new Vector3(Input.mousePosition.x, startPos.y, Input.mousePosition.z);
        transform.position = Camera.main.ScreenToWorldPoint(lastPos) + dist;
    }
    
    
}