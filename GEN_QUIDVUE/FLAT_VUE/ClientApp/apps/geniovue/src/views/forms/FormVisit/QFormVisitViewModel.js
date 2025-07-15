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
			name: 'VISIT',
			area: 'VISIT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Visit',
				updateFilesTickets: 'UpdateFilesTicketsVisit',
				setFile: 'SetFileVisit'
			}
		})

		/** The primary key. */
		this.ValCodvisit = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodvisit',
			originId: 'ValCodvisit',
			area: 'VISIT',
			field: 'CODVISIT',
			description: '',
		}).cloneFrom(values?.ValCodvisit))
		this.stopWatchers.push(watch(() => this.ValCodvisit.value, (newValue, oldValue) => this.onUpdate('visit.codvisit', this.ValCodvisit, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'VISIT',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: '',
		}).cloneFrom(values?.ValCodequip))
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('visit.codequip', this.ValCodequip, newValue, oldValue)))

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

		this.ValTitle = reactive(new modelFieldType.String({
			id: 'ValTitle',
			originId: 'ValTitle',
			area: 'VISIT',
			field: 'TITLE',
			maxLength: 85,
			description: computed(() => this.Resources.TITLE21885),
		}).cloneFrom(values?.ValTitle))
		this.stopWatchers.push(watch(() => this.ValTitle.value, (newValue, oldValue) => this.onUpdate('visit.title', this.ValTitle, newValue, oldValue)))

		this.ValStartdt = reactive(new modelFieldType.DateTime({
			id: 'ValStartdt',
			originId: 'ValStartdt',
			area: 'VISIT',
			field: 'STARTDT',
			description: computed(() => this.Resources.BEGINNING18124),
		}).cloneFrom(values?.ValStartdt))
		this.stopWatchers.push(watch(() => this.ValStartdt.value, (newValue, oldValue) => this.onUpdate('visit.startdt', this.ValStartdt, newValue, oldValue)))

		this.ValDtfim = reactive(new modelFieldType.DateTime({
			id: 'ValDtfim',
			originId: 'ValDtfim',
			area: 'VISIT',
			field: 'DTFIM',
			description: computed(() => this.Resources.END47577),
		}).cloneFrom(values?.ValDtfim))
		this.stopWatchers.push(watch(() => this.ValDtfim.value, (newValue, oldValue) => this.onUpdate('visit.dtfim', this.ValDtfim, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			type: 'TextEditor',
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'VISIT',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION07383),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('visit.descript', this.ValDescript, newValue, oldValue)))

		this.ValTodoodia = reactive(new modelFieldType.Boolean({
			id: 'ValTodoodia',
			originId: 'ValTodoodia',
			area: 'VISIT',
			field: 'TODOODIA',
			description: computed(() => this.Resources.DAY27593),
		}).cloneFrom(values?.ValTodoodia))
		this.stopWatchers.push(watch(() => this.ValTodoodia.value, (newValue, oldValue) => this.onUpdate('visit.todoodia', this.ValTodoodia, newValue, oldValue)))

		this.ValColor = reactive(new modelFieldType.String({
			id: 'ValColor',
			originId: 'ValColor',
			area: 'VISIT',
			field: 'COLOR',
			maxLength: 50,
			description: computed(() => this.Resources.COLOR55628),
		}).cloneFrom(values?.ValColor))
		this.stopWatchers.push(watch(() => this.ValColor.value, (newValue, oldValue) => this.onUpdate('visit.color', this.ValColor, newValue, oldValue)))

		this.ValObservat = reactive(new modelFieldType.String({
			id: 'ValObservat',
			originId: 'ValObservat',
			area: 'VISIT',
			field: 'OBSERVAT',
			maxLength: 50,
			description: computed(() => this.Resources.OBSERVATIONS03729),
		}).cloneFrom(values?.ValObservat))
		this.stopWatchers.push(watch(() => this.ValObservat.value, (newValue, oldValue) => this.onUpdate('visit.observat', this.ValObservat, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormVisitViewModel instance.
	 * @returns {QFormVisitViewModel} A new instance of QFormVisitViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodvisit'

	get QPrimaryKey() { return this.ValCodvisit.value }
	set QPrimaryKey(value) { this.ValCodvisit.updateValue(value) }
}
