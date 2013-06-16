﻿using System.Collections.Generic;
using FergusonMoriyam.Workflow.Interfaces.Domain;
using FergusonMoriyam.Workflow.Interfaces.Ui.Adapter;
using FergusonMoriyam.Workflow.Interfaces.Ui.Factory;
using FergusonMoriyam.Workflow.Ui.Adapter;

namespace FergusonMoriyam.Workflow.Ui.Factory
{
    public class UiWorkflowTaskCollectionFactory : IUiWorkflowTaskCollectionFactory
    {
        private static readonly UiWorkflowTaskCollectionFactory Factory = new UiWorkflowTaskCollectionFactory();

        public static UiWorkflowTaskCollectionFactory Instance
        {
            get { return Factory; }
        }

        public IUiWorkflowTaskCollection Create(IEnumerable<IWorkflowTask> tasks, IPointCollection pointCollection)
        {
            var u = new UiWorkflowTaskCollection {UiTasks = new Dictionary<string, IUiWorkflowTask>()};

            foreach(var task in tasks)
            {
                u.UiTasks.Add(task.Id.ToString(), UiWorkflowTaskFactory.Instance.Create(task, pointCollection.Points[task.Id.ToString()]));
            }

            return u;
        }
    }
}
