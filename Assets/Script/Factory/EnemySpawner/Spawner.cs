using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    public void spawn(Vector3 pos, ScoreUI scoreManage, GameObject entity)
    {
        GameObject newEntity = Instantiate(createEntity(entity), pos, Quaternion.identity);
    }

    public abstract GameObject createEntity(GameObject entity);

}

