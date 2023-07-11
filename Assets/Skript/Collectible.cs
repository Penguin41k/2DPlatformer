using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    [SerializeField] private UnityEvent _Player;
    private Animator _animator;
    private bool _isCollected;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PleyerController pleyerController))
        {
            if (_isCollected==false)
            {
                _Player?.Invoke();
                _isCollected = true;
            }

            _animator.SetBool("isCollected", true);
            float timeDelay = _animator.GetCurrentAnimatorStateInfo(0).length;
            Destroy(gameObject, timeDelay);
        }
    }
}
