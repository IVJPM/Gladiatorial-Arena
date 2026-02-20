using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectives
{
    public event EventHandler OnObjectiveUpdate;

    public void BeginObjective(Objective objective);

    public void EvaluateObjectiveProgress(Task task);

    public void CompleteObjective(Objective objective);

    public bool ObjectiveCompletion();
}
