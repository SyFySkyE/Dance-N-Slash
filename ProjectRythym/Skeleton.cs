﻿using System;

namespace ProjectRythym
{
    public enum SkeletonEnum { Alive, Dead, Up, Right, Left, Down }

    class Skeleton
    {
        protected SkeletonEnum currentState;
        public SkeletonEnum CurrentState { get { return this.currentState; }
            set
            {
                if (this.currentState != value)
                {
                    this.currentState = value;
                }
            }
        }

        public Skeleton()
        {
            currentState = SkeletonEnum.Alive;
        }
    }
}