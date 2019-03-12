using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int layerTohit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      if(collision.gameObject.layer == layerTohit)
        {
            if(collision.gameObject.GetComponent<Entity>())
            {
                collision.gameObject.GetComponent<Entity>().Dead();
            }
        }
    }

}
