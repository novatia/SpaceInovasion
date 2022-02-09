using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private bool m_Hit = false;
    public bool DestroyOnHit = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Enemy"))
        {
            if (DestroyOnHit)
                m_Hit = true;
        }
        
    }

    public bool HasHit()
    {
        return m_Hit;
    }

}
