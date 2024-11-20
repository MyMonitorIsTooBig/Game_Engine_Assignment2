using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreakyMode : MonoBehaviour
{
    public bool freak { get; private set; }

    public bool canFreak = true;

    private int freakMeter = 0;


    [SerializeField] enemySpawner _es;


    // Update is called once per frame
    void Update()
    {

        if (canFreak)
        {
            switch (freakMeter)
            {
                case 0:
                    if (Input.GetKey(KeyCode.F))
                    {
                        freakMeter++;
                    }
                    break;
                case 1:
                    if (Input.GetKey(KeyCode.R))
                    {
                        freakMeter++;
                    }
                    break;
                case 2:
                    if (Input.GetKey(KeyCode.E))
                    {
                        freakMeter++;
                    }
                    break;
                case 3:
                    if (Input.GetKey(KeyCode.A))
                    {
                        freakMeter++;
                    }
                    break;
                case 4:
                    if (Input.GetKey(KeyCode.K))
                    {
                        freakMeter++;
                    }
                    break;
                case 5:
                    _es._freakyMode = true;
                    canFreak = false;
                    break;
            }
            
        }
    }


}
