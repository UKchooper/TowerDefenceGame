using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint StandardTurret;
    public TurretBlueprint MissleLauncher;
    public TurretBlueprint LaserBeamer;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        buildManager.SelectTurretToBuild(StandardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missle launcher selected");
        buildManager.SelectTurretToBuild(MissleLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("Laser beamer selected");
        buildManager.SelectTurretToBuild(LaserBeamer);
    }
}
