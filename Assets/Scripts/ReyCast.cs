using UnityEngine;

public class ReyCast : MonoBehaviour
{
    [SerializeField] private ForceApplier _forceApplier;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitlInfo))
            {
                Cube cube = hitlInfo.collider.GetComponent<Cube>();

                if (cube)
                {
                    cube.OnClick();
                    _forceApplier.BlowUp(cube.transform.position, cube.transform.localScale.x);
                }
            }                
        }
    }
}
