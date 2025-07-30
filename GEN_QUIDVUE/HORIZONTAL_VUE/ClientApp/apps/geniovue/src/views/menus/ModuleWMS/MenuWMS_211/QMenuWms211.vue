<template>
	<div>
		<p><b>Dispatches</b></p>
	</div>

	<q-kanban
		:cards="cardsList"
		:columns="columnsList"
		:add-columns="controls.menu.config.allowColumnEdition"
		:texts="controls.menu.texts"
		v-on="controls.menu.handlers">
		<template #column="{ column }">
			<div
				v-for="additional in column.additionalInformation"
				:key="additional">
				{{ additional.value }}
			</div>
		</template>
		<template #default="{ item }">
			<q-kanban-card
				:card="item"
				:crud-actions="controls.menu.config.crudActions"
				:row-action-display="controls.menu.config.rowActionDisplay"
				v-on="controls.menu.handlersCard" />
		</template>
	</q-kanban>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, readonly } from 'vue'
	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'

	import hardcodedTexts from '@/hardcodedTexts'
	import netAPI from '@quidgest/clientapp/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuWMS_211ViewModel.js'

	const requiredTextResources = ['QMenuWMS_211', 'hardcoded', 'messages']

	export default {
		name: 'QMenuWms211',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the form is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_211', false),

				interfaceMetadata: {
					id: 'QMenuWMS_211', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '211',
					isMenuList: true,
					acronym: 'WMS_211',
					name: 'New Menu',
					route: 'menu-WMS_211',
					order: '211',
					controller: 'DISPA',
					action: 'WMS_Menu_211',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.KanbanControl({
						cardsTable: 'dispa',
						columnsTable: 'disst',
						controller: 'DISPA',
						action: 'WMS_Menu_211',
						hydrate: (_, data) => vm.model.hydrate(data),
						//fnHydrateViewModel: (data) => vm.model.hydrate(data),
						config: {
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DISPA',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DISPA',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DISPA',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DISPA',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'DISPA',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								}
							],
							rowClickAction: {
								id: 'RCA__DISPA',
								name: '_DISPA',
								title: '',
								isInReadOnly: true,
								params: {
									action: vm.openFormAction,
									type: 'form',
									formName: 'DISPA',
									mode: 'EDIT',
									isControlled: true,
									isRoute: true
								}
							},
							formsDefinition: {
								'DISPA': {
									fnKeySelector: (card) => card.DispaValCoddispa.value,
									isPopup: false
								},
							},
						},
					}, this)
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		created()
		{
			this.componentOnLoadProc.addBusy(loadResources(this, requiredTextResources), this.Resources[hardcodedTexts.genericLoad], 300)
		},

		computed: {
			cardsList() {
				const cardsList = []
				this.model.cards.forEach(card => {
					cardsList.push({
						id: card.id,
						column: card.column,
						order: card.order,
						value: card
					})
				})
				return cardsList
			},

			columnsList() {
				const columnsList = []
				this.model.columns.forEach(column => {
					columnsList.push({
						id: column.id,
						title: column.title,
						order: column.order,
						value: column
					})
				})
				return columnsList
			}
		},
	}
</script>
