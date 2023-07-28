using UnityEngine;

public class HeroLoader : MonoBehaviour
{
    [SerializeField]
    private Transform _heroRoot;

    [field:SerializeField]
    public GameObject HeroCamera { get; private set; }
    [field:SerializeField]
    public GameObject HeroLight { get; private set; }

    public void ShowHero(HeroSettings hero)
    {
        foreach (Transform childObject in _heroRoot)
        {
            Destroy(childObject.gameObject);
        }

        Instantiate(hero.Prefab, _heroRoot);
    }

    public void SetHeroRoot(Transform heroRoot)
    {
        _heroRoot.position = heroRoot.position;
        _heroRoot.rotation = heroRoot.rotation;
    }
}