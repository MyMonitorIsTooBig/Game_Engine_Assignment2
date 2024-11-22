using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Plugin : MonoBehaviour
{

    [SerializeField] string fileName;
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



    string text;

    List<int> settings = new List<int>();

    int settingNum = 0;

    int score = 0;
    int damage = 0;
    int moveSpeed = 0;
    int jumpHeight = 0;
    int enemyScore = 0;
    float enemySpeed = 0;
    int enemyDistance = 0;


    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();


        readFile();

        foreach(int inte in settings)
        {
            //TABLE: 0-score     1-damage      2-move speed      3-jump height      4-enemy score       5- enemy speed        6- enemy distance
            Debug.Log(inte);
            switch (settingNum)
            {
                case 0:
                    if (scoreChange)
                    {
                        score = inte;
                        ScoreUI.Instance.score = score;
                    }
                    break;
                case 1:
                    if (dmgChange)
                    {
                        damage = inte;
                        bulletStats.damage = damage;
                    }
                   break;
                case 2:
                    if (moveChange)
                    {
                        moveSpeed = inte;
                        player.moveSpeed = moveSpeed;
                    }
                    break;
                case 3:
                    if (jumpChange)
                    {
                        jumpHeight = inte;
                        player.jumpHeight = jumpHeight;
                    }
                    break;
                case 4:
                    if (enemScoreChange)
                    {
                        enemyScore = inte;
                        enemyStats._maxScore = enemyScore;
                    }
                    break;
                case 5:
                    if (enemSpeedChange)
                    {
                        enemySpeed = inte;
                        enemyStats._speed = enemySpeed;
                    }
                    break;
                case 6:
                    if (enemyDistChange)
                    {
                        enemyDistance = inte;
                        enemyStats._distance = enemyDistance;
                    }
                    break;
            }

            settingNum++;
        }
    }

    private void Update()
    {
        
    }

    void readFile()
    {
        if(fileName!= null)
        {
            text = File.ReadAllText(fileName);


            char[] seperators = { ',' };
            string[] strValues = text.Split(seperators);


            foreach(string str in strValues)
            {
                int val = 0;
                if(int.TryParse(str, out val))
                {
                    settings.Add(val);
                }
            }
        }

    }
}
