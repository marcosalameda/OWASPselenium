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
    public class UserRegistrationRegisto de novo utilizador : BaseUserRegistration
    {
        /// <inheritdoc/>
        public override void CreateRoles(User user)
        {
            user.AddModuleRole("GQT", Role.ROLE_20);
        }

        /// <inheritdoc/>
        public override void CreateEph(User newUser, IArea area, PersistentSupport sp)
        {
            CSGenioApess1 business = (CSGenioApess1)area;

            //database must be queried using admin permissions, not user permissions
            User adminUser = SecurityFactory.ElevateUserToAdmin(newUser);

            //create the business table record
            business.removeCalculatedFields();
            business.insert(sp);

            //create the usr association table that links the user to the eph [COMODANTE] Value
            var record = new CSGenioApwcom(adminUser, "Public")
            {
                ValCodpess1 = business.QPrimaryKey,
                ValCodpsw = newUser.Codpsw,
                //Change by [TMV] (03-08-2022) -> Makes sense to be a user record, to stamp the audit fields. And the action is triggred by a user
                UserRecord = true
            };

            //Using insert creates a new record but this record should already exist when the user is created
            List<CSGenioApwcom> dbRecords = CSGenioApwcom.searchList(sp, adminUser, CriteriaSet.And()
                .Equal(CSGenioApwcom.FldCodpess1, record.ValCodpess1)
                .Equal(CSGenioApwcom.FldCodpsw, record.ValCodpsw)
                .Equal(CSGenioApwcom.FldZzstate, 0));
            //If user record does not exist
            if (dbRecords == null || dbRecords.Count == 0)
            {
                record.insert(sp);
            }
            //User record exists
            else
            {
                record.QPrimaryKey = dbRecords[0].QPrimaryKey;
                record.update(sp);
            }
        }

// USE /[MANUAL GQT USER_CREATION_BUSINESS REGISTO DE NOVO UTILIZADOR]/

    }
}