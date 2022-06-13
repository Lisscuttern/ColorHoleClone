using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelServices : MonoBehaviour
{
    #region SerializeFields

    [SerializeField] private GameSettings m_gameSettings;

    #endregion

    #region Private Fields

    public int levelNumber;

    #endregion

    private void Start()
    {
        InitializeLevel();
    }

    /// <summary>
    /// This function initialize current level
    /// </summary>
    public void InitializeLevel()
    {
        levelNumber = PlayerPrefs.GetInt("LevelNumber");
        Instantiate(m_gameSettings.Levels[levelNumber].Prefab, Vector3.zero, Quaternion.identity);
    }

    /// <summary>
    /// This function help for getting next level
    /// </summary>
    public void NextLevel()
    {
        if (levelNumber >= m_gameSettings.Levels.Length - 1)
            return;

        levelNumber++;
        PlayerPrefs.SetInt("LevelNumber", levelNumber);
        InitializeLevel();
        LoadLevel();
    }
    
    /// <summary>
    /// this function help for play again the same level
    /// </summary>
    public void TryLevel()
    {
        if (levelNumber >= m_gameSettings.Levels.Length - 1)
            return;
        InitializeLevel();
        LoadLevel();
    }

    /// <summary>
    /// This function load scene with current level
    /// </summary>
    private void LoadLevel()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    
}