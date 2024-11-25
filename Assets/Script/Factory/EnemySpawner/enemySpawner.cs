using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Threading;

public class enemySpawner : Spawner
{
    [SerializeField]
    List<Transform> _spawns = new List<Transform>();

    [SerializeField]
    GameObject _enemyPrefab;
    [SerializeField]
    GameObject _evilEnemyPrefab;
    ScoreUI scoreManager;

    int randomNum;

    public bool started = false;

    PlayerManager _playerManager;


    public bool _freakyMode = false;
    [SerializeField]int _freakySpawnAmt = 20;

    int enemyType;

    
    void Start()
    {
        //scoreManager = GetComponent<ScoreUI>();

        scoreManager = FindObjectOfType<ScoreUI>();

        //check for children that are spawn locations then add them to the list
        Thread.Sleep(1000);
        GameObject[] enemySpawn = GameObject.FindGameObjectsWithTag("SpawnLocation");
        for (int i = 0; i < enemySpawn.Length; i++)
        {
            _spawns.Add(enemySpawn[i].transform);
        }
        //for(int i = 0; i < this.gameObject.transform.childCount; i++)
        //{
        //    Transform currentObject = this.gameObject.transform.GetChild(i);
        //    if (currentObject.tag == "SpawnLocation")
        //    {
        //        _spawns.Add(currentObject);
        //    }
        //}

    }

    void Update()
    {

        if (started)
        {
            //if current time is divisible by 10, summon an enemy

            //Spawns like 5 enemies every batch, unintended but maybe keep

            double time = Math.Round(timer.Instance.getTime(), 2);

            if (time % 10 == 0 && timer.Instance.canCount)
            {
                if (_freakyMode)
                {
                    for(int i = 0; i < _freakySpawnAmt; i++)
                    {
                        spawnEnemyInPosition(_spawns, _enemyPrefab);
                        spawnEnemyInPosition(_spawns, _evilEnemyPrefab);
                    }
                }
                else
                {
                    enemyType = Random.Range(0, 5);

                    if(enemyType == 3)
                    {
                        spawnEnemyInPosition(_spawns, _evilEnemyPrefab);
                    }
                    else
                    {
                        spawnEnemyInPosition(_spawns, _enemyPrefab);
                    }

                }
            }
        }

        
    }


    //creates a random number then spawns an enemy at the transform in the index of that random number
    void spawnEnemyInPosition(List<Transform> tArray, GameObject entity)
    {
        randomNum = Random.Range(0, _spawns.Count);
        spawn(tArray[randomNum].position, scoreManager, entity);
        
        //Debug.Log("enemy spawned");
    }


    public override GameObject createEntity(GameObject entity)
    {
        return entity;
    }
}
