﻿using System.Configuration;
using FergusonMoriyam.Workflow.Interfaces.Infrastructure;

namespace Web.Test.Infrastructure
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {

        private static readonly ConnectionStringProvider Provider = new ConnectionStringProvider();

        public static ConnectionStringProvider Instance
        {
            get { return Provider; }
        }

        protected ConnectionStringProvider()
        {
        }

        public string GetConncetionString()
        {
            return ConfigurationManager.ConnectionStrings["WorkflowConnection"].ConnectionString;
        }
    }
}
