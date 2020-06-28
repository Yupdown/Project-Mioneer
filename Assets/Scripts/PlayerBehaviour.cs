using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Merle.Mioneer
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField]
        private MioneerTileMap mioneerTilemap;

        [SerializeField]
        private Tilemap tileMap;

        [SerializeField]
        private float moveSpeed;

        private float moveTime = 10f;
        private Vector3 worldPosition;
        private Vector3Int worldTilePosition;
        private Vector3Int lastWorldTilePosition;

        private Transform transformCache;

        [SerializeField]
        private Animator characterAnimator;

        [SerializeField]
        private ParticleSystem runningParticle;

        [SerializeField]
        private Transform guideTransform;

        private float miningProgress;

        private Vector3Int miningPosition;

        [SerializeField]
        private GameObject dustPrefab;

        [SerializeField]
        private float miningPower;

        private float currentTileHealth;

        private void Awake()
        {
            transformCache = GetComponent<Transform>();

            miningProgress = -1f;
        }

        private void Update()
        {
            moveTime += Time.deltaTime * moveSpeed;
            float runningSpeed = (moveTime < 1.1f) ? 1f : 0f;

            characterAnimator.SetFloat("moveSpeed", runningSpeed);

            if (miningProgress >= 0f)
                miningProgress += Time.deltaTime;

            if (miningProgress > 0.25f)
            {
                currentTileHealth -= miningPower;

                if (currentTileHealth <= 0f)
                    mioneerTilemap.RemoveWall(miningPosition);

                StopMining();
            }

            worldPosition = Vector3.Lerp(lastWorldTilePosition, worldTilePosition, moveTime);
            transformCache.localPosition = tileMap.CellToLocalInterpolated(worldPosition + new Vector3(0.5f, 0.5f));
        }

        public void UpdateMovement(Vector2 value)
        {
            Vector3 moveDirection = Quaternion.Euler(Vector3.forward * -45f) * value;
            Vector3Int targetTilePosition = worldTilePosition + Vector3Int.RoundToInt(moveDirection);

            bool isMoving = moveTime < 1f;

            if (!isMoving)
            {
                bool flipX = value.x > 0f;
                transformCache.localScale = new Vector3(flipX ? -1f : 1f, 1f, 1f);

                bool isMining = !(miningProgress < 0f);

                if (mioneerTilemap.WallTileMap.GetTile(targetTilePosition) != null)
                {
                    if (isMining && targetTilePosition != miningPosition)
                        StopMining();

                    if (!isMining)
                        StartMining(targetTilePosition);
                }
                else
                {
                    if (isMining)
                        StopMining();
                    lastWorldTilePosition = worldTilePosition;
                    worldTilePosition = targetTilePosition;
                    moveTime = 0f;

                    Destroy(Instantiate(dustPrefab, transformCache.localPosition, Quaternion.identity), 1f);
                }
            }
            else if (targetTilePosition == lastWorldTilePosition)
            {
                lastWorldTilePosition = worldTilePosition;
                worldTilePosition = targetTilePosition;
                moveTime = 1f - moveTime;
            }
        }

        private void StartMining(Vector3Int position)
        {
            if (miningPosition != position)
                currentTileHealth = 80f;

            guideTransform.localPosition = tileMap.CellToWorld(position + Vector3Int.one);

            miningProgress = 0f;
            miningPosition = position;

            characterAnimator.SetBool("mining", true);
        }

        private void StopMining()
        {
            miningProgress = -1f;

            characterAnimator.SetBool("mining", false);
        }
    }

}