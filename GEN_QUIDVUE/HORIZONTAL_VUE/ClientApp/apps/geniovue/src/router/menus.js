// eslint-disable-next-line no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/GQT/menu/GQT_711',
			name: 'menu-GQT_711',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_711/QMenuGqt711.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '711',
				baseArea: 'PWCOM',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_161',
			name: 'menu-TBS_161',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_161/QMenuTbs161.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '161',
				baseArea: 'GENRE',
				hasInitialPHE: false,
				humanKeyFields: ['ValGender'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_1931',
			name: 'menu-TBS_1931',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_1931/QMenuTbs1931.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '1931',
				baseArea: 'FEECA',
				hasInitialPHE: false,
				humanKeyFields: ['ValFeedback'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_81',
			name: 'menu-GQT_81',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_81/QMenuGqt81.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '81',
				baseArea: 'NOTIF',
				hasInitialPHE: false,
				humanKeyFields: ['ValNrcomoda'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_251',
			name: 'menu-WMS_251',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_251/QMenuWms251.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '251',
				baseArea: 'DISST',
				hasInitialPHE: false,
				humanKeyFields: ['ValStatus'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_ASSET_CARD',
			name: 'menu-WMS_ASSET_CARD',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_ASSET_CARD/QMenuWmsAssetCard.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '41111',
				baseArea: 'ASSET',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3111',
			name: 'menu-PTN_3111',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3111/QMenuPtn3111.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3111',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3121',
			name: 'menu-PTN_3121',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3121/QMenuPtn3121.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3121',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3171',
			name: 'menu-PTN_3171',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3171/QMenuPtn3171.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3171',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DM_MB_R',
			name: 'menu-PTN_LIST_DM_MB_R',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DM_MB_R/QMenuPtnListDmMbR.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3I1',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_111',
			name: 'menu-GQT_111',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_111/QMenuGqt111.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '111',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_1211',
			name: 'menu-GQT_1211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_1211/QMenuGqt1211.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '1211',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_1311',
			name: 'menu-GQT_1311',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_1311/QMenuGqt1311.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '1311',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_141',
			name: 'menu-GQT_141',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_141/QMenuGqt141.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '141',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_1411',
			name: 'menu-GQT_1411',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_1411/QMenuGqt1411.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '1411',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
				limitations: ['minLendiValStart', 'maxLendiValStart' /* SE */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_151',
			name: 'menu-GQT_151',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_151/QMenuGqt151.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '151',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_DEVOL',
			name: 'menu-GQT_DEVOL',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_DEVOL/QMenuGqtDevol.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '16111',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_1711',
			name: 'menu-GQT_1711',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_1711/QMenuGqt1711.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '1711',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
				limitations: ['equip' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_DEVOLOBS',
			name: 'menu-GQT_DEVOLOBS',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_DEVOLOBS/QMenuGqtDevolobs.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '18111',
				baseArea: 'LENDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValLendinnr'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_131',
			name: 'menu-IMO_131',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_131/QMenuImo131.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '131',
				baseArea: 'CNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_211',
			name: 'menu-IMO_211',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_211/QMenuImo211.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '211',
				baseArea: 'CNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_231',
			name: 'menu-IMO_231',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_231/QMenuImo231.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '231',
				baseArea: 'CNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4271',
			name: 'menu-WMS_4271',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4271/QMenuWms4271.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4271',
				baseArea: 'CNTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_REPAIR_LIST',
			name: 'menu-GQT_REPAIR_LIST',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_REPAIR_LIST/QMenuGqtRepairList.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '311',
				baseArea: 'REPAR',
				hasInitialPHE: false,
				humanKeyFields: ['ValDtrepara'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T04C_ADD',
			name: 'menu-TRN_T04C_ADD',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T04C_ADD/QMenuTrnT04cAdd.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1421',
				baseArea: 'C_ADD',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_HWIZARD',
			name: 'menu-STY_HWIZARD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_HWIZARD/QMenuStyHwizard.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '42111',
				baseArea: 'SALE',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdentifi'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_VWIZARD',
			name: 'menu-STY_VWIZARD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_VWIZARD/QMenuStyVwizard.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '42211',
				baseArea: 'SALE',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdentifi'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_PWIZARD',
			name: 'menu-STY_PWIZARD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_PWIZARD/QMenuStyPwizard.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '42311',
				baseArea: 'SALE',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdentifi'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_511',
			name: 'menu-GQT_511',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_511/QMenuGqt511.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '511',
				baseArea: 'SALE',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdentifi'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_521',
			name: 'menu-GQT_521',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_521/QMenuGqt521.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '521',
				baseArea: 'SALE',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdentifi'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_531',
			name: 'menu-GQT_531',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_531/QMenuGqt531.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '531',
				baseArea: 'SALE',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdentifi'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_211',
			name: 'menu-WMS_211',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_211/QMenuWms211.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '211',
				baseArea: 'DISPA',
				hasInitialPHE: false,
				humanKeyFields: ['ValDispanr'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_2211',
			name: 'menu-WMS_2211',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_2211/QMenuWms2211.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '2211',
				baseArea: 'DISPA',
				hasInitialPHE: false,
				humanKeyFields: ['ValDispanr'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_2311',
			name: 'menu-WMS_2311',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_2311/QMenuWms2311.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '2311',
				baseArea: 'DISPA',
				hasInitialPHE: false,
				humanKeyFields: ['ValDispanr'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_241',
			name: 'menu-WMS_241',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_241/QMenuWms241.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '241',
				baseArea: 'DISPA',
				hasInitialPHE: false,
				humanKeyFields: ['ValDispanr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_361',
			name: 'menu-STY_361',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_361/QMenuSty361.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '361',
				baseArea: 'INPGR',
				hasInitialPHE: false,
				humanKeyFields: ['ValIcongro'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_411',
			name: 'menu-PTN_411',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_411/QMenuPtn411.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '411',
				baseArea: 'RORDF',
				hasInitialPHE: false,
				humanKeyFields: ['ValOrder'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_331',
			name: 'menu-GQT_331',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_331/QMenuGqt331.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '331',
				baseArea: 'SPECI',
				hasInitialPHE: false,
				humanKeyFields: ['ValEspecial'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_131',
			name: 'menu-TBS_131',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_131/QMenuTbs131.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '131',
				baseArea: 'CATEG',
				hasInitialPHE: false,
				humanKeyFields: ['ValCategoria', 'ValAbbreviation'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2911',
			name: 'menu-GQT_2911',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2911/QMenuGqt2911.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2911',
				baseArea: 'TPEQU',
				hasInitialPHE: false,
				humanKeyFields: ['ValTipoequi'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2A1',
			name: 'menu-GQT_2A1',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2A1/QMenuGqt2a1.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2A1',
				baseArea: 'TPEQU',
				hasInitialPHE: false,
				humanKeyFields: ['ValTipoequi'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2D11',
			name: 'menu-GQT_2D11',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2D11/QMenuGqt2d11.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2D11',
				baseArea: 'TPEQU',
				hasInitialPHE: false,
				humanKeyFields: ['ValTipoequi'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2D21',
			name: 'menu-GQT_2D21',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2D21/QMenuGqt2d21.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2D21',
				baseArea: 'TPEQU',
				hasInitialPHE: false,
				humanKeyFields: ['ValTipoequi'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_721',
			name: 'menu-WMS_721',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_721/QMenuWms721.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '721',
				baseArea: 'ADDRE',
				hasInitialPHE: false,
				humanKeyFields: ['ValAddressuse'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_3591',
			name: 'menu-STY_3591',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_3591/QMenuSty3591.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '3591',
				baseArea: 'CFAQS',
				hasInitialPHE: false,
				humanKeyFields: ['ValCategory'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_B1',
			name: 'menu-GQT_B1',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_B1/QMenuGqtB1.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: 'B1',
				baseArea: 'CFAQS',
				hasInitialPHE: false,
				humanKeyFields: ['ValCategory'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_441',
			name: 'menu-GQT_441',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_441/QMenuGqt441.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '441',
				baseArea: 'GITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T04C_BRN',
			name: 'menu-TRN_T04C_BRN',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T04C_BRN/QMenuTrnT04cBrn.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1411',
				baseArea: 'C_BRN',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_111',
			name: 'menu-PTN_111',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_111/QMenuPtn111.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '111',
				baseArea: 'DECOM',
				hasInitialPHE: false,
				humanKeyFields: ['ValDecomnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2C111',
			name: 'menu-GQT_2C111',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2C111/QMenuGqt2c111.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2C111',
				baseArea: 'DECOM',
				hasInitialPHE: false,
				humanKeyFields: ['ValDecomnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2C31',
			name: 'menu-GQT_2C31',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2C31/QMenuGqt2c31.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2C31',
				baseArea: 'DECOM',
				hasInitialPHE: false,
				humanKeyFields: ['ValDecomnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_A11',
			name: 'menu-GQT_A11',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_A11/QMenuGqtA11.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: 'A11',
				baseArea: 'PROJE',
				hasInitialPHE: false,
				humanKeyFields: ['ValProjecto'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_A31',
			name: 'menu-GQT_A31',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_A31/QMenuGqtA31.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: 'A31',
				baseArea: 'YEAR',
				hasInitialPHE: false,
				humanKeyFields: ['ValYear'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_211',
			name: 'menu-PTN_211',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_211/QMenuPtn211.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '211',
				baseArea: 'REGIO',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegiao'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_221',
			name: 'menu-PTN_221',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_221/QMenuPtn221.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '221',
				baseArea: 'REGIO',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegiao'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_121',
			name: 'menu-IMO_121',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_121/QMenuImo121.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '121',
				baseArea: 'REGIO',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegiao'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_221',
			name: 'menu-IMO_221',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_221/QMenuImo221.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '221',
				baseArea: 'REGIO',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegiao'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_2311',
			name: 'menu-IMO_2311',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_2311/QMenuImo2311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '2311',
				baseArea: 'REGIO',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegiao'],
				limitations: ['cntry' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T01AGENT',
			name: 'menu-TRN_T01AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T01AGENT/QMenuTrnT01agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1111',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T02AGENT',
			name: 'menu-TRN_T02AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T02AGENT/QMenuTrnT02agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1211',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T03AGENT',
			name: 'menu-TRN_T03AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T03AGENT/QMenuTrnT03agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1311',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T05AGENT',
			name: 'menu-TRN_T05AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T05AGENT/QMenuTrnT05agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1511',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T13AGENT',
			name: 'menu-TRN_T13AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T13AGENT/QMenuTrnT13agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1D11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T14AGENT',
			name: 'menu-TRN_T14AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T14AGENT/QMenuTrnT14agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1E11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T15AGENT',
			name: 'menu-TRN_T15AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T15AGENT/QMenuTrnT15agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1F11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T16AGENT',
			name: 'menu-TRN_T16AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T16AGENT/QMenuTrnT16agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1G11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T16AGENTBY',
			name: 'menu-TRN_T16AGENTBY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T16AGENTBY/QMenuTrnT16agentby.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1G41',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T18AGENT',
			name: 'menu-TRN_T18AGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T18AGENT/QMenuTrnT18agent.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1I11',
				baseArea: 'AGENT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_35911',
			name: 'menu-STY_35911',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_35911/QMenuSty35911.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '35911',
				baseArea: 'FAQS',
				hasInitialPHE: false,
				humanKeyFields: ['ValQuestion'],
				limitations: ['cfaqs' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_151',
			name: 'menu-TBS_151',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_151/QMenuTbs151.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '151',
				baseArea: 'TPCON',
				hasInitialPHE: false,
				humanKeyFields: ['ValTipocont'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T03COUNTRY',
			name: 'menu-TRN_T03COUNTRY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T03COUNTRY/QMenuTrnT03country.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1331',
				baseArea: 'CTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T12COUNTRY',
			name: 'menu-TRN_T12COUNTRY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T12COUNTRY/QMenuTrnT12country.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1C111',
				baseArea: 'CTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T13COUNTRY',
			name: 'menu-TRN_T13COUNTRY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T13COUNTRY/QMenuTrnT13country.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1D311',
				baseArea: 'CTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T16COUNTRY',
			name: 'menu-TRN_T16COUNTRY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T16COUNTRY/QMenuTrnT16country.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1G311',
				baseArea: 'CTRY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCountry'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2921',
			name: 'menu-GQT_2921',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2921/QMenuGqt2921.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2921',
				baseArea: 'FAMI1',
				hasInitialPHE: false,
				humanKeyFields: ['ValFamily'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_921',
			name: 'menu-GQT_921',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_921/QMenuGqt921.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '921',
				baseArea: 'LANGU',
				hasInitialPHE: false,
				humanKeyFields: ['ValLangua'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_IMGBACKGROUND',
			name: 'menu-STY_IMGBACKGROUND',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_IMGBACKGROUND/QMenuStyImgbackground.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2211',
				baseArea: 'WPESS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_PESSCARD',
			name: 'menu-STY_PESSCARD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_PESSCARD/QMenuStyPesscard.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2221',
				baseArea: 'WPESS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_CARDIMGTOP',
			name: 'menu-STY_CARDIMGTOP',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_CARDIMGTOP/QMenuStyCardimgtop.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2231',
				baseArea: 'WPESS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_CARDIMGTHUMB',
			name: 'menu-STY_CARDIMGTHUMB',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_CARDIMGTHUMB/QMenuStyCardimgthumb.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2241',
				baseArea: 'WPESS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_IMAGEMAGNIFIER',
			name: 'menu-STY_IMAGEMAGNIFIER',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_IMAGEMAGNIFIER/QMenuStyImagemagnifier.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '35311',
				baseArea: 'WPESS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_471',
			name: 'menu-GQT_471',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_471/QMenuGqt471.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '471',
				baseArea: 'CATTP',
				hasInitialPHE: false,
				humanKeyFields: ['ValTpcatego'],
			}
		},
		{
			path: '/:culture/:system/REG/menu/REG_111',
			name: 'menu-REG_111',
			component: () => import('@/views/menus/ModuleREG/MenuREG_111/QMenuReg111.vue'),
			meta: {
				routeType: 'menu',
				module: 'REG',
				order: '111',
				baseArea: 'REGIS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4231',
			name: 'menu-WMS_4231',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4231/QMenuWms4231.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4231',
				baseArea: 'FACTY',
				hasInitialPHE: false,
				humanKeyFields: ['ValType'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_421',
			name: 'menu-PTN_421',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_421/QMenuPtn421.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '421',
				baseArea: 'RORDI',
				hasInitialPHE: false,
				humanKeyFields: ['ValOrder'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_511',
			name: 'menu-WMS_511',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_511/QMenuWms511.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '511',
				baseArea: 'ENTIT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValInitials'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_5211',
			name: 'menu-WMS_5211',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_5211/QMenuWms5211.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '5211',
				baseArea: 'ENTIT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValInitials'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_5311',
			name: 'menu-WMS_5311',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_5311/QMenuWms5311.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '5311',
				baseArea: 'ENTIT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValInitials'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_5411',
			name: 'menu-WMS_5411',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_5411/QMenuWms5411.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '5411',
				baseArea: 'ENTIT',
				hasInitialPHE: false,
				humanKeyFields: ['ValName', 'ValInitials'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4261',
			name: 'menu-WMS_4261',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4261/QMenuWms4261.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4261',
				baseArea: 'LCEXT',
				hasInitialPHE: false,
				humanKeyFields: ['ValGlnext'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_7111',
			name: 'menu-WMS_7111',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_7111/QMenuWms7111.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '7111',
				baseArea: 'DTTYP',
				hasInitialPHE: false,
				humanKeyFields: ['ValString'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3131',
			name: 'menu-PTN_3131',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3131/QMenuPtn3131.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3131',
				baseArea: 'TBLB',
				hasInitialPHE: false,
				humanKeyFields: ['ValText'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3141',
			name: 'menu-PTN_3141',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3141/QMenuPtn3141.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3141',
				baseArea: 'TBLB',
				hasInitialPHE: false,
				humanKeyFields: ['ValText'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T03PHOTOS',
			name: 'menu-TRN_T03PHOTOS',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T03PHOTOS/QMenuTrnT03photos.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1351',
				baseArea: 'PROPH',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_MODAL',
			name: 'menu-STY_MODAL',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_MODAL/QMenuStyModal.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2411',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_ALERTS',
			name: 'menu-STY_ALERTS',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_ALERTS/QMenuStyAlerts.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '311',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_AUTH',
			name: 'menu-STY_AUTH',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_AUTH/QMenuStyAuth.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '3211',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_BTNFORM',
			name: 'menu-STY_BTNFORM',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_BTNFORM/QMenuStyBtnform.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '3311',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_MULTIFORM',
			name: 'menu-STY_MULTIFORM',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_MULTIFORM/QMenuStyMultiform.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '35611',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_EXTENDFORM',
			name: 'menu-STY_EXTENDFORM',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_EXTENDFORM/QMenuStyExtendform.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '357111',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_EXPOSETABLE',
			name: 'menu-STY_EXPOSETABLE',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_EXPOSETABLE/QMenuStyExposetable.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '357211',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_TIMELIN',
			name: 'menu-STY_TIMELIN',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_TIMELIN/QMenuStyTimelin.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '4111',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_461',
			name: 'menu-GQT_461',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_461/QMenuGqt461.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '461',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_491',
			name: 'menu-GQT_491',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_491/QMenuGqt491.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '491',
				baseArea: 'WAREH',
				hasInitialPHE: false,
				humanKeyFields: ['ValWarehdes'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_171',
			name: 'menu-TBS_171',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_171/QMenuTbs171.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '171',
				baseArea: 'GLOB',
				hasInitialPHE: false,
				humanKeyFields: ['ValHome'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4241',
			name: 'menu-WMS_4241',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4241/QMenuWms4241.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4241',
				baseArea: 'GLOB',
				hasInitialPHE: false,
				humanKeyFields: ['ValHome'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3161',
			name: 'menu-PTN_3161',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3161/QMenuPtn3161.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3161',
				baseArea: 'TBLK',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_6111',
			name: 'menu-GQT_6111',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_6111/QMenuGqt6111.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '6111',
				baseArea: 'CMPNY',
				hasInitialPHE: false,
				humanKeyFields: ['ValDesignat'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_621',
			name: 'menu-GQT_621',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_621/QMenuGqt621.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '621',
				baseArea: 'CMPNY',
				hasInitialPHE: false,
				humanKeyFields: ['ValDesignat'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_111',
			name: 'menu-TBS_111',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_111/QMenuTbs111.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '111',
				baseArea: 'CMPNY',
				hasInitialPHE: false,
				humanKeyFields: ['ValDesignat'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_431',
			name: 'menu-GQT_431',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_431/QMenuGqt431.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '431',
				baseArea: 'INDOC',
				hasInitialPHE: false,
				humanKeyFields: ['ValDocumenr'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4251',
			name: 'menu-WMS_4251',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4251/QMenuWms4251.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4251',
				baseArea: 'LOCAT',
				hasInitialPHE: false,
				humanKeyFields: ['ValGln'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2A11',
			name: 'menu-GQT_2A11',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2A11/QMenuGqt2a11.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2A11',
				baseArea: 'CMPKI',
				hasInitialPHE: false,
				humanKeyFields: ['ValOrder'],
				limitations: ['tpequ' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2B1',
			name: 'menu-GQT_2B1',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2B1/QMenuGqt2b1.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2B1',
				baseArea: 'CMPKI',
				hasInitialPHE: false,
				humanKeyFields: ['ValOrder'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_311',
			name: 'menu-WMS_311',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_311/QMenuWms311.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '311',
				baseArea: 'PRODU',
				hasInitialPHE: false,
				humanKeyFields: ['ValProduct'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_321',
			name: 'menu-WMS_321',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_321/QMenuWms321.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '321',
				baseArea: 'PRODU',
				hasInitialPHE: false,
				humanKeyFields: ['ValProduct'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4121',
			name: 'menu-WMS_4121',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4121/QMenuWms4121.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4121',
				baseArea: 'KINDE',
				hasInitialPHE: false,
				humanKeyFields: ['ValDesignat'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_131',
			name: 'menu-PTN_131',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_131/QMenuPtn131.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '131',
				baseArea: 'RULES',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_6141',
			name: 'menu-GQT_6141',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_6141/QMenuGqt6141.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '6141',
				baseArea: 'CATE1',
				hasInitialPHE: false,
				humanKeyFields: ['ValCategoria', 'ValAbbreviation'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_111',
			name: 'menu-IMO_111',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_111/QMenuImo111.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '111',
				baseArea: 'PROPR',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_1311',
			name: 'menu-IMO_1311',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_1311/QMenuImo1311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '1311',
				baseArea: 'PROPR',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['cntry' /* DB */]
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_1411',
			name: 'menu-PTN_1411',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_1411/QMenuPtn1411.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '1411',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3F111',
			name: 'menu-PTN_3F111',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3F111/QMenuPtn3f111.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3F111',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3F211',
			name: 'menu-PTN_3F211',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3F211/QMenuPtn3f211.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3F211',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_271',
			name: 'menu-GQT_271',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_271/QMenuGqt271.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '271',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_321',
			name: 'menu-GQT_321',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_321/QMenuGqt321.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '321',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_611111',
			name: 'menu-GQT_611111',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_611111/QMenuGqt611111.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '611111',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['cmpny' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_6111211',
			name: 'menu-GQT_6111211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_6111211/QMenuGqt6111211.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '6111211',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['cmpny' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_6111311',
			name: 'menu-GQT_6111311',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_6111311/QMenuGqt6111311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '6111311',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['cmpny' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_61211',
			name: 'menu-GQT_61211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_61211/QMenuGqt61211.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '61211',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_61311',
			name: 'menu-GQT_61311',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_61311/QMenuGqt61311.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '61311',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_61411',
			name: 'menu-GQT_61411',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_61411/QMenuGqt61411.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '61411',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['cate1' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_121',
			name: 'menu-TBS_121',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_121/QMenuTbs121.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '121',
				baseArea: 'PESSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_EDITABLETABLELIST',
			name: 'menu-PTN_EDITABLETABLELIST',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_EDITABLETABLELIST/QMenuPtnEditabletablelist.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '231',
				baseArea: 'GRPB',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3M1',
			name: 'menu-PTN_3M1',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3M1/QMenuPtn3m1.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3M1',
				baseArea: 'GRPB',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4331',
			name: 'menu-WMS_4331',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4331/QMenuWms4331.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4331',
				baseArea: 'USERS',
				hasInitialPHE: false,
				humanKeyFields: [],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_OVERVIEW',
			name: 'menu-STY_OVERVIEW',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_OVERVIEW/QMenuStyOverview.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '11',
				baseArea: 'UICOM',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4311',
			name: 'menu-WMS_4311',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4311/QMenuWms4311.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4311',
				baseArea: 'PERSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4321',
			name: 'menu-WMS_4321',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4321/QMenuWms4321.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4321',
				baseArea: 'PERSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_43211',
			name: 'menu-WMS_43211',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_43211/QMenuWms43211.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '43211',
				baseArea: 'PERSO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
				limitations: ['perso_gender' /* AC */]
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T03CONTACTS',
			name: 'menu-TRN_T03CONTACTS',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T03CONTACTS/QMenuTrnT03contacts.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1361',
				baseArea: 'PROCN',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T18CONTACT',
			name: 'menu-TRN_T18CONTACT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T18CONTACT/QMenuTrnT18contact.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1I21',
				baseArea: 'PROCN',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_1421',
			name: 'menu-PTN_1421',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_1421/QMenuPtn1421.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '1421',
				baseArea: 'HPESS',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_611',
			name: 'menu-WMS_611',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_611/QMenuWms611.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '611',
				baseArea: 'MESSA',
				hasInitialPHE: false,
				humanKeyFields: ['ValIdnotif'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_411',
			name: 'menu-GQT_411',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_411/QMenuGqt411.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '411',
				baseArea: 'OUTPT',
				hasInitialPHE: false,
				humanKeyFields: ['ValDocumenr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_421',
			name: 'menu-GQT_421',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_421/QMenuGqt421.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '421',
				baseArea: 'OUTPT',
				hasInitialPHE: false,
				humanKeyFields: ['ValDocumenr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_441',
			name: 'menu-STY_441',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_441/QMenuSty441.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '441',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_121',
			name: 'menu-PTN_121',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_121/QMenuPtn121.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '121',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MC_F',
			name: 'menu-PTN_LIST_DB_MC_F',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MC_F/QMenuPtnListDbMcF.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '371',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MB_MC_F',
			name: 'menu-PTN_LIST_DB_MB_MC_F',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MB_MC_F/QMenuPtnListDbMbMcF.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '381',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MC_R',
			name: 'menu-PTN_LIST_DB_MC_R',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MC_R/QMenuPtnListDbMcR.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '391',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MB_MC_R',
			name: 'menu-PTN_LIST_DB_MB_MC_R',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MB_MC_R/QMenuPtnListDbMbMcR.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3A1',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_451',
			name: 'menu-GQT_451',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_451/QMenuGqt451.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '451',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_4611',
			name: 'menu-GQT_4611',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_4611/QMenuGqt4611.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '4611',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
				limitations: ['wareh' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_4A1',
			name: 'menu-GQT_4A1',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_4A1/QMenuGqt4a1.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '4A1',
				baseArea: 'ITEM',
				hasInitialPHE: false,
				humanKeyFields: ['ValItemdes'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_4311',
			name: 'menu-PTN_4311',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_4311/QMenuPtn4311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '4311',
				baseArea: 'ROIGF',
				hasInitialPHE: false,
				humanKeyFields: ['ValOrder'],
				limitations: ['rogl1' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_141',
			name: 'menu-TBS_141',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_141/QMenuTbs141.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '141',
				baseArea: 'CONTA',
				hasInitialPHE: false,
				humanKeyFields: ['ValContacto'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_LEAFLET',
			name: 'menu-STY_LEAFLET',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_LEAFLET/QMenuStyLeaflet.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '3541',
				baseArea: 'INSTA',
				hasInitialPHE: false,
				humanKeyFields: ['ValSince'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_LEAFTLETDRAW',
			name: 'menu-STY_LEAFTLETDRAW',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_LEAFTLETDRAW/QMenuStyLeaftletdraw.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '3551',
				baseArea: 'INSTA',
				hasInitialPHE: false,
				humanKeyFields: ['ValSince'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_261',
			name: 'menu-GQT_261',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_261/QMenuGqt261.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '261',
				baseArea: 'INSTA',
				hasInitialPHE: false,
				humanKeyFields: ['ValSince'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_111',
			name: 'menu-WMS_111',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_111/QMenuWms111.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '111',
				baseArea: 'RECEI',
				hasInitialPHE: false,
				humanKeyFields: ['ValNumber'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_121',
			name: 'menu-WMS_121',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_121/QMenuWms121.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '121',
				baseArea: 'RECEI',
				hasInitialPHE: false,
				humanKeyFields: ['ValNumber'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_131',
			name: 'menu-WMS_131',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_131/QMenuWms131.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '131',
				baseArea: 'RECEI',
				hasInitialPHE: false,
				humanKeyFields: ['ValNumber'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3311',
			name: 'menu-PTN_3311',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3311/QMenuPtn3311.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3311',
				baseArea: 'ROOMS',
				hasInitialPHE: false,
				humanKeyFields: ['ValRoomnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3411',
			name: 'menu-PTN_3411',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3411/QMenuPtn3411.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3411',
				baseArea: 'ROOMS',
				hasInitialPHE: false,
				humanKeyFields: ['ValRoomnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_351',
			name: 'menu-PTN_351',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_351/QMenuPtn351.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '351',
				baseArea: 'ROOMS',
				hasInitialPHE: false,
				humanKeyFields: ['ValRoomnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2311',
			name: 'menu-GQT_2311',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2311/QMenuGqt2311.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2311',
				baseArea: 'ROOMS',
				hasInitialPHE: false,
				humanKeyFields: ['ValRoomnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_241',
			name: 'menu-GQT_241',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_241/QMenuGqt241.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '241',
				baseArea: 'ROOMS',
				hasInitialPHE: false,
				humanKeyFields: ['ValRoomnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_361',
			name: 'menu-PTN_361',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_361/QMenuPtn361.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '361',
				baseArea: 'EXPEN',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MC_T',
			name: 'menu-PTN_LIST_DB_MC_T',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MC_T/QMenuPtnListDbMcT.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3B1',
				baseArea: 'EXPEN',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MB_MC_T',
			name: 'menu-PTN_LIST_DB_MB_MC_T',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MB_MC_T/QMenuPtnListDbMbMcT.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3C1',
				baseArea: 'EXPEN',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_MB_TR',
			name: 'menu-PTN_LIST_DB_MB_TR',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_MB_TR/QMenuPtnListDbMbTr.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3J1',
				baseArea: 'EXPEN',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_LIST_DB_TR_F',
			name: 'menu-PTN_LIST_DB_TR_F',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_LIST_DB_TR_F/QMenuPtnListDbTrF.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3K1',
				baseArea: 'EXPEN',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_A21',
			name: 'menu-GQT_A21',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_A21/QMenuGqtA21.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: 'A21',
				baseArea: 'EXPEN',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescript'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_4411',
			name: 'menu-PTN_4411',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_4411/QMenuPtn4411.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '4411',
				baseArea: 'ROIGI',
				hasInitialPHE: false,
				humanKeyFields: ['ValOrder'],
				limitations: ['rogl1' /* DB */]
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_481',
			name: 'menu-GQT_481',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_481/QMenuGqt481.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '481',
				baseArea: 'ITEMC',
				hasInitialPHE: false,
				humanKeyFields: ['ValTpcateg'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3151',
			name: 'menu-PTN_3151',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3151/QMenuPtn3151.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3151',
				baseArea: 'TRSB',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/IMO/menu/IMO_LISTA_REGIAO',
			name: 'menu-IMO_LISTA_REGIAO',
			component: () => import('@/views/menus/ModuleIMO/MenuIMO_LISTA_REGIAO/QMenuImoListaRegiao.vue'),
			meta: {
				routeType: 'menu',
				module: 'IMO',
				order: '31',
				baseArea: 'PWREG',
				hasInitialPHE: false,
				humanKeyFields: [],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_181',
			name: 'menu-TBS_181',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_181/QMenuTbs181.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '181',
				baseArea: 'PWREG',
				hasInitialPHE: false,
				humanKeyFields: [],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_931',
			name: 'menu-GQT_931',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_931/QMenuGqt931.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '931',
				baseArea: 'ANEXD',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3H1',
			name: 'menu-PTN_3H1',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3H1/QMenuPtn3h1.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3H1',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_511',
			name: 'menu-PTN_511',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_511/QMenuPtn511.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '511',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_5211',
			name: 'menu-PTN_5211',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_5211/QMenuPtn5211.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '5211',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_5221',
			name: 'menu-PTN_5221',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_5221/QMenuPtn5221.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '5221',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_5231',
			name: 'menu-PTN_5231',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_5231/QMenuPtn5231.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '5231',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_531',
			name: 'menu-PTN_531',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_531/QMenuPtn531.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '531',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_5311',
			name: 'menu-PTN_5311',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_5311/QMenuPtn5311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '5311',
				baseArea: 'PESS1',
				hasInitialPHE: false,
				limitations: ['pess1' /* DB */]
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_431',
			name: 'menu-PTN_431',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_431/QMenuPtn431.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '431',
				baseArea: 'ROGL1',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_441',
			name: 'menu-PTN_441',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_441/QMenuPtn441.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '441',
				baseArea: 'ROGL1',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_ACCORD',
			name: 'menu-STY_ACCORD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_ACCORD/QMenuStyAccord.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2111',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_GROUPBOX',
			name: 'menu-STY_GROUPBOX',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_GROUPBOX/QMenuStyGroupbox.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2311',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_TABLE',
			name: 'menu-STY_TABLE',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_TABLE/QMenuStyTable.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '251',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_FULLCALENDAR',
			name: 'menu-STY_FULLCALENDAR',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_FULLCALENDAR/QMenuStyFullcalendar.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '35111',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_GOOGLEMAPS',
			name: 'menu-STY_GOOGLEMAPS',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_GOOGLEMAPS/QMenuStyGooglemaps.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '35211',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_371',
			name: 'menu-STY_371',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_371/QMenuSty371.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '371',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_241',
			name: 'menu-PTN_241',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_241/QMenuPtn241.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '241',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_251',
			name: 'menu-PTN_251',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_251/QMenuPtn251.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '251',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_331',
			name: 'menu-PTN_331',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_331/QMenuPtn331.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '331',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_341',
			name: 'menu-PTN_341',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_341/QMenuPtn341.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '341',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3G1',
			name: 'menu-PTN_3G1',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3G1/QMenuPtn3g1.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3G1',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3G11',
			name: 'menu-PTN_3G11',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3G11/QMenuPtn3g11.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3G11',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
				limitations: ['minEquipValDtaquisi', 'maxEquipValDtaquisi' /* SE */]
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_621',
			name: 'menu-PTN_621',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_621/QMenuPtn621.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '621',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_171',
			name: 'menu-GQT_171',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_171/QMenuGqt171.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '171',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_211',
			name: 'menu-GQT_211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_211/QMenuGqt211.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '211',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2211',
			name: 'menu-GQT_2211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2211/QMenuGqt2211.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2211',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_231',
			name: 'menu-GQT_231',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_231/QMenuGqt231.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '231',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_251',
			name: 'menu-GQT_251',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_251/QMenuGqt251.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '251',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2C11',
			name: 'menu-GQT_2C11',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2C11/QMenuGqt2c11.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2C11',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2C211',
			name: 'menu-GQT_2C211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2C211/QMenuGqt2c211.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2C211',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2D111',
			name: 'menu-GQT_2D111',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2D111/QMenuGqt2d111.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2D111',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_2D2111',
			name: 'menu-GQT_2D2111',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_2D2111/QMenuGqt2d2111.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '2D2111',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_6211',
			name: 'menu-GQT_6211',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_6211/QMenuGqt6211.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '6211',
				baseArea: 'EQUIP',
				hasInitialPHE: false,
				humanKeyFields: ['ValRegistnr'],
				limitations: ['cmpny' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T03CITY',
			name: 'menu-TRN_T03CITY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T03CITY/QMenuTrnT03city.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1341',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T12CITY',
			name: 'menu-TRN_T12CITY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T12CITY/QMenuTrnT12city.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1C121',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T13CITY',
			name: 'menu-TRN_T13CITY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T13CITY/QMenuTrnT13city.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1D321',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T16CITY',
			name: 'menu-TRN_T16CITY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T16CITY/QMenuTrnT16city.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1G321',
				baseArea: 'CITY',
				hasInitialPHE: false,
				humanKeyFields: ['ValCity'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_541',
			name: 'menu-GQT_541',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_541/QMenuGqt541.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '541',
				baseArea: 'PWORG',
				hasInitialPHE: false,
				humanKeyFields: [],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_911',
			name: 'menu-GQT_911',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_911/QMenuGqt911.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '911',
				baseArea: 'TRADU',
				hasInitialPHE: false,
				humanKeyFields: ['ValReferenc'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_281',
			name: 'menu-GQT_281',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_281/QMenuGqt281.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: '281',
				baseArea: 'PEDID',
				hasInitialPHE: false,
				humanKeyFields: ['ValNrpedido'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4211',
			name: 'menu-WMS_4211',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4211/QMenuWms4211.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4211',
				baseArea: 'FACIL',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/WMS/menu/WMS_4221',
			name: 'menu-WMS_4221',
			component: () => import('@/views/menus/ModuleWMS/MenuWMS_4221/QMenuWms4221.vue'),
			meta: {
				routeType: 'menu',
				module: 'WMS',
				order: '4221',
				baseArea: 'FACIL',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_321',
			name: 'menu-PTN_321',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_321/QMenuPtn321.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '321',
				baseArea: 'AERO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_1911',
			name: 'menu-TBS_1911',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_1911/QMenuTbs1911.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '1911',
				baseArea: 'AERO',
				hasInitialPHE: false,
				humanKeyFields: ['ValName'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_TABS',
			name: 'menu-STY_TABS',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_TABS/QMenuStyTabs.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '2611',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_INPTFIELD',
			name: 'menu-STY_INPTFIELD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_INPTFIELD/QMenuStyInptfield.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '3411',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_358111',
			name: 'menu-STY_358111',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_358111/QMenuSty358111.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '358111',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_358211',
			name: 'menu-STY_358211',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_358211/QMenuSty358211.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '358211',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_261',
			name: 'menu-PTN_261',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_261/QMenuPtn261.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '261',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_271',
			name: 'menu-PTN_271',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_271/QMenuPtn271.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '271',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_611',
			name: 'menu-PTN_611',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_611/QMenuPtn611.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '611',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/TBS/menu/TBS_1921',
			name: 'menu-TBS_1921',
			component: () => import('@/views/menus/ModuleTBS/MenuTBS_1921/QMenuTbs1921.vue'),
			meta: {
				routeType: 'menu',
				module: 'TBS',
				order: '1921',
				baseArea: 'FLDS',
				hasInitialPHE: false,
				humanKeyFields: ['ValDescrip'],
			}
		},
		{
			path: '/:culture/:system/GQT/menu/GQT_A41',
			name: 'menu-GQT_A41',
			component: () => import('@/views/menus/ModuleGQT/MenuGQT_A41/QMenuGqtA41.vue'),
			meta: {
				routeType: 'menu',
				module: 'GQT',
				order: 'A41',
				baseArea: 'AGREG',
				hasInitialPHE: false,
				humanKeyFields: ['ValValue'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T02PROPERTY',
			name: 'menu-TRN_T02PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T02PROPERTY/QMenuTrnT02property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1221',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T03PROPERTY',
			name: 'menu-TRN_T03PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T03PROPERTY/QMenuTrnT03property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1321',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T05PROPERTY',
			name: 'menu-TRN_T05PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T05PROPERTY/QMenuTrnT05property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1521',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T06PROPERTY',
			name: 'menu-TRN_T06PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T06PROPERTY/QMenuTrnT06property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1611',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T07PROPERTY',
			name: 'menu-TRN_T07PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T07PROPERTY/QMenuTrnT07property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1711',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T08PROPERTY',
			name: 'menu-TRN_T08PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T08PROPERTY/QMenuTrnT08property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1811',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T09PROPERTY',
			name: 'menu-TRN_T09PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T09PROPERTY/QMenuTrnT09property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1911',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T10PROPERTY',
			name: 'menu-TRN_T10PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T10PROPERTY/QMenuTrnT10property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1A11',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T11PROPERTY',
			name: 'menu-TRN_T11PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T11PROPERTY/QMenuTrnT11property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1B11',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T13PROPERTY',
			name: 'menu-TRN_T13PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T13PROPERTY/QMenuTrnT13property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1D21',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T14PROPERTY',
			name: 'menu-TRN_T14PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T14PROPERTY/QMenuTrnT14property.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1E111',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
				limitations: ['agent' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T15PROPERTY',
			name: 'menu-TRN_T15PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T15PROPERTY/QMenuTrnT15property.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1F111',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
				limitations: ['agent' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T16PROPERTY',
			name: 'menu-TRN_T16PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T16PROPERTY/QMenuTrnT16property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1G21',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T16PROPERTYBYAGENT',
			name: 'menu-TRN_T16PROPERTYBYAGENT',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T16PROPERTYBYAGENT/QMenuTrnT16propertybyagent.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1G411',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
				limitations: ['agent' /* DB */]
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T17PROPERTY',
			name: 'menu-TRN_T17PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T17PROPERTY/QMenuTrnT17property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1H11',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/TRN/menu/TRN_T19PROPERTY',
			name: 'menu-TRN_T19PROPERTY',
			component: () => import('@/views/menus/ModuleTRN/MenuTRN_T19PROPERTY/QMenuTrnT19property.vue'),
			meta: {
				routeType: 'menu',
				module: 'TRN',
				order: '1J11',
				baseArea: 'PROPE',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitle'],
			}
		},
		{
			path: '/:culture/:system/STY/menu/STY_DASHBOARD',
			name: 'menu-STY_DASHBOARD',
			component: () => import('@/views/menus/ModuleSTY/MenuSTY_DASHBOARD/QMenuStyDashboard.vue'),
			meta: {
				routeType: 'menu',
				module: 'STY',
				order: '431',
				baseArea: 'Dashboard',
				isDashboardPage: true,
				hasInitialPHE: false
			}
		},
		{
			path: '/:culture/:system/PTN/menu/PTN_3L1',
			name: 'menu-PTN_3L1',
			component: () => import('@/views/menus/ModulePTN/MenuPTN_3L1/QMenuPtn3l1.vue'),
			meta: {
				routeType: 'menu',
				module: 'PTN',
				order: '3L1',
				baseArea: 'Dashboard',
				isDashboardPage: true,
				hasInitialPHE: false
			}
		},
	]
}
