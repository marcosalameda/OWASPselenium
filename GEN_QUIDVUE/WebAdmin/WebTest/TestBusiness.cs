using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using GenioServer.security;
using Quidgest.Persistence.GenericQuery;

namespace WebTest
{    
    /// <summary>
    ///This is a test class for Test and is intended
    ///to contain all Test Unit Tests
    ///</summary>
    [TestClass()]
    public class TestNegocio
    {
	    [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Initalization code goes here
            PersistenceFactoryExtension.Use();
            CSGenio.persistence.PersistentSupport.SetControlQueries(
                GenioServer.persistence.PersistentSupportExtra.ControlQueries, 
                GenioServer.persistence.PersistentSupportExtra.ControlQueriesOverride);
            GenioServer.framework.OverrideQueryDeclaring.Use();
            //Dependency injection
            UserFactory.BusinessManager = new UserBusinessService();

        }

		// USE /[MANUAL GQT TESTNEGOCIO]/
    }
}
