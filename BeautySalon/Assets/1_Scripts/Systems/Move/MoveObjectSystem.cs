﻿using UnityEngine;

namespace SystemMove
{
    public class MoveObjectSystem : ChangeTransformSystem
    {
        protected override void ChangeTransform()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetTransform.position, speedChange * Time.deltaTime);

            if (transform.position == targetTransform.position)
            {
                EndChangeTransform();
            }
        }
        
    }
}
