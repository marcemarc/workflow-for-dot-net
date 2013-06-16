﻿using System;
using System.Linq;
using System.Reflection;
using System.Web.UI;
using ClientDependency.Core;
using FergusonMoriyam.Workflow.Interfaces.Application;
using FergusonMoriyam.Workflow.Interfaces.Domain;
using FergusonMoriyam.Workflow.Interfaces.Ui;
using FergusonMoriyam.Workflow.Umbraco.Web.Ui.Extensions;
using log4net;
using umbraco.BasePages;

[assembly: WebResource("FergusonMoriyam.Workflow.Umbraco.Web.Ui.Js.Util.js", "text/javascript")]
[assembly: WebResource("FergusonMoriyam.Workflow.Umbraco.Web.Ui.Js.Config.js", "text/javascript")]
namespace FergusonMoriyam.Workflow.Umbraco.Web.Ui
{

    public partial class EditConfigurationProperties : UmbracoEnsuredPage
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IGlobalisationService TheGlobalisationService { get; set; }


        private IWorkflowConfiguration _config;
        private IWorkflowEntityUi _ui;

        public IWorkflowConfigurationService TheWorkflowConfigurationService { get; set; }
        public IUiResolver TheWorkflowEntityUiResolver { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            SavePropertiesButton.Text = TheGlobalisationService.GetString("save_properties");

            this.AddResourceToClientDependency("FergusonMoriyam.Workflow.Umbraco.Web.Ui.Js.Util.js", ClientDependencyType.Javascript);
            this.AddResourceToClientDependency("FergusonMoriyam.Workflow.Umbraco.Web.Ui.Js.Config.js", ClientDependencyType.Javascript);

            var id = Convert.ToInt32(Request["id"]);

            _config = TheWorkflowConfigurationService.GetConfiguration(id);
            _ui = TheWorkflowEntityUiResolver.Resolve(_config);

            foreach (var control in _ui.Render(_config))
            {
                PropertiesUiPanel.Controls.Add(control);
            }
        }

        protected void SavePropertiesButtonClick(object sender, EventArgs e)
        {
            var values = _ui.UiProperties.ToDictionary(uiProperty => uiProperty.PropertyName, uiProperty => uiProperty.Value);
            TheWorkflowConfigurationService.SetConfigurationProperties(_config.Id, values);

            SavedLiteral.Visible = true;
        }

    }
}