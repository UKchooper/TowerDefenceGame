using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard turret selected");
        buildManager.SetTurretToBuild(buildManager.StandardTurretPrefab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Another turret selected");
        buildManager.SetTurretToBuild(buildManager.AnotherTurretPrefab);
    }
}
