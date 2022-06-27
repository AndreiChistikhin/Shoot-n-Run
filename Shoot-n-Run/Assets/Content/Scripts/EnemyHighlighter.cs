using System.Collections.Generic;
using UnityEngine;

public class EnemyHighlighter : MonoBehaviour
{
    [SerializeField] private List<EnemyView> _enemies;

    private readonly Color _normalEnemyColor = Color.red;
    private readonly Color _highlightedEnemyColor = Color.yellow;

    private void OnEnable()
    {
        EnemyView.EnemyDied += RemoveEnemy;
        PlayerShooting.RaycastColliderChanged += UpdateHighlight;
    }

    private void OnDisable()
    {
        EnemyView.EnemyDied -= RemoveEnemy;
        PlayerShooting.RaycastColliderChanged -= UpdateHighlight;
    }

    private void UpdateHighlight(Collider hitCollider)
    {
        RemoveAllHighlight();
        if (hitCollider == null || !hitCollider.TryGetComponent(out EnemyView highlighter))
            return;
        MeshRenderer enemyMaterial = highlighter.gameObject.GetComponent<MeshRenderer>();
        HighlightEnemy(enemyMaterial);
    }

    private void HighlightEnemy(Renderer renderer)
    {
        if (renderer.material.color == _highlightedEnemyColor)
            return;
        renderer.material.color = _highlightedEnemyColor;
    }

    private void RemoveAllHighlight()
    {
        foreach (var enemy in _enemies)
        {
            enemy.gameObject.GetComponent<MeshRenderer>().material.color = _normalEnemyColor;
        }
    }

    private void RemoveEnemy(EnemyView enemy)
    {
        _enemies.Remove(enemy);
    }
}