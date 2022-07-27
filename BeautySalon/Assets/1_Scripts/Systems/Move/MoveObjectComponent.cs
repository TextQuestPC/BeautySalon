﻿using Core;
using System;
using UnityEngine;

namespace SystemMove
{
    public class MoveObjectComponent : MonoBehaviour, IMove
    {
        [HideInInspector]
        public event Action EndedChangeTransform;

        protected Vector3 nextPos;
        // TODO: устанавливать скорость в конструкторе
        protected float speedMove = 10f;
        protected bool canMove = false;

        public float SetSpeed { set => speedMove = value; }

        private void Awake()
        {
            BoxManager.GetManager<UpdateManager>().AddMoveObject(this);
            nextPos = transform.position;
        }

        public void Move()
        {
            if (canMove)
            {
                if (transform.position != nextPos)
                {
                    transform.position = Vector3.MoveTowards(transform.position, nextPos, speedMove * Time.deltaTime);
                }
                else
                {
                    EndChangeTransform();
                }
            }
        }

        public void SetNextPosition(Vector3 nextPos)
        {
            nextPos.y = transform.position.y;
            this.nextPos = nextPos;
            canMove = true;
        }

        protected void EndChangeTransform()
        {
            canMove = false;

            EndedChangeTransform?.Invoke();
        }
    }
}