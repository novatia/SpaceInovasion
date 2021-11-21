using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float Speed;

    public float xMin = -0.5f;
    public float xMax = 0.5f;
    public float yStep = 1;

    private bool m_Side;

    public float Size = 7;

    private void  CalculateLimits() 
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            float currentX = gameObject.transform.GetChild(i).transform.position.x;

            if (xMin > currentX)
            {
                xMin = currentX;
            }

            if (xMax < currentX)
            {
                xMax = currentX;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateLimits();
        Vector3 position = transform.position;

        if (m_Side)
        {
            position.x += Speed * Time.deltaTime;
        }
        else {
            position.x -= Speed * Time.deltaTime;
        }


        if ( position.x < xMin + Size)
        {
            m_Side = true;
            position.y -= yStep;
        }

        if (position.x > xMax - Size)
        {
            m_Side = false;
            position.y -= yStep;
        }

        transform.position = position;
        
    }
}
