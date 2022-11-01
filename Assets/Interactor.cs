using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Interactor : MonoBehaviour
    {
        public static Interactor Instance;

        [SerializeField] private Transform _interactionPoint;
        [SerializeField] private float _interactionPointRadius = 0.5f;
        [SerializeField] private LayerMask _interactableMask;
        public int _numFound;
        private readonly Collider[] _colliders = new Collider[3];


        private void Start()
        {
            
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
        }
    private void LateUpdate()
    {
        _numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders,
                                   _interactableMask);
        Interact();        
    }
    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("interact");
            var interactable = _colliders[0].GetComponent<IInteractable>();
            if (_numFound > 0)
            {
                if (interactable != null)
                {
                    interactable.Interact(this);
                    return;
                }


            }
            

        }

    }
}


