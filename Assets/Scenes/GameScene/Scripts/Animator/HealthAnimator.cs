using System.Collections;
using UnityEngine;

namespace Scenes.GameScene.Scripts.Animator
{
    public class HealthAnimator : MonoBehaviour
    {
        private UnityEngine.Animator statusAnimator;

        [SerializeField]
        private float timeFrom = 1f;
        [SerializeField]
        private float timeTo = 5f;

        [SerializeField]
        private int animationStates = 4;

        // Start is called before the first frame update
        private void Start()
        {
            statusAnimator = GetComponent<UnityEngine.Animator>();
            StartRandomizeValue();
        }

        private void StartRandomizeValue()
        {
            StartCoroutine(RandomizeValue());
        }

        private IEnumerator RandomizeValue()
        {
            var previousValue = statusAnimator.GetInteger("randomState");
            var newValue = GenerateNewValue(previousValue);
            statusAnimator.SetInteger("randomState", newValue);
            yield return new WaitForSeconds(Random.Range(timeFrom, timeTo));
            StartRandomizeValue();
        }

        private int GenerateNewValue(int previousValue)
        {
            var generatedValue = previousValue;
            while (generatedValue == previousValue)
            {
                generatedValue = Random.Range(1, animationStates);
            }

            return generatedValue;
        }

        public void SetHealth(int health)
        {
            statusAnimator.SetInteger("health", health);
        }
    }
}
