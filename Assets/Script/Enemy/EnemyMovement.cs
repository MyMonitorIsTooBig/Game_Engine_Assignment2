using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Observer
{

    [SerializeField] enemySO enemyStats;



    private ScoreUI scoreUI;
    bool _playerDead = false;

    [SerializeField]
    GameObject player;
    [SerializeField]
    Rigidbody rb;
    public int health = 5;

    bool run = false;

    Vector3 _playerPosition;

    PlayerManager _playerManager;

    CameraFollow _camera;

    float _distPlayer = 0.0f;
    Vector3 normalDist;
    public override void Notify(Subject subject)
    {
        _playerDead = subject.GetComponent<PlayerManager>().isDead;
        _playerPosition = subject.GetComponent<PlayerManager>().currentPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreUI = FindObjectOfType<ScoreUI>();

        _playerManager = FindObjectOfType<PlayerManager>();
        _playerManager.attachObserver(this);

        _camera = GameObject.Find("camParent").GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerDead && player!= null)
        {
            _distPlayer = Vector3.Magnitude(_playerPosition - transform.position);
            if (_distPlayer < enemyStats._distance)
            {
                run = true;
            }
            else
            {
                run = false;
            }
        }
        if (health <= 0)
        {
            Die();
        }

        if (run)
        {
            normalDist = Vector3.Normalize(_playerPosition - transform.position);
            rb.AddForce(-normalDist * enemyStats._speed * 10f * Time.deltaTime, ForceMode.Force);
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
        //_camera.triggerAnimation("camGood");
        scoreUI.OnEnemyDeath();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.AddForce(transform.up.normalized * 5 * 200f, ForceMode.Force);
        }
    }

}
