using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "EvilEnemyStats", menuName = "MyScriptableObjects/EvilEnemyStats", order = 2)]

public class evilSO : ScriptableObject
{
    [field: Header("Evil Enemy Stats")]
    [field: SerializeField]
    public float _speed { get; private set; } = 0f;
    [field: SerializeField] public int _distance { get; private set; } = 0;
    [field: SerializeField] public int _maxScore { get; private set; } = 3;


}
