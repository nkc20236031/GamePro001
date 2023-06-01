using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
    private void Start() {
        //‰‰o‚ªŠ®—¹‚µ‚½‚çíœ
        var particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
    }
}
