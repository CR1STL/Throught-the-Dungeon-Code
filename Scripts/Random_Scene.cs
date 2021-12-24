using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneAdvance
{
    public List<int> scenarios;

    private static SceneAdvance instance;

    public SceneAdvance()
    {
        scenarios = new List<int> { 5, 6, 7, 8, 9 };
    }

    public static SceneAdvance Instance
    {
        get => instance == null ? (instance = new SceneAdvance()) : instance;
    }
    public void LoadNextScene()
    {
        if (scenarios.Count == 0)
        {
            SceneManager.LoadScene(10);
            scenarios = new List<int> { 5, 6, 7, 8, 9 };
            return;
        }
        int randomIndex = UnityEngine.Random.Range(0, scenarios.Count);
        int currentScenario = scenarios[randomIndex];
        scenarios.RemoveAt(randomIndex);
        SceneManager.LoadScene(currentScenario);
    }
    public void Death_Scene()
    {
        SceneManager.LoadScene(0);
        scenarios = new List<int> { 5, 6, 7, 8, 9 };
        return;
    }
}