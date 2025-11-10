using System;
using UnityEngine;

public class Municao : MonoBehaviour
{
    //Não esqueça de modificar no Editor.
    //Usei o valor 5
    [SerializeField] float ySpeed;
   
    Rigidbody2D _rb;

    void Awake()
    {
        //Referência para o Corpo Rígido
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //Acessar o Corpo Rígido e aplicar a força
        _rb.AddForceY(ySpeed, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
}