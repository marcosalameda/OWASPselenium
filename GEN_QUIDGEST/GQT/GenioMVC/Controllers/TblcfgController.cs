using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GenioMVC.Helpers;
using GenioMVC.Helpers.Attributes;
using GenioMVC.Models;
using GenioMVC.Models.Navigation;
using GenioMVC.ViewModels;
using CSGenio.framework;
using CSGenio.persistence;
using GenioServer.security;
using CSGenio.business;
using Quidgest.Persistence.GenericQuery;
using System.Globalization;
using System.Web.Routing;
using Newtonsoft.Json;


namespace GenioMVC.Controllers.Tblcfg
{
    public class TblcfgController : ControllerBase
    {
        public ActionResult Index()
        {
            return Json(new
            {
                Success = true
            });
        }

        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult SaveConfig(string uuid, string configName, bool isSelected, string data)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);
            //bool isNewConfig = false;

            //Get saved configuration
            CSGenioAtblcfg userTableConfigSelected = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            //If record doesn't exist, create new record
            if (userTableConfigSelected == null)
            {
                userTableConfigSelected = new CSGenioAtblcfg(user);
                sp.openConnection();
                userTableConfigSelected.insert(sp);
                sp.closeConnection();

                userTableConfigSelected.ValCodpsw = user.Codpsw;
                userTableConfigSelected.ValUuid = uuid;
                userTableConfigSelected.ValName = configName;
                userTableConfigSelected.ValConfig = "";
                //userTableConfigSelected.ValDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                //userTableConfigSelected.ValZzstate = 0;

                //isNewConfig = true;
            }

            //Store configuration data
            userTableConfigSelected.ValConfig = data;

            try
            {
                //Save record
                sp.openTransaction();
                userTableConfigSelected.change(sp, (CriteriaSet)null);
                sp.closeTransaction();

                CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
                    .Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
                    .Equal(CSGenioAtblcfgsel.FldUuid, uuid)
                    .Equal(CSGenioAtblcfgsel.FldZzstate, 0))
                    .FirstOrDefault();

                //If record doesn't exist, create it
                if (userTableConfigSelectedInfo == null)
                {
                    userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);
                    sp.openConnection();
                    userTableConfigSelectedInfo.insert(sp);
                    sp.closeConnection();

                    userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
                    userTableConfigSelectedInfo.ValUuid = uuid;
                    userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigSelected.ValCodtblcfg;

                    //Save record
                    sp.openTransaction();
                    userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
                    sp.closeTransaction();
                }
                else if (isSelected)
                {
                    userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigSelected.ValCodtblcfg;

                    //Save record
                    sp.openTransaction();
                    userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
                    sp.closeTransaction();
                }

                //Clear cache
                UserUiSettings.Invalidate(uuid, user);

                return Json(new
                {
                    Success = true
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                return Json(new
                {
                    Success = false,
                    e.Message
                });
            }
        }

        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult SelectConfig(string uuid, string configName)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            //If clearing what is set as the default configuration
            if (string.IsNullOrEmpty(configName)) {
                //Get record of what view is set as default
                CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
                    .Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
                    .Equal(CSGenioAtblcfgsel.FldUuid, uuid)
                    .Equal(CSGenioAtblcfgsel.FldZzstate, 0))
                    .FirstOrDefault();

                //If record exists, delete it
                if (userTableConfigSelectedInfo != null)
                {
                    sp.openConnection();
                    userTableConfigSelectedInfo.delete(sp);
                    sp.closeConnection();

                    //Clear cache
                    UserUiSettings.Invalidate(uuid, user);
                }

                return JsonOK();
            }

            //Get saved configuration
            CSGenioAtblcfg userTableConfigSelected = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            //If record doesn't exist
            if (userTableConfigSelected == null)
            {
                return Json(new
                {
                    Success = false
                });
            }

            try
            {
                //Get record of what view is selected
                CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
                    .Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
                    .Equal(CSGenioAtblcfgsel.FldUuid, uuid)
                    .Equal(CSGenioAtblcfgsel.FldZzstate, 0))
                    .FirstOrDefault();

                //If record doesn't exist, create it
                if (userTableConfigSelectedInfo == null)
                {
                    userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);
                    sp.openConnection();
                    userTableConfigSelectedInfo.insert(sp);
                    sp.closeConnection();

                    userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
                    userTableConfigSelectedInfo.ValUuid = uuid;
                }
                
                userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigSelected.ValCodtblcfg;

                //Save record
                sp.openTransaction();
                userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
                sp.closeTransaction();

                //Clear cache
                UserUiSettings.Invalidate(uuid, user);

                return Json(new
                {
                    Success = true
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                return Json(new
                {
                    Success = false,
                    e.Message
                });
            }
        }

        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult GetConfig(string uuid, string configName)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            //Get saved configuration
            CSGenioAtblcfg userTableConfigSelected = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            //If record doesn't exist
            if (userTableConfigSelected == null)
            {
                return Json(new
                {
                    Success = false
                });
            }

            //Clear cache
            UserUiSettings.Invalidate(uuid, user);

            return Json(new
            {
                Success = true,
                Config = userTableConfigSelected.ValConfig,
                ConfigName = configName
            });

        }

        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult DeleteConfig(string uuid, string configName)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            bool deletedDefaultView = false;

            //Get saved configuration
            CSGenioAtblcfg userTableConfigSelected = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            //If record doesn't exist
            if (userTableConfigSelected == null)
            {
                return Json(new
                {
                    Success = false
                });
            }

            try
            {
                CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
                    .Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
                    .Equal(CSGenioAtblcfgsel.FldUuid, uuid)
                    .Equal(CSGenioAtblcfgsel.FldZzstate, 0))
                    .FirstOrDefault();

                //If record exists
                if (userTableConfigSelectedInfo != null)
                {
                    //If view is selected as default
                    if (userTableConfigSelectedInfo.ValCodtblcfg.Equals(userTableConfigSelected.ValCodtblcfg)) {
                        sp.openTransaction();
                        userTableConfigSelectedInfo.delete(sp);
                        userTableConfigSelected.delete(sp);
                        sp.closeTransaction();
                        deletedDefaultView = true;
                    }
                    //If view is not selected as default
                    else
                    {
                        sp.openTransaction();
                        userTableConfigSelected.delete(sp);
                        sp.closeTransaction();
                    }
                }
                //If record does not exist
                else
                {
                    sp.openTransaction();
                    userTableConfigSelected.delete(sp);
                    sp.closeTransaction();
                }

                //Clear cache
                UserUiSettings.Invalidate(uuid, user);

                return Json(new
                {
                    Success = true,
                    DeletedDefaultView = deletedDefaultView
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                return Json(new
                {
                    Success = false,
                    e.Message
                });
            }
        }

        [AuthorizeForUsers]
        [HttpPost]
        [HttpParamAction]
        public ActionResult CopyConfig(string uuid, string configName, bool isSelected, string copyFromName)
        {
            User user = UserContext.Current.User;
            PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

            //Get saved configuration
            CSGenioAtblcfg userTableConfigToCopy = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, copyFromName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            //If record to copy doesn't exist
            if (userTableConfigToCopy == null)
            {
                return Json(new
                {
                    Success = false,
                    ErrorNo = 1,
                    ErrorMsg = "copyFromName view does not exist"
                });
            }

            //Check for saved configuration
            CSGenioAtblcfg userTableConfigSelected = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
                .Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
                .Equal(CSGenioAtblcfg.FldUuid, uuid)
                .Equal(CSGenioAtblcfg.FldName, configName)
                .Equal(CSGenioAtblcfg.FldZzstate, 0))
                .FirstOrDefault();

            //If record already exists
            if (userTableConfigSelected != null)
            {
                return Json(new
                {
                    Success = false,
                    ErrorNo = 2,
                    ErrorMsg = "configName view already exists"
                });
            }

            //Create new record
            userTableConfigSelected = new CSGenioAtblcfg(user);
            sp.openConnection();
            userTableConfigSelected.insert(sp);
            sp.closeConnection();

            userTableConfigSelected.ValCodpsw = user.Codpsw;
            userTableConfigSelected.ValUuid = uuid;
            userTableConfigSelected.ValName = configName;
            userTableConfigSelected.ValConfig = userTableConfigToCopy.ValConfig;

            try
            {
                //Save record
                sp.openTransaction();
                userTableConfigSelected.change(sp, (CriteriaSet)null);
                sp.closeTransaction();

                CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
                    .Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
                    .Equal(CSGenioAtblcfgsel.FldUuid, uuid)
                    .Equal(CSGenioAtblcfgsel.FldZzstate, 0))
                    .FirstOrDefault();

                if (isSelected)
                {
                    //If record doesn't exist, create it
                    if (userTableConfigSelectedInfo == null)
                    {
                        userTableConfigSelectedInfo = new CSGenioAtblcfgsel(user);
                        sp.openConnection();
                        userTableConfigSelectedInfo.insert(sp);
                        sp.closeConnection();

                        userTableConfigSelectedInfo.ValCodpsw = user.Codpsw;
                        userTableConfigSelectedInfo.ValUuid = uuid;
                        userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigSelected.ValCodtblcfg;

                        //Save record
                        sp.openTransaction();
                        userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
                        sp.closeTransaction();
                    }

                    userTableConfigSelectedInfo.ValCodtblcfg = userTableConfigSelected.ValCodtblcfg;

                    //Save record
                    sp.openTransaction();
                    userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
                    sp.closeTransaction();
                }

                //Clear cache
                UserUiSettings.Invalidate(uuid, user);

                return Json(new
                {
                    Success = true,
                    LoadDefaultView = isSelected
                });
            }
            catch (Exception e)
            {
                sp.rollbackTransaction();
                sp.closeConnection();

                return Json(new
                {
                    Success = false,
                    e.Message
                });
            }
        }
    }
}
