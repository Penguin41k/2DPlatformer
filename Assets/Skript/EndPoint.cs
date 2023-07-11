using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EndPoint : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PleyerController pleyerController))
        {
           _animator.enabled= true;
        }
    }
}
