﻿using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Jobs;
using UnityEngine;

struct MoveLeft : IComponentData
{
    public float Speed;
}

[AlwaysSynchronizeSystem]
public class MoveLeftSystem : JobComponentSystem
{
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        float dt = Time.DeltaTime;
        Entities.ForEach((ref Position p, in MoveLeft move) =>
        {
            p.Value.x -= move.Speed * dt;
            if( p.Value.x < 0 )
                p.Value.x = 39;
        }).Run();
        return default;
    }
}
