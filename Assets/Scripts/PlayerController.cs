using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 5f;
    public Vector3 StartPosition = new Vector3(0, -4, -1);
    private Vector3 m_CurrentPosition;
    private WeaponsController m_WeaponController;

    public float xLimit = 4f;

    private bool m_CantMoveLeft = false;
    private bool m_CantMoveRight = false;

    private bool m_GameOver = false;
    void Start()
    {
        m_CurrentPosition = StartPosition;
        m_WeaponController = GetComponent<WeaponsController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("LeftBound"))
            m_CantMoveLeft = true;
        if (collision.gameObject.tag.Contains("RightBound"))
            m_CantMoveRight = true;

        if (collision.gameObject.tag.Contains("Enemy")) {
            m_GameOver = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("LeftBound"))
            m_CantMoveLeft = false;
        if (collision.gameObject.tag.Contains("RightBound"))
            m_CantMoveRight = false;
    }


    // Update is called once per frame
    void Update()
    {
        float x = m_CurrentPosition.x;

        if (m_GameOver)
            return;


        if (!m_CantMoveLeft)
            if (Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.LeftArrow))
        //if (Input.GetKey(KeyCode.LeftArrow))
            m_CurrentPosition.x -= Time.deltaTime * Speed;


        if (!m_CantMoveRight)

            //if (Input.GetKey(KeyCode.RightArrow))
            if (Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.RightArrow))
            m_CurrentPosition.x += Time.deltaTime * Speed;



    //    if (Mathf.Abs(m_CurrentPosition.x) > xLimit)
      //      m_CurrentPosition.x = x;

        if (Input.GetButton("Fire") || Input.GetKey(KeyCode.Space))
        //if (Input.GetKey(KeyCode.Space))
            m_WeaponController.Fire();

        transform.position = m_CurrentPosition;
    }
}
