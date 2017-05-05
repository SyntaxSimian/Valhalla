using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int BulletDamage = 10;
	void Start ()
    {
        //this.gameObject.SetActive(false);
        heightAdjustment.y = Random.Range(0.4f, 0.4f);
	}

    Vector3 heightAdjustment;
	void Update ()
    {
        this.transform.position += (Vector3.right * 0.8f);
        if(this.transform.position.x > 20)
        {
            this.gameObject.SetActive(false);
        }
	}

    //public void 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EffectLibraryAgent.PlayEffect(EffectLibraryAgent.Effects.BulletImpact1, this.transform.position);

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().damage(CharacterSheet.GetWeapon0Damage() * 2);
        }

        this.gameObject.SetActive(false);
    }
}
