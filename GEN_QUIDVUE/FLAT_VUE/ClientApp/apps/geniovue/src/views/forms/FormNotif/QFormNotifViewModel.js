/* eslint-disable @typescript-eslint/no-unused-vars */
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
/* eslint-enable @typescript-eslint/no-unused-vars */

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
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'NOTIF',
			area: 'NOTIF',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Notif',
				updateFilesTickets: 'UpdateFilesTicketsNotif',
				setFile: 'SetFileNotif'
			}
		})

		/** The primary key. */
		this.ValCodnotif = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodnotif',
			originId: 'ValCodnotif',
			area: 'NOTIF',
			field: 'CODNOTIF',
			description: '',
		}).cloneFrom(values?.ValCodnotif))
		this.stopWatchers.push(watch(() => this.ValCodnotif.value, (newValue, oldValue) => this.onUpdate('notif.codnotif', this.ValCodnotif, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'NOTIF',
			field: 'CODPESSO',
			relatedArea: 'PESS2',
			description: computed(() => this.Resources.RECIPIENT_KEY__COMOD31618),
		}).cloneFrom(values?.ValCodpesso))
		this.stopWatchers.push(watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('notif.codpesso', this.ValCodpesso, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValNrcomoda = reactive(new modelFieldType.Number({
			id: 'ValNrcomoda',
			originId: 'ValNrcomoda',
			area: 'NOTIF',
			field: 'NRCOMODA',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO__OF_THE_DADATO35934),
		}).cloneFrom(values?.ValNrcomoda))
		this.stopWatchers.push(watch(() => this.ValNrcomoda.value, (newValue, oldValue) => this.onUpdate('notif.nrcomoda', this.ValNrcomoda, newValue, oldValue)))

		this.ValBegin = reactive(new modelFieldType.DateTime({
			id: 'ValBegin',
			originId: 'ValBegin',
			area: 'NOTIF',
			field: 'BEGIN',
			description: computed(() => this.Resources.BEGINNING18124),
		}).cloneFrom(values?.ValBegin))
		this.stopWatchers.push(watch(() => this.ValBegin.value, (newValue, oldValue) => this.onUpdate('notif.begin', this.ValBegin, newValue, oldValue)))

		this.ValEnd = reactive(new modelFieldType.DateTime({
			id: 'ValEnd',
			originId: 'ValEnd',
			area: 'NOTIF',
			field: 'END',
			description: computed(() => this.Resources.END47577),
		}).cloneFrom(values?.ValEnd))
		this.stopWatchers.push(watch(() => this.ValEnd.value, (newValue, oldValue) => this.onUpdate('notif.end', this.ValEnd, newValue, oldValue)))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'NOTIF',
			field: 'EMAIL',
			maxLength: 100,
			description: computed(() => this.Resources.RECIPIENT_S_EMAIL43894),
		}).cloneFrom(values?.ValEmail))
		this.stopWatchers.push(watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('notif.email', this.ValEmail, newValue, oldValue)))

		this.ValIdnotif = reactive(new modelFieldType.String({
			id: 'ValIdnotif',
			originId: 'ValIdnotif',
			area: 'NOTIF',
			field: 'IDNOTIF',
			maxLength: 50,
			description: computed(() => this.Resources.NOTIFICATION_ID_THAT61751),
		}).cloneFrom(values?.ValIdnotif))
		this.stopWatchers.push(watch(() => this.ValIdnotif.value, (newValue, oldValue) => this.onUpdate('notif.idnotif', this.ValIdnotif, newValue, oldValue)))

		this.ValIdmsg = reactive(new modelFieldType.String({
			id: 'ValIdmsg',
			originId: 'ValIdmsg',
			area: 'NOTIF',
			field: 'IDMSG',
			maxLength: 85,
			description: computed(() => this.Resources.MESSAGE_ID37133),
		}).cloneFrom(values?.ValIdmsg))
		this.stopWatchers.push(watch(() => this.ValIdmsg.value, (newValue, oldValue) => this.onUpdate('notif.idmsg', this.ValIdmsg, newValue, oldValue)))

		this.ValMessage = reactive(new modelFieldType.MultiLineString({
			id: 'ValMessage',
			originId: 'ValMessage',
			area: 'NOTIF',
			field: 'MESSAGE',
			description: computed(() => this.Resources.TEXT_OF_THE_SENT_MES52307),
		}).cloneFrom(values?.ValMessage))
		this.stopWatchers.push(watch(() => this.ValMessage.value, (newValue, oldValue) => this.onUpdate('notif.message', this.ValMessage, newValue, oldValue)))

		this.ValMailerr = reactive(new modelFieldType.String({
			id: 'ValMailerr',
			originId: 'ValMailerr',
			area: 'NOTIF',
			field: 'MAILERR',
			maxLength: 300,
			description: computed(() => this.Resources.ERROR_SENDING_EMAIL53846),
		}).cloneFrom(values?.ValMailerr))
		this.stopWatchers.push(watch(() => this.ValMailerr.value, (newValue, oldValue) => this.onUpdate('notif.mailerr', this.ValMailerr, newValue, oldValue)))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'NOTIF',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.RECIPIENT65165),
		}).cloneFrom(values?.ValDesignat))
		this.stopWatchers.push(watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('notif.designat', this.ValDesignat, newValue, oldValue)))

		this.ValCreatdat = reactive(new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'NOTIF',
			field: 'CREATDAT',
			isFixed: true,
			description: computed(() => this.Resources.CREATION__DATE13180),
		}).cloneFrom(values?.ValCreatdat))
		this.stopWatchers.push(watch(() => this.ValCreatdat.value, (newValue, oldValue) => this.onUpdate('notif.creatdat', this.ValCreatdat, newValue, oldValue)))

		this.ValCreatope = reactive(new modelFieldType.String({
			id: 'ValCreatope',
			originId: 'ValCreatope',
			area: 'NOTIF',
			field: 'CREATOPE',
			maxLength: 20,
			isFixed: true,
			description: computed(() => this.Resources.CREATION__OPERATOR50535),
		}).cloneFrom(values?.ValCreatope))
		this.stopWatchers.push(watch(() => this.ValCreatope.value, (newValue, oldValue) => this.onUpdate('notif.creatope', this.ValCreatope, newValue, oldValue)))

		this.ValReturned = reactive(new modelFieldType.Boolean({
			id: 'ValReturned',
			originId: 'ValReturned',
			area: 'NOTIF',
			field: 'RETURNED',
			description: computed(() => this.Resources.RETURNED01606),
		}).cloneFrom(values?.ValReturned))
		this.stopWatchers.push(watch(() => this.ValReturned.value, (newValue, oldValue) => this.onUpdate('notif.returned', this.ValReturned, newValue, oldValue)))

		this.ValDtdevolu = reactive(new modelFieldType.Date({
			id: 'ValDtdevolu',
			originId: 'ValDtdevolu',
			area: 'NOTIF',
			field: 'DTDEVOLU',
			description: computed(() => this.Resources.RETURN32222),
		}).cloneFrom(values?.ValDtdevolu))
		this.stopWatchers.push(watch(() => this.ValDtdevolu.value, (newValue, oldValue) => this.onUpdate('notif.dtdevolu', this.ValDtdevolu, newValue, oldValue)))

		this.TablePess2Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess2Name',
			originId: 'ValName',
			area: 'PESS2',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePess2Name))
		this.stopWatchers.push(watch(() => this.TablePess2Name.value, (newValue, oldValue) => this.onUpdate('pess2.name', this.TablePess2Name, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormNotifViewModel instance.
	 * @returns {QFormNotifViewModel} A new instance of QFormNotifViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodnotif'

	get QPrimaryKey() { return this.ValCodnotif.value }
	set QPrimaryKey(value) { this.ValCodnotif.updateValue(value) }
}
