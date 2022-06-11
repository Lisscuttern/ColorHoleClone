using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleComponent : MonoBehaviour
{
    #region SerializeFields
    
    [Header("Movement Limits")] 
    [SerializeField] private float xClamp;
    [SerializeField] private float zClamp;
    [SerializeField] Camera mainCamera;
    #endregion
    
    #region Private Fields

    private Vector3 _mOffset;
    private float _zCoordinate;
    private float _yPositionAtStart;
    
    #endregion
    

    void Update()
    {
        Movement();
    }

    /// <summary>
    /// This function return user touch point on screen
    /// </summary>
    /// <returns>touchPoint</returns>
    private Vector3 GetMouseWorldPos()
    {
        Vector3 touchPoint = Input.mousePosition;
        touchPoint.z = _zCoordinate;
        return mainCamera.ScreenToWorldPoint(touchPoint);
    }

    
    /// <summary>
    /// Thşs function help for black hole movement
    /// </summary>
    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 currentPosition = gameObject.transform.position;
            _zCoordinate = mainCamera.WorldToScreenPoint(currentPosition).z;
            _mOffset = currentPosition - GetMouseWorldPos();
        }

        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(
                Mathf.Clamp(GetMouseWorldPos().x + _mOffset.x, -xClamp, xClamp),
                -1.98f,
                Mathf.Clamp(GetMouseWorldPos().z + _mOffset.z, -zClamp, zClamp));
        }
    }
}