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
			name: 'EQUIP_EMPTY',
			area: 'Home',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Equip_empty',
				updateFilesTickets: 'UpdateFilesTicketsEquip_empty',
				setFile: 'SetFileEquip_empty'
			}
		})


		/** The remaining form fields. */
		this.TableCntryCountry = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCntryCountry',
			originId: 'ValCountry',
			area: 'CNTRY',
			field: 'COUNTRY',
			maxLength: 90,
			description: computed(() => this.Resources.COUNTRY64133),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCntryCountry))
		this.stopWatchers.push(watch(() => this.TableCntryCountry.value, (newValue, oldValue) => this.onUpdate('cntry.country', this.TableCntryCountry, newValue, oldValue)))

		this.CntryValCodcntryFilterKey = reactive(new modelFieldType.ForeignKey({
			id: 'CntryValCodcntryFilterKey',
			originId: 'CntryValCodcntryFilterKey',
			area: 'CNTRY',
			field: 'CODCNTRY',
			relatedArea: 'global-filter-CNTRY',// History entry key
			isGlobalFilterField: true,
			ignoreFldSubmit: true
		}).cloneFrom(values?.CntryValCodcntryFilterKey))
		this.stopWatchers.push(watch(() => this.CntryValCodcntryFilterKey.value, (newValue, oldValue) => this.onUpdate('cntry.codcntry', this.CntryValCodcntryFilterKey, newValue, oldValue)))

		this.TableCmpnyDesignat = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableCmpnyDesignat',
			originId: 'ValDesignat',
			area: 'CMPNY',
			field: 'DESIGNAT',
			maxLength: 85,
			description: computed(() => this.Resources.DESIGNATION35876),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableCmpnyDesignat))
		this.stopWatchers.push(watch(() => this.TableCmpnyDesignat.value, (newValue, oldValue) => this.onUpdate('cmpny.designat', this.TableCmpnyDesignat, newValue, oldValue)))

		this.CmpnyValCodempreFilterKey = reactive(new modelFieldType.ForeignKey({
			id: 'CmpnyValCodempreFilterKey',
			originId: 'CmpnyValCodempreFilterKey',
			area: 'CMPNY',
			field: 'CODEMPRE',
			relatedArea: 'global-filter-CMPNY',// History entry key
			isGlobalFilterField: true,
			ignoreFldSubmit: true
		}).cloneFrom(values?.CmpnyValCodempreFilterKey))
		this.stopWatchers.push(watch(() => this.CmpnyValCodempreFilterKey.value, (newValue, oldValue) => this.onUpdate('cmpny.codempre', this.CmpnyValCodempreFilterKey, newValue, oldValue)))

		this.TablePess1Name = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePess1Name',
			originId: 'ValName',
			area: 'PESS1',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TablePess1Name))
		this.stopWatchers.push(watch(() => this.TablePess1Name.value, (newValue, oldValue) => this.onUpdate('pess1.name', this.TablePess1Name, newValue, oldValue)))

		this.Pess1ValCodpessoFilterKey = reactive(new modelFieldType.ForeignKey({
			id: 'Pess1ValCodpessoFilterKey',
			originId: 'Pess1ValCodpessoFilterKey',
			area: 'PESS1',
			field: 'CODPESSO',
			relatedArea: 'global-filter-PESS1',// History entry key
			isGlobalFilterField: true,
			ignoreFldSubmit: true
		}).cloneFrom(values?.Pess1ValCodpessoFilterKey))
		this.stopWatchers.push(watch(() => this.Pess1ValCodpessoFilterKey.value, (newValue, oldValue) => this.onUpdate('pess1.codpesso', this.Pess1ValCodpessoFilterKey, newValue, oldValue)))

		this.ValShowrc = reactive(new modelFieldType.Boolean({
			type: 'FormFilter',
			id: 'ValShowrc',
			originId: 'ValShowrc',
			area: 'EQUIP',
			field: 'SHOWRC',
			description: computed(() => this.Resources.SHOW_RECORD53851),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.ValShowrc))
		this.stopWatchers.push(watch(() => this.ValShowrc.value, (newValue, oldValue) => this.onUpdate('equip.showrc', this.ValShowrc, newValue, oldValue)))

		this.ValIfabatif = reactive(new modelFieldType.Boolean({
			type: 'FormFilter',
			id: 'ValIfabatif',
			originId: 'ValIfabatif',
			area: 'EQUIP',
			field: 'IFABATIF',
			description: computed(() => this.Resources.DOWNED_EQUIPMENT43331),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.ValIfabatif))
		this.stopWatchers.push(watch(() => this.ValIfabatif.value, (newValue, oldValue) => this.onUpdate('equip.ifabatif', this.ValIfabatif, newValue, oldValue)))

		this.ValFrequenc = reactive(new modelFieldType.Number({
			type: 'FormFilter',
			id: 'ValFrequenc',
			originId: 'ValFrequenc',
			area: 'EQUIP',
			field: 'FREQUENC',
			maxDigits: 2,
			decimalDigits: 0,
			arrayOptions: computed(() => new qProjArrays.QArrayFreqempr(vm.$getResource).elements),
			description: computed(() => this.Resources.LOAN_FREQUENCY00701),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.ValFrequenc))
		this.stopWatchers.push(watch(() => this.ValFrequenc.value, (newValue, oldValue) => this.onUpdate('equip.frequenc', this.ValFrequenc, newValue, oldValue)))

		this.ValItemdes = reactive(new modelFieldType.String({
			type: 'FormFilter',
			id: 'ValItemdes',
			originId: 'ValItemdes',
			area: 'ITEM',
			field: 'ITEMDES',
			maxLength: 85,
			description: computed(() => this.Resources.ARTICLE60065),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.ValItemdes))
		this.stopWatchers.push(watch(() => this.ValItemdes.value, (newValue, oldValue) => this.onUpdate('item.itemdes', this.ValItemdes, newValue, oldValue)))

		this.ValTipoequi = reactive(new modelFieldType.String({
			type: 'FormFilter',
			id: 'ValTipoequi',
			originId: 'ValTipoequi',
			area: 'TPEQU',
			field: 'TIPOEQUI',
			maxLength: 50,
			description: computed(() => this.Resources.TYPE_OF_EQUIPMENT18080),
			isGlobalFilterField: true,
			ignoreFldSubmit: true,
		}).cloneFrom(values?.ValTipoequi))
		this.stopWatchers.push(watch(() => this.ValTipoequi.value, (newValue, oldValue) => this.onUpdate('tpequ.tipoequi', this.ValTipoequi, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormEquipEmptyViewModel instance.
	 * @returns {QFormEquipEmptyViewModel} A new instance of QFormEquipEmptyViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}
}
