using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public Weapon position;
    void Update()
    {
        _audioSource.panStereo = position.transform.position.x / 30;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            _audioSource.Play();
        }
    }
    
}
