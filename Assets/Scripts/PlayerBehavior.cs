using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;

    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;

    //chapter8
    public float jumpVelocity = 5f;

    private bool _isJumping;

    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    private CapsuleCollider _col;

    public GameObject bullet;
    public float bulletSpeed = 100f;

    private bool _isShooting;
    private GameBehavior _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * moveSpeed;
        _hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        /*
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */

        //chapter8
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
        _isShooting |= Input.GetMouseButtonDown(0);
    }

    void FixedUpdate()
    {
        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        //chapter8
        /*
        if (_isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;
        */

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * jumpVelocity, ForceMode.Impulse);
        }
        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(bullet, this.transform.position + new Vector3(0, 0, 1), this.transform.rotation);
            Rigidbody bulletRB = newBullet.GetComponent<Rigidbody>();
            bulletRB.velocity = this.transform.forward * bulletSpeed;
        }
        _isShooting = false;
    }

    private bool IsGrounded()
    {
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, _col.bounds.min.y, _col.bounds.center.z);
        bool grounded = Physics.CheckCapsule(_col.bounds.center, capsuleBottom, distanceToGround, groundLayer, QueryTriggerInteraction.Ignore);
        return grounded;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.HP -= 1;
            Debug.LogFormat("Player has {0} health remaining", _gameManager.HP);
        }
    }
}
