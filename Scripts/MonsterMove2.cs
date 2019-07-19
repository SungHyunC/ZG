using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove2 : MonoBehaviour
{
    public CharacterMove1 move1;
    Transform target;
    Transform enemy;
    Animator anim;
    public float speed;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Room").transform;
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("sumen"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        if (target != null)
        {
            anim.SetBool("isMoving", true);
            transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
        }
        if(dir.x >= 0)
        {
            
            Vector3 scale = transform.localScale;
            scale.x = -Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
        else
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }
    }
}
