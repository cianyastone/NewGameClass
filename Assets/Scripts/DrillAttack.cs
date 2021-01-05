using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillAttack : MonoBehaviour
{
    public int Drilldamage;
    public float DrillStartTime;
    public float Drilltime;
    public float speed;
    public float endDistance;
    public bool flag;

    private Rigidbody2D myRigidbody;
    private float playx;
    private PolygonCollider2D coll2D;
    private Vector3 startPos;
    // private Animator myAnim;
    private PlayerController pc;
 
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
        // firstSpeed = Vector3.Distance(Obj.transform.position, PathB.transform.position) * speed;
        coll2D = GetComponent<PolygonCollider2D>();   
        myRigidbody = GetComponent<Rigidbody2D>();
        pc = GetComponent<PlayerController>();
        flag=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Attack();    
        if(flag){
            startPos = this.transform.position;
            flag=false;
        }
        // float deltatime = Time.deltaTime;
    }

    public void Attacked()
    {
        float moveDir = Input.GetAxis("Horizontal");
        
        StartCoroutine(StartAttack());
        //this.transform.Translate(Vector2.right * speed);
        //move forward
        myRigidbody.AddRelativeForce(new Vector2(50*speed,0), ForceMode2D.Impulse);
        flag=true;
        // float step = speed;
 	    // gameObject.transform.localPosition =new Vector2(Mathf.Lerp(gameObject.transform.localPosition.x, endDistance, step),0);//插值算法也可以
        StartCoroutine(disableHitbox());   
    }

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(DrillStartTime);
        coll2D.enabled = true;
        
        // Vector2 playerVe = new Vector2(moveDir * speed,0.0f);
        // myRigidbody.velocity = playerVe;
        // float distance = (transform.position - startPos).sqrMagnitude;
        // if(distance > speed-1)
        // {
        //     yield return new WaitForSeconds(5);
        //     coll2D.enabled = false;
        //     transform.Translate(startPos);
        //     // myAnim.SetBool("Drillattack", false);
        // }
    }

    IEnumerator disableHitbox()
    {
        yield return new WaitForSeconds(Drilltime);
        myRigidbody.MovePosition(startPos);
        
        yield return new WaitForSeconds(Drilltime);
        coll2D.enabled = false;
        pc.DrillBack();
    }
}