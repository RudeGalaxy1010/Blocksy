using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockPlacer : MonoBehaviour
{
    private const float OneSecond = 1f;

    [SerializeField] private List<BlockPlace> _blockPlaces;
    [SerializeField] private PlayerDetector _playerDetector;
    [SerializeField] private float _blocksRate;
    [SerializeField] private float _blocksPlaceTime;

    private BlockPool _blocksPool;

    private float BlocksGetTime => OneSecond / _blocksRate;
    private bool HasEmptyPlaces => _blockPlaces.Count > 0;

    public void Construct(BlockPool blocksPool)
    {
        _blocksPool = blocksPool;
    }

    private void Update()
    {
        if (_playerDetector.Player == null || this.HasActiveTimer() || HasEmptyPlaces == false)
        {
            return;
        }
        
        if (TryGetBlock(_playerDetector.Player, out Block block) == true)
        {
            block.Grab();
            block.transform.position = _playerDetector.Player.transform.position;
            PlaceBlock(block);
            this.StartTimer(() => { }, BlocksGetTime, 1);
        }
    }

    private bool TryGetBlock(Player player, out Block block)
    {
        if (player.Inventory.CanRemove(typeof(Block)) == false)
        {
            block = null;
            return false;
        }

        player.Inventory.Remove(typeof(Block));
        block = _blocksPool.Get();

        return true;
    }

    private void PlaceBlock(Block block)
    {
        BlockPlace blockPlace = TryGetPlace();

        if (blockPlace != null)
        {
            Sequence sequence = DOTween.Sequence()
                .Join(block.transform.DOMove(blockPlace.transform.position, _blocksPlaceTime))
                .Join(block.transform.DOScale(blockPlace.transform.localScale, _blocksPlaceTime))
                .Join(block.transform.DORotate(blockPlace.transform.rotation.eulerAngles, _blocksPlaceTime))
                .OnComplete(() => OnPlaceBlockComplete(blockPlace));
        }
    }

    private BlockPlace TryGetPlace()
    {
        return _blockPlaces[Random.Range(0, _blockPlaces.Count)];
    }

    private void OnPlaceBlockComplete(BlockPlace blockPlace)
    {
        blockPlace.gameObject.SetActive(false);
        _blockPlaces.Remove(blockPlace);
    }
}
