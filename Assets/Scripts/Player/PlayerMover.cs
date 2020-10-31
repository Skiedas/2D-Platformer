using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _numberOfJumps;
    [SerializeField] private float _rayDistance;

    private Animator _animator;
    private Rigidbody2D _rb;
    private PlayerInput _input;
    private float _moveDirection;
    private int _jumpsLeft;
    private float _lastDirection = 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Jump.performed += cxt => TryJump();
    }

    private void Update()
    {
        _moveDirection = _input.Player.Move.ReadValue<float>();

        IsGrounded();
        Move(_moveDirection);
        SetLookDirection(_moveDirection);
    }

    private void Move(float moveDirection)
    {
        float normalizedSpeed = moveDirection * _speed * Time.deltaTime;
        transform.Translate(new Vector3(normalizedSpeed, 0, 0));

        _animator.SetInteger("AnimState", Mathf.Abs((int)moveDirection));
    }

    private void TryJump()
    {
        if (_jumpsLeft > 0)
            Jump();
    }

    private void Jump()
    {
        _jumpsLeft--;
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        _animator.SetTrigger("Jump");
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _rayDistance);

        if (hit.collider != null)
        {
            _jumpsLeft = _numberOfJumps - 1;
            return true;
        }
        else
            return false;
    }

    private void SetLookDirection(float moveDirection)
    {
        if (moveDirection != 0)
            _lastDirection = moveDirection;

        transform.localScale = new Vector3(_lastDirection, 1, 1);
    }
}