using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathLerp : MonoBehaviour
{
    private float interpolateAmount;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform pointD;
    
    // [SerializeField] private Transform pointAB;
    // [SerializeField] private Transform pointBC;
    // [SerializeField] private Transform pointCD;
    // [SerializeField] private Transform pointAB_BC;
    // [SerializeField] private Transform pointBC_CD;
    [SerializeField] private Transform pointABCD;
    
    void Update()
    {
        interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;

        /*pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);
        pointAB.transform.up = pointB.position - pointA.position;
        
        pointBC.position = Vector3.Lerp(pointB.position, pointC.position, interpolateAmount);
        pointBC.transform.up = pointC.position - pointB.position;
        
        pointAB_BC.position = Vector3.Lerp(pointAB.position, pointBC.position, interpolateAmount);
        pointAB_BC.transform.up = pointBC.position - pointAB.position;
        
        pointBC_CD.position = Vector3.Lerp(pointBC.position, pointCD.position, interpolateAmount);
        pointBC_CD.transform.up = pointCD.position - pointBC.position;

        pointABCD.position = Vector3.Lerp(pointBC_CD.position, pointAB_BC.position, interpolateAmount);*/

        pointABCD.position = CubicLerp(pointA.position, pointB.position, pointC.position, pointD.position,
            interpolateAmount);
        pointABCD.transform.up = pointD.position - pointA.position;

        /*pointCD.position = Vector3.Lerp(pointC.position, pointD.position, interpolateAmount);
        pointCD.transform.up = pointD.position - pointC.position;
        
        pointDE.position = Vector3.Lerp(pointD.position, pointE.position, interpolateAmount);
        pointDE.transform.up = pointE.position - pointD.position;
        
        pointEF.position = Vector3.Lerp(pointE.position, pointF.position, interpolateAmount);
        pointEF.transform.up = pointF.position - pointE.position;
        
        pointFG.position = Vector3.Lerp(pointF.position, pointG.position, interpolateAmount);
        pointFG.transform.up = pointG.position - pointF.position;
        
        pointGH.position = Vector3.Lerp(pointG.position, pointH.position, interpolateAmount);
        pointGH.transform.up = pointH.position - pointG.position;
        
        pointHI.position = Vector3.Lerp(pointH.position, pointI.position, interpolateAmount);
        pointHI.transform.up = pointI.position - pointH.position;
        
        pointIJ.position = Vector3.Lerp(pointI.position, pointJ.position, interpolateAmount);
        pointIJ.transform.up = pointJ.position - pointI.position;
        
        pointJK.position = Vector3.Lerp(pointJ.position, pointK.position, interpolateAmount);
        pointJK.transform.up = pointK.position - pointJ.position;*/


    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c , t);

        return Vector3.Lerp(ab, bc, interpolateAmount);
    }

    private Vector3 CubicLerp(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        Vector3 ab_bc = QuadraticLerp(a, b, c, t);
        Vector3 bc_cd = QuadraticLerp(b, c, d, t);

        return Vector3.Lerp(ab_bc, bc_cd, interpolateAmount);
    }
}
