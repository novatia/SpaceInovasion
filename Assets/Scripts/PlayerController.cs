using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Weapon;
    public float Speed = 5f;
    public Vector3 StartPosition = new Vector3(0, -4, -1);
    private Vector3 m_CurrentPosition;
    private WeaponsController m_WeaponController;

    public float xLimit = 4f;

    void Start()
    {
        m_CurrentPosition = StartPosition;
        m_WeaponController = GetComponent<WeaponsController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = m_CurrentPosition.x;

        if (Input.GetKey(KeyCode.LeftArrow))
            m_CurrentPosition.x -= Time.deltaTime * Speed;

        if (Input.GetKey(KeyCode.RightArrow))
            m_CurrentPosition.x += Time.deltaTime * Speed;

        if (Mathf.Abs(m_CurrentPosition.x) > xLimit)
            m_CurrentPosition.x = x;

        if (Input.GetKey(KeyCode.Space))
            m_WeaponController.Fire();

        transform.position = m_CurrentPosition;
    }
}
