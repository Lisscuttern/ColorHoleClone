using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleComponent : MonoBehaviour
{
    #region SerializeFields
    

    [SerializeField] Camera mainCamera;

    [SerializeField] private LevelManager m_levelManager;
    [SerializeField] private Level m_level;
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
        if (m_levelManager.GetSecondStageControl())
            return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 currentPosition = gameObject.transform.position;
            _zCoordinate = mainCamera.WorldToScreenPoint(currentPosition).z;
            _mOffset = currentPosition - GetMouseWorldPos();
        }

        if (Input.GetMouseButton(0))
        {
            if (m_levelManager.GetStageComplete())
            {
                transform.position = new Vector3(
                    Mathf.Clamp(GetMouseWorldPos().x + _mOffset.x, -m_level.FirstStageXLimit, m_level.FirstStageXLimit),
                    -1.98f,
                    Mathf.Clamp(GetMouseWorldPos().z + _mOffset.z, m_level.SecondStageMinZLimit, m_level.SecondStageMaxZLimit));
            }
            else
            {
                transform.position = new Vector3(
                    Mathf.Clamp(GetMouseWorldPos().x + _mOffset.x, -m_level.FirstStageXLimit, m_level.FirstStageXLimit),
                    -1.98f,
                    Mathf.Clamp(GetMouseWorldPos().z + _mOffset.z, -m_level.FirstStageZLimit, m_level.FirstStageZLimit));
            }
            
        }
    }
}