using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class climb : MonoBehaviour
{
    [SerializeField]private movement Movement;

    private void Update()
    {
        
    }

    public void checkClimb()
    {
        if (Physics.Raycast(Movement.chest.position, Movement.chest.TransformDirection(Vector3.forward), out RaycastHit hitChestinfo, 1f, Movement.climbLedge))
        {
            Debug.DrawRay(Movement.head.position, Movement.head.TransformDirection(Vector3.forward) * hitChestinfo.distance, Color.red);

            if (Physics.Raycast(Movement.head.position, Movement.head.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 1f, Movement.climbLedge))
            {
                Debug.DrawRay(Movement.head.position, Movement.head.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
                Debug.Log("climbidle");
                Movement.rb.useGravity = false;
                Movement.rb.isKinematic = true;
                Movement.animator.SetBool("Climb", true);
                Movement.climbOn = true;
            }
        }
    }
}
