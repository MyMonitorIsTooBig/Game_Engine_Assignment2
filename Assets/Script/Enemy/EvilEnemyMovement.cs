using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilEnemyMovement : Observer
{

    [SerializeField] evilSO enemyStats;



    private ScoreUI scoreUI;
    bool _playerDead = false;

    [SerializeField]
    GameObject player;
    [SerializeField]
    public int health = 5;

    bool run = false;


    PlayerManager _playerManager;

    public override void Notify(Subject subject)
    {
        _playerDead = subject.GetComponent<PlayerManager>().isDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreUI = FindObjectOfType<ScoreUI>();

        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.attachObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }

    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        scoreUI.OnEvilDeath();
        Destroy(gameObject);
    }


}
