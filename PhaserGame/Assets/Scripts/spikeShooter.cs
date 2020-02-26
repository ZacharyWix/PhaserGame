using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeShooter : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawnPoint;
    public Transform despawnPoint;
    public float shootDelay;
    public float projectileSpeed;
    private firingDirection.directionSelector shootingDirection;
    //private colorController colorCon;

    private float timer;
    private Vector2 despawnVector;
    

    private void Start()
    {
        timer = shootDelay;
        despawnVector.x = despawnPoint.position.x;
        despawnVector.y = despawnPoint.position.y;
        switch (transform.rotation.eulerAngles.z)
        {
            case 0f: shootingDirection = firingDirection.directionSelector.up; break;
            case 90f: shootingDirection = firingDirection.directionSelector.left; break;
            case 180f: shootingDirection = firingDirection.directionSelector.down; break;
            case 270f: shootingDirection = firingDirection.directionSelector.right; break;
            default: shootingDirection = firingDirection.directionSelector.left; break;
        }

        spawnSpike();

        //colorCon = GameObject.Find("Player").GetComponent<colorController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            spawnSpike();

            timer = shootDelay;
        }
        
    }

    private void spawnSpike()
    {
        GameObject spawnedProjectile = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

        //Spawn in a new spike, with an attached spikeProjectile script to make it move
        spikeProjectile sp = spawnedProjectile.AddComponent<spikeProjectile>() as spikeProjectile;
        movingPlatformPlayerMover mover = null;

        //If the spike is moving down, make it so the player becomes a child of the spike when standing on top of it
        if (shootingDirection == firingDirection.directionSelector.down)
        {
            mover = spawnedProjectile.transform.GetChild(0).gameObject.AddComponent<movingPlatformPlayerMover>() as movingPlatformPlayerMover;
        }

        //Set the values of the new spike
        sp.despawnPoint = despawnVector;
        sp.speed = projectileSpeed;
        sp.direction = shootingDirection;
    }
}
