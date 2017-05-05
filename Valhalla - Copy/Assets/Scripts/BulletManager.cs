using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    List<GameObject> BulletList;
    float fireDelay = 0.1f;
    GameObject bullet;
    PlayerCharacter player;

    void Start()
    {
        BulletList = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        BulletList.Add(bullet);
    }
	
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fire();    
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            resetFireCounter();
        }
    }

    void fire()
    {
        fireCounter += Time.deltaTime;

        if (fireCounter > fireDelay)
        {
            bool foundBullet = false;
            foreach(GameObject g in BulletList)
            {
                if (g.activeSelf == false)
                {
                    g.SetActive(true);
                    foundBullet = true;
                    g.transform.position = player.transform.position + (Vector3.right * 1f);
                    break;
                }
            }
            if (!foundBullet)
            {
                GameObject b = Instantiate(bullet);
                b.transform.position = player.transform.position + (Vector3.right * 1f);
                BulletList.Add(b);
            }
            

            resetFireCounter();
        }
    }
    float fireCounter;
    void resetFireCounter()
    {
        fireCounter = 0;
    }
}
