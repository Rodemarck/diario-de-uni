using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[RequireComponent(typeof(Rigidbody2D))]
public class Personagem : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocidade;
    public float gravidade;
    public int localidade;
    public string nome;
    private Vector2 movimento;
    private Rigidbody2D _rigidbody;
    private CapsuleCollider2D _collider;
    private int direcao;
    void Start()
    {
        _rigidbody= GetComponent<Rigidbody2D>();
        _collider = GetComponent<CapsuleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        DetectaMovimento();
    }
    private void Cair(){

    }
    private void DetectaMovimento(){
        direcao = 0;
        if(Input.GetKey(KeyCode.A)) direcao = 1;
        else if(Input.GetKey(KeyCode.D)) direcao = -1;
        _rigidbody.velocity = new Vector2(direcao * velocidade,0);
    }
}
