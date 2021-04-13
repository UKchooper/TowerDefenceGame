using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color HoverColour;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

    private Renderer rend;
    private Color startColour;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;

        buildManager = BuildManager.Instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
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
