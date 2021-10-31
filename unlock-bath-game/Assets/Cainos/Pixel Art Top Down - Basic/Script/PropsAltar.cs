using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//when something get into the alta, make the runes glow
namespace Cainos.PixelArtTopDown_Basic
{

    public class PropsAltar : MonoBehaviour
    {
        public List<SpriteRenderer> runes;
        public float lerpSpeed;

        public Color curColor;
        public Color targetColor;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Crate"))
            {
                targetColor = new Color(1, 1, 1, 1);
                PadsDetector.Instance.AddActive();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Crate"))
            {
                targetColor = new Color(1, 1, 1, 0);
                PadsDetector.Instance.RemoveActive();
            }
        }

        private void Update()
        {
            curColor = Color.Lerp(curColor, targetColor, lerpSpeed * Time.deltaTime);

            foreach (var r in runes)
            {
                r.color = curColor;
            }
        }
        
    }
}
