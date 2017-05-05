using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter player;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCharacter>();
        CharacterSheet.Weapon[] weap = new CharacterSheet.Weapon[1];
        weap[0] = new CharacterSheet.Weapon("bullet", 10);
        CharacterSheet.SetCharacter(weap);
	}
	
	void Update ()
    {
        move();
        fire();
	}

    Vector2 moveVector = new Vector2();
    private void move()
    {
        moveVector.y = Input.GetAxis("KeyboardUpDown");
        moveVector.x = Input.GetAxis("KeyboardLeftRight");
        player.MoveShip(moveVector);
    }
    private void fire()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //player.fire();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            player.resetFireCounter();
        }
    }
}
