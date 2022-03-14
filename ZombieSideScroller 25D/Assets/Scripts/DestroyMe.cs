using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    public float aliveTime;
    private void Awake() {
        Destroy(gameObject, aliveTime);
    }
}
