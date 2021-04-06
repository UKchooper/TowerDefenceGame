using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColour;
    public Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColour;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColour = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there! - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = BuildManager.Instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = HoverColour;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColour;
    }
}
