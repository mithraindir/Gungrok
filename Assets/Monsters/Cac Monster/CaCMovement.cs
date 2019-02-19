using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaCMonsterMovement : MonoBehaviour
{
    //movement speed
    public float speed;
    
    GameObject knight;
    GameObject archer;

    Vector3 Vector3Knight;
    Vector3 VectorMonster;
    private Rigidbody monster;

    private float Abs (float x)
    {
        if (x > 0)
            return x;
        return -x;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        //monster object
        monster = GetComponent<Rigidbody>();

        //get players (for coordinates)
        knight = GameObject.FindGameObjectWithTag("KnightPlayer");

    }

    // Update is called once per frame
    void Update()
    {
        //monster's coordinates
        VectorMonster = monster.transform.position;
        float MonsterX = VectorMonster.x;
        float MonsterZ = VectorMonster.z;


        //knight's coordinates
        Vector3Knight = knight.transform.position;
        float KnightX = Vector3Knight.x;
        float KnightZ = Vector3Knight.z;

        //Move to the closest direction
        if (Abs(Abs(KnightX) - Abs(MonsterX)) > Abs(Abs(KnightZ) - Abs(MonsterZ)))
        {
            if (KnightX < MonsterX)
                monster.velocity = new Vector3(-speed, 0, 0);
            else
                monster.velocity = new Vector3(speed, 0, 0);
        }
        else
        {
            if (KnightZ < MonsterZ)
                monster.velocity = new Vector3(0, 0, -speed);
            else
                monster.velocity = new Vector3(0, 0, speed);
        }

        


    }
}
