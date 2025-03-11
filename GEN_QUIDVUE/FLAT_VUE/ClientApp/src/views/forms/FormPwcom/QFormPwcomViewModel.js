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
			name: 'PWCOM',
			area: 'PWCOM',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_PWCOM'
			}
		})

		/** The primary key. */
		this.ValCodpwcom = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpwcom',
			originId: 'ValCodpwcom',
			area: 'PWCOM',
			field: 'CODPWCOM',
			description: '',
		}).cloneFrom(values?.ValCodpwcom))
		watch(() => this.ValCodpwcom.value, (newValue, oldValue) => this.onUpdate('pwcom.codpwcom', this.ValCodpwcom, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'PWCOM',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: '',
		}).cloneFrom(values?.ValCodpsw))
		watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('pwcom.codpsw', this.ValCodpsw, newValue, oldValue))

		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'PWCOM',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			description: computed(() => this.Resources._COMOMODOR01469),
		}).cloneFrom(values?.ValCodpess1))
		watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('pwcom.codpess1', this.ValCodpess1, newValue, oldValue))

		/** The remaining form fields. */
		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePswNome))
		watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue))

		this.TablePess1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess1Name',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePess1Name))
		watch(() => this.TablePess1Name.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.TablePess1Name, newValue, oldValue))

		this.ValFoto = reactive(new modelFieldType.Image({
			id: 'ValFoto',
			originId: 'ValFoto',
			area: 'PWCOM',
			field: 'FOTO',
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.ValFoto))
		watch(() => this.ValFoto.value, (newValue, oldValue) => this.onUpdate('pwcom.foto', this.ValFoto, newValue, oldValue))

		/** The form fields used only in formulas. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'PWCOM',
			field: 'NAME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:pwcom.codpsw'],
				isServerRecalc: true,
				isEmpty: qApi.emptyC,
			},
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('pwcom.name', this.ValName, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormPwcomViewModel instance.
	 * @returns {QFormPwcomViewModel} A new instance of QFormPwcomViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpwcom'

	get QPrimaryKey() { return this.ValCodpwcom.value }
	set QPrimaryKey(value) { this.ValCodpwcom.updateValue(value) }
}
