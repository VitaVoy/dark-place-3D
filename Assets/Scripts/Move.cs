using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField]
    private float _speed; 
    [SerializeField]
    private float _runSpeed = 8.0f;
    [SerializeField]
    private float _walkSpeed = 4.0f;
    [SerializeField]
    private float _jumpSpeed = 8.0f;
    [SerializeField]
    private float _gravity = 20.0f; 
    private Vector3 _moveDir = Vector3.zero; 
    private CharacterController _controller; 

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (_controller.isGrounded)
        {
            Walk();          
        }

        if (Input.GetKeyDown(KeyCode.Space) && _controller.isGrounded)
        {
            _moveDir.y = _jumpSpeed;
        }

        if (Input.GetKey(KeyCode.LeftShift) && _controller.isGrounded && Energy.energyLenghth > 0)
        {
            Run();          

            if (Energy.energyLenghth > 0)
                Energy.energyLenghth -= 25.0f * Time.deltaTime;
            else
                Energy.energyLenghth = 0;
        }

        if (Mathf.Approximately(_speed, _walkSpeed) && Energy.energyLenghth < 200)
        {
            Energy.energyLenghth += 25.0f * Time.deltaTime;
        }
        
        _moveDir.y -= _gravity * Time.deltaTime;
        _controller.Move(_moveDir * Time.deltaTime);         
    }

    private void Walk()
    {
        _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDir = transform.TransformDirection(_moveDir);
        _speed = _walkSpeed;
        _moveDir *= _speed;
    }

    private void Run()
    {
        _moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _moveDir = transform.TransformDirection(_moveDir);
        _speed = _runSpeed;
        _moveDir *= _speed;
    }


}
