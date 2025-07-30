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
			name: 'ANEXD',
			area: 'ANEXD',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Anexd',
				updateFilesTickets: 'UpdateFilesTicketsAnexd',
				setFile: 'SetFileAnexd'
			}
		})

		/** The primary key. */
		this.ValCodanexd = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodanexd',
			originId: 'ValCodanexd',
			area: 'ANEXD',
			field: 'CODANEXD',
			description: '',
		}).cloneFrom(values?.ValCodanexd))
		this.stopWatchers.push(watch(() => this.ValCodanexd.value, (newValue, oldValue) => this.onUpdate('anexd.codanexd', this.ValCodanexd, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'ANEXD',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: '',
		}).cloneFrom(values?.ValCodequip))
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('anexd.codequip', this.ValCodequip, newValue, oldValue)))

		this.ValCodlang = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodlang',
			originId: 'ValCodlang',
			area: 'ANEXD',
			field: 'CODLANG',
			relatedArea: 'LANGU',
			description: computed(() => this.Resources._LANGUAGE30793),
		}).cloneFrom(values?.ValCodlang))
		this.stopWatchers.push(watch(() => this.ValCodlang.value, (newValue, oldValue) => this.onUpdate('anexd.codlang', this.ValCodlang, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableEquipRegistnr = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableEquipRegistnr',
			originId: 'ValRegistnr',
			area: 'EQUIP',
			field: 'REGISTNR',
			maxLength: 6,
			description: computed(() => this.Resources.NO__REGISTER04207),
		}).cloneFrom(values?.TableEquipRegistnr))
		this.stopWatchers.push(watch(() => this.TableEquipRegistnr.value, (newValue, oldValue) => this.onUpdate('equip.registnr', this.TableEquipRegistnr, newValue, oldValue)))

		this.ValDthranex = reactive(new modelFieldType.DateTime({
			id: 'ValDthranex',
			originId: 'ValDthranex',
			area: 'ANEXD',
			field: 'DTHRANEX',
			description: computed(() => this.Resources.ATTACHED26247),
		}).cloneFrom(values?.ValDthranex))
		this.stopWatchers.push(watch(() => this.ValDthranex.value, (newValue, oldValue) => this.onUpdate('anexd.dthranex', this.ValDthranex, newValue, oldValue)))

		this.ValReferenc = reactive(new modelFieldType.String({
			id: 'ValReferenc',
			originId: 'ValReferenc',
			area: 'ANEXD',
			field: 'REFERENC',
			maxLength: 50,
			description: computed(() => this.Resources.REFERENCE28402),
		}).cloneFrom(values?.ValReferenc))
		this.stopWatchers.push(watch(() => this.ValReferenc.value, (newValue, oldValue) => this.onUpdate('anexd.referenc', this.ValReferenc, newValue, oldValue)))

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'ANEXD',
			field: 'TITLE',
			maxLength: 85,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('anexd.title', this.ValTitle, newValue, oldValue)))

		this.TableLanguLangua = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableLanguLangua',
			originId: 'ValLangua',
			area: 'LANGU',
			field: 'LANGUA',
			maxLength: 50,
			description: computed(() => this.Resources.LANGUAGE16872),
		}).cloneFrom(values?.TableLanguLangua))
		this.stopWatchers.push(watch(() => this.TableLanguLangua.value, (newValue, oldValue) => this.onUpdate('langu.langua', this.TableLanguLangua, newValue, oldValue)))

		this.ValTittradu = reactive(new modelFieldType.String({
			id: 'ValTittradu',
			originId: 'ValTittradu',
			area: 'ANEXD',
			field: 'TITTRADU',
			maxLength: 85,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					const fieldId = params?.originField?.id
					const data = typeof fieldId === 'string' ? { [fieldId]: params.originField.value } : {}
					return this.recalculateFormulas(data)
				},
				dependencyEvents: ['fieldChange:anexd.title', 'fieldChange:anexd.codlang'],
				isServerRecalc: true,
				isEmpty: qApi.emptyC,
			},
			description: computed(() => this.Resources.TRANSLATED_TITLE58577),
		}).cloneFrom(values?.ValTittradu))
		this.stopWatchers.push(watch(() => this.ValTittradu.value, (newValue, oldValue) => this.onUpdate('anexd.tittradu', this.ValTittradu, newValue, oldValue)))

		this.ValDocument = reactive(new modelFieldType.Document({
			id: 'ValDocument',
			originId: 'ValDocument',
			area: 'ANEXD',
			field: 'DOCUMENT',
			properties: computed(() => this.ValDocumentPropertiesVM),
			documentFK: computed(() => this.ValDocumentfk),
			currentDocument: computed(() => this.ValDocumentData),
			description: computed(() => this.Resources.DOCUMENT00695),
		}).cloneFrom(values?.ValDocument))
		this.stopWatchers.push(watch(() => this.ValDocument.value, (newValue, oldValue) => this.onUpdate('anexd.document', this.ValDocument, newValue, oldValue)))

		this.ValDocumentPropertiesVM = reactive(new modelFieldType.Base({
			id: 'ValDocumentPropertiesVM',
			area: 'ANEXD',
			field: 'DOCUMENTDOCUM',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocumentPropertiesVM))
		this.ValDocumentfk = reactive(new modelFieldType.String({
			id: 'ValDocumentfk',
			area: 'ANEXD',
			field: 'DOCUMENTFK'
		}).cloneFrom(values?.ValDocumentfk))
		this.stopWatchers.push(watch(() => this.ValDocumentfk.value, (newValue, oldValue) => this.onUpdate('anexd.documentfk', this.ValDocumentfk, newValue, oldValue)))
		this.ValDocumentData = reactive(new modelFieldType.DocumentData({
			id: 'ValDocumentData',
			area: 'ANEXD',
			field: 'DOCUMENTDATA',
			ignoreFldSubmit: true
		}).cloneFrom(values?.ValDocumentData))
		this.stopWatchers.push(watch(() => this.ValDocumentData.value, (newValue, oldValue) => this.onUpdate('anexd.documentdata', this.ValDocumentData, newValue, oldValue), { deep: true }))
	}

	/**
	 * Creates a clone of the current QFormAnexdViewModel instance.
	 * @returns {QFormAnexdViewModel} A new instance of QFormAnexdViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodanexd'

	get QPrimaryKey() { return this.ValCodanexd.value }
	set QPrimaryKey(value) { this.ValCodanexd.updateValue(value) }
}
