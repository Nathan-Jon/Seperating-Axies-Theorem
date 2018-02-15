﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace GameEngine
{
    class AssetBase
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity;
        public Vector2 Acceleration;
        public Vector2 Gravity = new Vector2(0, 0);


        //Inverse mass to encourage multiplication and not diviision due to multiplication being faster
        public float InverseMass =  -1.5f;
        public float Restitution = 1f;
        public float Damping = 0.5f;



        public void ApplyForce(Vector2 force)
        {
            Acceleration += force * InverseMass;
        }

        public void ApplyImpulse(Vector2 closingVelo)
        {
            Velocity = closingVelo * Restitution;
        }

        public void UpdatePhysics()
        {
            Velocity += Acceleration;
            Velocity *= Damping;
            Position += Velocity;
            Acceleration = Gravity;
        }

    }
}
