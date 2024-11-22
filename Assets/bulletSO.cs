using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(fileName = "BulletStats", menuName = "MyScriptableObjects/BulletStats", order = 2)]

public class bulletSO : ScriptableObject
{
    [field: Header("Weapon Base Stats")]
    [field: SerializeField]
    public int damage { get; set; } = 5;


}
