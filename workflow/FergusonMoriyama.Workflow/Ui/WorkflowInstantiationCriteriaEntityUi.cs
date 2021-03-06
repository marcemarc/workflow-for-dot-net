﻿using FergusonMoriyam.Workflow.Domain;
using FergusonMoriyam.Workflow.Interfaces.Application;
using FergusonMoriyam.Workflow.Interfaces.Ui;
using FergusonMoriyam.Workflow.Ui.Generic;
using FergusonMoriyam.Workflow.Ui.WorklowInstantiationCriteriaUi.Property;

namespace FergusonMoriyam.Workflow.Ui
{
    public class WorkflowInstantiationCriteriaEntityUi : WorkflowEntityUi, IGlobalisable
    {
        public IGlobalisationService TheGlobalisationService
        {
            get;
            set;
        }

        public WorkflowInstantiationCriteriaEntityUi()
        {
           
            UiProperties.Add((IWorkflowUiProperty) CreateGlobalisedObject(typeof(NamePropertyUi)));
            UiProperties.Add((IWorkflowUiProperty) CreateGlobalisedObject(typeof(EventsPropertyUi)));
            UiProperties.Add((IWorkflowUiProperty) CreateGlobalisedObject(typeof(CancelEventPropertyUi)));
            UiProperties.Add((IWorkflowUiProperty) CreateGlobalisedObject(typeof(ActivePropertyUi)));
            UiProperties.Add((IWorkflowUiProperty) CreateGlobalisedObject(typeof(WorkflowConfigurationPropertyUi)));
        }

        public override bool SupportsType(object o)
        {
            return o.GetType() == typeof(WorkflowInstantiationCriteria);
        }

        public override string EntityName
        {
            get { return TheGlobalisationService.GetString("instantiation_criteria"); }
        } 
    }
}
