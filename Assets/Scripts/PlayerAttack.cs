using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage;
    public float StartTime;
    public float time;

    private PolygonCollider2D coll2D;
 
    // private PlayerInputAction controls;

    // void  Awake()
    // {
    //     controls = new PlayerInputAction();
    //     controls.GamePlay.Attack.started += ctx => Attack();
    // }

    // void OnEnable()
    // {
    //     controls.GamePlay.Enable();
    // }

    // void OnDisable()
    // {
    //     controls.GamePlay.Disable();
    // }

    // Start is called before the first frame update
    void Start()
    {
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Attack();
    }

    void Attack()
    {
        if(Input.GetButtonDown("Attack"))
        {
            StartCoroutine(StartAttack());
        }
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(StartTime);
        coll2D.enabled = true;
        StartCoroutine(disableHitbox());
    }

    IEnumerator disableHitbox()
    {
        yield return new WaitForSeconds(time);
        coll2D.enabled = false;
    }
}
