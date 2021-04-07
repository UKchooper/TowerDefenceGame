using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColour;
    public Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColour;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.Instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }

        rend.material.color = HoverColour;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
