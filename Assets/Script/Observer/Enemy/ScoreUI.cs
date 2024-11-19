using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : singleton<ScoreUI>, EnemyObserver
{
    public int score = 0;
    public int maxScore = 3;

    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GameObject.Find("scoreText").GetComponent<TextMeshProUGUI>();
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
