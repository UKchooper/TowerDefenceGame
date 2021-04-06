using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }

        Instance = this;
    }

    public GameObject StandardTurretPrefab;

    private void Start()
    {
        turretToBuild = StandardTurretPrefab;
    }

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    
}
