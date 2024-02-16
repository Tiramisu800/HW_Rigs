using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KnightController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private KeyCode _JumpKey;
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Button _jumpButton;
    private bool isJump = false;

    void Update()
    {
        Move(); 
    }
    private void OnEnable()
    {
        _jumpButton.onClick.AddListener(Jump);
    }

    private void OnDisable()
    {
        _jumpButton.onClick.RemoveAllListeners();
    }

    public void Move()
    {
        float inputDir = Input.GetAxis("Horizontal");

        _animator.SetFloat("Blend", Mathf.Abs(inputDir));

        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x + inputDir, transform.position.y, 0), Time.deltaTime * _moveSpeed);

        if (Input.GetKeyDown(_JumpKey) && isJump != true) { _animator.SetTrigger("jump"); isJump = true; }


    }

    private void Jump()
    {
        _animator.SetTrigger("jump");
    }
}


