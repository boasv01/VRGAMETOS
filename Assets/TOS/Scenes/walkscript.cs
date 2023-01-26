using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkscript : MonoBehaviour
{
    public Rigidbody PlayerRigid;
 public float m_speed;
 
 void FixedUpdate(){
  if(Input.GetKey(KeyCode.W)){
   PlayerRigid.velocity = transform.forward * m_speed * Time.deltaTime;
  }
  if(Input.GetKey(KeyCode.A)){
   PlayerRigid.velocity = -transform.right * m_speed * Time.deltaTime;
  }
  if(Input.GetKey(KeyCode.S)){
   PlayerRigid.velocity = -transform.forward * m_speed * Time.deltaTime;
  }
  if(Input.GetKey(KeyCode.D)){
   PlayerRigid.velocity = transform.right * m_speed * Time.deltaTime;
        }
 }
}
