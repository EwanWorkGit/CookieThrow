using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] Camera Cam;
    [SerializeField] Image InteractIcon;

    [SerializeField] float InteractionRange = 4f;

    private void Update()
    {
        Ray ray = Cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
        Physics.Raycast(ray, out RaycastHit hit);

        if(hit.collider != null)
        {
            //find IInteractible
            if(Vector3.Distance(transform.position, hit.transform.position) < InteractionRange && hit.transform.TryGetComponent(out IInteractible interactible))
            {
                if (!InteractIcon.gameObject.activeInHierarchy)
                    InteractIcon.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactible.Interact();
                }
            }
            else
            {
                if(InteractIcon.gameObject.activeInHierarchy)
                    InteractIcon.gameObject.SetActive(false);
            }
        }
        
    }
}
