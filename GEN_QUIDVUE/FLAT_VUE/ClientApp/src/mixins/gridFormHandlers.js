import { computed } from 'vue'

import hardcodedTexts from '@/hardcodedTexts.js'
import formControlClass from '@/mixins/formControl.js'
import FormHandlers from '@/mixins/formHandlers.js'

/*****************************************************************
 * This mixin defines methods to be reused by editable table     *
 * list forms.                                                   *
 *****************************************************************/
export default {
	emits: {
		'mark-for-deletion': () => true,
		'undo-deletion': () => true
	},

	mixins: [
		FormHandlers
	],

	props: {
		/**
		 * The initial state of the editable table list row.
		 */
		initialState: {
			type: String,
			default: ''
		}
	},

	data()
	{
		return {
			currentRouteParams: {},

			formButtons: new formControlClass.FormControlButtons(),

			texts: {
				delete: computed(() => this.Resources[hardcodedTexts.delete]),
				remove: computed(() => this.Resources[hardcodedTexts.remove]),
				restore: computed(() => this.Resources[hardcodedTexts.restore])
			},

			markedForDeletion: false
		}
	},

	computed: {
		/**
		 * The state of the row.
		 */
		state()
		{
			if (this.markedForDeletion)
				return 'DELETED'
			else if (this.nestedModel.hasServerErrorMessages())
				return 'ERRORS'
			else if (this.initialState === 'NEW')
				return this.nestedModel.isDirty ? 'NEW' : 'NEW--EMPTY'
			return this.nestedModel.isDirty ? 'EDITED' : ''
		},

		/**
		 * The class associated to the state of the row.
		 */
		rowClass()
		{
			return `grid-table-row${this.state !== '' ? '__' + this.state.toLowerCase() : ''}`
		},

		/**
		 * The icon associated to the state of the row.
		 */
		rowStateIcon()
		{
			switch (this.state)
			{
				case 'NEW':
					return 'add-outline'
				case 'NEW--EMPTY':
					return 'add'
				case 'EDITED':
					return 'pencil'
				case 'ERRORS':
					return 'exclamation-sign'
				case 'DELETED':
					return 'delete'
				default:
					return ''
			}
		},

		/**
		 * Whether to show the "delete" button or not.
		 * This button should be visible for all pre-existing rows.
		 */
		showDeleteBtn()
		{
			return this.mode === 'EDIT'
				&& this.permissions.canDelete
				&& this.initialState === ''
		},

		/**
		 * Whether to show the "remove" button or not.
		 * This button should be visible for new rows.
		 */
		showRemoveBtn()
		{
			return this.initialState === 'NEW'
				&& this.nestedModel.isDirty
		},

		/**
		 * Whether to show the "undo" button or not.
		 * This button should be visible for rows that are
		 * marked to be deleted.
		 */
		showUndoBtn()
		{
			return this.state === 'DELETED'
		}
	},

	methods: {
		/**
		 * Marks this row for deletion when the main form is saved.
		 */
		markForDeletion()
		{
			this.markedForDeletion = true
			this.emitEvent('mark-for-deletion')
		},

		/**
		 * Undoes the "Mark for deletion" action.
		 */
		undoMarkForDeletion()
		{
			this.markedForDeletion = false
			this.emitEvent('undo-deletion')
		}
	}
}
