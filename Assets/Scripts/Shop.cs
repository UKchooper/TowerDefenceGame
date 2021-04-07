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

    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missle launcher selected");
        buildManager.SetTurretToBuild(buildManager.MissleLauncherPrefab);
    }
}
