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
			name: 'F_MENUIT',
			area: 'MENUIT',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_F_MENUIT',
				updateFilesTickets: 'UpdateFilesTicketsF_MENUIT'
			}
		})

		/** The primary key. */
		this.ValCodmenuit = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodmenuit',
			originId: 'ValCodmenuit',
			area: 'MENUIT',
			field: 'CODMENUIT',
			description: '',
		}).cloneFrom(values?.ValCodmenuit))
		watch(() => this.ValCodmenuit.value, (newValue, oldValue) => this.onUpdate('menuit.codmenuit', this.ValCodmenuit, newValue, oldValue))

		/** The used foreign keys. */
		this.ValMclass = reactive(new modelFieldType.ForeignKey({
			id: 'ValMclass',
			originId: 'ValMclass',
			area: 'MENUIT',
			field: 'MCLASS',
			relatedArea: 'MENUC',
			description: computed(() => this.Resources.MENU_ITEM_CLASS00317),
		}).cloneFrom(values?.ValMclass))
		watch(() => this.ValMclass.value, (newValue, oldValue) => this.onUpdate('menuit.mclass', this.ValMclass, newValue, oldValue))

		/** The remaining form fields. */
		this.ValSigl = reactive(new modelFieldType.String({
			id: 'ValSigl',
			originId: 'ValSigl',
			area: 'MENUIT',
			field: 'SIGL',
			maxLength: 50,
			maskType: 'UP',
			description: computed(() => this.Resources.SIGLA14738),
		}).cloneFrom(values?.ValSigl))
		watch(() => this.ValSigl.value, (newValue, oldValue) => this.onUpdate('menuit.sigl', this.ValSigl, newValue, oldValue))

		this.ValOrder = reactive(new modelFieldType.Number({
			id: 'ValOrder',
			originId: 'ValOrder',
			area: 'MENUIT',
			field: 'ORDER',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.ORDER39632),
		}).cloneFrom(values?.ValOrder))
		watch(() => this.ValOrder.value, (newValue, oldValue) => this.onUpdate('menuit.order', this.ValOrder, newValue, oldValue))

		this.ValMtype = reactive(new modelFieldType.String({
			id: 'ValMtype',
			originId: 'ValMtype',
			area: 'MENUIT',
			field: 'MTYPE',
			maxLength: 50,
			description: computed(() => this.Resources.MENU_ITEM_TYPE45031),
		}).cloneFrom(values?.ValMtype))
		watch(() => this.ValMtype.value, (newValue, oldValue) => this.onUpdate('menuit.mtype', this.ValMtype, newValue, oldValue))

		this.TableMenucMenucl = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableMenucMenucl',
			originId: 'ValMenucl',
			area: 'MENUC',
			field: 'MENUCL',
			maxLength: 50,
			description: computed(() => this.Resources.MENU_ITEM_CLASS00317),
		}).cloneFrom(values?.TableMenucMenucl))
		watch(() => this.TableMenucMenucl.value, (newValue, oldValue) => this.onUpdate('menuc.menucl', this.TableMenucMenucl, newValue, oldValue))

		this.ValMdesc = reactive(new modelFieldType.MultiLineString({
			id: 'ValMdesc',
			originId: 'ValMdesc',
			area: 'MENUIT',
			field: 'MDESC',
			description: computed(() => this.Resources.MENU_TYPE_DESCRIPTIO58222),
		}).cloneFrom(values?.ValMdesc))
		watch(() => this.ValMdesc.value, (newValue, oldValue) => this.onUpdate('menuit.mdesc', this.ValMdesc, newValue, oldValue))

		this.ValMenuimg = reactive(new modelFieldType.Image({
			id: 'ValMenuimg',
			originId: 'ValMenuimg',
			area: 'MENUIT',
			field: 'MENUIMG',
			description: computed(() => this.Resources.MENU_TYPE_IMAGE24741),
		}).cloneFrom(values?.ValMenuimg))
		watch(() => this.ValMenuimg.value, (newValue, oldValue) => this.onUpdate('menuit.menuimg', this.ValMenuimg, newValue, oldValue))

		this.ValLink = reactive(new modelFieldType.String({
			id: 'ValLink',
			originId: 'ValLink',
			area: 'MENUIT',
			field: 'LINK',
			maxLength: 50,
			description: computed(() => this.Resources.EXAMPLE_LINK09181),
		}).cloneFrom(values?.ValLink))
		watch(() => this.ValLink.value, (newValue, oldValue) => this.onUpdate('menuit.link', this.ValLink, newValue, oldValue))
	}

	/**
	 * Creates a clone of the current QFormFMenuitViewModel instance.
	 * @returns {QFormFMenuitViewModel} A new instance of QFormFMenuitViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodmenuit'

	get QPrimaryKey() { return this.ValCodmenuit.value }
	set QPrimaryKey(value) { this.ValCodmenuit.updateValue(value) }
}
