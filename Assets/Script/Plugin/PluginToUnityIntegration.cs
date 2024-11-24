using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CheatPlugin;

public class PluginToUnityIntegration : MonoBehaviour
{

    [SerializeField] CheatPlugin.CheatPlugin _plugin;


    [SerializeField] bulletSO bulletStats;
    [SerializeField] enemySO enemyStats;
    [SerializeField] PlayerMovement player;


    [SerializeField] bool scoreChange = false;
    [SerializeField] bool dmgChange = false;
    [SerializeField] bool moveChange = false;
    [SerializeField] bool jumpChange = false;
    [SerializeField] bool enemScoreChange = false;
    [SerializeField] bool enemSpeedChange = false;
    [SerializeField] bool enemyDistChange = false;


    bool canUpdate = true;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void Update()
    {
        if (canUpdate)
        {
            player = GameObject.Find("Player").GetComponent<PlayerMovement>();

            if (scoreChange)
            {
                ScoreUI.Instance.score = _plugin.score;
            }
            if (dmgChange)
            {
                bulletStats.damage = _plugin.damage;
            }
            if (moveChange)
            {
                player.moveSpeed = _plugin.moveSpeed;
            }
            if (jumpChange)
            {
                player.jumpHeight = _plugin.jumpHeight;
            }
            if (enemScoreChange)
            {
                enemyStats._maxScore = _plugin.enemyScore;
            }
            if (enemSpeedChange)
            {
                enemyStats._speed = _plugin.enemySpeed;
            }
            if (enemyDistChange)
            {
                enemyStats._distance = _plugin.enemyDistance;
            }

            canUpdate = false;
        }
    }



}
