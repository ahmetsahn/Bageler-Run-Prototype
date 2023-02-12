using UnityEngine;

public class BagelPoolSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bagels;

    private void OnEnable() => AddListeners();

    private void OnDisable() => RemoveListeners();

    private GameObject GetPooledObjectForActive()
    {

        for (int i = 0; i < bagels.Length; i++)
        {
            if (!bagels[i].activeSelf)
            {
                return bagels[i];
            }
        }

        return null;

    }

    private GameObject GetPooledObjectForDeactive()
    {

        for (int i = bagels.Length-1; i >= 0; i--)
        {
            
            if (bagels[i].activeSelf)
            {
                return bagels[i];
            }
        }

        return null;

    }

    private void ActiveObject(int value)
    {
        for (int i = 0; i < value; i++)
        {
          
            GameObject obj = GetPooledObjectForActive();
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
        
    }

    private void DeactiveObject(int value)
    {
        for (int i = 0; i < value; i++)
        {
            GameObject obj = GetPooledObjectForDeactive();
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

    }

    private void AddListeners()
    {
        GameEventsSystem.OnActiveBagelFromPool += ActiveObject;
        GameEventsSystem.OnDeactiveBagelFromPool += DeactiveObject;
    }

    private void RemoveListeners()
    {
        GameEventsSystem.OnActiveBagelFromPool -= ActiveObject;
        GameEventsSystem.OnDeactiveBagelFromPool -= DeactiveObject;
    }
}
