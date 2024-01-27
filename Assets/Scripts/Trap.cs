using DG.Tweening;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Transform spike;
    [SerializeField] private float yMoveValue;

    private void OnCollisionEnter(Collision collision)
    {
        spike.DOMoveY(yMoveValue, 1).OnComplete(SpikeDown);
    }

    private void SpikeDown()
    {
        spike.DOMoveY(-1.5f, 1);
    }
}
