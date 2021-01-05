using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public int skillAmount=0;

    private PolygonCollider2D coll2D;

    // Start is called before the first frame update
    void Start()
    {
        coll2D = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // void status()
    // {
    //     if(Input.GetButtonDown("Skill"))
    //     {
    //         skillAmount ++;
    //         if(skillAmount > 1)
    //         {
    //             skillAmount = 0;
    //         }
    //     }
    //     switch (skillAmount)
    //     {
    //         case 0:
    //             myAnim.SetBool("Drill", true);
    //             // myAnim.SetBool("Sling", false);
    //             break;
    //         case 1:
    //             // myAnim.SetBool("Sling", true);
    //             myAnim.SetBool("Drill", false);
    //             break;
    //         default:
    //             break;
    //     }
    // }
}
