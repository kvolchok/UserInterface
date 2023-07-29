using UnityEngine;

public class HeroLoader : MonoBehaviour
{
    [SerializeField]
    private Transform _heroRoot;

    public void ShowHero(HeroSettings hero)
    {
        foreach (Transform childObject in _heroRoot)
        {
            Destroy(childObject.gameObject);
        }

        Instantiate(hero.Prefab, _heroRoot);
    }
}