using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Bullet : MonoBehaviour
{
    public float range = 10f;
    public float damage = 5f;
    Ray _shootRay;
    RaycastHit _shootHit;
    int _shootableMask;
    LineRenderer _gunLine;
    [SerializeField] PlayerController playerController;

    private void Awake() {
        var num = Random.Range(0, 2);
        _shootableMask = LayerMask.GetMask("shootable");
        _gunLine = GetComponent<LineRenderer>();

        _shootRay.origin = transform.position;
        _shootRay.direction = transform.forward;

        _gunLine.SetPosition(0, transform.position);

        if(Physics.Raycast(_shootRay, out _shootHit, range, _shootableMask)){
            //Impacto el raycast
            _gunLine.SetPosition(1, _shootHit.point);
        }else{
            //No impacto el raycast
            if(num == 1)_gunLine.enabled = true;
            else _gunLine.enabled = false;

            _gunLine.SetPosition(1, _shootRay.origin + _shootRay.direction * range);
            
        }

    }

}
