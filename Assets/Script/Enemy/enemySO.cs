using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemyStats", menuName = "MyScriptableObjects/EnemyStats", order = 1)]

public class enemySO : ScriptableObject
{
    [field: Header("Weapon Base Stats")]
    [field: SerializeField]
    public float _speed { get;  set; } = 25f;
    [field: SerializeField] public int _distance { get;  set; } = 50;
    [field: SerializeField] public int _maxScore { get;  set; } = 3;


}
