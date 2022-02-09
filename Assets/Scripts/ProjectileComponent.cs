using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileEffects{
    Fire1,
    Fire2
}

public class ProjectileComponent : ProjectileBehaviour
{
    private Projectile m_Projectile;
    public ProjectileEffects Effect;

    public void Init()
    {
        switch (Effect)
        {
            case ProjectileEffects.Fire1:
                {
                    m_Projectile = new Fire1(gameObject);
                    break;
                }
            case ProjectileEffects.Fire2:
                {
                    m_Projectile = new Fire2(gameObject);
                    break;
                }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void GetEffect(GameObject affected)
    {
        m_Projectile.GetEffect(affected);
    }

    
    public void Fire()
    {
        StartCoroutine(m_Projectile.ProjectileMovement());
    }
}
