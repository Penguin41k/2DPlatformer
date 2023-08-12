using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Collectible : MonoBehaviour
{
    [SerializeField] private UnityEvent _hero;

    private Animator _animator;
    private bool _isCollected;
    private string _collected = "Collected";
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _isCollected = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isCollected == false)
        {
            if (other.gameObject.TryGetComponent(out PlayerBag playerBag))
            {
                _hero?.Invoke();
                _isCollected = true;
                _animator.SetBool(_collected, true);
                float timeDelay = _animator.GetCurrentAnimatorStateInfo(0).length; ;
                Destroy(gameObject, timeDelay);
            }
        }
    }
}
