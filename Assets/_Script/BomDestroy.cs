using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Script
{
    public class BomDestroy : MonoBehaviour
    {
        private Coroutine _timer;
        [SerializeField] private float lifetime = 2f;
        
        private void OnEnable()
        {
            _timer = StartCoroutine(DisableAfterDelay());
        }

        private IEnumerator DisableAfterDelay()
        {
            yield return new WaitForSeconds(lifetime);
            gameObject.SetActive(false);
        }
        private void OnDisable()
        {
            if (_timer != null)
            {
                StopCoroutine(_timer);
                _timer = null;
            }
        }
    }
}

