using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectives
{
    public void BeginObjective(Objective objective);

    public void EvaluateObjectiveProgress();

    public void CompleteObjective(Objective objective);

    public bool ObjectiveCompletion();
}
