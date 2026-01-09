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
import DNFormViewModelGrpbPseudtblb from '@/views/forms/FormGrpb/QGridFormGrpbPseudtblbViewModel.js'
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
			name: 'GRPB',
			area: 'GRPB',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Grpb',
				updateFilesTickets: 'UpdateFilesTicketsGrpb',
				setFile: 'SetFileGrpb'
			}
		})

		/** The primary key. */
		this.ValCodgrpb = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodgrpb',
			originId: 'ValCodgrpb',
			area: 'GRPB',
			field: 'CODGRPB',
			description: '',
		}).cloneFrom(values?.ValCodgrpb))
		this.stopWatchers.push(watch(() => this.ValCodgrpb.value, (newValue, oldValue) => this.onUpdate('grpb.codgrpb', this.ValCodgrpb, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'GRPB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		this.stopWatchers.push(watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('grpb.name', this.ValName, newValue, oldValue)))
		/** The Grid Table List value. */
		this.ValTblb = reactive(new modelFieldType.GridTableList({
			id: 'ValTblb',
			area: 'TBLB',
			field: 'TBLB',
			viewModelClass: DNFormViewModelGrpbPseudtblb,
		}, this.vueContext).cloneFrom(values?.ValTblb))
		this.stopWatchers.push(watch(() => this.ValTblb.value?.newElements, () => this.onUpdate('pseud.tblb', this.ValTblb, this.ValTblb.value), { deep: true }))
		this.stopWatchers.push(watch(() => this.ValTblb.value?.editedElements, () => this.onUpdate('pseud.tblb', this.ValTblb, this.ValTblb.value), { deep: true }))
		this.stopWatchers.push(watch(() => this.ValTblb.value?.removedElements, () => this.onUpdate('pseud.tblb', this.ValTblb, this.ValTblb.value), { deep: true }))
	}

	/**
	 * Creates a clone of the current QFormGrpbViewModel instance.
	 * @returns {QFormGrpbViewModel} A new instance of QFormGrpbViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodgrpb'

	get QPrimaryKey() { return this.ValCodgrpb.value }
	set QPrimaryKey(value) { this.ValCodgrpb.updateValue(value) }
}
