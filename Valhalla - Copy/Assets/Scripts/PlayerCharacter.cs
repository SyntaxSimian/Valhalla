using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    EffectLibrary eLib;

    Rigidbody2D rbody;
    float fireDelay = 0.1f;

    //stats
    int health = 500;
    int damage = 10;

    float acceleration = 40;
	// Use this for initialization
	void Start ()
    {
        rbody = this.gameObject.GetComponent<Rigidbody2D>();
        tracerCounter = 0;
        eLib = GameObject.FindGameObjectWithTag("EffectLibrary").GetComponent<EffectLibrary>();
	}

    float fireCounter;
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void MoveShip(Vector2 AccelerationVector) 
    {
        rbody.AddForce(AccelerationVector * acceleration, ForceMode2D.Force);
    }

    Ray r2d;
    public void fire()
    {
        fireCounter += Time.deltaTime;

        if (fireCounter > fireDelay)
        {
            r2d.origin = this.gameObject.transform.position;
            r2d.direction = Vector2.right;
            RaycastHit rayHit;
            fireTracer();
            if (Physics.Raycast(r2d, out rayHit, 50))
            {
                eLib.SpawnImpact(rayHit.point);
                if(rayHit.collider.GetComponent<Enemy>())
                {
                    rayHit.collider.GetComponent<Enemy>().damage(damage);
                }
            }
            resetFireCounter();
        }
    }
    int tracerCounter;
    private void fireTracer()
    {
        if (tracerCounter > 4)
        {
            eLib.SpawnTracer(this.transform.position);
            tracerCounter = 0;
        }
        tracerCounter++;
    }
    public void resetFireCounter()
    {
        fireCounter = 0;
    }
}
