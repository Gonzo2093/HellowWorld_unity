using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; // Скорость в м/с
    public float fireRate = 0.3f; // Выстрелов в секунду (не используется)

    // Update вызывается в каждом кадре
    void Update()
    {
        Move();
    }
    public virtual void Move()
    {
        Vector3 tempPos = Pos;
        tempPos.y -= speed * Time.deltaTime;
        Pos = tempPos;
    }
    void OnCollisionEnter(Collision coll)
    {
        GameObject other = coll.gameObject;
        switch (other.tag)
        {
            case "Hero":
                // Пока не реализовано, но здесь наносятся повреждения герою
                break;
            case "HeroLaser":
                Destroy(this.gameObject);
                break;
        }
    }
    // Это свойство: метод, действующий
    public Vector3 Pos
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }
}