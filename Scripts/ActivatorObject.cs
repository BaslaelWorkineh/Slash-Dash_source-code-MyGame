using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorObject : MonoBehaviour
{
    // Start is called before the first frame update

        public GameObject objectToActivate;
        public GameObject tobeDeactivated;
        public GameObject Player;
        public GameObject Player1;

        private void Start()
        {
            StartCoroutine(ActivationRoutine());
            objectToActivate.SetActive(false);
            Player1.SetActive(false);
    }

        private IEnumerator ActivationRoutine()
        {
            //Wait for 14 secs.
            yield return new WaitForSeconds(34);


            objectToActivate.SetActive(true);
            tobeDeactivated.SetActive(false);
            Player.SetActive(false);
            Player1.SetActive(true);

        }
    
}
