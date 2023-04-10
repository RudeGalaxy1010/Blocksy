using DG.Tweening;
using UnityEngine;

public class BlocksCollector : MonoBehaviour
{
    [SerializeField] private BlocksDetector _blocksDetector;

    private Player _player;
    private Inventory _inventory;
    private int _blocksToCollect;

    public void Construct(Player player, Inventory inventory)
    {
        _player = player;
        _inventory = inventory;
        _blocksToCollect = 0;
    }

    private void OnEnable()
    {
        _blocksDetector.BlockDetected += OnBLockDetected;
    }

    private void OnDisable()
    {
        _blocksDetector.BlockDetected -= OnBLockDetected;
    }

    private void OnBLockDetected(Block block)
    {
        if (_inventory.CanAdd(block.GetType(), _blocksToCollect + 1))
        {
            Collect(block);
        }
    }

    private void Collect(Block block)
    {
        _blocksToCollect++;
        block.Grab();
        Sequence sequence = DOTween.Sequence()
            .Join(block.transform.DOMove(_player.transform.position, 1f))
            .Join(block.transform.DOScale(Vector3.zero, 1f))
            .OnComplete(() => OnBlockMoveComplete(block));
    }

    private void OnBlockMoveComplete(Block block)
    {
        AddBlockToInventory(block);
        block.DOKill();
        block.ResetScale();
        block.Release();
        block.Destroy();
    }

    private void AddBlockToInventory(Block block)
    {
        _inventory.Add(block.GetType());
        _blocksToCollect--;
    }
}
