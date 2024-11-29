using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoJugador : MonoBehaviour
{
    public float moveSpeed = 10f; 
    public float rotateSpeed = 75f;
    private float vInput;
    private float hInput;
    private Rigidbody _rb;

    //Variables para el Salto
    public float JumpVelocity = 5f;
    private bool _isJumping;

    public float DistanceToGround = 0.1f;
    public LayerMask SueloLayer;
    private CapsuleCollider _col;

    //Variables para las balas
    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }

   
    void Update()
    {

        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;

        _isJumping |= Input.GetKeyDown(KeyCode.E);

        _isShooting |= Input.GetKeyDown(KeyCode.Space);
    }

    void FixedUpdate()
    {
        
        Vector3 rotation = Vector3.up * hInput;
       
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        
        _rb.MovePosition(this.transform.position + this.transform.forward * vInput *
        Time.fixedDeltaTime);
       
        _rb.MoveRotation(_rb.rotation * angleRot);

        //Comprobar Salto
        if (_isJumping && IsGrounded())
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        }

        _isJumping = false;

        //Comprobar Disparo
        if (_isShooting)
        {
            
            GameObject newBullet = Instantiate(Bullet,
            this.transform.position + new Vector3(0, 0, 1),
            this.transform.rotation);
            
            Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>();
            
            BulletRB.velocity = this.transform.forward * BulletSpeed;
        }
        
        _isShooting = false;


    }

    private bool IsGrounded()
    {
        
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
        _col.bounds.min.y, _col.bounds.center.z);
        
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
        capsuleBottom, DistanceToGround, SueloLayer,
        QueryTriggerInteraction.Ignore);

        return grounded;
    }


}
