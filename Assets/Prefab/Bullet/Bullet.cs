using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] bulletSO bulletStats;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * Time.deltaTime * 5000f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag != "Bullet")
        {

            if (other.gameObject.GetComponent<EnemyMovement>() != null)
            {
                other.GetComponent<EnemyMovement>().TakeDamage(bulletStats.damage);
            }

            if(other.gameObject.GetComponent<EvilEnemyMovement>() != null)
            {
                other.GetComponent<EvilEnemyMovement>().TakeDamage(bulletStats.damage);
            }
            //Destroy(gameObject);
            rb.velocity = Vector3.zero;
            gameObject.SetActive(false);
            
        }
        
    }
}
