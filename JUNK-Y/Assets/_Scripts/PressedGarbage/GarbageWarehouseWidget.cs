using UnityEngine.UI;
using UnityEngine;

namespace Junky.Garbage
{
    public class GarbageWarehouseWidget : MonoBehaviour
    {
        [SerializeField] private GarbageWarehouse _garbageCollector;

        [SerializeField] private Text _outputText;
        [SerializeField] private float _indentFromGarbage;

        private void OnEnable()
        {
            _garbageCollector.OnPointsChange += UpdatePointsText;
            _outputText.enabled = false;
        }
        private void UpdatePointsText(int newValue, Transform lastGarbage)
        {
            _outputText.enabled = true;
            _outputText.text = newValue.ToString();

            var newYPosition = lastGarbage.position.y + _indentFromGarbage;
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
        }
        private void OnDisable()
        {
            _garbageCollector.OnPointsChange -= UpdatePointsText;
        }
    }
}
