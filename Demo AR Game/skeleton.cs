
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour {

    float speed = 1;
    public Transform target; //GoldCoin

    Vector3 targetPosition;  //GoldCoin_position
    Vector3 currentPosition;  //Skeleton_position
    Vector3 directionOfTravel; //Distance Between them


    void Update()
    {
        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;

        targetPosition = target.transform.position; // Get position of GoldObj
        currentPosition = this.transform.position; // Get position of SkeletonObj

        directionOfTravel = targetPosition - currentPosition;


        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;

        //keep only the horizontal Direction
        targetDirection.y = 0;

        

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);


        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);


        Move();

    }
     


    void Move()
    {
        //when two markers near to each other

        if (Vector3.Distance(currentPosition, targetPosition) < 0.1f)
        {
            this.transform.Translate(
                    (directionOfTravel.x * speed * Time.deltaTime),
                    (directionOfTravel.y * speed * Time.deltaTime),
                    (directionOfTravel.z * speed * Time.deltaTime),
                    Space.World);

        }

    }
   

}













