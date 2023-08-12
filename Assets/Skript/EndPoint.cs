using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EndPoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _quantityOfCollectible;

    private string _endGame = "EndGame";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _quantityOfCollectible = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out PlayerBag playerBag))
        {
            if (_quantityOfCollectible == playerBag.amountCollectible)
            {
                _animator.SetBool(_endGame, true);
            }
        }
    }
}
