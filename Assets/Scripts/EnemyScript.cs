using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] GameObject explosion;
    // [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnParticleCollision(GameObject other)
    {
        explosion.SetActive(true);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
