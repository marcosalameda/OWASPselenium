using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using Microsoft.AspNetCore.Mvc;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.Controllers.Tblcfg
{
	public class TblcfgController : ControllerBase
	{
        public TblcfgController(UserContextService userContextService) : base(userContextService)
        {
        }

		public ActionResult Index()
		{
			return Json(new { Success = true });
		}

		public class RequestConfigModel
		{
            public string Uuid { get; set; }
            public string ConfigName { get; set; }
            public bool IsSelected { get; set; }
            public string? Data { get; set; }
			public string? CopyFromName { get; set; }
        }

		[HttpPost]
		public ActionResult SaveConfig([FromBody]RequestConfigModel requestModel)
		{
			// Don't allow changes in maintenance mode
			if(Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
			var configName = requestModel.ConfigName;
			var isSelected = requestModel.IsSelected;
			var data = requestModel.Data;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist, create new record
			if (userTableConfig == null)
			{
                userTableConfig = new CSGenioAtblcfg(user);
				sp.openConnection();
                userTableConfig.insert(sp);
				sp.closeConnection();

                userTableConfig.ValCodpsw = user.Codpsw;
                userTableConfig.ValUuid = uuid;
                userTableConfig.ValName = configName;
                userTableConfig.ValConfig = "";
			}

            //Store configuration data
            userTableConfig.ValConfig = data;

			//Set to current version
			userTableConfig.ValUsrsetv = Configuration.UserSettingsVersion;

			try
			{
				//Save record
				sp.openTransaction();
                userTableConfig.change(sp, (CriteriaSet)null);
				sp.closeTransaction();

				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
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
					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

					//Save record
					sp.openTransaction();
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}
				else if (isSelected)
				{
					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

					//Save record
					sp.openTransaction();
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

				return Json(new { Success = true });
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return Json(new { Success = false, e.Message });
			}
		}

		[HttpPost]
        public ActionResult SelectConfig([FromBody] RequestConfigModel requestModel)
		{
            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//If clearing what is set as the default configuration
			if (string.IsNullOrEmpty(configName))
			{
				//Get record of what view is set as default
				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				//If record exists, delete it
				if (userTableConfigSelectedInfo != null)
				{
					sp.openConnection();
					userTableConfigSelectedInfo.delete(sp);
					sp.closeConnection();

					//Clear cache
					TableUiSettings.Invalidate(uuid, user);
				}

				return JsonOK();
			}

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist
			if (userTableConfig == null)
				return Json(new { Success = false });

			try
			{
				//Get record of what view is selected
				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
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

				userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

				//Save record
				sp.openTransaction();
				userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
				sp.closeTransaction();

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

				return Json(new { Success = true });
			}
			catch (Exception e)
			{
				sp.rollbackTransaction();
				sp.closeConnection();

				return Json(new { Success = false, e.Message });
			}
		}

		[HttpPost]
		public ActionResult GetConfig([FromBody] RequestConfigModel requestModel)
		{
            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist
			if (userTableConfig == null)
				return Json(new { Success = false });

			return Json(new
			{
				Success = true,
				Config = userTableConfig.ValConfig,
				ConfigName = configName
			});
		}

		[HttpPost]
		public ActionResult DeleteConfig([FromBody] RequestConfigModel requestModel)
		{
            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			bool deletedDefaultView = false;

			//Get saved configuration
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record doesn't exist
			if (userTableConfig == null)
				return Json(new { Success = false });

			try
			{
				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
					.FirstOrDefault();

				//If record exists
				if (userTableConfigSelectedInfo != null)
				{
					//If view is selected as default
					if (userTableConfigSelectedInfo.ValCodtblcfg.Equals(userTableConfig.ValCodtblcfg))
					{
						sp.openTransaction();
						userTableConfigSelectedInfo.delete(sp);
                        userTableConfig.delete(sp);
						sp.closeTransaction();
						deletedDefaultView = true;
					}
					//If view is not selected as default
					else
					{
						sp.openTransaction();
                        userTableConfig.delete(sp);
						sp.closeTransaction();
					}
				}
				//If record does not exist
				else
				{
					sp.openTransaction();
                    userTableConfig.delete(sp);
					sp.closeTransaction();
				}

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

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

				return Json(new { Success = false, e.Message });
			}
		}

		[HttpPost]
		public ActionResult CopyConfig([FromBody] RequestConfigModel requestModel)
		{
            // Don't allow changes in maintenance mode
            if (Maintenance.Current.IsActive)
                return Json(new { Success = false, Message = Resources.Resources.O_SISTEMA_ENCONTRA_S37912 });

            var uuid = requestModel.Uuid;
            var configName = requestModel.ConfigName;
            var isSelected = requestModel.IsSelected;
            var copyFromName = requestModel.CopyFromName;

			User user = UserContext.Current.User;
			PersistentSupport sp = PersistentSupport.getPersistentSupport(user.Year, user.Name);

			//Get saved configuration
			CSGenioAtblcfg userTableConfigToCopy = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, copyFromName))
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
			CSGenioAtblcfg userTableConfig = CSGenioAtblcfg.searchList(sp, user, CriteriaSet.And()
				.Equal(CSGenioAtblcfg.FldCodpsw, user.Codpsw)
				.Equal(CSGenioAtblcfg.FldUuid, uuid)
				.Equal(CSGenioAtblcfg.FldName, configName))
				.FirstOrDefault();

			//If record already exists
			if (userTableConfig != null)
			{
				return Json(new
				{
					Success = false,
					ErrorNo = 2,
					ErrorMsg = "configName view already exists"
				});
			}

            //Create new record
            userTableConfig = new CSGenioAtblcfg(user);
			sp.openConnection();
            userTableConfig.insert(sp);
			sp.closeConnection();

            userTableConfig.ValCodpsw = user.Codpsw;
            userTableConfig.ValUuid = uuid;
            userTableConfig.ValName = configName;
            userTableConfig.ValConfig = userTableConfigToCopy.ValConfig;

			try
			{
				//Save record
				sp.openTransaction();
                userTableConfig.change(sp, (CriteriaSet)null);
				sp.closeTransaction();

				CSGenioAtblcfgsel userTableConfigSelectedInfo = CSGenioAtblcfgsel.searchList(sp, user, CriteriaSet.And()
					.Equal(CSGenioAtblcfgsel.FldCodpsw, user.Codpsw)
					.Equal(CSGenioAtblcfgsel.FldUuid, uuid))
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
						userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

						//Save record
						sp.openTransaction();
						userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
						sp.closeTransaction();
					}

					userTableConfigSelectedInfo.ValCodtblcfg = userTableConfig.ValCodtblcfg;

					//Save record
					sp.openTransaction();
					userTableConfigSelectedInfo.change(sp, (CriteriaSet)null);
					sp.closeTransaction();
				}

				//Clear cache
				TableUiSettings.Invalidate(uuid, user);

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

				return Json(new { Success = false, e.Message });
			}
		}
	}
}
