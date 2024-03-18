<template>
	<div
		ref="popperContainer"
		class="popover q-fc-event-info"
		role="tooltip">
		<div class="popover-body">
			<div
				class="container-fluid"
				v-if="showInfo && eventData">
				<q-row-container is-large>
					<div class="actions float-right q-fc-event-info_btns">
						<template v-if="!_isEmpty(buttons)">
							<q-button-group borderless>
								<q-button
									v-for="btn in buttons"
									:key="btn.title"
									class="q-fc-event-info_btn-crud"
									:title="btn.title"
									@click="btn.callback">
									<q-icon
										v-if="btn.icon"
										v-bind="btn.icon" />
								</q-button>
							</q-button-group>
							<span class="action-sep"></span>
						</template>

						<q-button
							b-style="secondary"
							borderless
							class="q-fc-event-info_btn-close"
							:title="texts.close"
							@click="emitClose">
							<q-icon icon="remove" />
						</q-button>
					</div>
				</q-row-container>

				<div class="row q-fc-event-info_title">
					<div class="col-1">
						<q-icon
							icon="tag"
							:style="{
								fill: eventData.backgroundColor || defaultEventColor
							}" />
					</div>
					<div class="col-11">
						<span class="form-header">
							{{ eventData?.title }}
						</span>
					</div>
				</div>
				<div class="row q-fc-event-info_date">
					<div class="col-1"></div>
					<div class="col-11">
						<template v-if="eventData?.allDay === true">
							{{ eventData?.start?.toLocaleDateString() }}
						</template>
						<template v-else-if="eventData?.allDay === false">
							{{ eventData?.start?.toLocaleString() }}
							&nbsp;-&nbsp;
							{{ eventData?.end?.toLocaleString() }}
						</template>
					</div>
				</div>
				<div
					class="row q-fc-event-info_description"
					v-if="!_isEmpty(eventData?.extendedProps?.description)">
					<div class="col-1">
						<q-icon icon="list" />
					</div>
					<div class="col-11">
						<span>{{ eventData?.extendedProps?.description }}</span>
					</div>
				</div>
			</div>
			<div v-else></div>
		</div>
	</div>
</template>

<script>
	/*const DEFAULT_EVENT_DATA = {
		id: null,
		title: '',
		start: undefined,
		end: undefined,
		allDay: false,
		description: ''
	};*/

	import _isEmpty from 'lodash-es/isEmpty'
	import _forEach from 'lodash-es/forEach'

	import { btnHasPermission, validateTexts } from '@/mixins/genericFunctions.js'

	import QRowContainer from '@/components/containers/RowContainer.vue'

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		close: 'Close'
	}

	export default {
		name: 'QFullCalendarEventInfo',

		emits: ['close', 'event-action'],

		components: {
			QRowContainer
		},

		props: {
			/**
			 * Event data object containing all relevant details for the event being displayed.
			 * Should include event id, title, start and end times, allDay flag, extendedProps with additional info.
			 */
			eventData: {
				type: Object,
				default: undefined
			},

			/**
			 * Flag indicating whether event info should be displayed.
			 */
			showInfo: {
				type: Boolean,
				default: false
			},

			/**
			 * Array of CRUD action objects which may contain action name, title, icon, and type.
			 * Determines which actions to present to the user.
			 */
			crudActions: {
				type: Array,
				default: undefined
			},

			/**
			 * Flag indicating if the event info should be in a blocked state, preventing any modifications.
			 */
			readonly: {
				type: Boolean,
				default: true
			},

			/**
			 * Object containing the necessary localizable strings to be used within the component.
			 */
			texts: {
				type: Object,
				validator: (value) => validateTexts(DEFAULT_TEXTS, value),
				default: () => DEFAULT_TEXTS
			}
		},

		expose: [],

		data()
		{
			return {
				defaultEventColor: 'var(--fc-event-bg-color, #3788d8)'
			}
		},

		computed: {
			/**
			 * Filters the CRUD actions to display based on permissions and a blocked state.
			 * Creates button data for each CRUD action with a callback to perform the action.
			 */
			buttons()
			{
				const _buttons = []

				if (!_isEmpty(this.eventData))
				{
					_forEach(this.crudActions, (crudAction) => {
						if (
							(crudAction.isInReadOnly || this.readonly === false) &&
							btnHasPermission(
								this.eventData?.extendedProps?.btnPermission,
								crudAction.name
							)
						)
						{
							_buttons.push({
								title: crudAction.title,
								icon: crudAction.icon,
								type: crudAction.type,
								callback: () =>
									this.onExecuteAction({
										...crudAction,
										rowKey: this.eventData.id
									})
							})
						}
					})
				}

				return _buttons
			}
		},

		created()
		{
			// Add event handler for outside click.
			document.addEventListener('click', this.handleClickOutside)
		},

		beforeUnmount()
		{
			document.removeEventListener('click', this.handleClickOutside)
		},

		methods: {
			_isEmpty,

			/**
			 * Emits a close event to signal the dismissal of the event info.
			 */
			emitClose()
			{
				this.$emit('close')
			},

			/**
			 * Checks if the event argument is related to the event being displayed.
			 * @param {Event} event - The DOM event that occurred.
			 * @returns {Boolean} Whether the event is related to the displayed event.
			 */
			isEvent(event)
			{
				let maxDeep = 5
				let targetElement = event.target

				while (targetElement && 0 < maxDeep--)
				{
					if (targetElement.hasAttribute('data-qfc-event'))
						return true

					targetElement = targetElement.parentElement
				}

				return false
			},

			/**
			 * Handles a click outside of the event display, closing the display if applicable.
			 * @param {Event} event - The DOM event that occurred.
			 */
			handleClickOutside(event)
			{
				if (
					this.showInfo &&
					!this.isEvent(event) &&
					!this.$refs.popperContainer.contains(event.target)
				)
					this.emitClose()
			},

			/**
			 * Handles the selected CRUD action by emitting the event-action event and closing the event info.
			 * @param {Object} params - The CRUD action parameters.
			 */
			onExecuteAction(params)
			{
				this.$emit('event-action', params)
				this.emitClose()
			}
		}
	}
</script>
