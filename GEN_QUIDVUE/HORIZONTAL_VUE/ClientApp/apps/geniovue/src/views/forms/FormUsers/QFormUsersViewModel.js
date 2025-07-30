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
			name: 'USERS',
			area: 'USERS',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Users',
				updateFilesTickets: 'UpdateFilesTicketsUsers',
				setFile: 'SetFileUsers'
			}
		})

		/** The primary key. */
		this.ValCodusers = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodusers',
			originId: 'ValCodusers',
			area: 'USERS',
			field: 'CODUSERS',
			description: '',
		}).cloneFrom(values?.ValCodusers))
		this.stopWatchers.push(watch(() => this.ValCodusers.value, (newValue, oldValue) => this.onUpdate('users.codusers', this.ValCodusers, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodpsw = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodpsw',
			originId: 'ValCodpsw',
			area: 'USERS',
			field: 'CODPSW',
			relatedArea: 'PSW',
			description: computed(() => this.Resources.__LOGIN09030),
		}).cloneFrom(values?.ValCodpsw))
		this.stopWatchers.push(watch(() => this.ValCodpsw.value, (newValue, oldValue) => this.onUpdate('users.codpsw', this.ValCodpsw, newValue, oldValue)))

		this.ValCodperso = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodperso',
			originId: 'ValCodperso',
			area: 'USERS',
			field: 'CODPERSO',
			relatedArea: 'PERSO',
			description: computed(() => this.Resources.__PERSON30342),
		}).cloneFrom(values?.ValCodperso))
		this.stopWatchers.push(watch(() => this.ValCodperso.value, (newValue, oldValue) => this.onUpdate('users.codperso', this.ValCodperso, newValue, oldValue)))

		/** The remaining form fields. */
		this.TablePswNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePswNome',
			originId: 'ValNome',
			area: 'PSW',
			field: 'NOME',
			maxLength: 100,
			description: computed(() => this.Resources.NAME31974),
		}).cloneFrom(values?.TablePswNome))
		this.stopWatchers.push(watch(() => this.TablePswNome.value, (newValue, oldValue) => this.onUpdate('psw.nome', this.TablePswNome, newValue, oldValue)))

		this.TablePersoName = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TablePersoName',
			originId: 'ValName',
			area: 'PERSO',
			field: 'NAME',
			maxLength: 85,
			description: computed(() => this.Resources.PERSON_NAME40980),
		}).cloneFrom(values?.TablePersoName))
		this.stopWatchers.push(watch(() => this.TablePersoName.value, (newValue, oldValue) => this.onUpdate('perso.name', this.TablePersoName, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormUsersViewModel instance.
	 * @returns {QFormUsersViewModel} A new instance of QFormUsersViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodusers'

	get QPrimaryKey() { return this.ValCodusers.value }
	set QPrimaryKey(value) { this.ValCodusers.updateValue(value) }
}
