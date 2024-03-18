<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-if="componentOnLoadProc.loaded"
					v-bind="model.menu"
					v-on="model.menu.handlers">
				</q-table>

				<q-table-extra-extension
					:list-ctrl="model.menu"
					v-on="model.menu.handlers" />
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:b-style="btn.style"
						:disabled="btn.disabled"
						:icon-on-right="btn.iconOnRight"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable no-unused-vars */
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import genericFunctions from '@/mixins/genericFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'

	import { loadResources } from '@/plugins/i18n.js'
	import asyncProcM from '@/api/global/asyncProcMonitoring.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import netAPI from '@/api/network'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	import qEnums from '@/mixins/quidgest.mainEnums.js'
	/* eslint-enable no-unused-vars */

	const requiredTextResources = ['QMenuTBS_1931', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS TBS_MENU_1931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuTbs1931',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuTBS_1931', false),

				interfaceMetadata: {
					id: 'QMenuTBS_1931', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '1931',
					isMenuList: true,
					acronym: 'TBS_1931',
					name: 'FEECA',
					route: 'menu-TBS_1931',
					order: '1931',
					controller: 'FEECA',
					action: 'TBS_Menu_1931',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'FEECA',
						action: 'TBS_Menu_1931',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'Flds.ValDescrip',
								area: 'FLDS',
								field: 'DESCRIP',
								label: computed(() => this.Resources.DESCRICAO51618),
								scrollData: 30,
								pkColumn: 'ValCodflds',
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValFeedback',
								area: 'FEECA',
								field: 'FEEDBACK',
								label: computed(() => this.Resources.FEEDBACK52855),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.DocumentColumn({
								order: 3,
								name: 'Flds.ValAttach',
								area: 'FLDS',
								field: 'ATTACH',
								label: computed(() => this.Resources.ANEXOS65235),
								dataLength: 50,
								scrollData: 30,
								sortable: false,
								pkColumn: 'ValCodflds',
								viewType: qEnums.documentViewTypeMode.Print,
							}),
						],
						config: {
							name: 'TBS_Menu_1931',
							serverMode: true,
							pkColumn: 'ValCodfeeca',
							tableAlias: 'FEECA',
							tableNamePlural: computed(() => this.Resources.FIELD_FEEDBACK53085),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.FEEDBACK_CAMPO42437),
							showAlternatePagination: true,
							permissions: {
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
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
										formName: 'FEECA',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FEECA',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FEECA',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FEECA',
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
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'FEECA',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA_TBS_19311',
								name: 'form-FEECA',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodfeeca
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'FEECA',
								}
							},
							formsDefinition: {
								'FEECA': {
									fnKeySelector: (row) => row.Fields.ValCodfeeca,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: FEECA
							crudConditions: {
							},
							defaultSearchColumnName: 'ValFeedback',
							defaultSearchColumnNameOriginal: 'ValFeedback',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-FLDS', 'changed-FEECA'],
						uuid: 'bcd28de4-9e50-4d1a-92e0-3c661c0ab999',
						allSelectedRows: 'false',
						headerLevel: 1
					}, this)
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(to, next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_CODEJS TBS_MENU_1931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS TBS_MENU_1931]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
