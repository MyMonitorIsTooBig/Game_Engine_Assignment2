using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUI : MonoBehaviour, EnemyObserver
{
    public int score = 0;
    public int maxScore = 3;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private static ScoreUI _instance;


    public static ScoreUI Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ScoreUI>();

                if (_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(ScoreUI).Name;
                    _instance = obj.AddComponent<ScoreUI>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this as ScoreUI;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if(scoreText == null && SceneManager.GetActiveScene().name == "SampleScene")
        {
            scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
        }
    }

    public void OnHealthChanged(int newHealth)
    {
        Debug.Log($"Enemy health changed: {newHealth}");
        // Optionally update the UI with new health
    }

    public void OnEnemyDeath()
    {
        score += Random.Range(1, maxScore);
    }

    public void OnEvilDeath()
    {
        score -= Random.Range(1, maxScore*2);
    }
    void OnGUI()
    {
        scoreText.text = score.ToString();
    }
}
