import _assignIn from 'lodash-es/assignIn'
import _forEach from 'lodash-es/forEach'
import _isEmpty from 'lodash-es/isEmpty'

import { triggerEvents } from './quidgest.mainEnums.js'
import formFunctions from './formFunctions.js'
import FormViewModelBase from './formViewModelBase.js'
import eventBus from '@/api/global/eventBus.js'

export class FormControlButton
{
	constructor()
	{
		this.id = undefined
		this.icon = undefined
		this.type = undefined
		this.text = ''
		this.style = ''
		this.showInHeader = false
		this.showInFooter = false
		this.isActive = false
		this.isVisible = false
		this.disabled = false
		this.action = () => false
	}
}

export class FormControlButtons
{
	constructor()
	{
		this.changeToShow = new FormControlButton()
		this.changeToEdit = new FormControlButton()
		this.changeToDuplicate = new FormControlButton()
		this.changeToDelete = new FormControlButton()
		this.changeToInsert = new FormControlButton()
	}
}

export class FormControl
{
	constructor(_vueContext)
	{
		this.vueContext = _vueContext
		/**
		 * The form UI components visibility
		 */
		this.uiComponents = {
			header: true,
			headerButtons: true,
			footer: true
		}
		this.initialized = false
	}

	Init(initTabs, isEditable)
	{
		if (typeof initTabs !== 'boolean')
			initTabs = true

		this.isEditable = typeof isEditable === 'boolean' ? isEditable : true

		this.InitModel()
		this.InitControls(initTabs)
		this.InitBtns()
		this.InitTriggers()

		this.initialized = true

		if (typeof this.vueContext.afterLoad === 'function')
			this.vueContext.afterLoad()
	}

	InitModel()
	{
		if (this.vueContext.model instanceof FormViewModelBase)
			this.vueContext.model.initFieldsValueFormula()
	}

	InitControls(initTabs)
	{
		if (!this.vueContext.controls)
			return

		_forEach(this.vueContext.controls, (ctrl) => {
			if (initTabs || ctrl.type !== 'Tabs')
				ctrl.Init(this.isEditable)
		})
	}

	InitTabs()
	{
		if (!this.vueContext.controls)
			return

		_forEach(this.vueContext.controls, (ctrl) => {
			if (ctrl.type === 'Tabs')
				ctrl.Init(this.isEditable)
		})
	}

	CalcFieldsFormulas()
	{
		if (this.vueContext.model instanceof FormViewModelBase)
			this.vueContext.model.calcFieldsFormulas()
	}

	CalcShowWhenFormulas()
	{
		this.vueContext.internalEvents.emit('CALC_SHOW_WHEN_FORMULAS')
	}

	CalcBlockWhenFormulas()
	{
		this.vueContext.internalEvents.emit('CALC_BLOCK_WHEN_FORMULAS')
	}

	CalcFillWhenFormulas()
	{
		if (this.vueContext.model instanceof FormViewModelBase)
			this.vueContext.model.calcFillWhenFormulas()
	}

	CalcAllInterfaceFormulas()
	{
		this.CalcShowWhenFormulas()
		this.CalcBlockWhenFormulas()
		this.CalcFillWhenFormulas()
	}

	CalcAllFormulas()
	{
		this.CalcFieldsFormulas()
		this.CalcAllInterfaceFormulas()
	}

	SetupBtns()
	{
		// Nested forms will not change the buttons available on the side bar.
		if (this.vueContext.isNested)
			return
		else if (this.vueContext.isHomePage)
		{
			this.ClearBtns()
			return
		}

		eventBus.emit('changed-form-buttons', this.vueContext.formButtonSections)
	}

	InitBtns()
	{
		if (!this.vueContext.formButtons)
			return

		this.SetupBtns()
		this.vueContext.internalEvents.on('form-buttons-change', () => this.SetupBtns())
	}

	InitTriggers()
	{
		if (typeof this.vueContext.getTriggers !== 'function')
			return

		// Get all the periodic triggers.
		const triggers = this.vueContext.getTriggers(triggerEvents.periodic)

		this.triggerIntervalIds = []

		// Schedule execution of periodic events.
		_forEach(triggers, (t) => {
			const intervalId = setInterval(() => formFunctions.executeTriggerAction(t), t.periodicity * 1000)
			this.triggerIntervalIds.push(intervalId)
		})
	}

	ClearBtns()
	{
		// Nested forms will not change the buttons available on the side bar.
		if (this.vueContext.isNested)
			return

		eventBus.emit('changed-form-buttons', {})
	}

	/**
	 * Defines the form's anchors.
	 */
	setFormAnchors(controlsTree, open = false)
	{
		eventBus.emit('changed-form-anchors', controlsTree)
		if (open)
			eventBus.emit('open-sidebar-on-tab', 'form-anchors-tab')
	}

	/**
	 * Defines if the form is in editable mode.
	 * In addition to being locked/unlocked, some controls may be invisible in non-editable modes.
	 * @param {boolean} isEditableForm
	 */
	setFormModeBlockAndVisibility(isEditable)
	{
		this.isEditable = typeof isEditable === 'boolean' ? isEditable : true
		if (this.vueContext.controls)
		{
			_forEach(this.vueContext.controls, (ctrl) => {
				if (ctrl.setFormModeBlockAndVisibility)
					ctrl.setFormModeBlockAndVisibility(this.isEditable)
			})
		}
	}

	/**
	 * Change the form UI components visibility.
	 * @param {object} options { header, headerButtons, footer }
	 */
	setUIComponents(options)
	{
		_assignIn(this.uiComponents, options)
	}

	/**
	 * Setup of the various listeners for changes to the DB, which will update the respective list whenever changes occur.
	 */
	initListOnDBChangeEvent()
	{
		for (let tableName of this.vueContext.tableFields || [])
		{
			let table = this.vueContext.controls[tableName]
			if (_isEmpty(table))
				continue

			// We give an id to the list reload method, so the listener can be correctly removed later.
			table.reloadList = (dirtyFields) => this.vueContext.reloadList(tableName, dirtyFields)
			eventBus.onMany(table.changeEvents, table.reloadList)
		}
	}

	/**
	 * Remove of the various listeners for changes to the DB, which will update the respective list whenever changes occur.
	 */
	removeListOnDBChangeEvent()
	{
		for (let tableName of this.vueContext.tableFields || [])
		{
			let table = this.vueContext.controls[tableName]
			if (!_isEmpty(table))
				eventBus.offMany(table.changeEvents, table.reloadList)
		}
	}

	Destroy()
	{
		this.ClearBtns()

		this.removeListOnDBChangeEvent()

		if (this.vueContext.model instanceof FormViewModelBase)
			this.vueContext.model.unbindEvents()

		_forEach(this.vueContext.controls, (ctrl) => {
			if (ctrl.destroy)
				ctrl.destroy()
		})

		this.DestroyTriggers()
	}

	DestroyTriggers()
	{
		if (_isEmpty(this.triggerIntervalIds))
			return

		_forEach(this.triggerIntervalIds, (intervalId) => clearInterval(intervalId))

		this.triggerIntervalIds.length = 0
	}
}

export default {
	FormControl,
	FormControlButtons,
	FormControlButton
}
