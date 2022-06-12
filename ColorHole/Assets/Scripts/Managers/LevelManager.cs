using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    #region SerializeFields

    
    [SerializeField] private GameSettings m_gameSettings;
    [SerializeField] private Level m_level;
    [SerializeField] private GameObject m_holeGameObject;
    [SerializeField] private Slider m_sliderFirstStage;
    [SerializeField] private Slider m_sliderSecondStage;
    [SerializeField] private GameObject m_gate;
    [SerializeField] private CinemachineVirtualCamera m_cinemachineVirtualCamera;
    [SerializeField] private List<GameObject> m_wrongCubesFirstStage = new List<GameObject>();

    #endregion

    #region Private Fields

    private int firstStageValue;
    private int secondStageValue;
    private bool secondStageControl;
    private bool stageComplete;

    #endregion


    private void Start()
    {
        firstStageValue = m_level.FirstStageValue;
        secondStageValue = m_level.SecondStageValue;
        m_sliderFirstStage.maxValue = firstStageValue;
        m_sliderSecondStage.maxValue = secondStageValue;
    }

    private void Update()
    {
        OpenGate();
        MoveSecondStage();
    }

    /// <summary>
    /// This function increase sliders
    /// </summary>
    public void LevelProgress()
    {
        if (m_sliderFirstStage.value <= firstStageValue)
        {
            m_sliderFirstStage.value += 1;
        }

        if (m_sliderFirstStage.value == firstStageValue && m_sliderSecondStage.value <= secondStageValue)
        {
            m_sliderSecondStage.value += 1;
        }
    }

    /// <summary>
    /// This function control level complete or not
    /// </summary>
    public void LevelEndControl()
    {
        if (m_sliderSecondStage.value <= secondStageValue)
        {
            //Level Complete
        }
    }

    /// <summary>
    /// This function control game is over or not
    /// </summary>
    public void GameOver()
    {
        //Game Over
    }

    /// <summary>
    /// This function open the corridor gate 
    /// </summary>
    private void OpenGate()
    {
        if (m_sliderFirstStage.value < firstStageValue)
            return;

        m_gate.transform.DOMoveY(m_gameSettings.GateEndPosY, m_gameSettings.GateMoveDuration);
    }

    /// <summary>
    /// This function move hole from firt stage to second stage
    /// </summary>
    private void MoveSecondStage()
    {
        if (m_sliderFirstStage.value < firstStageValue)
            return;

        if (stageComplete)
            return;
        
        
        Invoke("MakeSecondStageControlTrue",0.8f);

        for (int i = 0; i < m_wrongCubesFirstStage.Count; i++)
        {
            m_wrongCubesFirstStage[i].gameObject.SetActive(false);
        }
        
        if (secondStageControl)
        {
            m_holeGameObject.transform.DOMoveX(0, 2f).OnComplete(() =>
            {
                m_holeGameObject.transform.DOMoveZ(16, 3f).OnComplete(
                    () =>
                    {
                        secondStageControl = false;
                        stageComplete = true;
                    });
                m_cinemachineVirtualCamera.transform.DOMoveZ(12, 3f);
            });
        }
    }

    private void MakeSecondStageControlTrue()
    {
        secondStageControl = true;
    }

    /// <summary>
    /// This function return second stage control
    /// </summary>
    /// <returns>secondStageControl</returns>
    public bool GetSecondStageControl()
    {
        return secondStageControl;
    }

    public bool GetStageComplete()
    {
        return stageComplete;
    }
}