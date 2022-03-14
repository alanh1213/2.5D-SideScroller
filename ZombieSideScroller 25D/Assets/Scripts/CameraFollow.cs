using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform objetivo;
    [SerializeField] private Vector3 _offSet;
    [Range(1, 10)][SerializeField] private float _smoothMovement = 1;
    
 void FixedUpdate()
     {
        
       SeguirObjetivo();
        
     }

 void SeguirObjetivo()
     {
         Vector3 targetPosition = objetivo.position + _offSet;
         transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothMovement * Time.deltaTime);
     }
}
