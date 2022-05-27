using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    public UI Player;
    public float MoveSpeed;
    public GameObject BulletPrefab;
    public Transform BulletPoint;
    public Rigidbody RBBullet;
    public float BulletSpeed;

    public int _heal = 3;

    private float _speed;
    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _speed = Input.GetAxis("Horizontal");
        if (transform.position.x > 22)
            transform.position = new Vector3(22, transform.position.y, transform.position.z);
        if (transform.position.x < -22)
            transform.position = new Vector3(-22, transform.position.y, transform.position.z);
        transform.position += MoveSpeed * transform.right * _speed * Time.deltaTime;
        _audioSource.panStereo = transform.position.x / 30;
        if (Input.GetKeyUp(KeyCode.Mouse0) && Player.CanShoot == true)
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
