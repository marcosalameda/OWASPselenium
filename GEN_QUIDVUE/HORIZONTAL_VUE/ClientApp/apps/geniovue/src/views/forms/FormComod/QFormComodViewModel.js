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
			name: 'COMOD',
			area: 'LENDI',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Comod',
				updateFilesTickets: 'UpdateFilesTicketsComod',
				setFile: 'SetFileComod'
			}
		})

		/** The primary key. */
		this.ValCodlendi = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodlendi',
			originId: 'ValCodlendi',
			area: 'LENDI',
			field: 'CODLENDI',
			description: '',
		}).cloneFrom(values?.ValCodlendi))
		this.stopWatchers.push(watch(() => this.ValCodlendi.value, (newValue, oldValue) => this.onUpdate('lendi.codlendi', this.ValCodlendi, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpess1 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess1',
			originId: 'ValCodpess1',
			area: 'LENDI',
			field: 'CODPESS1',
			relatedArea: 'PESS1',
			description: computed(() => this.Resources._COMOMODOR01469),
		}).cloneFrom(values?.ValCodpess1))
		this.stopWatchers.push(watch(() => this.ValCodpess1.value, (newValue, oldValue) => this.onUpdate('lendi.codpess1', this.ValCodpess1, newValue, oldValue)))

		this.ValCodpess2 = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpess2',
			originId: 'ValCodpess2',
			area: 'LENDI',
			field: 'CODPESS2',
			relatedArea: 'PESS2',
			description: computed(() => this.Resources._DADATARY21139),
		}).cloneFrom(values?.ValCodpess2))
		this.stopWatchers.push(watch(() => this.ValCodpess2.value, (newValue, oldValue) => this.onUpdate('lendi.codpess2', this.ValCodpess2, newValue, oldValue)))

		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'LENDI',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: computed(() => this.Resources._EQUIPMENT12605),
		}).cloneFrom(values?.ValCodequip))
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('lendi.codequip', this.ValCodequip, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePess1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess1Name',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePess1Name))
		this.stopWatchers.push(watch(() => this.TablePess1Name.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.TablePess1Name, newValue, oldValue)))

		this.TablePess2Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess2Name',
			originId: 'ValName',
			area: 'PESS2',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePess2Name))
		this.stopWatchers.push(watch(() => this.TablePess2Name.value, (newValue, oldValue) => this.onUpdate('pess2.name', this.TablePess2Name, newValue, oldValue)))

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

		this.EquipValDesignat = reactive(new modelFieldType.String({
			id: 'EquipValDesignat',
			originId: 'ValDesignat',
			area: 'EQUIP',
			field: 'DESIGNAT',
			maxLength: 85,
			isFixed: true,
			description: computed(() => this.Resources.DESIGNATION35876),
		}).cloneFrom(values?.EquipValDesignat))
		this.stopWatchers.push(watch(() => this.EquipValDesignat.value, (newValue, oldValue) => this.onUpdate('equip.designat', this.EquipValDesignat, newValue, oldValue)))

		this.EquipValFrequenc = reactive(new modelFieldType.Number({
			id: 'EquipValFrequenc',
			originId: 'ValFrequenc',
			area: 'EQUIP',
			field: 'FREQUENC',
			maxDigits: 2,
			decimalDigits: 0,
			isFixed: true,
			arrayOptions: computed(() => new qProjArrays.QArrayFreqempr(vm.$getResource).elements),
			description: computed(() => this.Resources.LOAN_FREQUENCY00701),
		}).cloneFrom(values?.EquipValFrequenc))
		this.stopWatchers.push(watch(() => this.EquipValFrequenc.value, (newValue, oldValue) => this.onUpdate('equip.frequenc', this.EquipValFrequenc, newValue, oldValue)))

		this.ValLendinnr = reactive(new modelFieldType.Number({
			id: 'ValLendinnr',
			originId: 'ValLendinnr',
			area: 'LENDI',
			field: 'LENDINNR',
			maxDigits: 6,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMBER_OF_LENDING63925),
		}).cloneFrom(values?.ValLendinnr))
		this.stopWatchers.push(watch(() => this.ValLendinnr.value, (newValue, oldValue) => this.onUpdate('lendi.lendinnr', this.ValLendinnr, newValue, oldValue)))

		this.ValStart = reactive(new modelFieldType.DateTime({
			id: 'ValStart',
			originId: 'ValStart',
			area: 'LENDI',
			field: 'START',
			description: computed(() => this.Resources.BEGINNING18124),
		}).cloneFrom(values?.ValStart))
		this.stopWatchers.push(watch(() => this.ValStart.value, (newValue, oldValue) => this.onUpdate('lendi.start', this.ValStart, newValue, oldValue)))

		this.ValWarndt = reactive(new modelFieldType.DateTime({
			id: 'ValWarndt',
			originId: 'ValWarndt',
			area: 'LENDI',
			field: 'WARNDT',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: SomaDias([LENDI->START],[EQUIP->FREQUENC])
					return qApi.SomaDias(this.ValStart.value,this.EquipValFrequenc.value)
				},
				dependencyEvents: ['fieldChange:lendi.start', 'fieldChange:equip.frequenc'],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.WARNING52043),
		}).cloneFrom(values?.ValWarndt))
		this.stopWatchers.push(watch(() => this.ValWarndt.value, (newValue, oldValue) => this.onUpdate('lendi.warndt', this.ValWarndt, newValue, oldValue)))

		this.ValEnd = reactive(new modelFieldType.DateTime({
			id: 'ValEnd',
			originId: 'ValEnd',
			area: 'LENDI',
			field: 'END',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: SomaDias([LENDI->WARNDT],1)
					return qApi.SomaDias(this.ValWarndt.value,1)
				},
				dependencyEvents: ['fieldChange:lendi.warndt'],
				isServerRecalc: false,
				isEmpty: qApi.emptyD,
			},
			description: computed(() => this.Resources.END47577),
		}).cloneFrom(values?.ValEnd))
		this.stopWatchers.push(watch(() => this.ValEnd.value, (newValue, oldValue) => this.onUpdate('lendi.end', this.ValEnd, newValue, oldValue)))

		this.ValObservat = reactive(new modelFieldType.MultiLineString({
			type: 'MarkdownEditor',
			id: 'ValObservat',
			originId: 'ValObservat',
			area: 'LENDI',
			field: 'OBSERVAT',
			description: computed(() => this.Resources.OBSERVATIONS03729),
		}).cloneFrom(values?.ValObservat))
		this.stopWatchers.push(watch(() => this.ValObservat.value, (newValue, oldValue) => this.onUpdate('lendi.observat', this.ValObservat, newValue, oldValue)))

		this.ValReturndt = reactive(new modelFieldType.Date({
			id: 'ValReturndt',
			originId: 'ValReturndt',
			area: 'LENDI',
			field: 'RETURNDT',
			description: computed(() => this.Resources.RETURN32222),
		}).cloneFrom(values?.ValReturndt))
		this.stopWatchers.push(watch(() => this.ValReturndt.value, (newValue, oldValue) => this.onUpdate('lendi.returndt', this.ValReturndt, newValue, oldValue)))

		this.ValReturned = reactive(new modelFieldType.Boolean({
			id: 'ValReturned',
			originId: 'ValReturned',
			area: 'LENDI',
			field: 'RETURNED',
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: iif(emptyD([LENDI->RETURNDT])==1,0,1)
					return qApi.iif(qApi.emptyD(this.ValReturndt.value)===1,0,1)
				},
				dependencyEvents: ['fieldChange:lendi.returndt'],
				isServerRecalc: false,
				isEmpty: qApi.emptyL,
			},
			description: computed(() => this.Resources.RETURNED01606),
		}).cloneFrom(values?.ValReturned))
		this.stopWatchers.push(watch(() => this.ValReturned.value, (newValue, oldValue) => this.onUpdate('lendi.returned', this.ValReturned, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormComodViewModel instance.
	 * @returns {QFormComodViewModel} A new instance of QFormComodViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodlendi'

	get QPrimaryKey() { return this.ValCodlendi.value }
	set QPrimaryKey(value) { this.ValCodlendi.updateValue(value) }
}
