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
			name: 'TPCON',
			area: 'TPCON',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_TPCON'
			}
		})

		/** The primary key. */
		this.ValCodtpcon = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtpcon',
			originId: 'ValCodtpcon',
			area: 'TPCON',
			field: 'CODTPCON',
			description: '',
		}).cloneFrom(values?.ValCodtpcon))
		watch(() => this.ValCodtpcon.value, (newValue, oldValue) => this.onUpdate('tpcon.codtpcon', this.ValCodtpcon, newValue, oldValue))

		/** The used foreign keys. */
		this.ValCodgenre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodgenre',
			originId: 'ValCodgenre',
			area: 'TPCON',
			field: 'CODGENRE',
			relatedArea: 'GENRE',
			description: '',
		}).cloneFrom(values?.ValCodgenre))
		watch(() => this.ValCodgenre.value, (newValue, oldValue) => this.onUpdate('tpcon.codgenre', this.ValCodgenre, newValue, oldValue))

		/** The remaining form fields. */
		this.TableGenreGender = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableGenreGender',
			originId: 'ValGender',
			area: 'GENRE',
			field: 'GENDER',
			maxLength: 20,
			description: computed(() => this.Resources.GENRE63303),
		}).cloneFrom(values?.TableGenreGender))
		watch(() => this.TableGenreGender.value, (newValue, oldValue) => this.onUpdate('genre.gender', this.TableGenreGender, newValue, oldValue))

		this.ValTipocont = reactive(new modelFieldType.String({
			id: 'ValTipocont',
			originId: 'ValTipocont',
			area: 'TPCON',
			field: 'TIPOCONT',
			maxLength: 50,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.ValTipocont))
		watch(() => this.ValTipocont.value, (newValue, oldValue) => this.onUpdate('tpcon.tipocont', this.ValTipocont, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormTpconViewModel instance.
	 * @returns {QFormTpconViewModel} A new instance of QFormTpconViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtpcon'

	get QPrimaryKey() { return this.ValCodtpcon.value }
	set QPrimaryKey(value) { this.ValCodtpcon.value = value }
}
