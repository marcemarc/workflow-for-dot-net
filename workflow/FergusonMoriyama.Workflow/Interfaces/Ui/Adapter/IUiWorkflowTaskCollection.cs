﻿using System.Collections.Generic;

namespace FergusonMoriyam.Workflow.Interfaces.Ui.Adapter
{
    public interface IUiWorkflowTaskCollection
    {
        IDictionary<string, IUiWorkflowTask> UiTasks { get; }
    }
}
