using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrewFactory : GenericFactory<ScrewBehaviour>
{

    protected override IEnumerator Creating()
    {
        while (_isSpawn) 
        {
            ScrewBehaviour screw = _pool.GetFreeElement();
            screw.transform.position = Borders.GetRandomVectorInViewport();
            yield return new WaitForSeconds(speedOfOccurrence);
        }
    }
}
