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
			name: 'REPAR',
			area: 'REPAR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Repar',
				updateFilesTickets: 'UpdateFilesTicketsRepar',
				setFile: 'SetFileRepar'
			}
		})

		/** The primary key. */
		this.ValCodrepar = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodrepar',
			originId: 'ValCodrepar',
			area: 'REPAR',
			field: 'CODREPAR',
			description: '',
		}).cloneFrom(values?.ValCodrepar))
		this.stopWatchers.push(watch(() => this.ValCodrepar.value, (newValue, oldValue) => this.onUpdate('repar.codrepar', this.ValCodrepar, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodempre = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodempre',
			originId: 'ValCodempre',
			area: 'REPAR',
			field: 'CODEMPRE',
			relatedArea: 'CMPNY',
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
				dependencyEvents: ['fieldChange:repar.codequip'],
				isServerRecalc: true,
				isEmpty: qApi.emptyG,
			},
			description: computed(() => this.Resources._COMPANY02087),
		}).cloneFrom(values?.ValCodempre))
		this.stopWatchers.push(watch(() => this.ValCodempre.value, (newValue, oldValue) => this.onUpdate('repar.codempre', this.ValCodempre, newValue, oldValue)))

		this.ValCodcateg = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodcateg',
			originId: 'ValCodcateg',
			area: 'REPAR',
			field: 'CODCATEG',
			relatedArea: 'CATE1',
			isFixed: true,
			description: computed(() => this.Resources._CATEGORY37591),
		}).cloneFrom(values?.ValCodcateg))
		this.stopWatchers.push(watch(() => this.ValCodcateg.value, (newValue, oldValue) => this.onUpdate('repar.codcateg', this.ValCodcateg, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodequip = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodequip',
			originId: 'ValCodequip',
			area: 'REPAR',
			field: 'CODEQUIP',
			relatedArea: 'EQUIP',
			description: computed(() => this.Resources._EQUIPMENT12605),
		}).cloneFrom(values?.ValCodequip))
		this.stopWatchers.push(watch(() => this.ValCodequip.value, (newValue, oldValue) => this.onUpdate('repar.codequip', this.ValCodequip, newValue, oldValue)))

		this.ValCodespec = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodespec',
			originId: 'ValCodespec',
			area: 'REPAR',
			field: 'CODESPEC',
			relatedArea: 'SPECI',
			description: computed(() => this.Resources._SPECIALTY24336),
		}).cloneFrom(values?.ValCodespec))
		this.stopWatchers.push(watch(() => this.ValCodespec.value, (newValue, oldValue) => this.onUpdate('repar.codespec', this.ValCodespec, newValue, oldValue)))

		this.ValCodpesso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpesso',
			originId: 'ValCodpesso',
			area: 'REPAR',
			field: 'CODPESSO',
			relatedArea: 'PESSO',
			description: computed(() => this.Resources._REPAIRER36801),
		}).cloneFrom(values?.ValCodpesso))
		this.stopWatchers.push(watch(() => this.ValCodpesso.value, (newValue, oldValue) => this.onUpdate('repar.codpesso', this.ValCodpesso, newValue, oldValue)))

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

		this.EquipValPhotogra = reactive(new modelFieldType.Image({
			id: 'EquipValPhotogra',
			originId: 'ValPhotogra',
			area: 'EQUIP',
			field: 'PHOTOGRA',
			isFixed: true,
			description: computed(() => this.Resources.PHOTO51874),
		}).cloneFrom(values?.EquipValPhotogra))
		this.stopWatchers.push(watch(() => this.EquipValPhotogra.value, (newValue, oldValue) => this.onUpdate('equip.photogra', this.EquipValPhotogra, newValue, oldValue)))

		this.ValDtrepara = reactive(new modelFieldType.DateTime({
			id: 'ValDtrepara',
			originId: 'ValDtrepara',
			area: 'REPAR',
			field: 'DTREPARA',
			description: computed(() => this.Resources.FIXED_IN00179),
		}).cloneFrom(values?.ValDtrepara))
		this.stopWatchers.push(watch(() => this.ValDtrepara.value, (newValue, oldValue) => this.onUpdate('repar.dtrepara', this.ValDtrepara, newValue, oldValue)))

		this.ValNrrepara = reactive(new modelFieldType.Number({
			id: 'ValNrrepara',
			originId: 'ValNrrepara',
			area: 'REPAR',
			field: 'NRREPARA',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.NO_RUMOUR_IN_THE_COM15248),
		}).cloneFrom(values?.ValNrrepara))
		this.stopWatchers.push(watch(() => this.ValNrrepara.value, (newValue, oldValue) => this.onUpdate('repar.nrrepara', this.ValNrrepara, newValue, oldValue)))

		this.ValTipoarea = reactive(new modelFieldType.String({
			id: 'ValTipoarea',
			originId: 'ValTipoarea',
			area: 'REPAR',
			field: 'TIPOAREA',
			maxLength: 1,
			arrayOptions: computed(() => new qProjArrays.QArrayAreatecn(vm.$getResource).elements),
			description: computed(() => this.Resources.TECHNICAL_AREA50773),
		}).cloneFrom(values?.ValTipoarea))
		this.stopWatchers.push(watch(() => this.ValTipoarea.value, (newValue, oldValue) => this.onUpdate('repar.tipoarea', this.ValTipoarea, newValue, oldValue)))

		this.TableSpeciEspecial = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableSpeciEspecial',
			originId: 'ValEspecial',
			area: 'SPECI',
			field: 'ESPECIAL',
			maxLength: 50,
			description: computed(() => this.Resources.SPECIALTY09304),
		}).cloneFrom(values?.TableSpeciEspecial))
		this.stopWatchers.push(watch(() => this.TableSpeciEspecial.value, (newValue, oldValue) => this.onUpdate('speci.especial', this.TableSpeciEspecial, newValue, oldValue)))

		this.TablePessoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePessoName',
			originId: 'ValName',
			area: 'PESSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePessoName))
		this.stopWatchers.push(watch(() => this.TablePessoName.value, (newValue, oldValue) => this.onUpdate('pesso.name', this.TablePessoName, newValue, oldValue)))

		this.ValDescript = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescript',
			originId: 'ValDescript',
			area: 'REPAR',
			field: 'DESCRIPT',
			description: computed(() => this.Resources.DESCRIPTION_OF_THE_R26085),
		}).cloneFrom(values?.ValDescript))
		this.stopWatchers.push(watch(() => this.ValDescript.value, (newValue, oldValue) => this.onUpdate('repar.descript', this.ValDescript, newValue, oldValue)))

		this.ValHours = reactive(new modelFieldType.Number({
			id: 'ValHours',
			originId: 'ValHours',
			area: 'REPAR',
			field: 'HOURS',
			maxDigits: 10,
			decimalDigits: 0,
			description: computed(() => this.Resources.SPENT_ON_HOURS19285),
		}).cloneFrom(values?.ValHours))
		this.stopWatchers.push(watch(() => this.ValHours.value, (newValue, oldValue) => this.onUpdate('repar.hours', this.ValHours, newValue, oldValue)))

		/** The form fields used only in formulas. */
		this.SpeciValAreatecn = reactive(new modelFieldType.String({
			id: 'SpeciValAreatecn',
			originId: 'ValAreatecn',
			area: 'SPECI',
			field: 'AREATECN',
			maxLength: 1,
			isFixed: true,
			arrayOptions: computed(() => new qProjArrays.QArrayAreatecn(vm.$getResource).elements),
			description: computed(() => this.Resources.TECHNICAL_AREA50773),
		}).cloneFrom(values?.SpeciValAreatecn))
		this.stopWatchers.push(watch(() => this.SpeciValAreatecn.value, (newValue, oldValue) => this.onUpdate('speci.areatecn', this.SpeciValAreatecn, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormReparViewModel instance.
	 * @returns {QFormReparViewModel} A new instance of QFormReparViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodrepar'

	get QPrimaryKey() { return this.ValCodrepar.value }
	set QPrimaryKey(value) { this.ValCodrepar.updateValue(value) }
}
