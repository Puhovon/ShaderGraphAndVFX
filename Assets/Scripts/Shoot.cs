using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] private ParticleSystem particles;

    [SerializeField] private Animation animation;

    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !animation.isPlaying)
        {
            animation.Play();
            particles.Play();
        }
    }

}
