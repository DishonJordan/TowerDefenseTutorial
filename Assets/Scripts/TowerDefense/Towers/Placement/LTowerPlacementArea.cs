using Core.Utilities;
using TowerDefense.UI.HUD;
using UnityEngine;

namespace TowerDefense.Towers.Placement
{
    /// <summary>
    /// An area suitable for placing a single tower
    /// </summary>
    [RequireComponent(typeof(Collider))]
    public class LTowerPlacementArea : MonoBehaviour, IPlacementArea
    {
        /// <summary>
        /// Visualisation prefab to instantiate
        /// </summary>
        public PlacementTile PlacementTilePrefab;

        /// <summary>
        /// Visualisation prefab to instantiate on mobile platforms
        /// </summary>
        public PlacementTile PlacementTilePrefabMobile;

        /// <summary>
        /// <see cref="PlacementTile"/> we've spawned on our spot
        /// </summary>
        private PlacementTile spawnedTile;

        /// <summary>
        /// If the area is occupied
        /// </summary>
        private bool isOccupied;

        public Transform startPosition;
        public Transform middlePosition;
        public Transform endPosition;
        public float speed;

        /// <summary>
        /// Set up visualisation tile
        /// </summary>
        protected void Awake()
        {
            PlacementTile tileToUse;
#if UNITY_STANDALONE
            tileToUse = PlacementTilePrefab;
#else
			tileToUse = PlacementTilePrefabMobile;
#endif

            if (tileToUse != null)
            {
                spawnedTile = Instantiate(tileToUse);
                spawnedTile.transform.SetParent(transform);
                spawnedTile.transform.localPosition = new Vector3(0f, 0.05f, 0f);
            }
        }

        /// <summary>
        /// Returns (0, 0), as there is only one available spot
        /// </summary>
        /// <param name="worldPosition"><see cref="Vector3"/> indicating world space coordinates to convert.</param>
        /// <param name="sizeOffset"><see cref="IntVector2"/> indicating size of object to center.</param>
        public IntVector2 WorldToGrid(Vector3 worldPosition, IntVector2 sizeOffset)
        {
            return new IntVector2(0, 0);
        }

        /// <summary>
        /// Returns transform.position, as there is only one available spot
        /// </summary>
        /// <param name="gridPosition">The coordinate in grid space</param>
        /// <param name="sizeOffset"><see cref="IntVector2"/> indicating size of object to center.</param>
        public Vector3 GridToWorld(IntVector2 gridPosition, IntVector2 sizeOffset)
        {
            return transform.position;
        }

        /// <summary>
        /// Tests whether the placement area is valid.
        /// </summary>
        /// <param name="gridPos">The grid location</param>
        /// <param name="size">The size of the item</param>
        public TowerFitStatus Fits(IntVector2 gridPos, IntVector2 size)
        {
            if (isOccupied)
            {
                return TowerFitStatus.Overlaps;
            }
            else
            {
                return TowerFitStatus.Fits;
            }
        }

        /// <summary>
        /// Occupies the area
        /// </summary>
        /// <param name="gridPos"></param>
        /// <param name="size"></param>
        public void Occupy(IntVector2 gridPos, IntVector2 size)
        {
            isOccupied = true;

            if (spawnedTile != null)
            {
                spawnedTile.SetState(PlacementTileState.Filled);
            }
        }

        /// <summary>
        /// Clears the area
        /// </summary>
        /// <param name="gridPos"></param>
        /// <param name="size"></param>
        public void Clear(IntVector2 gridPos, IntVector2 size)
        {
            isOccupied = false;

            if (spawnedTile != null)
            {
                spawnedTile.SetState(PlacementTileState.Empty);
            }
        }

        public bool IsMovable() => true;

        public string GetMovementScriptName()
        {
            return "MultiPointMovement";
        }

        public Vector3 GetStartVector()
        {
            return startPosition.position;
        }

        public Vector3 GetMiddleVector()
        {
            return middlePosition.position;
        }

        public Vector3 GetEndVector()
        {
            return endPosition.position;
        }

        public float GetSpeed()
        {
            return speed;
        }

#if UNITY_EDITOR
        /// <summary>
        /// Draw the spot as a smalls phere in the scene view.
        /// </summary>
        void OnDrawGizmos()
        {
            Color prevCol = Gizmos.color;
            Gizmos.color = Color.cyan;

            Matrix4x4 originalMatrix = Gizmos.matrix;
            Gizmos.matrix = transform.localToWorldMatrix;

            Gizmos.DrawWireSphere(Vector3.zero, 1);

            Gizmos.matrix = originalMatrix;
            Gizmos.color = prevCol;

            // Draw icon too
            Gizmos.DrawIcon(transform.position + Vector3.up, "build_zone.png", true);
        }
#endif
    }
}