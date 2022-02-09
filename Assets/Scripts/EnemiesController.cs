using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float Speed;

    public float yStep = 0.2f;

    private float m_Direction = -1f;
    private float m_SpeedMultiplier = 1.0f;
    private bool m_StepDown = false;

    public void GoRight()
    {
        m_Direction = 1;
        StepDown();
    }

    private void StepDown()
    {
        m_StepDown = true;
        m_SpeedMultiplier += 0.1f;
    }

    public void GoLeft()
    {
        m_Direction = -1;
        StepDown();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        position.x += m_Direction* Speed * m_SpeedMultiplier * Time.deltaTime;

        if (m_StepDown) 
        {
            position.y -= yStep;

            m_StepDown = false;
        }

        transform.position = position;
    }
}
