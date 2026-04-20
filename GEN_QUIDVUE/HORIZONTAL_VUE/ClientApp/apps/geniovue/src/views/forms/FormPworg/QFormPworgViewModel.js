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
			name: 'PWORG',
			area: 'PWORG',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Pworg',
				updateFilesTickets: 'UpdateFilesTicketsPworg',
				setFile: 'SetFilePworg'
			}
		})

		/** The primary key. */
		this.ValCodpworg = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpworg',
			originId: 'ValCodpworg',
			area: 'PWORG',
			field: 'CODPWORG',
			description: '',
		}).cloneFrom(values?.ValCodpworg))
		this.stopWatchers.push(watch(() => this.ValCodpworg.value, (newValue, oldValue) => this.onUpdate('pworg.codpworg', this.ValCodpworg, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'PWORG',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: '',
		}).cloneFrom(values?.ValCodpsw))
		this.stopWatchers.push(watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('pworg.codpsw', this.ValCodpsw, newValue, oldValue)))

		this.ValCodorgan = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodorgan',
			originId: 'ValCodorgan',
			area: 'PWORG',
			field: 'CODORGAN',
			relatedArea: 'ORGAN',
			description: '',
		}).cloneFrom(values?.ValCodorgan))
		this.stopWatchers.push(watch(() => this.ValCodorgan.value, (newValue, oldValue) => this.onUpdate('pworg.codorgan', this.ValCodorgan, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePswNome))
		this.stopWatchers.push(watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue)))

		this.TableOrganOrganiza = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableOrganOrganiza',
			originId: 'ValOrganiza',
			area: 'ORGAN',
			field: 'ORGANIZA',
			maxLength: 85,
			description: computed(() => this.Resources.ORGANIZATION64123),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableOrganOrganiza))
		this.stopWatchers.push(watch(() => this.TableOrganOrganiza.value, (newValue, oldValue) => this.onUpdate('organ.organiza', this.TableOrganOrganiza, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPworgViewModel instance.
	 * @returns {QFormPworgViewModel} A new instance of QFormPworgViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpworg'

	get QPrimaryKey() { return this.ValCodpworg.value }
	set QPrimaryKey(value) { this.ValCodpworg.updateValue(value) }
}
