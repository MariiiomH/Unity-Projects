using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick : MonoBehaviour {
  

    public Transform skele;  //skeletonObj
    Rigidbody rb;            //GoldCoin    

    public GameObject skele_child , Marker_skel_parent ; 

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    void OnCollisionEnter(Collision col)
    {

        //Move Rigidbody with skeleObj
        rb.MovePosition(skele.position + skele.forward * Time.deltaTime);

        //Move skeleObj Toward his Marker (Follow his parent)
        skele_child.transform.parent = Marker_skel_parent.transform;
        skele_child.transform.position = Marker_skel_parent.transform.position;

        //Move Both Rigidbody & skeleObj Toward The Marker of Skele
        rb.MovePosition(skele_child.transform.position + skele.forward * Time.deltaTime);
       
        //to stop GoldCoin from movement 
        rb.velocity = Vector3.zero;
         


    }



}

