/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'ENTIX',
			area: 'ENTIT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Entix',
				updateFilesTickets: 'UpdateFilesTicketsEntix',
				setFile: 'SetFileEntix'
			}
		})

		/** The primary key. */
		this.ValCodentit = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'ENTIT',
			field: 'CODENTIT',
			description: '',
		}).cloneFrom(values?.ValCodentit))
		this.stopWatchers.push(watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('entit.codentit', this.ValCodentit, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValFirstfacilitie = reactive(new modelFieldType.ForeignKey({
			id: 'ValFirstfacilitie',
			originId: 'ValFirstfacilitie',
			area: 'ENTIT',
			field: 'FIRSTFAC',
			relatedArea: 'FACI1',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:entit.founded', 'fieldChange:entit.codentit'],
				isServerRecalc: true,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources.FIRST_INCORPORATED_F63789),
		}).cloneFrom(values?.ValFirstfacilitie))
		this.stopWatchers.push(watch(() => this.ValFirstfacilitie.value, (newValue, oldValue) => this.onUpdate('entit.firstfacilitie', this.ValFirstfacilitie, newValue, oldValue)))

		this.ValLastfacilitie = reactive(new modelFieldType.ForeignKey({
			id: 'ValLastfacilitie',
			originId: 'ValLastfacilitie',
			area: 'ENTIT',
			field: 'LASTFACI',
			relatedArea: 'FACI2',
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:entit.founded', 'fieldChange:entit.codentit'],
				isServerRecalc: true,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources.LAST_INCORPORATED_FA29541),
		}).cloneFrom(values?.ValLastfacilitie))
		this.stopWatchers.push(watch(() => this.ValLastfacilitie.value, (newValue, oldValue) => this.onUpdate('entit.lastfacilitie', this.ValLastfacilitie, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'ENTIT',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.ValName, newValue, oldValue)))

		this.ValFounded = reactive(new modelFieldType.Date({
			id: 'ValFounded',
			originId: 'ValFounded',
			area: 'ENTIT',
			field: 'FOUNDED',
			description: computed(() => this.Resources.FOUNDED_IN54120),
		}).cloneFrom(values?.ValFounded))
		this.stopWatchers.push(watch(() => this.ValFounded.value, (newValue, oldValue) => this.onUpdate('entit.founded', this.ValFounded, newValue, oldValue)))

		this.ValInitials = reactive(new modelFieldType.String({
			id: 'ValInitials',
			originId: 'ValInitials',
			area: 'ENTIT',
			field: 'INITIALS',
			maxLength: 10,
			description: computed(() => this.Resources.COMPANY_INITIALS56204),
		}).cloneFrom(values?.ValInitials))
		this.stopWatchers.push(watch(() => this.ValInitials.value, (newValue, oldValue) => this.onUpdate('entit.initials', this.ValInitials, newValue, oldValue)))

		this.ValRegistra = reactive(new modelFieldType.String({
			id: 'ValRegistra',
			originId: 'ValRegistra',
			area: 'ENTIT',
			field: 'REGISTRA',
			maxLength: 30,
			description: computed(() => this.Resources.LEGAL_REGISTRATION04413),
		}).cloneFrom(values?.ValRegistra))
		this.stopWatchers.push(watch(() => this.ValRegistra.value, (newValue, oldValue) => this.onUpdate('entit.registra', this.ValRegistra, newValue, oldValue)))

		this.ValTaxnumbe = reactive(new modelFieldType.String({
			id: 'ValTaxnumbe',
			originId: 'ValTaxnumbe',
			area: 'ENTIT',
			field: 'TAXNUMBE',
			maxLength: 30,
			description: computed(() => this.Resources.VAT_NUMBER24236),
		}).cloneFrom(values?.ValTaxnumbe))
		this.stopWatchers.push(watch(() => this.ValTaxnumbe.value, (newValue, oldValue) => this.onUpdate('entit.taxnumbe', this.ValTaxnumbe, newValue, oldValue)))

		this.ValIban = reactive(new modelFieldType.String({
			id: 'ValIban',
			originId: 'ValIban',
			area: 'ENTIT',
			field: 'IBAN',
			maxLength: 33,
			description: computed(() => this.Resources.IBAN__INTERNATIONAL_45066),
		}).cloneFrom(values?.ValIban))
		this.stopWatchers.push(watch(() => this.ValIban.value, (newValue, oldValue) => this.onUpdate('entit.iban', this.ValIban, newValue, oldValue)))

		this.ValPhonenum = reactive(new modelFieldType.String({
			id: 'ValPhonenum',
			originId: 'ValPhonenum',
			area: 'ENTIT',
			field: 'PHONENUM',
			maxLength: 20,
			description: computed(() => this.Resources.PHONE_NUMBER20774),
		}).cloneFrom(values?.ValPhonenum))
		this.stopWatchers.push(watch(() => this.ValPhonenum.value, (newValue, oldValue) => this.onUpdate('entit.phonenum', this.ValPhonenum, newValue, oldValue)))

		this.ValOwner = reactive(new modelFieldType.String({
			id: 'ValOwner',
			originId: 'ValOwner',
			area: 'ENTIT',
			field: 'OWNER',
			maxLength: 50,
			description: computed(() => this.Resources.OWNER09558),
		}).cloneFrom(values?.ValOwner))
		this.stopWatchers.push(watch(() => this.ValOwner.value, (newValue, oldValue) => this.onUpdate('entit.owner', this.ValOwner, newValue, oldValue)))

		this.ValCarrier = reactive(new modelFieldType.Boolean({
			id: 'ValCarrier',
			originId: 'ValCarrier',
			area: 'ENTIT',
			field: 'CARRIER',
			description: computed(() => this.Resources.CARRIER64855),
		}).cloneFrom(values?.ValCarrier))
		this.stopWatchers.push(watch(() => this.ValCarrier.value, (newValue, oldValue) => this.onUpdate('entit.carrier', this.ValCarrier, newValue, oldValue)))

		this.ValSupplier = reactive(new modelFieldType.Boolean({
			id: 'ValSupplier',
			originId: 'ValSupplier',
			area: 'ENTIT',
			field: 'SUPPLIER',
			description: computed(() => this.Resources.SUPPLIER17230),
		}).cloneFrom(values?.ValSupplier))
		this.stopWatchers.push(watch(() => this.ValSupplier.value, (newValue, oldValue) => this.onUpdate('entit.supplier', this.ValSupplier, newValue, oldValue)))

		this.ValManufact = reactive(new modelFieldType.Boolean({
			id: 'ValManufact',
			originId: 'ValManufact',
			area: 'ENTIT',
			field: 'MANUFACT',
			description: computed(() => this.Resources.MANUFACTURER50759),
		}).cloneFrom(values?.ValManufact))
		this.stopWatchers.push(watch(() => this.ValManufact.value, (newValue, oldValue) => this.onUpdate('entit.manufact', this.ValManufact, newValue, oldValue)))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'ENTIT',
			field: 'TELEPHON',
			maxLength: 20,
			description: computed(() => this.Resources.TELEPHONE28697),
		}).cloneFrom(values?.ValTelephon))
		this.stopWatchers.push(watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('entit.telephon', this.ValTelephon, newValue, oldValue)))

		this.ValFax = reactive(new modelFieldType.String({
			id: 'ValFax',
			originId: 'ValFax',
			area: 'ENTIT',
			field: 'FAX',
			maxLength: 20,
			description: computed(() => this.Resources.FAX08532),
		}).cloneFrom(values?.ValFax))
		this.stopWatchers.push(watch(() => this.ValFax.value, (newValue, oldValue) => this.onUpdate('entit.fax', this.ValFax, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'ENTIT',
			field: 'EMAIL',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('entit.email', this.ValEmail, newValue, oldValue)))

		this.ValWebsite = reactive(new modelFieldType.String({
			id: 'ValWebsite',
			originId: 'ValWebsite',
			area: 'ENTIT',
			field: 'WEBSITE',
			maxLength: 254,
			description: computed(() => this.Resources.WEB_SITE06263),
		}).cloneFrom(values?.ValWebsite))
		this.stopWatchers.push(watch(() => this.ValWebsite.value, (newValue, oldValue) => this.onUpdate('entit.website', this.ValWebsite, newValue, oldValue)))

		this.ValPerson = reactive(new modelFieldType.String({
			id: 'ValPerson',
			originId: 'ValPerson',
			area: 'ENTIT',
			field: 'PERSON',
			maxLength: 85,
			description: computed(() => this.Resources.PERSON_DEPARTMENT_TO28777),
		}).cloneFrom(values?.ValPerson))
		this.stopWatchers.push(watch(() => this.ValPerson.value, (newValue, oldValue) => this.onUpdate('entit.person', this.ValPerson, newValue, oldValue)))

		this.ValContact = reactive(new modelFieldType.String({
			id: 'ValContact',
			originId: 'ValContact',
			area: 'ENTIT',
			field: 'CONTACT',
			maxLength: 30,
			description: computed(() => this.Resources.CONTACT_TELEPHONE_NU12694),
		}).cloneFrom(values?.ValContact))
		this.stopWatchers.push(watch(() => this.ValContact.value, (newValue, oldValue) => this.onUpdate('entit.contact', this.ValContact, newValue, oldValue)))

		this.ValLanguage = reactive(new modelFieldType.String({
			id: 'ValLanguage',
			originId: 'ValLanguage',
			area: 'ENTIT',
			field: 'LANGUAGE',
			maxLength: 2,
			description: computed(() => this.Resources.LANGUAGE16872),
		}).cloneFrom(values?.ValLanguage))
		this.stopWatchers.push(watch(() => this.ValLanguage.value, (newValue, oldValue) => this.onUpdate('entit.language', this.ValLanguage, newValue, oldValue)))

		this.ValCurrency = reactive(new modelFieldType.String({
			id: 'ValCurrency',
			originId: 'ValCurrency',
			area: 'ENTIT',
			field: 'CURRENCY',
			maxLength: 3,
			description: computed(() => this.Resources.CURRENCY13881),
		}).cloneFrom(values?.ValCurrency))
		this.stopWatchers.push(watch(() => this.ValCurrency.value, (newValue, oldValue) => this.onUpdate('entit.currency', this.ValCurrency, newValue, oldValue)))

		this.ValBuilding = reactive(new modelFieldType.String({
			id: 'ValBuilding',
			originId: 'ValBuilding',
			area: 'ENTIT',
			field: 'BUILDING',
			maxLength: 25,
			description: computed(() => this.Resources.BUILDING_HOUSE_NUMBE20738),
		}).cloneFrom(values?.ValBuilding))
		this.stopWatchers.push(watch(() => this.ValBuilding.value, (newValue, oldValue) => this.onUpdate('entit.building', this.ValBuilding, newValue, oldValue)))

		this.ValStreet = reactive(new modelFieldType.String({
			id: 'ValStreet',
			originId: 'ValStreet',
			area: 'ENTIT',
			field: 'STREET',
			maxLength: 50,
			description: computed(() => this.Resources.STREET44324),
		}).cloneFrom(values?.ValStreet))
		this.stopWatchers.push(watch(() => this.ValStreet.value, (newValue, oldValue) => this.onUpdate('entit.street', this.ValStreet, newValue, oldValue)))

		this.ValTown = reactive(new modelFieldType.String({
			id: 'ValTown',
			originId: 'ValTown',
			area: 'ENTIT',
			field: 'TOWN',
			maxLength: 50,
			description: computed(() => this.Resources.TOWN_CITY16259),
		}).cloneFrom(values?.ValTown))
		this.stopWatchers.push(watch(() => this.ValTown.value, (newValue, oldValue) => this.onUpdate('entit.town', this.ValTown, newValue, oldValue)))

		this.ValCounty = reactive(new modelFieldType.String({
			id: 'ValCounty',
			originId: 'ValCounty',
			area: 'ENTIT',
			field: 'COUNTY',
			maxLength: 50,
			description: computed(() => this.Resources.COUNTY_PROVINCE34285),
		}).cloneFrom(values?.ValCounty))
		this.stopWatchers.push(watch(() => this.ValCounty.value, (newValue, oldValue) => this.onUpdate('entit.county', this.ValCounty, newValue, oldValue)))

		this.ValState = reactive(new modelFieldType.String({
			id: 'ValState',
			originId: 'ValState',
			area: 'ENTIT',
			field: 'STATE',
			maxLength: 50,
			description: computed(() => this.Resources.STATE_PROVINCE28516),
		}).cloneFrom(values?.ValState))
		this.stopWatchers.push(watch(() => this.ValState.value, (newValue, oldValue) => this.onUpdate('entit.state', this.ValState, newValue, oldValue)))

		this.ValPostalco = reactive(new modelFieldType.String({
			id: 'ValPostalco',
			originId: 'ValPostalco',
			area: 'ENTIT',
			field: 'POSTALCO',
			maxLength: 10,
			description: computed(() => this.Resources.ZIP_POSTAL_CODE55613),
		}).cloneFrom(values?.ValPostalco))
		this.stopWatchers.push(watch(() => this.ValPostalco.value, (newValue, oldValue) => this.onUpdate('entit.postalco', this.ValPostalco, newValue, oldValue)))

		this.ValPobox = reactive(new modelFieldType.String({
			id: 'ValPobox',
			originId: 'ValPobox',
			area: 'ENTIT',
			field: 'POBOX',
			maxLength: 5,
			description: computed(() => this.Resources.POST_OFFICE_BOX06223),
		}).cloneFrom(values?.ValPobox))
		this.stopWatchers.push(watch(() => this.ValPobox.value, (newValue, oldValue) => this.onUpdate('entit.pobox', this.ValPobox, newValue, oldValue)))

		this.TableFaci1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFaci1Name',
			originId: 'ValName',
			area: 'FACI1',
			field: 'NAME',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.FACILITY_NAME19514),
		}).cloneFrom(values?.TableFaci1Name))
		this.stopWatchers.push(watch(() => this.TableFaci1Name.value, (newValue, oldValue) => this.onUpdate('faci1.name', this.TableFaci1Name, newValue, oldValue)))

		this.TableFaci2Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableFaci2Name',
			originId: 'ValName',
			area: 'FACI2',
			field: 'NAME',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.FACILITY_NAME19514),
		}).cloneFrom(values?.TableFaci2Name))
		this.stopWatchers.push(watch(() => this.TableFaci2Name.value, (newValue, oldValue) => this.onUpdate('faci2.name', this.TableFaci2Name, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormEntixViewModel instance.
	 * @returns {QFormEntixViewModel} A new instance of QFormEntixViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodentit'

	get QPrimaryKey() { return this.ValCodentit.value }
	set QPrimaryKey(value) { this.ValCodentit.updateValue(value) }
}
