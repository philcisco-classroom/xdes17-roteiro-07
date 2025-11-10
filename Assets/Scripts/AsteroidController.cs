using System;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{

    Rigidbody2D _rb;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] GameObject dissolveVFX;
    Collider2D _collider2D;

    [SerializeField] float speedY;
    [SerializeField] AudioClip clip;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _rb.AddForceY(-speedY, ForceMode2D.Impulse);

        _collider2D = GetComponentInChildren<Collider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject vfx = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        GameObject dissolveVFX = Instantiate(this.dissolveVFX, transform.position,Quaternion.identity);
        dissolveVFX.GetComponent<SpriteRenderer>().sprite = GetComponentInChildren<SpriteRenderer>().sprite;
        Destroy(vfx,1.0f);
        Destroy(dissolveVFX,1);
        _collider2D.enabled = false;
        AudioSource.PlayClipAtPoint(clip,transform.position);
        Destroy(gameObject);
    }
}