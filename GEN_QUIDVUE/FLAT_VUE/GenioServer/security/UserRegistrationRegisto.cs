using System;
using System.Collections;
using System.Collections.Generic;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using CSGenio;

namespace GenioServer.security
{    
    /// <inheritdoc/>
    public class UserRegistrationRegisto : BaseUserRegistration
    {
        /// <inheritdoc/>
        public override void CreateRoles(User user)
        {
            user.AddModuleRole("GQT", Role.ROLE_1);
        }

        /// <inheritdoc/>
        public override void CreateEph(User newUser, IArea area, PersistentSupport sp)
        {
            CSGenioAregis business = (CSGenioAregis)area;

            //database must be queried using admin permissions, not user permissions
            User adminUser = SecurityFactory.ElevateUserToAdmin(newUser);

            //create the business table record
            business.removeCalculatedFields();
            business.insert(sp);

        }

// USE /[MANUAL GQT USER_CREATION_BUSINESS registo]/

    }
}