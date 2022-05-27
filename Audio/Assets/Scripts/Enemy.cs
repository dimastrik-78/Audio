using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    [SerializeField] AudioSource _AudioSource;
    public AudioMixer audioMixer;
    private Rigidbody _Rigidbody;
    private Transform _position;
    private int Move = 0;
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody>();
        _position = GetComponent<Transform>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            audioMixer.SetFloat("MainMusicDistortion", 0.75f);
            StartCoroutine(DestroyEnemy());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerDamageZone")
        {
            Destroy(gameObject);
        }
    }
    private IEnumerator DestroyEnemy()
    {
        _Rigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        _AudioSource.panStereo = _position.position.x;
        _AudioSource.Play();
        GetComponent<CapsuleCollider>().enabled = false;
        _Rigidbody.AddForce(Vector3.back * Move, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        audioMixer.SetFloat("MainMusicDistortion", 0f);
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
