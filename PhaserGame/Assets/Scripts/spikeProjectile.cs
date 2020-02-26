using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeProjectile : MonoBehaviour
{
    //private Rigidbody2D rb;
    public Vector2 despawnPoint;
    public float speed;
    public firingDirection.directionSelector direction;

    private Transform trans;
    //private colorController colorCon;

    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        //colorCon = GameObject.Find("Player").GetComponent<colorController>();
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //rb.drag = 0f;
        //rb.angularDrag = 0.05f;
        //rb.gravityScale = 0f;
        //rb.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = speed * Time.deltaTime;

        //move projectile towards the despawn location
        trans.position = Vector2.MoveTowards(trans.position, despawnPoint, step);

        switch (direction)
        {
            case firingDirection.directionSelector.left:
                if(trans.position.x <= despawnPoint.x) { Destroy(this.gameObject); /*colorCon.coloredObjects.Remove(this.gameObject);*/ } break;
            case firingDirection.directionSelector.right:
                if (trans.position.x >= despawnPoint.x) { Destroy(this.gameObject); /*colorCon.coloredObjects.Remove(this.gameObject);*/ } break;
            case firingDirection.directionSelector.up:
                if (trans.position.y >= despawnPoint.y) { Destroy(this.gameObject); /*colorCon.coloredObjects.Remove(this.gameObject);*/ } break;
            case firingDirection.directionSelector.down:
                if (trans.position.y <= despawnPoint.y) { Destroy(this.gameObject); /*colorCon.coloredObjects.Remove(this.gameObject);*/ } break;
            default:
                Destroy(this.gameObject);
                /*colorCon.coloredObjects.Remove(this.gameObject);*/
                break;
        }
    }
}
