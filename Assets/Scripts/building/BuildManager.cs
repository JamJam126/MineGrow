using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    [Header("References")]
    public Transform player;
    public float placementOffset = 1.5f;

    private BuildingData currentBuilding;
    private GameObject previewObject;

    // Store last movement direction
    private Vector2 lastMoveDir = Vector2.right;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (currentBuilding == null || previewObject == null)
            return;

        // 🔥 READ INPUT (NOT VELOCITY)
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 inputDir = new Vector2(h, v);

        if (inputDir.magnitude > 0.01f)
        {
            lastMoveDir = inputDir.normalized;
        }

        // Place preview in front of movement direction
        Vector3 targetPos = player.position + (Vector3)(lastMoveDir * placementOffset);
        targetPos.z = 0f;
        previewObject.transform.position = targetPos;

        // Color feedback
        SpriteRenderer sr = previewObject.GetComponent<SpriteRenderer>();
        if (IsValidPosition(targetPos))
            sr.color = new Color(0f, 1f, 0f, 0.5f);
        else
            sr.color = new Color(1f, 0f, 0f, 0.5f);

        // Place building
        if (Input.GetMouseButtonDown(0) && IsValidPosition(targetPos))
        {
            PlaceBuilding(targetPos);
        }

        // Cancel placement
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            CancelPlacement();
        }
    }

    public void StartPlacement(BuildingData building)
    {
        if (building == null)
        {
            Debug.LogError("BuildingData is NULL!");
            return;
        }

        CancelPlacement();
        currentBuilding = building;

        previewObject = Instantiate(building.prefab);
        previewObject.transform.position = Vector3.zero;

        SpriteRenderer sr = previewObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 0.5f);
        sr.sortingOrder = 100;

        Collider2D col = previewObject.GetComponent<Collider2D>();
        if (col != null)
            col.enabled = false;
    }

    void PlaceBuilding(Vector3 position)
    {
        Instantiate(
            currentBuilding.prefab,
            new Vector3(position.x, position.y, 0f),
            Quaternion.identity
        );

        PlayerData.Instance.ReduceMoney(currentBuilding.price);

        CancelPlacement();
    }

    void CancelPlacement()
    {
        if (previewObject != null)
            Destroy(previewObject);

        previewObject = null;
        currentBuilding = null;
    }

    bool IsValidPosition(Vector3 pos)
    {
        return pos.x > -10f && pos.x < 10f &&
               pos.y > -5f && pos.y < 5f;
    }
}
