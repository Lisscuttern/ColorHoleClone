using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Level m_level;
    private int firstStageValue;
    private int secondStageValue;
    [SerializeField] private Slider m_sliderFirstStage;
    [SerializeField] private Slider m_sliderSecondStage;

    private void Start()
    {
        firstStageValue = m_level.FirstStageValue;
        secondStageValue = m_level.SecondStageValue;
        m_sliderFirstStage.maxValue = firstStageValue;
        m_sliderSecondStage.maxValue = secondStageValue;
    }



    public void LevelProgress()
    {
        if (m_sliderFirstStage.value <= firstStageValue)
        {
            m_sliderFirstStage.value += 1;
        }
        
    }
}