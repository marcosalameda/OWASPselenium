import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/ABATE/:mode/:id?',
			name: 'form-ABATE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAbate/QFormAbate.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'DECOM',
				humanKeyFields: ['ValDecomnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/ABATEREQ/:mode/:id?',
			name: 'form-ABATEREQ',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAbatereq/QFormAbatereq.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'DECOM',
				humanKeyFields: ['ValDecomnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/ACCORDI/:mode/:id?',
			name: 'form-ACCORDI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAccordi/QFormAccordi.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/ADDRE/:mode/:id?',
			name: 'form-ADDRE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAddre/QFormAddre.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ADDRE',
				humanKeyFields: ['ValAddressuse']
			}
		},
		{
			path: '/:culture/:system/:module/form/AERO/:mode/:id?',
			name: 'form-AERO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAero/QFormAero.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AERO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/AGENT01/:mode/:id?',
			name: 'form-AGENT01',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAgent01/QFormAgent01.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AGENT',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/AGENT02/:mode/:id?',
			name: 'form-AGENT02',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAgent02/QFormAgent02.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AGENT',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/AGENT05/:mode/:id?',
			name: 'form-AGENT05',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAgent05/QFormAgent05.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AGENT',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/AGREG/:mode/:id?',
			name: 'form-AGREG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAgreg/QFormAgreg.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'AGREG',
				humanKeyFields: ['ValValue']
			}
		},
		{
			path: '/:culture/:system/:module/form/ANEXD/:mode/:id?',
			name: 'form-ANEXD',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAnexd/QFormAnexd.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ANEXD',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/ANO/:mode/:id?',
			name: 'form-ANO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAno/QFormAno.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'YEAR',
				humanKeyFields: ['ValYear']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARMAPESS/:mode/:id?',
			name: 'form-ARMAPESS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArmapess/QFormArmapess.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WPESS',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARMAZ/:mode/:id?',
			name: 'form-ARMAZ',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArmaz/QFormArmaz.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARMAZ03/:mode/:id?',
			name: 'form-ARMAZ03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArmaz03/QFormArmaz03.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARMAZPOP/:mode/:id?',
			name: 'form-ARMAZPOP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArmazpop/QFormArmazpop.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARTGL/:mode/:id?',
			name: 'form-ARTGL',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArtgl/QFormArtgl.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GITEM',
				humanKeyFields: ['ValItemdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARTIG/:mode/:id?',
			name: 'form-ARTIG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArtig/QFormArtig.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEM',
				humanKeyFields: ['ValItemdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARTIGEXT/:mode/:id?',
			name: 'form-ARTIGEXT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArtigext/QFormArtigext.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEM',
				humanKeyFields: ['ValItemdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARTIGINV/:mode/:id?',
			name: 'form-ARTIGINV',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArtiginv/QFormArtiginv.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEM',
				humanKeyFields: ['ValItemdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ARTIGVAL/:mode/:id?',
			name: 'form-ARTIGVAL',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormArtigval/QFormArtigval.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEM',
				humanKeyFields: ['ValItemdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/ASSMA/:mode/:id?',
			name: 'form-ASSMA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAssma/QFormAssma.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ASSMA',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/ASSPA/:mode/:id?',
			name: 'form-ASSPA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAsspa/QFormAsspa.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ASSPA',
				humanKeyFields: ['ValText']
			}
		},
		{
			path: '/:culture/:system/:module/form/ATTAC/:mode/:id?',
			name: 'form-ATTAC',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAttac/QFormAttac.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ATTAC',
				humanKeyFields: ['ValAttached']
			}
		},
		{
			path: '/:culture/:system/:module/form/AUTHENT/:mode/:id?',
			name: 'form-AUTHENT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormAuthent/QFormAuthent.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/BTNSFORM/:mode/:id?',
			name: 'form-BTNSFORM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormBtnsform/QFormBtnsform.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/C_ADD/:mode/:id?',
			name: 'form-C_ADD',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCAdd/QFormCAdd.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'C_ADD',
				humanKeyFields: ['ValCountry']
			}
		},
		{
			path: '/:culture/:system/:module/form/C_BRN/:mode/:id?',
			name: 'form-C_BRN',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCBrn/QFormCBrn.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'C_BRN',
				humanKeyFields: ['ValCountry']
			}
		},
		{
			path: '/:culture/:system/:module/form/CAMPO/:mode/:id?',
			name: 'form-CAMPO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCampo/QFormCampo.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLDS',
				humanKeyFields: ['ValDescrip']
			}
		},
		{
			path: '/:culture/:system/:module/form/CATAR/:mode/:id?',
			name: 'form-CATAR',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCatar/QFormCatar.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEMC',
				humanKeyFields: ['ValTpcateg']
			}
		},
		{
			path: '/:culture/:system/:module/form/CATE1/:mode/:id?',
			name: 'form-CATE1',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCate1/QFormCate1.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CATE1',
				humanKeyFields: ['ValCategoria', 'ValAbbreviation']
			}
		},
		{
			path: '/:culture/:system/:module/form/CATEG/:mode/:id?',
			name: 'form-CATEG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCateg/QFormCateg.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CATEG',
				humanKeyFields: ['ValCategoria', 'ValAbbreviation']
			}
		},
		{
			path: '/:culture/:system/:module/form/CFAQS/:mode/:id?',
			name: 'form-CFAQS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCfaqs/QFormCfaqs.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CFAQS',
				humanKeyFields: ['ValCategory']
			}
		},
		{
			path: '/:culture/:system/:module/form/CITY03/:mode/:id?',
			name: 'form-CITY03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCity03/QFormCity03.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CITY',
				humanKeyFields: ['ValCity']
			}
		},
		{
			path: '/:culture/:system/:module/form/CMPKI/:mode/:id?',
			name: 'form-CMPKI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCmpki/QFormCmpki.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CMPKI',
				humanKeyFields: ['ValOrder']
			}
		},
		{
			path: '/:culture/:system/:module/form/COMOD/:mode/:id?',
			name: 'form-COMOD',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormComod/QFormComod.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LENDI',
				humanKeyFields: ['ValLendinnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/CONTA/:mode/:id?',
			name: 'form-CONTA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormConta/QFormConta.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CONTA',
				humanKeyFields: ['ValContacto']
			}
		},
		{
			path: '/:culture/:system/:module/form/CONTAC03/:mode/:id?',
			name: 'form-CONTAC03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormContac03/QFormContac03.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROCN',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/CONTAC06/:mode/:id?',
			name: 'form-CONTAC06',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormContac06/QFormContac06.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROCN',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/CONTAC19/:mode/:id?',
			name: 'form-CONTAC19',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormContac19/QFormContac19.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROCN',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/CTRY03/:mode/:id?',
			name: 'form-CTRY03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormCtry03/QFormCtry03.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CTRY',
				humanKeyFields: ['ValCountry']
			}
		},
		{
			path: '/:culture/:system/:module/form/DENTR/:mode/:id?',
			name: 'form-DENTR',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDentr/QFormDentr.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INDOC',
				humanKeyFields: ['ValDocumenr']
			}
		},
		{
			path: '/:culture/:system/:module/form/DESPE/:mode/:id?',
			name: 'form-DESPE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDespe/QFormDespe.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EXPEN',
				humanKeyFields: ['ValDescript']
			}
		},
		{
			path: '/:culture/:system/:module/form/DILIN/:mode/:id?',
			name: 'form-DILIN',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDilin/QFormDilin.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'DILIN',
				humanKeyFields: ['ValLinenumb']
			}
		},
		{
			path: '/:culture/:system/:module/form/DISPA/:mode/:id?',
			name: 'form-DISPA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDispa/QFormDispa.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'DISPA',
				humanKeyFields: ['ValDispanr']
			}
		},
		{
			path: '/:culture/:system/:module/form/DISST/:mode/:id?',
			name: 'form-DISST',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDisst/QFormDisst.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'DISST',
				humanKeyFields: ['ValStatus']
			}
		},
		{
			path: '/:culture/:system/:module/form/DOCSD/:mode/:id?',
			name: 'form-DOCSD',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDocsd/QFormDocsd.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'OUDOC',
				humanKeyFields: ['ValNrdocsda']
			}
		},
		{
			path: '/:culture/:system/:module/form/DSAID/:mode/:id?',
			name: 'form-DSAID',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDsaid/QFormDsaid.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'OUTPT',
				humanKeyFields: ['ValDocumenr']
			}
		},
		{
			path: '/:culture/:system/:module/form/DTTYP/:mode/:id?',
			name: 'form-DTTYP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormDttyp/QFormDttyp.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'DTTYP',
				humanKeyFields: ['ValString']
			}
		},
		{
			path: '/:culture/:system/:module/form/EMPRE/:mode/:id?',
			name: 'form-EMPRE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEmpre/QFormEmpre.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CMPNY',
				humanKeyFields: ['ValDesignat']
			}
		},
		{
			path: '/:culture/:system/:module/form/ENTIT/:mode/:id?',
			name: 'form-ENTIT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEntit/QFormEntit.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ENTIT',
				humanKeyFields: ['ValName', 'ValInitials']
			}
		},
		{
			path: '/:culture/:system/:module/form/ENTIX/:mode/:id?',
			name: 'form-ENTIX',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEntix/QFormEntix.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ENTIT',
				humanKeyFields: ['ValName', 'ValInitials']
			}
		},
		{
			path: '/:culture/:system/:module/form/EQUDOCUM/:mode/:id?',
			name: 'form-EQUDOCUM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEqudocum/QFormEqudocum.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/EQUIGROU/:mode/:id?',
			name: 'form-EQUIGROU',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEquigrou/QFormEquigrou.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/EQUIP/:mode/:id?',
			name: 'form-EQUIP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEquip/QFormEquip.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/EQUIPM/:mode/:id?',
			name: 'form-EQUIPM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEquipm/QFormEquipm.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ASSET',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/ESPEC/:mode/:id?',
			name: 'form-ESPEC',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEspec/QFormEspec.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'SPECI',
				humanKeyFields: ['ValEspecial']
			}
		},
		{
			path: '/:culture/:system/:module/form/ESPPE/:mode/:id?',
			name: 'form-ESPPE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEsppe/QFormEsppe.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ESPPE',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/EVCAT/:mode/:id?',
			name: 'form-EVCAT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormEvcat/QFormEvcat.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EVCAT',
				humanKeyFields: ['ValSince']
			}
		},
		{
			path: '/:culture/:system/:module/form/EXTERNO/:mode/:id?',
			name: 'form-EXTERNO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormExterno/QFormExterno.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PESSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/EXTFORMS/:mode/:id?',
			name: 'form-EXTFORMS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormExtforms/QFormExtforms.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/FACIL/:mode/:id?',
			name: 'form-FACIL',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFacil/QFormFacil.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FACIL',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/FACILFEX/:mode/:id?',
			name: 'form-FACILFEX',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFacilfex/QFormFacilfex.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FACIL',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/FACTY/:mode/:id?',
			name: 'form-FACTY',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFacty/QFormFacty.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FACTY',
				humanKeyFields: ['ValType']
			}
		},
		{
			path: '/:culture/:system/:module/form/FAMI1/:mode/:id?',
			name: 'form-FAMI1',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFami1/QFormFami1.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FAMI1',
				humanKeyFields: ['ValFamily']
			}
		},
		{
			path: '/:culture/:system/:module/form/FAQS/:mode/:id?',
			name: 'form-FAQS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFaqs/QFormFaqs.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FAQS',
				humanKeyFields: ['ValQuestion']
			}
		},
		{
			path: '/:culture/:system/:module/form/FEECA/:mode/:id?',
			name: 'form-FEECA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFeeca/QFormFeeca.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FEECA',
				humanKeyFields: ['ValFeedback']
			}
		},
		{
			path: '/:culture/:system/:module/form/FIELDHLP/:mode/:id?',
			name: 'form-FIELDHLP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFieldhlp/QFormFieldhlp.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLDS',
				humanKeyFields: ['ValDescrip']
			}
		},
		{
			path: '/:culture/:system/:module/form/FLDSCOND/:mode/:id?',
			name: 'form-FLDSCOND',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFldscond/QFormFldscond.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLDS',
				humanKeyFields: ['ValDescrip']
			}
		},
		{
			path: '/:culture/:system/:module/form/FLDSTBL/:mode/:id?',
			name: 'form-FLDSTBL',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFldstbl/QFormFldstbl.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLDS',
				humanKeyFields: ['ValDescrip']
			}
		},
		{
			path: '/:culture/:system/:module/form/FOTOS/:mode/:id?',
			name: 'form-FOTOS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFotos/QFormFotos.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PHOTO',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/FULLCALE/:mode/:id?',
			name: 'form-FULLCALE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormFullcale/QFormFullcale.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/GENCO/:mode/:id?',
			name: 'form-GENCO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGenco/QFormGenco.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GENRE',
				humanKeyFields: ['ValGender']
			}
		},
		{
			path: '/:culture/:system/:module/form/GLOB/:mode/:id?',
			name: 'form-GLOB',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGlob/QFormGlob.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GLOB',
				humanKeyFields: ['ValHome']
			}
		},
		{
			path: '/:culture/:system/:module/form/GLOBFACT/:mode/:id?',
			name: 'form-GLOBFACT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGlobfact/QFormGlobfact.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GLOB',
				humanKeyFields: ['ValHome']
			}
		},
		{
			path: '/:culture/:system/:module/form/GMAPS/:mode/:id?',
			name: 'form-GMAPS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGmaps/QFormGmaps.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/GROUPBX/:mode/:id?',
			name: 'form-GROUPBX',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGroupbx/QFormGroupbx.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/GRPB/:mode/:id?',
			name: 'form-GRPB',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormGrpb/QFormGrpb.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GRPB',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/HOMEG/:mode/:id?',
			name: 'form-HOMEG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormHomeg/QFormHomeg.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'GLOB',
				humanKeyFields: ['ValHome']
			}
		},
		{
			path: '/:culture/:system/:module/form/IDIOM/:mode/:id?',
			name: 'form-IDIOM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormIdiom/QFormIdiom.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LANGU',
				humanKeyFields: ['ValLangua']
			}
		},
		{
			path: '/:culture/:system/:module/form/IMGMAGN/:mode/:id?',
			name: 'form-IMGMAGN',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormImgmagn/QFormImgmagn.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WPESS',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/INFIELDS/:mode/:id?',
			name: 'form-INFIELDS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormInfields/QFormInfields.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLDS',
				humanKeyFields: ['ValDescrip']
			}
		},
		{
			path: '/:culture/:system/:module/form/INGROUPS/:mode/:id?',
			name: 'form-INGROUPS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormIngroups/QFormIngroups.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INPGR',
				humanKeyFields: ['ValIcongro']
			}
		},
		{
			path: '/:culture/:system/:module/form/INSTA/:mode/:id?',
			name: 'form-INSTA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormInsta/QFormInsta.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INSTA',
				humanKeyFields: ['ValSince']
			}
		},
		{
			path: '/:culture/:system/:module/form/KINDE/:mode/:id?',
			name: 'form-KINDE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormKinde/QFormKinde.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'KINDE',
				humanKeyFields: ['ValDesignat']
			}
		},
		{
			path: '/:culture/:system/:module/form/LCEXT/:mode/:id?',
			name: 'form-LCEXT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLcext/QFormLcext.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LCEXT',
				humanKeyFields: ['ValGlnext']
			}
		},
		{
			path: '/:culture/:system/:module/form/LDENT/:mode/:id?',
			name: 'form-LDENT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLdent/QFormLdent.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LDENT',
				humanKeyFields: ['ValLine']
			}
		},
		{
			path: '/:culture/:system/:module/form/LDENTNOR/:mode/:id?',
			name: 'form-LDENTNOR',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLdentnor/QFormLdentnor.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LDENT',
				humanKeyFields: ['ValLine']
			}
		},
		{
			path: '/:culture/:system/:module/form/LDSAI/:mode/:id?',
			name: 'form-LDSAI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLdsai/QFormLdsai.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'OUTPU',
				humanKeyFields: ['ValLine']
			}
		},
		{
			path: '/:culture/:system/:module/form/LEAFLETD/:mode/:id?',
			name: 'form-LEAFLETD',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLeafletd/QFormLeafletd.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INSTA',
				humanKeyFields: ['ValSince']
			}
		},
		{
			path: '/:culture/:system/:module/form/LEAFLETT/:mode/:id?',
			name: 'form-LEAFLETT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLeaflett/QFormLeaflett.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'INSTA',
				humanKeyFields: ['ValSince']
			}
		},
		{
			path: '/:culture/:system/:module/form/LISTACAM/:mode/:id?',
			name: 'form-LISTACAM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormListacam/QFormListacam.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'FLDS',
				humanKeyFields: ['ValDescrip']
			}
		},
		{
			path: '/:culture/:system/:module/form/LNHAG/:mode/:id?',
			name: 'form-LNHAG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLnhag/QFormLnhag.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LNHAG',
				humanKeyFields: ['ValQtdtpequ']
			}
		},
		{
			path: '/:culture/:system/:module/form/LNHDE/:mode/:id?',
			name: 'form-LNHDE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLnhde/QFormLnhde.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LNHDE',
				humanKeyFields: ['ValOrdem']
			}
		},
		{
			path: '/:culture/:system/:module/form/LNHDF/:mode/:id?',
			name: 'form-LNHDF',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLnhdf/QFormLnhdf.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LNHDF',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/LNHPD/:mode/:id?',
			name: 'form-LNHPD',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLnhpd/QFormLnhpd.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LNHPD',
				humanKeyFields: ['ValLine']
			}
		},
		{
			path: '/:culture/:system/:module/form/LOCAT/:mode/:id?',
			name: 'form-LOCAT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormLocat/QFormLocat.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'LOCAT',
				humanKeyFields: ['ValGln']
			}
		},
		{
			path: '/:culture/:system/:module/form/MANUA/:mode/:id?',
			name: 'form-MANUA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormManua/QFormManua.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MANUA',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/MESSA/:mode/:id?',
			name: 'form-MESSA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMessa/QFormMessa.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MESSA',
				humanKeyFields: ['ValIdnotif']
			}
		},
		{
			path: '/:culture/:system/:module/form/MLTFORM/:mode/:id?',
			name: 'form-MLTFORM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMltform/QFormMltform.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/MOVIM/:mode/:id?',
			name: 'form-MOVIM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormMovim/QFormMovim.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'MOVIM',
				humanKeyFields: ['ValDhmudanc']
			}
		},
		{
			path: '/:culture/:system/:module/form/NOTIF/:mode/:id?',
			name: 'form-NOTIF',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormNotif/QFormNotif.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'NOTIF',
				humanKeyFields: ['ValNrcomoda']
			}
		},
		{
			path: '/:culture/:system/:module/form/PAIS/:mode/:id?',
			name: 'form-PAIS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPais/QFormPais.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CNTRY',
				humanKeyFields: ['ValCountry']
			}
		},
		{
			path: '/:culture/:system/:module/form/PARAM/:mode/:id?',
			name: 'form-PARAM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormParam/QFormParam.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PARAM',
				humanKeyFields: ['ValParameter']
			}
		},
		{
			path: '/:culture/:system/:module/form/PEDID/:mode/:id?',
			name: 'form-PEDID',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPedid/QFormPedid.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PEDID',
				humanKeyFields: ['ValNrpedido']
			}
		},
		{
			path: '/:culture/:system/:module/form/PEOPLE/:mode/:id?',
			name: 'form-PEOPLE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPeople/QFormPeople.vue'),
			meta: {
				routeType: 'form',
				baseArea: '',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/PERSO/:mode/:id?',
			name: 'form-PERSO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPerso/QFormPerso.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PERSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PESS1/:mode/:id?',
			name: 'form-PESS1',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPess1/QFormPess1.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PESS1',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PESSO/:mode/:id?',
			name: 'form-PESSO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPesso/QFormPesso.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PESSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PESSO1/:mode/:id?',
			name: 'form-PESSO1',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPesso1/QFormPesso1.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PESSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PESSOHIS/:mode/:id?',
			name: 'form-PESSOHIS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPessohis/QFormPessohis.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PESSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PESSOSEP/:mode/:id?',
			name: 'form-PESSOSEP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPessosep/QFormPessosep.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PESSO',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PESSPOP/:mode/:id?',
			name: 'form-PESSPOP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPesspop/QFormPesspop.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WPESS',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PHOTO03/:mode/:id?',
			name: 'form-PHOTO03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPhoto03/QFormPhoto03.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPH',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PLIST/:mode/:id?',
			name: 'form-PLIST',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPlist/QFormPlist.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ITEM',
				humanKeyFields: ['ValItemdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/PRODU/:mode/:id?',
			name: 'form-PRODU',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormProdu/QFormProdu.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PRODU',
				humanKeyFields: ['ValProduct']
			}
		},
		{
			path: '/:culture/:system/:module/form/PRODUSIM/:mode/:id?',
			name: 'form-PRODUSIM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormProdusim/QFormProdusim.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PRODU',
				humanKeyFields: ['ValProduct']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROJE/:mode/:id?',
			name: 'form-PROJE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormProje/QFormProje.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROJE',
				humanKeyFields: ['ValProjecto']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE01/:mode/:id?',
			name: 'form-PROPE01',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope01/QFormPrope01.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE03/:mode/:id?',
			name: 'form-PROPE03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope03/QFormPrope03.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE05/:mode/:id?',
			name: 'form-PROPE05',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope05/QFormPrope05.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE06/:mode/:id?',
			name: 'form-PROPE06',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope06/QFormPrope06.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE07/:mode/:id?',
			name: 'form-PROPE07',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope07/QFormPrope07.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE08/:mode/:id?',
			name: 'form-PROPE08',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope08/QFormPrope08.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE09/:mode/:id?',
			name: 'form-PROPE09',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope09/QFormPrope09.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE10/:mode/:id?',
			name: 'form-PROPE10',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope10/QFormPrope10.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE11/:mode/:id?',
			name: 'form-PROPE11',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope11/QFormPrope11.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE17/:mode/:id?',
			name: 'form-PROPE17',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope17/QFormPrope17.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPE19/:mode/:id?',
			name: 'form-PROPE19',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPrope19/QFormPrope19.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPE',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPPAIS/:mode/:id?',
			name: 'form-PROPPAIS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormProppais/QFormProppais.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CNTRY',
				humanKeyFields: ['ValCountry']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPR00/:mode/:id?',
			name: 'form-PROPR00',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPropr00/QFormPropr00.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPR',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PROPRALL/:mode/:id?',
			name: 'form-PROPRALL',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormProprall/QFormProprall.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PROPR',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PWCOM/:mode/:id?',
			name: 'form-PWCOM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPwcom/QFormPwcom.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PWCOM',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/PWORG/:mode/:id?',
			name: 'form-PWORG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPworg/QFormPworg.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PWORG',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/PWREG/:mode/:id?',
			name: 'form-PWREG',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPwreg/QFormPwreg.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PWREG',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/RECEI/:mode/:id?',
			name: 'form-RECEI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRecei/QFormRecei.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'RECEI',
				humanKeyFields: ['ValNumber']
			}
		},
		{
			path: '/:culture/:system/:module/form/REGIA/:mode/:id?',
			name: 'form-REGIA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRegia/QFormRegia.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REGIO',
				humanKeyFields: ['ValRegiao']
			}
		},
		{
			path: '/:culture/:system/:module/form/REGIA_ML/:mode/:id?',
			name: 'form-REGIA_ML',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRegiaMl/QFormRegiaMl.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REGIO',
				humanKeyFields: ['ValRegiao']
			}
		},
		{
			path: '/:culture/:system/:module/form/REGIA_ON/:mode/:id?',
			name: 'form-REGIA_ON',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRegiaOn/QFormRegiaOn.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REGIO',
				humanKeyFields: ['ValRegiao']
			}
		},
		{
			path: '/:culture/:system/:module/form/REGIAPRO/:mode/:id?',
			name: 'form-REGIAPRO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRegiapro/QFormRegiapro.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REGIO',
				humanKeyFields: ['ValRegiao']
			}
		},
		{
			path: '/:culture/:system/:module/form/REGIS/:mode/:id?',
			name: 'form-REGIS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRegis/QFormRegis.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REGIS',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/REGRA/:mode/:id?',
			name: 'form-REGRA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRegra/QFormRegra.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'RULES',
				humanKeyFields: ['ValDescript']
			}
		},
		{
			path: '/:culture/:system/:module/form/RELIN/:mode/:id?',
			name: 'form-RELIN',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRelin/QFormRelin.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'RELIN',
				humanKeyFields: ['ValLinenumb']
			}
		},
		{
			path: '/:culture/:system/:module/form/REPAR/:mode/:id?',
			name: 'form-REPAR',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRepar/QFormRepar.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'REPAR',
				humanKeyFields: ['ValDtrepara']
			}
		},
		{
			path: '/:culture/:system/:module/form/ROGL1/:mode/:id?',
			name: 'form-ROGL1',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRogl1/QFormRogl1.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ROGL1',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/ROIGF/:mode/:id?',
			name: 'form-ROIGF',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRoigf/QFormRoigf.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ROIGF',
				humanKeyFields: ['ValOrder']
			}
		},
		{
			path: '/:culture/:system/:module/form/ROIGI/:mode/:id?',
			name: 'form-ROIGI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRoigi/QFormRoigi.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ROIGI',
				humanKeyFields: ['ValOrder']
			}
		},
		{
			path: '/:culture/:system/:module/form/RORDF/:mode/:id?',
			name: 'form-RORDF',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRordf/QFormRordf.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'RORDF',
				humanKeyFields: ['ValOrder']
			}
		},
		{
			path: '/:culture/:system/:module/form/RORDI/:mode/:id?',
			name: 'form-RORDI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormRordi/QFormRordi.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'RORDI',
				humanKeyFields: ['ValOrder']
			}
		},
		{
			path: '/:culture/:system/:module/form/SALAS/:mode/:id?',
			name: 'form-SALAS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormSalas/QFormSalas.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'ROOMS',
				humanKeyFields: ['ValRoomnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/SBCAT/:mode/:id?',
			name: 'form-SBCAT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormSbcat/QFormSbcat.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'SBCAT',
				humanKeyFields: ['ValSubcateg']
			}
		},
		{
			path: '/:culture/:system/:module/form/TABPR/:mode/:id?',
			name: 'form-TABPR',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTabpr/QFormTabpr.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TABPR',
				humanKeyFields: ['ValSince']
			}
		},
		{
			path: '/:culture/:system/:module/form/TBLB/:mode/:id?',
			name: 'form-TBLB',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTblb/QFormTblb.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TBLB',
				humanKeyFields: ['ValText']
			}
		},
		{
			path: '/:culture/:system/:module/form/TBLK/:mode/:id?',
			name: 'form-TBLK',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTblk/QFormTblk.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TBLK',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/TIMEQUIP/:mode/:id?',
			name: 'form-TIMEQUIP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTimequip/QFormTimequip.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/TMLINE/:mode/:id?',
			name: 'form-TMLINE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTmline/QFormTmline.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'WAREH',
				humanKeyFields: ['ValWarehdes']
			}
		},
		{
			path: '/:culture/:system/:module/form/TPCAT/:mode/:id?',
			name: 'form-TPCAT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTpcat/QFormTpcat.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CATTP',
				humanKeyFields: ['ValTpcatego']
			}
		},
		{
			path: '/:culture/:system/:module/form/TPCON/:mode/:id?',
			name: 'form-TPCON',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTpcon/QFormTpcon.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TPCON',
				humanKeyFields: ['ValTipocont']
			}
		},
		{
			path: '/:culture/:system/:module/form/TPEQ1/:mode/:id?',
			name: 'form-TPEQ1',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTpeq1/QFormTpeq1.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TPEQ1',
				humanKeyFields: ['ValTipoequi']
			}
		},
		{
			path: '/:culture/:system/:module/form/TPEQU/:mode/:id?',
			name: 'form-TPEQU',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTpequ/QFormTpequ.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TPEQU',
				humanKeyFields: ['ValTipoequi']
			}
		},
		{
			path: '/:culture/:system/:module/form/TPPRO/:mode/:id?',
			name: 'form-TPPRO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTppro/QFormTppro.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TPPRO',
				humanKeyFields: ['ValTppropri']
			}
		},
		{
			path: '/:culture/:system/:module/form/TRADU/:mode/:id?',
			name: 'form-TRADU',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTradu/QFormTradu.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TRADU',
				humanKeyFields: ['ValReferenc']
			}
		},
		{
			path: '/:culture/:system/:module/form/TRSB/:mode/:id?',
			name: 'form-TRSB',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTrsb/QFormTrsb.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TRSB',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/UICOM/:mode/:id?',
			name: 'form-UICOM',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormUicom/QFormUicom.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'UICOM',
				humanKeyFields: ['ValName']
			}
		},
		{
			path: '/:culture/:system/:module/form/USERS/:mode/:id?',
			name: 'form-USERS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormUsers/QFormUsers.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'USERS',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDA/:mode/:id?',
			name: 'form-VENDA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVenda/QFormVenda.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/:mode/:id?',
			name: 'form-VENDAW',
			props: route => propsConverter(route),
			meta: {
				routeType: 'form',
				isWizard: true,
				wizardId: 'Vendaw_Fases',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW01/:mode/:id?',
			name: 'form-VENDAW-VENDAW01',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw01/QFormVendawVendaw01.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW02/:mode/:id?',
			name: 'form-VENDAW-VENDAW02',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw02/QFormVendawVendaw02.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW03/:mode/:id?',
			name: 'form-VENDAW-VENDAW03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw03/QFormVendawVendaw03.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW04/:mode/:id?',
			name: 'form-VENDAW-VENDAW04',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw04/QFormVendawVendaw04.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW05/:mode/:id?',
			name: 'form-VENDAW-VENDAW05',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw05/QFormVendawVendaw05.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW06/:mode/:id?',
			name: 'form-VENDAW-VENDAW06',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw06/QFormVendawVendaw06.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW07/:mode/:id?',
			name: 'form-VENDAW-VENDAW07',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw07/QFormVendawVendaw07.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAW/VENDAW08/:mode/:id?',
			name: 'form-VENDAW-VENDAW08',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw08/QFormVendawVendaw08.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAW',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/:mode/:id?',
			name: 'form-VENDAWP',
			props: route => propsConverter(route),
			meta: {
				routeType: 'form',
				isWizard: true,
				wizardId: 'Vendawp_Fases',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW01/:mode/:id?',
			name: 'form-VENDAWP-VENDAW01',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw01/QFormVendawpVendaw01.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW02/:mode/:id?',
			name: 'form-VENDAWP-VENDAW02',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw02/QFormVendawpVendaw02.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW03/:mode/:id?',
			name: 'form-VENDAWP-VENDAW03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw03/QFormVendawpVendaw03.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW04/:mode/:id?',
			name: 'form-VENDAWP-VENDAW04',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw04/QFormVendawpVendaw04.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW05/:mode/:id?',
			name: 'form-VENDAWP-VENDAW05',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw05/QFormVendawpVendaw05.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW06/:mode/:id?',
			name: 'form-VENDAWP-VENDAW06',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw06/QFormVendawpVendaw06.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW07/:mode/:id?',
			name: 'form-VENDAWP-VENDAW07',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw07/QFormVendawpVendaw07.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWP/VENDAW08/:mode/:id?',
			name: 'form-VENDAWP-VENDAW08',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw08/QFormVendawpVendaw08.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWP',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/:mode/:id?',
			name: 'form-VENDAWV',
			props: route => propsConverter(route),
			meta: {
				routeType: 'form',
				isWizard: true,
				wizardId: 'Vendawv_Fases',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW01/:mode/:id?',
			name: 'form-VENDAWV-VENDAW01',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw01/QFormVendawvVendaw01.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW02/:mode/:id?',
			name: 'form-VENDAWV-VENDAW02',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw02/QFormVendawvVendaw02.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW03/:mode/:id?',
			name: 'form-VENDAWV-VENDAW03',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw03/QFormVendawvVendaw03.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW04/:mode/:id?',
			name: 'form-VENDAWV-VENDAW04',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw04/QFormVendawvVendaw04.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW05/:mode/:id?',
			name: 'form-VENDAWV-VENDAW05',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw05/QFormVendawvVendaw05.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW06/:mode/:id?',
			name: 'form-VENDAWV-VENDAW06',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw06/QFormVendawvVendaw06.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW07/:mode/:id?',
			name: 'form-VENDAWV-VENDAW07',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw07/QFormVendawvVendaw07.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VENDAWV/VENDAW08/:mode/:id?',
			name: 'form-VENDAWV-VENDAW08',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVendaw08/QFormVendawvVendaw08.vue'),
			meta: {
				routeType: 'form',
				isWizardStep: true,
				parentRoute: 'form-VENDAWV',
				baseArea: 'SALE',
				humanKeyFields: ['ValIdentifi']
			}
		},
		{
			path: '/:culture/:system/:module/form/VISIT/:mode/:id?',
			name: 'form-VISIT',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVisit/QFormVisit.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'VISIT',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/VISIT2/:mode/:id?',
			name: 'form-VISIT2',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormVisit2/QFormVisit2.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'VISIT',
				humanKeyFields: ['ValTitle']
			}
		},
		{
			path: '/:culture/:system/:module/form/WID_COLA/:mode/:id?',
			name: 'form-WID_COLA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWidCola/QFormWidCola.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CMPNY',
				humanKeyFields: ['ValDesignat']
			}
		},
		{
			path: '/:culture/:system/:module/form/WID_EQUI/:mode/:id?',
			name: 'form-WID_EQUI',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWidEqui/QFormWidEqui.vue'),
			meta: {
				routeType: 'form',
				baseArea: '',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/WID_GRAP/:mode/:id?',
			name: 'form-WID_GRAP',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWidGrap/QFormWidGrap.vue'),
			meta: {
				routeType: 'form',
				baseArea: '',
				humanKeyFields: []
			}
		},
		{
			path: '/:culture/:system/:module/form/WID_IEQU/:mode/:id?',
			name: 'form-WID_IEQU',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWidIequ/QFormWidIequ.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EQUIP',
				humanKeyFields: ['ValRegistnr']
			}
		},
		{
			path: '/:culture/:system/:module/form/WID_PESS/:mode/:id?',
			name: 'form-WID_PESS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormWidPess/QFormWidPess.vue'),
			meta: {
				routeType: 'form',
				baseArea: '',
				humanKeyFields: []
			}
		},
	]
}
