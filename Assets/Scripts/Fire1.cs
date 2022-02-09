using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire1 : Projectile
{
    public GameObject gameObject;

    public Fire1(GameObject gameObject) {
        this.gameObject = gameObject;
        this.Speed = 10;
        this.TimeToLive = 2;
    }

    public override void GetEffect(GameObject Affected)
    {
        GameObject.Destroy(Affected);
        GameObject.Destroy(gameObject);
    }

    public override IEnumerator ProjectileMovement()
    {
        float CurrentLive = 0;
        SpriteRenderer sprite = gameObject.GetComponentInChildren<SpriteRenderer>();

        while (true)
        {
            CurrentLive += Time.deltaTime;
            Vector2 position = gameObject.transform.position;

            position.y += Speed * Time.deltaTime;

            gameObject.transform.position = position;


            if (CurrentLive > TimeToLive)
                break;

            yield return new WaitForEndOfFrame();
        }

        GameObject.Destroy(gameObject);
        yield return null;
    }
}
