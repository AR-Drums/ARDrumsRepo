using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    
    public Material stickMaterial;
    public Material targetMaterial;

    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit targetHitInfo = new RaycastHit();
        bool targetHit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out targetHitInfo);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.position = raycastHit.point;
        }

        if (targetHitInfo.transform.tag.Equals("DrumCollider"))
        {
            this.GetComponent<Renderer>().material = targetMaterial;
        } 
        else
        {
            this.GetComponent<Renderer>().material = stickMaterial;
        }
    }
}
