using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  public float life = 3;

  private void Awake()
  {
    Destroy(gameObject, life);
  }

  private void OnCollisionEnter(Collision other)
  {
    Vector3 wallPos = other.transform.position;
    float wallPosX = other.transform.position.x;
    // Debug.Log("Hey I touch here: "+wallPosX);
    // Debug.Log(gameObject.transform.position);
    Destroy(gameObject);
    
  }

}
