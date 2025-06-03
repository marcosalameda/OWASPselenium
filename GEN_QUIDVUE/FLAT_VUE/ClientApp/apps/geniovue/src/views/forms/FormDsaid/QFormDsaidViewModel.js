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
			name: 'DSAID',
			area: 'OUTPT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_DSAID'
			}
		})

		/** The primary key. */
		this.ValCodoutpt = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodoutpt',
			originId: 'ValCodoutpt',
			area: 'OUTPT',
			field: 'CODOUTPT',
			description: '',
		}).cloneFrom(values?.ValCodoutpt))
		watch(() => this.ValCodoutpt.value, (newValue, oldValue) => this.onUpdate('outpt.codoutpt', this.ValCodoutpt, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodwareh = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodwareh',
			originId: 'ValCodwareh',
			area: 'OUTPT',
			field: 'CODWAREH',
			relatedArea: 'WARE1',
			description: computed(() => this.Resources.BY_OMISSION13050),
		}).cloneFrom(values?.ValCodwareh))
		watch(() => this.ValCodwareh.value, (newValue, oldValue) => this.onUpdate('outpt.codwareh', this.ValCodwareh, newValue, oldValue))

		/** The remaining form fields. */
		this.TableWare1Warehdes = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableWare1Warehdes',
			originId: 'ValWarehdes',
			area: 'WARE1',
			field: 'WAREHDES',
			maxLength: 85,
			description: computed(() => this.Resources.WAREHOUSE51864),
		}).cloneFrom(values?.TableWare1Warehdes))
		watch(() => this.TableWare1Warehdes.value, (newValue, oldValue) => this.onUpdate('ware1.warehdes', this.TableWare1Warehdes, newValue, oldValue))

		this.ValDocumenr = reactive(new modelFieldType.Number({
			id: 'ValDocumenr',
			originId: 'ValDocumenr',
			area: 'OUTPT',
			field: 'DOCUMENR',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_14817),
		}).cloneFrom(values?.ValDocumenr))
		watch(() => this.ValDocumenr.value, (newValue, oldValue) => this.onUpdate('outpt.documenr', this.ValDocumenr, newValue, oldValue))

		this.ValDhdocume = reactive(new modelFieldType.DateTime({
			id: 'ValDhdocume',
			originId: 'ValDhdocume',
			area: 'OUTPT',
			field: 'DHDOCUME',
			description: computed(() => this.Resources.DATE18475),
		}).cloneFrom(values?.ValDhdocume))
		watch(() => this.ValDhdocume.value, (newValue, oldValue) => this.onUpdate('outpt.dhdocume', this.ValDhdocume, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormDsaidViewModel instance.
	 * @returns {QFormDsaidViewModel} A new instance of QFormDsaidViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodoutpt'

	get QPrimaryKey() { return this.ValCodoutpt.value }
	set QPrimaryKey(value) { this.ValCodoutpt.updateValue(value) }
}
