<template>
	<div
		:id="controlId"
		data-testid="calendarContainer"
		:class="['row-line-group', $attrs.class]"
		:key="refreshKey"
		v-if="!hideControl">
		<full-calendar
			:options="calendarOptions"
			ref="calendar" />

		<div v-show="showEventInfo">
			<q-full-calendar-event-info
				ref="eventInfo"
				:event-data="eventInfoData"
				:show-info="showEventInfo"
				:crud-actions="listConfig.crudActions"
				:readonly="readonly"
				:texts="texts"
				@event-action="handleEventAction"
				@close="closePopper" />
		</div>
	</div>
</template>

<script>
	import { nextTick } from 'vue'
	import Popper from 'popper.js'
	import _get from 'lodash-es/get'
	import _set from 'lodash-es/set'
	import _mergeWith from 'lodash-es/mergeWith'
	import _findIndex from 'lodash-es/findIndex'
	import _findKey from 'lodash-es/findKey'
	//import _isDate from 'lodash-es/isDate'
	import _isEmpty from 'lodash-es/isEmpty'
	import _some from 'lodash-es/some'
	import _startsWith from 'lodash-es/startsWith'
	import _keys from 'lodash-es/keys'
	import _pickBy from 'lodash-es/pickBy'

	import '@fullcalendar/core/vdom' // quick fix for Vite
	import '@fullcalendar/core'
	import FullCalendar from '@fullcalendar/vue3'
	import dayGridPlugin from '@fullcalendar/daygrid'
	import timeGridPlugin from '@fullcalendar/timegrid'
	import interactionPlugin from '@fullcalendar/interaction'
	import listPlugin from '@fullcalendar/list'
	import resourceTimelinePlugin from '@fullcalendar/resource-timeline'
	import resourceTimeGridPlugin from '@fullcalendar/resource-timegrid'
	import resourceDayGridPlugin from '@fullcalendar/resource-daygrid'

	// Allowed languages
	import ptLocale from '@fullcalendar/core/locales/pt'
	import frLocale from '@fullcalendar/core/locales/fr'
	import esLocale from '@fullcalendar/core/locales/es'
	import catLocale from '@fullcalendar/core/locales/ca'
	import zhoLocale from '@fullcalendar/core/locales/zh-cn'
	import danLocale from '@fullcalendar/core/locales/da'
	import gerLocale from '@fullcalendar/core/locales/de'
	import polLocale from '@fullcalendar/core/locales/pl'
	import chiLocale from '@fullcalendar/core/locales/zh-tw'
	import araLocale from '@fullcalendar/core/locales/ar'
	import pbrLocale from '@fullcalendar/core/locales/pt-br'
	import eusLocale from '@fullcalendar/core/locales/eu'

	import { validateTexts } from '@/mixins/genericFunctions.js'

	import qCalendarObj from './fullcalendar/QFullCalendarObjects.js'
	import { themePlugin/*, QFullCalendarTheme*/ } from './fullcalendar/QFullCalendarTheme.js'

	import QFullCalendarEventInfo from './fullcalendar/QFullCalendarEventInfo.vue'

	const DEFAULT_FULL_CALENDAR_OPTIONS = {
		/** The events array [https://fullcalendar.io/docs/event-object] */
		events: [],
		/** Configures Whether Tooltip will display or not */
		noTooltips: false,
		/** Determines if events being dragged and resized are allowed to overlap each other [https://fullcalendar.io/docs/eventOverlap] */
		eventsOverlap: false,
		/** To remove the dates from calendar */
		noDates: false,
		/** Sets the max height of the view area of the calendar[https://fullcalendar.io/docs/contentHeight] */
		maxHeight: '',
		/** Auto height to the calendar[https://fullcalendar.io/docs/contentHeight] */
		autoHeight: true,
		/** Determines the first time slot that will be displayed for each day[https://fullcalendar.io/docs/slotMinTime] */
		slotMinTime: '00:00:00',
		/** Determines the last time slot that will be displayed for each day[https://fullcalendar.io/docs/slotMaxTime] */
		slotMaxTime: '23:59:59',
		/** Configures Whether events can be edit[https://fullcalendar.io/docs/editable] */
		editable: true,
		/** Determines if the “all-day” slot is displayed at the top of the calendar[https://fullcalendar.io/docs/allDaySlot] */
		allDaySlot: true,
		/** Configures Whether calendar will have weekends [https://fullcalendar.io/docs/weekends] */
		weekends: true,
		/** Limits which dates the user can navigate to and where events can go [https://fullcalendar.io/docs/validRange] */
		limitRange: { start: null, end: null },
		/** calendar language */
		locale: 'en',
		/** Locals (translations) */
		locales: [
			ptLocale,
			frLocale,
			esLocale,
			catLocale,
			zhoLocale,
			danLocale,
			gerLocale,
			polLocale,
			chiLocale,
			araLocale,
			pbrLocale,
			eusLocale
		],
		/**
		 * 12 / 24 hour format for the events time and slot time labels
		 * [https://fullcalendar.io/docs/v5/eventTimeFormat]
		 * [https://fullcalendar.io/docs/v5/slotLabelFormat]
		 */
		hour12: false
	}

	/** Configures the header toolbar [https://fullcalendar.io/docs/headerToolbar] */
	const FULL_CALENDAR_VIEWS = [
		{ name: 'dayGridDay', mappedProp: 'viewDayGridDay', default: true },
		{ name: 'dayGridWeek', mappedProp: 'viewDayGridWeek', default: true },
		{ name: 'dayGridMonth', mappedProp: 'viewDayGridMonth', default: true },
		{ name: 'timeGridDay', mappedProp: 'viewTimeGridDay', default: false },
		{ name: 'timeGridWeek', mappedProp: 'viewTimeGridWeek', default: false },
		{ name: 'listDay', mappedProp: 'viewListDay', default: false },
		{ name: 'listWeek', mappedProp: 'viewListWeek', default: false },
		{ name: 'listMonth', mappedProp: 'viewListMonth', default: false },
		{ name: 'listYear', mappedProp: 'viewListYear', default: false },
		{
			name: 'resourceTimelineDay',
			mappedProp: 'viewResourceTimelineDay',
			default: false
		},
		{
			name: 'resourceTimelineWeek',
			mappedProp: 'viewResourceTimelineWeek',
			default: false
		},
		{
			name: 'resourceTimelineMonth',
			mappedProp: 'viewResourceTimelineMonth',
			default: false
		},
		{
			name: 'resourceTimelineYear',
			mappedProp: 'viewResourceTimelineYear',
			default: false
		},
		{
			name: 'resourceTimeGridDay',
			mappedProp: 'viewResourceTimeGridDay',
			default: false
		},
		{
			name: 'resourceTimeGidWeek',
			mappedProp: 'viewResourceTimeGridWeek',
			default: false
		},
		{
			name: 'resourceDayGridDay',
			mappedProp: 'viewResourceDayGridDay',
			default: false
		}
	]

	/*
	const FULL_CALENDAR_UI = {
		direction: 'ltr',
		buttonText: {
			prev: 'prev',
			next: 'next',
			prevYear: 'prev year',
			nextYear: 'next year',
			year: 'year',
			today: 'today',
			month: 'month',
			week: 'week',
			day: 'day',
			list: 'list'
		},
		weekText: 'W',
		weekTextLong: 'Week',
		closeHint: 'Close',
		timeHint: 'Time',
		eventHint: 'Event',
		allDayText: 'all-day',
		moreLinkText: 'more',
		noEventsText: 'No events to display'
	}
	*/

	// The texts needed by the component.
	const DEFAULT_TEXTS = {
		close: 'Close',
		errorOnlyEventsLastLevel: 'It is only allowed to schedule events at the last level of resources.'
	}

	export default {
		name: 'QCalendar',

		components: {
			FullCalendar,
			QFullCalendarEventInfo
		},

		inheritAttrs: false,

		emits: [
			'event-click',
			'event-drop',
			'event-dropped',
			'event-resize',
			'event-date-click',
			'event-date-select',
			'event-action',
			'show-error'
		],

		props: {
			/**
			 * Unique identifier for control.
			 */
			id: String,

			/**
			 * Indicates whether the control is disabled.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * Whether or not the control is currently visible.
			 */
			isVisible: {
				type: Boolean,
				default: true
			},

			/**
			 * The data from which we will display the markers.
			 */
			mappedValues: {
				type: Array,
				default: () => []
			},

			/**
			 * The defined style variables.
			 */
			styleVariables: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The defined mapping variables.
			 */
			mappingVariables: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The configuration of the list.
			 */
			listConfig: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The necessary strings to be used inside the component.
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
				controlId: this.id || this._.uid,

				options: DEFAULT_FULL_CALENDAR_OPTIONS,

				//themePlugin: window.qfc || new QFullCalendarTheme(),

				refreshKey: 0,
				hideControl: false,
				hasRendered: this.isVisible,

				popper: undefined,
				showEventInfo: false,
				eventInfoData: undefined
			}
		},

		computed: {
			/**
			 * Configure whether the control is scheduler or calendar.
			 */
			isScheduler()
			{
				return _findKey(this.options?.views || {}, (_, view) => _startsWith(view, 'resource')) !== undefined
			},

			/**
			 * Useful to keep calendar on the same page (view) when different views are used,
			 * without 'jumping' to the default view after a form reload.
			 */
			fullReload()
			{
				return false
			},

			/**
			 * The FullCalendar options.
			 */
			calendarOptions()
			{
				return {
					/**
					 * An array of Event Objects that will be displayed on the calendar.
					 * [https://fullcalendar.io/docs/v5/events-array]
					 */
					events: this.options.events,
					plugins: this.getPlugins(),
					/**
					 * The initial view when the calendar loads.
					 */
					initialView: this.getView(),
					/** Configures Whether events can be edit[https://fullcalendar.io/docs/editable] */
					editable: this.options.editable,

					locale: this.fixLocaleCode(this.listConfig?.locale ?? DEFAULT_FULL_CALENDAR_OPTIONS.locale),
					locales: DEFAULT_FULL_CALENDAR_OPTIONS.locales,

					/**
					 * Determines the time-text that will be displayed on each event.
					 * [https://fullcalendar.io/docs/v5/eventTimeFormat]
					 */
					eventTimeFormat: {
						// 'hh:mm' format
						hour: '2-digit',
						minute: '2-digit',
						hour12: this.options.hour12 //(if it's true will add AM or PM)
					},

					/**
					 * Determines the text that will be displayed within a time slot.
					 * [https://fullcalendar.io/docs/v5/slotLabelFormat]
					 */
					slotLabelFormat: {
						hour: 'numeric',
						minute: '2-digit',
						omitZeroMinute: false,
						meridiem: 'short',
						hour12: this.options.hour12 //(if it's true will add AM or PM)
					},

					/**
					 * The frequency for displaying time slots.
					 * [https://fullcalendar.io/docs/v5/slotDuration]
					 */
					slotDuration: this.options.slotDuration,

					/**
					 * The frequency that the time slots should be labelled with text.
					 * [https://fullcalendar.io/docs/v5/slotLabelInterval]
					 */
					//slotLabelInterval: this.options.slotLabelInterval,

					/**
					 * Determines if timed events in TimeGrid view should visually overlap.
					 * [https://fullcalendar.io/docs/v5/slotEventOverlap]
					 */
					slotEventOverlap: true,
					/**
					 * Allow events’ durations to be editable through resizing.
					 * (this needs the interaction plugin)
					 */
					eventDurationEditable: true,
					/** Allows a user to highlight multiple days or timeslots by clicking and dragging
					 *	[https://fullcalendar.io/docs/v5/selectable]
					 */
					selectable: false,
					/**
					 * Determines the number of weeks displayed in a month view.
					 * 	If true, the calendar will always be 6 weeks tall.
					 * 	If false, the calendar will have either 4, 5, or 6 weeks, depending on the month.
					 *	[https://fullcalendar.io/docs/v5/fixedWeekCount]
					 */
					fixedWeekCount: false,
					/**
					 * Renders the calendar with a given theme system.
					 * standard / bootstrap5 / bootstrap / ...
					 *  [https://fullcalendar.io/docs/v5/themeSystem]
					 */
					themeSystem: 'quidgest', //"standard", //"bootstrap",
					/**
					 * Whether to draw a “placeholder” event while the user is dragging
					 *  [https://fullcalendar.io/docs/v5/selectMirror]
					 */
					selectMirror: true,

					/**
					 * Determines if events being dragged and resized are allowed to overlap each other
					 *  [https://fullcalendar.io/docs/eventOverlap]
					 */
					eventOverlap: this.options.eventsOverlap,
					/**
					 * Whether or not to display a marker indicating the current time.
					 *  [https://fullcalendar.io/docs/v5/nowIndicator]
					 */
					nowIndicator: this.options.noDates ? false : true,
					/**
					 * Configures Whether calendar will have weekends
					 *  [https://fullcalendar.io/docs/weekends]
					 */
					weekends: this.options.weekends,
					/** Determines if the “all-day” slot is displayed at the top of the calendar[https://fullcalendar.io/docs/allDaySlot] */
					allDaySlot: this.options.allDaySlot,

					/**
					 * Determines the text that will be displayed on the calendar’s column headings.
					 *  [https://fullcalendar.io/docs/v5/dayHeaderFormat]
					 */
					dayHeaderFormat: this.options.noDates ? { weekday: 'long' } : undefined /*{
							weekday: 'short',
							month: 'numeric',
							day: 'numeric',
							omitCommas: true
						}*/,
					/**
					 * Defines the buttons and title at the top of the calendar.
					 *  [https://fullcalendar.io/docs/v5/headerToolbar]
					 */
					headerToolbar: this.options.noDates
						? false
						: {
							left: 'prevYear,prev,next,nextYear today',
							center: 'title',
							right: this.getViewsAsString(this.options.views)
						},
					/**
					 * Called after the calendar’s date range has been initially set or changed in some way and the DOM has been updated.
					 *  [https://fullcalendar.io/docs/v5/datesSet]
					 * @param {*} dateInfo
					 */
					datesSet: (dateInfo) => this.handleDatesSet(dateInfo),

					/** Sets the max height of the view area of the calendar[https://fullcalendar.io/docs/contentHeight] */
					contentHeight: this.getHeight(),

					/** Limits which dates the user can navigate to and where events can go [https://fullcalendar.io/docs/validRange] */
					validRange: this.options.limitRange,
					/** Determines the first time slot that will be displayed for each day[https://fullcalendar.io/docs/slotMinTime] */
					slotMinTime: this.options.slotMinTime,
					/** Determines the last time slot that will be displayed for each day[https://fullcalendar.io/docs/slotMaxTime] */
					slotMaxTime: this.options.slotMaxTime,

					// Add 'title' attribute to the event HTML
					eventDidMount: this.eventDidMount,
					eventWillUnmount: this.eventWillUnmount,

					// Event handlers
					dateClick: this.handleDateClick,
					select: this.handleDateSelect,
					eventClick: this.handleEventClick,
					eventDrop: this.drop,
					eventResize: this.resize,
					drop: this.dropped,

					// Scheduler Otions - added just when it's scheduler
					...this.getSchedulerOtions()
				}
			}
		},

		created()
		{
			this.mapOptions(this.styleVariables, this.mappedValues)
		},

		beforeUnmount()
		{
			this.closePopper()
		},

		methods: {
			/**
			 * Map values for initializing FullCalendar events and resources.
			 * @param {Array} mappedValues - Mapped rows value.
			 */
			mapValues(mappedValues)
			{
				let mappedOptions = {
					events: [],
					resources: [],
					groupInfo: {}
				}

				for (let mappedValue of mappedValues)
				{
					let event = new qCalendarObj.EventObject({
						editable: _get(mappedValue, 'eventEditable.rawData', false) && this.readonly !== true,
						extendedProps: {
							btnPermission: mappedValue.btnPermission
						}
					})
					event.mapValues(mappedValue)
					mappedOptions.events.push(event.getOnlyDefinedOptions())

					let resource = new qCalendarObj.ResourceObject()
					resource.mapValues(mappedValue)
					let rIdx = _findIndex(mappedOptions.resources, (r) => r.id === resource.id)

					if (rIdx === -1)
						mappedOptions.resources.push(resource)
					else if (resource.hasChildren)
						mappedOptions.resources[rIdx].unionChilds(resource)

					if (!_isEmpty(resource.groupId))
						_set(mappedOptions.groupInfo, resource.groupId, resource.groupLabel)
				}

				return mappedOptions
			},

			/**
			 * Get the active view types as a comma-separated string for FullCalendar.
			 * @param {Object} views - The views configuration.
			 * @returns {string} Comma-separated string of active view names.
			 */
			getViewsAsString(views)
			{
				let keys = _keys(_pickBy(views, (viewIsActive) => viewIsActive === true))
				return keys.join(',')
			},

			/**
			 * Map the views based on the style variables.
			 * @param {Object} styleVariables - Mapped style variables.
			 * @returns {Object} Mapped views object where the key is the view name and the value is a boolean indicating if the view is active.
			 */
			mapViews(styleVariables)
			{
				/*
					dayGridDay, dayGridWeek, dayGridMonth, timeGridDay, timeGridWeek, listDay, listWeek, listMonth, listYear, resourceTimelineDay, resourceTimelineWeek, resourceTimelineMonth, resourceTimelineYear, resourceTimeGridDay, resourceTimeGidWeek, resourceDayGridDay
				*/

				const views = {}
				FULL_CALENDAR_VIEWS.forEach((mode) => (views[mode.name] = _get(styleVariables, `${mode.mappedProp}.value`, false)))

				// If no one - set default
				if (!_some(views, (viewIsActive) => viewIsActive === true))
					FULL_CALENDAR_VIEWS.forEach((mode) => (views[mode.name] = mode.default))

				return views
			},

			/**
			 * Initialize FullCalendar options from mapped variables.
			 * @param {Object} styleVariables - Mapped style variables.
			 * @param {Array} mappedValues - Mapped rows value.
			 */
			mapOptions(styleVariables, mappedValues)
			{
				let views = this.mapViews(styleVariables)

				// Merge default option and mapped
				let options = _mergeWith(
					{},
					DEFAULT_FULL_CALENDAR_OPTIONS,
					{
						editable: this.readonly !== true,
						noTooltips: _get(styleVariables, 'extraNoTooltips.value'),
						eventsOverlap: _get(styleVariables, 'extraEventsOverlap.value'),
						noDates: _get(styleVariables, 'extraNoDates.value'),
						/** Configures the header toolbar [https://fullcalendar.io/docs/headerToolbar] */
						views: views,
						/** Configures the initial view of Calendar [https://fullcalendar.io/docs/initialView] */
						initialView: _get(
							styleVariables,
							'initialView.value',
							_findKey(views, (viewIsActive) => viewIsActive === true)
						),
						autoHeight: _get(styleVariables, 'extraAutoHeight.value'),
						maxHeight: _get(styleVariables, 'extraMaxHeight.value', '750'),
						slotMinTime: _get(styleVariables, 'extraSlotMinTime.value'),
						slotMaxTime: _get(styleVariables, 'extraSlotMaxTime.value'),
						allDaySlot: _get(styleVariables, 'extraAllDaySlot.value'),
						limitRange: {
							start: _get(styleVariables, 'extraLimitRangeStart.value', null),
							end: _get(styleVariables, 'extraLimitRangeEnd.value', null)
						},
						hour12: _get(styleVariables, 'extraHour12.value'),
						slotDuration: _get(styleVariables, 'extraSlotDuration.value', '00:30:00'),
						slotLabelInterval: _get(styleVariables, 'extraSlotLabelInterval.value', '01:00:00')
					},
					this.mapValues(mappedValues),
					(objValue, srcValue) => {
						if (typeof srcValue === 'undefined')
							return objValue

						return srcValue
					}
				)

				// Validations

				/*
				// The limit range validation
				const limitRangeRegex =
					/^((?:(?:1[6-9]|2[0-9])\d{2})(-)(?:(?:(?:0?[13578]|1[02])(-)31)|((0?[1,3-9]|1[0-2])(-)(29|30))))$|^(?:(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00)))(-)0?2(-)29)$|^(?:(?:1[6-9]|2[0-9])\d{2})(-)(?:(?:0?[1-9])|(?:1[0-2]))(-)(?:0?[1-9]|1\d|2[0-8])$/
				if (
					!_isDate(options?.limitRange?.start) &&
					!limitRangeRegex.test(options?.limitRange?.start)
				)
					_set(
						options,
						'limitRange.start',
						DEFAULT_FULL_CALENDAR_OPTIONS.limitRange.start
					)
				if (
					!_isDate(options?.limitRange?.end) &&
					!limitRangeRegex.test(options?.limitRange?.end)
				)
					_set(
						options,
						'limitRange.end',
						DEFAULT_FULL_CALENDAR_OPTIONS.limitRange.end
					)
				*/

				// The slot limits validation
				let timeMinMaxCheck = /^([01]\d|2[0-3]):([0-5]\d)(:([0-5]\d))?$/
				if (!timeMinMaxCheck.test(options?.slotMinTime))
					options.slotMinTime = DEFAULT_FULL_CALENDAR_OPTIONS.slotMinTime
				if (!timeMinMaxCheck.test(options?.slotMaxTime))
					options.slotMaxTime = DEFAULT_FULL_CALENDAR_OPTIONS.slotMaxTime

				this.options = options
			},

			/**
			 * Get the options for FullCalendar when operating in scheduler mode.
			 * @returns {Object} Scheduler specific options object.
			 */
			getSchedulerOtions()
			{
				return this.isScheduler
					? {
						/**
						 * Resource group field to adderss revelent Groups [https://fullcalendar.io/docs/resourceGroupField]
						 */
						resourceGroupField: 'groupId',
						resourceGroupLabelContent: (propHook) => {
							return _get(this.options.groupInfo, propHook.groupValue, 'Undefined')
						},
						/**
						 * Determines the ordering of the resource list.
						 * default: 'id,title'
						 */
						resourceOrder: 'title',
						/**
						 * Sets the height of the view area of the calendar[https://fullcalendar.io/docs/schedulerLicenseKey]
						 * GPL-My-Project-Is-Open-Source / CC-Attribution-NonCommercial-NoDerivatives
						 */
						schedulerLicenseKey: this.listConfig?.schedulerLicenseKey,
						/**
						 * Resources Array For Schedular [https://fullcalendar.io/docs/resources-array]
						 */
						resources: this.options.resources
					}
					: {}
			},

			/**
			 * Returns the active plugins for the current FullCalendar.
			 * @returns {Object[]} An array of FullCalendar plugins.
			 */
			getPlugins()
			{
				let plugins = [interactionPlugin, themePlugin]

				if (this.options.views.dayGridDay || this.options.views.dayGridWeek || this.options.views.dayGridMonth)
					plugins.push(dayGridPlugin)

				if (this.options.views.timeGridDay || this.options.views.timeGridWeek)
					plugins.push(timeGridPlugin)

				if (this.options.views.listDay || this.options.views.listWeek || this.options.views.listMonth || this.options.views.listYear)
					plugins.push(listPlugin)

				if (this.options.views.resourceTimelineDay ||
					this.options.views.resourceTimelineWeek ||
					this.options.views.resourceTimelineMonth ||
					this.options.views.resourceTimelineYear)
					plugins.push(resourceTimelinePlugin)

				if (this.options.views.resourceTimeGridDay || this.options.views.resourceTimeGidWeek)
					plugins.push(resourceTimeGridPlugin)

				if (this.options.views.resourceDayGridDay)
					plugins.push(resourceDayGridPlugin)

				return plugins
			},

			/**
			 * Returns the current view for the FullCalendar.
			 * @returns {string} The current view name.
			 */
			getView()
			{
				if (sessionStorage['fcDefaultView' + this.id])
					return sessionStorage['fcDefaultView' + this.id]
				return this.options.initialView
			},

			/**
			 * Closes any open popper displaying event information.
			 */
			closePopper()
			{
				this.showEventInfo = false
				this.eventInfoData = undefined

				if (this.popper && typeof this.popper.destroy === 'function')
					this.popper.destroy()
				this.popper = undefined
			},

			/**
			 * Shows a popper with event details and CRUD actions.
			 * @param {Object} info - Event object with details to display.
			 */
			showPopper(info)
			{
				this.closePopper()

				this.eventInfoData = info.event

				this.popper = new Popper(info.el, this.$refs.eventInfo.$el, {
					placement: 'auto',
					modifiers: {
						offset: {
							// Added an offset to avoid the calendar from covering the event.
							enabled: true,
							offset: '0,10'
						}
					}
				})

				this.showEventInfo = true
			},

			/**
			 * Event mount handler.
			 * Called right after the element has been added to the DOM. If the event data changes, this is NOT called again.
			 * There we will add the 'title' attribute for events.
			 * @param {Object} info - Event info with details to process.
			 */
			eventDidMount(info)
			{
				info.el.setAttribute('data-qfc-event', true)

				if (!this.options.noTooltips)
					info.el.setAttribute('title', info.event.extendedProps.description)
			},

			/**
			 * Event unmount handler for FullCalendar events.
			 */
			eventWillUnmount()
			{
				// Destroy all possible poppers.
				this.closePopper()
			},

			/**
			 * Determines the height for the FullCalendar, either auto or a fixed max height.
			 * @returns {string} Height for the FullCalendar.
			 */
			getHeight()
			{
				return this.options.autoHeight ? 'auto' : this.options.maxHeight ? this.options.maxHeight : '750px'
			},

			handleDateClick(eventData)
			{
				// Check if the click was on a background event. If it was then does nothing.
				if (eventData.jsEvent.target.classList.contains('fc-bgevent'))
					return

				const hasChildren = _some(this.options.resources, res => res.hasChildren)

				if (this.isScheduler && hasChildren && eventData.resource?._resource?.parentId === '')
				{
					this.$emit('show-error', { message: this.texts.errorOnlyEventsLastLevel })
					return
				}

				const startDateField = _get(this.mappingVariables, 'eventStart.sources[0]'),
					endDateField = _get(this.mappingVariables, 'eventEnd.sources[0]'),
					allDayField = _get(this.mappingVariables, 'eventAllDay.sources[0]'),
					startTimeField = _get(this.mappingVariables, 'extraEventStartTime.sources[0]'),
					endTimeField = _get(this.mappingVariables, 'extraEventEndTime.sources[0]'),
					selectedDateField = _get(this.mappingVariables, 'extraEventSelectedDate.sources[0]')

				const parameters = {
					isScheduler: this.isScheduler,
					allDay: _get(eventData, 'allDay', false),
					noDates: this.options.noDates,
					newEdit: !this.isScheduler,
					hasNewResource: this.isScheduler ? true : !(eventData.oldResource === null && eventData.newResource === null),
					hasChildren,
					resourceId: this.isScheduler ? (eventData.resource?.id || '') : '',

					minTime: this.options.slotMinTime,
					maxTime: this.options.slotMaxTime,

					dateTimeINI: eventData.dateStr,
					selectedDate: eventData.date,

					validDateStart: this.options.limitRange.start,
					validDateEnd: this.options.limitRange.end,

					startDateField,
					endDateField,
					allDayField,

					startTimeField,
					endTimeField,
					selectedDateField
				}

				this.$emit('event-date-click', { parameters, eventData })
			},

			/**
			 * Handler for selection of a date or a date range on FullCalendar.
			 * @param {Object} selectInfo - Information about the date selection.
			 */
			handleDateSelect(selectInfo)
			{
				this.$emit('event-date-select', selectInfo)
			},

			/**
			 * Event click handler.
			 * Will open popper for show event datails and CRUD actions.
			 * @param {Object} info - Event object
			 */
			handleEventClick(info)
			{
				this.closePopper()
				if (info.event.display !== 'background')
					this.showPopper(info)

				this.$emit('event-click', info.event)
			},

			/**
			 * Handles event action emitted from popper.
			 * @param {Object} actionParams - Parameters for the event action.
			 */
			handleEventAction(actionParams)
			{
				this.$emit('event-action', actionParams)
			},

			/**
			 * Handles the event when the date range or view type changes in the FullCalendar component.
			 * This method is designed to automatically navigate to the date of the first event
			 * when the "timeGridWeek" view is activated, under specific conditions.
			 * It also saves the current view type to the sessionStorage for persistence across
			 * page reloads when multiple views are used, preventing the calendar from resetting to a default view.
			 *
			 * @param {Object} dateInfo - An object containing information about the current date range and view type.
			 * @param {Date} dateInfo.start - The start date of the currently visible date range.
			 * @param {Date} dateInfo.end - The end date of the currently visible date range.
			 * @param {Object} dateInfo.view - An object representing the current view.
			 * @param {string} dateInfo.view.type - The type of the current view (e.g., "timeGridWeek").
			 *
			 * Conditions for navigating to the first event date:
			 * 1. The view type must be "timeGridWeek".
			 * 2. The 'noDates' option is true, indicating a preference to focus on events without specific date association.
			 * 3. There must be at least one event present.
			 *
			 * If the first event's date is outside the currently visible date range,
			 * the calendar will navigate to that date to bring the event into view.
			 */
			handleDatesSet(dateInfo)
			{
				// Check if the view needs to be persisted across form reloads and save the current view type.
				if (this.fullReload)
					sessionStorage['fcDefaultView' + this.controlId] = dateInfo.view.type

				// Condition to check for 'timeGridWeek' view, 'noDates' option true, and existence of events.
				if (dateInfo.view.type === 'timeGridWeek' && this.options.noDates && this.options.events?.length > 0)
				{
					// Extract the start date of the first event.
					const firstEventDate = this.options.events[0].start
					// Convert the first event's start date into a Date object for comparison.
					const eventDate = new Date(firstEventDate)
					// Retrieve the FullCalendar API to interact with the calendar.
					const calendarApi = this.$refs.calendar.getApi()

					// If the event date is not within the currently visible range, navigate to that date.
					if (eventDate < dateInfo.start || eventDate >= dateInfo.end)
						calendarApi.gotoDate(firstEventDate)
				}
			},

			/**
			 * Handler for events dropped into the calendar from an external source.
			 * @param {Object} info - The event drop information object.
			 */
			dropped(info)
			{
				this.$emit('event-dropped', info)
			},

			/**
			 * Handles the drop of an existing calendar event to a new date/time.
			 * @param {Object} eventData - The event drop information.
			 */
			drop(eventData)
			{
				this.$emit('event-drop', eventData)
			},

			/**
			 * Handles the resize event of an event in the FullCalendar.
			 * @param {Object} info - The event resize information object.
			 */
			resize(info)
			{
				this.$emit('event-resize', info)
			},

			/**
			 * Adjusts the provided locale code to match the format expected by FullCalendar.
			 * This function maps specific locale codes from your system to the corresponding
			 * locale codes supported by FullCalendar.
			 *
			 * @param {string} locale - The locale code as used in your system. These codes typically
			 * follow the format of language code followed by a dash and a country code (e.g., 'en-US').
			 * @returns {string} - The adjusted locale code that matches FullCalendar's expected format.
			 */
			fixLocaleCode(locale)
			{
				switch (locale)
				{
					case 'pt-PT':
					case 'te-PT': return 'pt'
					case 'en-US': return 'en'
					case 'es-ES': return 'es'
					case 'ca-ES': return 'ca'
					case 'zh-CN': return 'zh-cn'
					case 'zh-TW': return 'zh-tw'
					case 'ar-MA': return 'ar'
					case 'en-JM': return 'en'
					case 'pt-BR': return 'pt-br'
					case 'eu-ES': return 'eu'
					default: return locale
				}
			}
		},

		watch: {
			mappedValues: {
				handler(newValue)
				{
					this.mapOptions(this.styleVariables, newValue)
				},
				deep: true
			},

			styleVariables: {
				handler(newValue)
				{
					this.mapOptions(newValue, this.mappedValues)
				},
				deep: true
			},

			isVisible(newValue, oldValue)
			{
				/**
				 * When the control is not visible during its creation, the grid of dates and events is not rendered correctly.
				 * That's why we need to force rendering when control goes from hidden to visible.
				 * note: the «render» method is internally protected from simultaneous re-renders.
				 */
				if (!this.hasRendered && newValue && !oldValue && typeof this.$refs.calendar?.getApi === 'function')
				{
					this.hasRendered = true
					let calendar = this.$refs.calendar?.getApi()
					nextTick().then(() => calendar?.render())
				}
			}

			/*
			themePlugin: {
				handler()
				{
					this.hideControl = true
					this.mapOptions(this.styleVariables, this.mappedValues)
					this.refreshKey++
					this.hideControl = false
				},
				deep: true,
			}
			*/
		}
	}
</script>
