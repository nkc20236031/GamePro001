using UnityEngine;

public class explosion : MonoBehaviour {
    private void Start() {
        //���o������������폜
        var particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
    }
}
