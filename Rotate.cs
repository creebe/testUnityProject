using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //variables for MagicOne
    private GameObject magicOneParentGO;
    private GameObject dialOneGO;
    public ProceduralRing magicOneChildPR;
    private float offSetAngleForMagicOne;
    private bool touchOne;
    private MeshCollider magicOneChildMC;
    private MeshRenderer magicOneChildMR;

    [SerializeField]
    private float upperRotateYLimit = 500f;

    private int midPoint = 380;
    private float rangeForDialActivation = 1.5f;

    private void Start()
    {
        //caching for MagicOne
        magicOneParentGO = GameObject.Find("MagicOneParent");
        dialOneGO = GameObject.Find("DialOne");
        magicOneChildPR = GameObject.Find("MagicOneChild").GetComponent<ProceduralRing>();
        offSetAngleForMagicOne = -1 * (magicOneChildPR.Angle / 2);
        magicOneChildMC = GameObject.Find("MagicOneChild").GetComponent<MeshCollider>();
        magicOneChildMR = GameObject.Find("MagicOneChild").GetComponent<MeshRenderer>();
    }

    void Update()
    {
        ManageTouchOne();
    }

    void ManageTouchOne()
    {
        float distfromDialOne = Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), dialOneGO.transform.position);

        if (distfromDialOne < rangeForDialActivation)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - dialOneGO.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(offSetAngleForMagicOne, Vector3.forward) * Quaternion.AngleAxis(angle, Vector3.forward);
            magicOneParentGO.transform.rotation = rotation;
        }
    }
}