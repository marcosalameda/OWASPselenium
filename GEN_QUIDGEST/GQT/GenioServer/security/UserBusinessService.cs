using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using CSGenio.framework;
using CSGenio.business;
using CSGenio.persistence;
using Quidgest.Persistence.GenericQuery;
using System.Threading;
using CSGenio;

namespace GenioServer.security
{    
    /// <summary>
    /// Business layer methods that are necessary to create users
    /// </summary>
    public class UserBusinessService : IUserBusinessManager
    {
        private PersistentSupport sp;
        private  User user;

        public void SetLocalProperties(PersistentSupport sp, User user)
        {
            this.sp = sp;
            this.user = user;
        }

        /// <summary>
        /// Creates the necessary association for COMODANTE EPH
        /// </summary>
        /// <param name="psw">A userlogin (psw) record</param>
        /// <param name="valEph">The value of the link field of the EPH (CODPESS1)</param>
        public void CreateEph_COMODANTE(CSGenioApsw psw, string valEph)
        {
            CSGenioApwcom record = new CSGenioApwcom(user, "Public");
            record.ValCodpess1 = valEph;
            record.ValCodpsw = psw.ValCodpsw;
            record.UserRecord = true; //Change by [TMV] (03-08-2022) -> Makes sense to be a user record, to stamp the audit fields. And the action is triggred by a user
			
			//Using insert creates a new record but this record should already exist when the user is created
			List<CSGenioApwcom> dbRecords = CSGenioApwcom.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioApwcom.FldCodpess1, record.ValCodpess1)
                .Equal(CSGenioApwcom.FldCodpsw, record.ValCodpsw)
                .Equal(CSGenioApwcom.FldZzstate, 0));
            //If user record does not exist
            if(dbRecords == null || dbRecords.Count == 0) {
                record.insert(sp);
            }
            //User record exists
            else {
                record.update(sp);
            }
        }
    }
}