using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsController : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Vector3 Offset;
    public float Speed=10;
    public float TimeToLive = 2;
    public float TriggerDelay = 0.4f;
    private bool m_Hit=false;
    private List<GameObject> m_ProjectileList;
    private bool m_TriggerDisabled = false;
    private float m_TriggerTimer = 0;
    
    void Start()
    {
        m_ProjectileList = new List<GameObject>();
    }

    private IEnumerator ProjectileMovement(GameObject projectile)
    {
        float CurrentLive = 0;
        SpriteRenderer sprite = projectile.GetComponentInChildren<SpriteRenderer>();

        ProjectileComponent pc = projectile.GetComponent<ProjectileComponent>();


        while (!pc.HasHit())
        {
            CurrentLive += Time.deltaTime;

            {
                Vector2 position = projectile.transform.position;

                position.y += Speed * Time.deltaTime;

                projectile.transform.position = position;


                if (CurrentLive > TimeToLive)
                    break;
                yield return new WaitForEndOfFrame();
            }
        }

        Destroy(projectile);
        yield return null;
    }

    public void Fire()
    {
        if (!m_TriggerDisabled)
        {
            m_TriggerDisabled = true;
            m_TriggerTimer = 0;
            GameObject projectile = Instantiate(ProjectilePrefab, transform.position + Offset, Quaternion.identity) as GameObject;

            StartCoroutine(ProjectileMovement(projectile));

            m_ProjectileList.Add(projectile);

        }
    }

    private void Update()
    {
        if (m_TriggerDisabled) {
            m_TriggerTimer += Time.deltaTime;
            if (m_TriggerTimer >= TriggerDelay)
                m_TriggerDisabled = false;
        }
    }
}