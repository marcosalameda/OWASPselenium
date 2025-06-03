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
			name: 'TBLK',
			area: 'TBLK',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_TBLK'
			}
		})

		/** The primary key. */
		this.ValCodtblk = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtblk',
			originId: 'ValCodtblk',
			area: 'TBLK',
			field: 'CODTBLK',
			description: '',
		}).cloneFrom(values?.ValCodtblk))
		watch(() => this.ValCodtblk.value, (newValue, oldValue) => this.onUpdate('tblk.codtblk', this.ValCodtblk, newValue, oldValue))

		/** The used foreign keys. */
		this.ValFkey1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValFkey1',
			originId: 'ValFkey1',
			area: 'TBLK',
			field: 'FKEY1',
			relatedArea: 'GRPB',
			description: computed(() => this.Resources.FOREIGN_KEY_154750),
		}).cloneFrom(values?.ValFkey1))
		watch(() => this.ValFkey1.value, (newValue, oldValue) => this.onUpdate('tblk.fkey1', this.ValFkey1, newValue, oldValue))

		this.ValFkey2 = reactive(new modelFieldType.ForeignKey({
			id: 'ValFkey2',
			originId: 'ValFkey2',
			area: 'TBLK',
			field: 'FKEY2',
			relatedArea: 'TRSB',
			description: computed(() => this.Resources.FOREIGN_KEY_255115),
		}).cloneFrom(values?.ValFkey2))
		watch(() => this.ValFkey2.value, (newValue, oldValue) => this.onUpdate('tblk.fkey2', this.ValFkey2, newValue, oldValue))

		/** The remaining form fields. */
		this.ValName = reactive(new modelFieldType.String({
			id: 'ValName',
			originId: 'ValName',
			area: 'TBLK',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.ValName))
		watch(() => this.ValName.value, (newValue, oldValue) => this.onUpdate('tblk.name', this.ValName, newValue, oldValue))

		this.TableGrpbName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableGrpbName',
			originId: 'ValName',
			area: 'GRPB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableGrpbName))
		watch(() => this.TableGrpbName.value, (newValue, oldValue) => this.onUpdate('grpb.name', this.TableGrpbName, newValue, oldValue))

		this.TableTrsbName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTrsbName',
			originId: 'ValName',
			area: 'TRSB',
			field: 'NAME',
			maxLength: 50,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TableTrsbName))
		watch(() => this.TableTrsbName.value, (newValue, oldValue) => this.onUpdate('trsb.name', this.TableTrsbName, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormTblkViewModel instance.
	 * @returns {QFormTblkViewModel} A new instance of QFormTblkViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtblk'

	get QPrimaryKey() { return this.ValCodtblk.value }
	set QPrimaryKey(value) { this.ValCodtblk.updateValue(value) }
}
