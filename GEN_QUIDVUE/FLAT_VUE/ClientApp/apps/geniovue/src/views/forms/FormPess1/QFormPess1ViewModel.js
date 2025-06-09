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
			name: 'PESS1',
			area: 'PESS1',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PESS1',
				updateFilesTickets: 'UpdateFilesTicketsPESS1'
			}
		})

		/** The primary key. */
		this.ValCodpesso = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'PESS1',
			field: 'CODPESSO',
			description: '',
		}).cloneFrom(values?.ValCodpesso))
		watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('pess1.codpesso', this.ValCodpesso, newValue, oldValue))

		/** The hidden foreign keys. */
		this.ValCodcateg = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'PESS1',
			field: 'CODCATEG',
			relatedArea: 'CATE2',
			isFixed: true,
			description: computed(() => this.Resources._LAST_CATEGORY61019),
		}).cloneFrom(values?.ValCodcateg))
		watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('pess1.codcateg', this.ValCodcateg, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'PESS1',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('pess1.codempre', this.ValCodempre, newValue, oldValue))

		this.ValCodparte = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodparte',
			originId: 'ValCodparte',
			area: 'PESS1',
			field: 'CODPARTE',
			relatedArea: 'STAKE',
			description: computed(() => this.Resources._INTERESTED_PARTY56973),
		}).cloneFrom(values?.ValCodparte))
		watch(() => this.ValCodparte.value, (newValue, oldValue) => this.onUpdate('pess1.codparte', this.ValCodparte, newValue, oldValue))

		/** The remaining form fields. */
		this.TableCmpnyDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCmpnyDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.TableCmpnyDesignat))
		watch(() => this.TableCmpnyDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.TableCmpnyDesignat, newValue, oldValue))

		this.TableStakeDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableStakeDesignat',
			originId: 'ValDesignat',
			area: 'STAKE',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.TableStakeDesignat))
		watch(() => this.TableStakeDesignat.value, (newValue, oldValue) => this.onUpdate('stake.designat', this.TableStakeDesignat, newValue, oldValue))

		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.ValName, newValue, oldValue))

		this.ValGender = reactive(new modelFieldType.String({
			id: 'ValGender',
			originId: 'ValGender',
			area: 'PESS1',
			field: 'GENDER',
			maxLength: 1,
			arrayOptions: computed(() => qProjArrays.QArrayGenero.setResources(vm.$getResource).elements),
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.ValGender))
		watch(() => this.ValGender.value, (newValue, oldValue) => this.onUpdate('pess1.gender', this.ValGender, newValue, oldValue))

		this.ValDtnascim = reactive(new modelFieldType.Date({
			id: 'ValDtnascim',
			originId: 'ValDtnascim',
			area: 'PESS1',
			field: 'DTNASCIM',
			description: computed(() => this.Resources.BIRTH21799),
		}).cloneFrom(values?.ValDtnascim))
		watch(() => this.ValDtnascim.value, (newValue, oldValue) => this.onUpdate('pess1.dtnascim', this.ValDtnascim, newValue, oldValue))

		this.ValIdfuncio = reactive(new modelFieldType.Number({
			id: 'ValIdfuncio',
			originId: 'ValIdfuncio',
			area: 'PESS1',
			field: 'IDFUNCIO',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.OFFICIAL_NO_34819),
		}).cloneFrom(values?.ValIdfuncio))
		watch(() => this.ValIdfuncio.value, (newValue, oldValue) => this.onUpdate('pess1.idfuncio', this.ValIdfuncio, newValue, oldValue))

		this.ValTelephon = reactive(new modelFieldType.String({
			id: 'ValTelephon',
			originId: 'ValTelephon',
			area: 'PESS1',
			field: 'TELEPHON',
			maxLength: 20,
			description: computed(() => this.Resources.PHONE56703),
		}).cloneFrom(values?.ValTelephon))
		watch(() => this.ValTelephon.value, (newValue, oldValue) => this.onUpdate('pess1.telephon', this.ValTelephon, newValue, oldValue))

		this.ValEmail = reactive(new modelFieldType.String({
			id: 'ValEmail',
			originId: 'ValEmail',
			area: 'PESS1',
			field: 'EMAIL',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail))
		watch(() => this.ValEmail.value, (newValue, oldValue) => this.onUpdate('pess1.email', this.ValEmail, newValue, oldValue))

		this.ValEmail2 = reactive(new modelFieldType.String({
			id: 'ValEmail2',
			originId: 'ValEmail2',
			area: 'PESS1',
			field: 'EMAIL2',
			maxLength: 254,
			description: computed(() => this.Resources.EMAIL25170),
		}).cloneFrom(values?.ValEmail2))
		watch(() => this.ValEmail2.value, (newValue, oldValue) => this.onUpdate('pess1.email2', this.ValEmail2, newValue, oldValue))

		this.ValPhotogra = reactive(new modelFieldType.Image({
			id: 'ValPhotogra',
			originId: 'ValPhotogra',
			area: 'PESS1',
			field: 'PHOTOGRA',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValPhotogra))
		watch(() => this.ValPhotogra.value, (newValue, oldValue) => this.onUpdate('pess1.photogra', this.ValPhotogra, newValue, oldValue))

		this.ValDtultcat = reactive(new modelFieldType.Date({
			id: 'ValDtultcat',
			originId: 'ValDtultcat',
			area: 'PESS1',
			field: 'DTULTCAT',
			description: computed(() => this.Resources.SINCE47259),
		}).cloneFrom(values?.ValDtultcat))
		watch(() => this.ValDtultcat.value, (newValue, oldValue) => this.onUpdate('pess1.dtultcat', this.ValDtultcat, newValue, oldValue))

		this.ValExterna = reactive(new modelFieldType.Boolean({
			id: 'ValExterna',
			originId: 'ValExterna',
			area: 'PESS1',
			field: 'EXTERNA',
			description: computed(() => this.Resources.EXTERNAL13375),
		}).cloneFrom(values?.ValExterna))
		watch(() => this.ValExterna.value, (newValue, oldValue) => this.onUpdate('pess1.externa', this.ValExterna, newValue, oldValue))

		this.ValInterna = reactive(new modelFieldType.Boolean({
			id: 'ValInterna',
			originId: 'ValInterna',
			area: 'PESS1',
			field: 'INTERNA',
			description: computed(() => this.Resources.INTERNAL04894),
		}).cloneFrom(values?.ValInterna))
		watch(() => this.ValInterna.value, (newValue, oldValue) => this.onUpdate('pess1.interna', this.ValInterna, newValue, oldValue))

		this.ValIdade = reactive(new modelFieldType.Number({
			id: 'ValIdade',
			originId: 'ValIdade',
			area: 'PESS1',
			field: 'IDADE',
			maxDigits: 5,
			decimalDigits: 0,
			description: computed(() => this.Resources.AGE28663),
		}).cloneFrom(values?.ValIdade))
		watch(() => this.ValIdade.value, (newValue, oldValue) => this.onUpdate('pess1.idade', this.ValIdade, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPess1ViewModel instance.
	 * @returns {QFormPess1ViewModel} A new instance of QFormPess1ViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpesso'

	get QPrimaryKey() { return this.ValCodpesso.value }
	set QPrimaryKey(value) { this.ValCodpesso.updateValue(value) }
}
