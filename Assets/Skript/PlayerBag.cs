using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    public int amountCollectible { get; private set; }

    public void AddCollectible()
    {
        amountCollectible++;
    }
}
