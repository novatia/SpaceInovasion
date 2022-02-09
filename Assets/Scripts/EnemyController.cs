using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag.Contains("LeftBound"))
            transform.parent.gameObject.GetComponent<EnemiesController>().GoRight();

        if (collision.gameObject.tag.Contains("RightBound"))
            transform.parent.gameObject.GetComponent<EnemiesController>().GoLeft();

        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
        }

//        if (collision.gameObject.tag == "Player")

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
