using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;
    public GameObject projectile;
    float _nextBullet;
    PlayerController myPlayer;
    Animator anim;
    private void Awake() {
        _nextBullet = 0f;
        myPlayer = transform.root.GetComponent<PlayerController>();
        anim = transform.root.GetComponent<Animator>();
    }

    private void Update() {

        if(Input.GetAxisRaw("Fire1") > 0 && _nextBullet < Time.time){
            _nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot;
            if(myPlayer.GetFacing() == -1f){
                rot = new Vector3(0, -90f, 0);
            }else{
                rot = new Vector3(0, 90f, 0);
            }

            var bala = Instantiate(projectile, transform.position, Quaternion.Euler(rot));
            anim.SetTrigger("fire");
            //anim.SetLayerWeight(1, 1);
        }
    }
}
