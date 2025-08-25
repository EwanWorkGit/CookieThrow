using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] float InteractionRange = 4f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            Physics.Raycast(ray, out RaycastHit hit);

            if(hit.collider != null)
            {
                //find IInteractible
                if(hit.transform.TryGetComponent(out IInteractible interactible))
                {
                    if(Vector3.Distance(transform.position, hit.transform.position) < InteractionRange)
                    {
                        interactible.Interact();
                    }
                }
            }
        }
    }
}
