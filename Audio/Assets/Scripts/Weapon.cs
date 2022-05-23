using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public float MoveSpeed;
    public GameObject BulletPrefab;
    public Transform BulletPoint;
    public Rigidbody RBBullet;
    public float BulletSpeed;
    private float Speed;
    private Rigidbody rb;
    private float firePointX;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Speed = Input.GetAxis("Horizontal");
        if (transform.position.x > 30)
            transform.position = new Vector3(24, -10, 15);
        if (transform.position.x < -30)
            transform.position = new Vector3(-24, -10, 15);
        transform.position += MoveSpeed * transform.right * Speed * Time.deltaTime;
        _audioSource.panStereo = transform.position.x / 30;
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        _audioSource.Play();
        GameObject Bullet = Instantiate(BulletPrefab, BulletPoint.position, Quaternion.identity);
        RBBullet = Bullet.GetComponent<Rigidbody>();
        RBBullet.AddForce(Vector3.forward * BulletSpeed, ForceMode.Impulse);
    }
}
