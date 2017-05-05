using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    int health = 15;
    public bool clone = false;

    EffectLibrary effectLibrary;
    // Use this for initialization
    void Start ()
    {
        effectLibrary = GameObject.FindGameObjectWithTag("EffectLibrary").GetComponent<EffectLibrary>();

        if (this.gameObject.transform.position.x >= 0)
        {
            pathTargets = FlightPaths.assignPath(ref pathTargets, new Vector3(0, 0, 15), FlightPaths.paths.hookFly);
        }
        else { pathTargets = FlightPaths.assignPath(ref pathTargets, new Vector3(0, 0, 15), FlightPaths.paths.reverseHookFly); }
	}
	
	// Update is called once per frame
	void Update ()
    {
        testAI();
		if (clone && health <= 0)
        {
            //effectLibrary.SpawnSmallEnemyKill(this.transform.position);
            EffectLibraryAgent.PlayEffect(EffectLibraryAgent.Effects.ExplosionEnemySmall, this.transform.position);
            Destroy(this.gameObject);
        }
	}

    public void damage(int damage)
    {
        health -= damage;
    }

    Vector3[] pathTargets;
    int currentTarget = 0;
    void testAI()
    {
        // make it move to a random y point in front of the player ship for 3-4 secs
        //the have it move in a wavering negative x after that. 
        //do the opposite for starting at negative x 
        if (currentTarget < pathTargets.Length)
        {
            if (Vector3.Distance(this.transform.position, pathTargets[currentTarget]) > 2)
            {
                moveEnemy(pathTargets[currentTarget]);
            }
            else { currentTarget++; }
            
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    float topSpeed = 0.15f, acceleration = 0.015f;
    Vector3 deltaMove = Vector3.zero;
    void moveEnemy(Vector3 target)
    {
        deltaMove.x = this.transform.position.x > target.x 
                      ? Mathf.Lerp(deltaMove.x, -topSpeed, acceleration) 
                      : Mathf.Lerp(deltaMove.x, topSpeed, acceleration);

        deltaMove.y = this.transform.position.y > target.y
                      ? Mathf.Lerp(deltaMove.y, -topSpeed, acceleration)
                      : Mathf.Lerp(deltaMove.y, topSpeed, acceleration);

        this.transform.position += deltaMove;
    }
}
