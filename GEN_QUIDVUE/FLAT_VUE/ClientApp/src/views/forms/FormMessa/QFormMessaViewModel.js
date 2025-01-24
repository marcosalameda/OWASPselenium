/* eslint-disable no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import ViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@/mixins/genericFunctions.js'
import modelFieldType from '@/mixins/formModelFieldTypes.js'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@/api/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends ViewModelBase
 */
export default class ViewModel extends ViewModelBase
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

		/** The view model metadata */
		_merge(this.modelInfo, {
			name: 'MESSA',
			area: 'MESSA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_MESSA'
			}
		})

		/** The primary key. */
		this.ValCodmessa = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmessa',
			originId: 'ValCodmessa',
			area: 'MESSA',
			field: 'CODMESSA',
			description: '',
		}).cloneFrom(values?.ValCodmessa))
		watch(() => this.ValCodmessa.value, (newValue, oldValue) => this.onUpdate('messa.codmessa', this.ValCodmessa, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodentit = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodentit',
			originId: 'ValCodentit',
			area: 'MESSA',
			field: 'CODENTIT',
			relatedArea: 'ENTIT',
			description: computed(() => this.Resources._ENTITY_22923),
		}).cloneFrom(values?.ValCodentit))
		watch(() => this.ValCodentit.value, (newValue, oldValue) => this.onUpdate('messa.codentit', this.ValCodentit, newValue, oldValue))

		this.ValCodperso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperso',
			originId: 'ValCodperso',
			area: 'MESSA',
			field: 'CODPERSO',
			relatedArea: 'PERSO',
			description: computed(() => this.Resources._PERSON_09109),
		}).cloneFrom(values?.ValCodperso))
		watch(() => this.ValCodperso.value, (newValue, oldValue) => this.onUpdate('messa.codperso', this.ValCodperso, newValue, oldValue))

		/** The remaining form fields. */
		this.ValIdnotif = reactive(new modelFieldType.String({
			id: 'ValIdnotif',
			originId: 'ValIdnotif',
			area: 'MESSA',
			field: 'IDNOTIF',
			maxLength: 50,
			description: computed(() => this.Resources.NOTIFICATION_ID25507),
		}).cloneFrom(values?.ValIdnotif))
		watch(() => this.ValIdnotif.value, (newValue, oldValue) => this.onUpdate('messa.idnotif', this.ValIdnotif, newValue, oldValue))

		this.ValIdmsg = reactive(new modelFieldType.String({
			id: 'ValIdmsg',
			originId: 'ValIdmsg',
			area: 'MESSA',
			field: 'IDMSG',
			maxLength: 50,
			description: computed(() => this.Resources.MESSAGE_ID37133),
		}).cloneFrom(values?.ValIdmsg))
		watch(() => this.ValIdmsg.value, (newValue, oldValue) => this.onUpdate('messa.idmsg', this.ValIdmsg, newValue, oldValue))

		this.ValMailsent = reactive(new modelFieldType.Boolean({
			id: 'ValMailsent',
			originId: 'ValMailsent',
			area: 'MESSA',
			field: 'MAILSENT',
			description: computed(() => this.Resources.E_MAIL_SENT_60490),
		}).cloneFrom(values?.ValMailsent))
		watch(() => this.ValMailsent.value, (newValue, oldValue) => this.onUpdate('messa.mailsent', this.ValMailsent, newValue, oldValue))

		this.ValMailerr = reactive(new modelFieldType.String({
			id: 'ValMailerr',
			originId: 'ValMailerr',
			area: 'MESSA',
			field: 'MAILERR',
			maxLength: 300,
			description: computed(() => this.Resources.ERROR_SENDING_MAIL44674),
		}).cloneFrom(values?.ValMailerr))
		watch(() => this.ValMailerr.value, (newValue, oldValue) => this.onUpdate('messa.mailerr', this.ValMailerr, newValue, oldValue))

		this.TableEntitName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEntitName',
			originId: 'ValName',
			area: 'ENTIT',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.LEGAL_NAME42902),
		}).cloneFrom(values?.TableEntitName))
		watch(() => this.TableEntitName.value, (newValue, oldValue) => this.onUpdate('entit.name', this.TableEntitName, newValue, oldValue))

		this.TablePersoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePersoName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.PERSON_NAME40980),
		}).cloneFrom(values?.TablePersoName))
		watch(() => this.TablePersoName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.TablePersoName, newValue, oldValue))

		this.ValDocum_nr = reactive(new modelFieldType.Number({
			id: 'ValDocum_nr',
			originId: 'ValDocum_nr',
			area: 'MESSA',
			field: 'DOCUM_NR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.DOCUMENT_NUMBER28451),
		}).cloneFrom(values?.ValDocum_nr))
		watch(() => this.ValDocum_nr.value, (newValue, oldValue) => this.onUpdate('messa.docum_nr', this.ValDocum_nr, newValue, oldValue))

		this.ValDesignat = reactive(new modelFieldType.String({
			id: 'ValDesignat',
			originId: 'ValDesignat',
			area: 'MESSA',
			field: 'DESIGNAT',
			maxLength: 50,
			description: computed(() => this.Resources.TO_WHOM_THE_MESSAGE_02337),
		}).cloneFrom(values?.ValDesignat))
		watch(() => this.ValDesignat.value, (newValue, oldValue) => this.onUpdate('messa.designat', this.ValDesignat, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'MESSA',
			field: 'EMAIL',
			maxLength: 254,
			description: computed(() => this.Resources.E_MAIL_TO_WHOM_THE_M37668),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('messa.email', this.ValEmail, newValue, oldValue))

		this.ValMessage = reactive(new modelFieldType.MultiLineString({
			id: 'ValMessage',
			originId: 'ValMessage',
			area: 'MESSA',
			field: 'MESSAGE',
			description: computed(() => this.Resources.MESSAGE30602),
		}).cloneFrom(values?.ValMessage))
		watch(() => this.ValMessage.value, (newValue, oldValue) => this.onUpdate('messa.message', this.ValMessage, newValue, oldValue))

		this.ValCreatope = reactive(new modelFieldType.String({
			id: 'ValCreatope',
			originId: 'ValCreatope',
			area: 'MESSA',
			field: 'CREATOPE',
			maxLength: 128,
			description: computed(() => this.Resources.CREATED_BY12292),
			isFixed: true,
		}).cloneFrom(values?.ValCreatope))
		watch(() => this.ValCreatope.value, (newValue, oldValue) => this.onUpdate('messa.creatope', this.ValCreatope, newValue, oldValue))

		this.ValCreatdat = reactive(new modelFieldType.Date({
			id: 'ValCreatdat',
			originId: 'ValCreatdat',
			area: 'MESSA',
			field: 'CREATDAT',
			description: computed(() => this.Resources.CREATED_ON00051),
			isFixed: true,
		}).cloneFrom(values?.ValCreatdat))
		watch(() => this.ValCreatdat.value, (newValue, oldValue) => this.onUpdate('messa.creatdat', this.ValCreatdat, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormMessaViewModel instance.
	 * @returns {QFormMessaViewModel} A new instance of QFormMessaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmessa'

	get QPrimaryKey() { return this.ValCodmessa.value }
	set QPrimaryKey(value) { this.ValCodmessa.updateValue(value) }
}
