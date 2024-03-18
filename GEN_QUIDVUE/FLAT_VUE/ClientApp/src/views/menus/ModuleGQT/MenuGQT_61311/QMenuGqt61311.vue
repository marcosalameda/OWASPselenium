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

	const requiredTextResources = ['QMenuGQT_61311', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS GQT_MENU_61311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuGqt61311',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuGQT_61311', false),

				interfaceMetadata: {
					id: 'QMenuGQT_61311', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '61311',
					isMenuList: true,
					acronym: 'GQT_61311',
					name: 'PESSO',
					route: 'menu-GQT_61311',
					order: '61311',
					controller: 'PESSO',
					action: 'GQT_Menu_61311',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableListControl({
						controller: 'PESSO',
						action: 'GQT_Menu_61311',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'PESSO',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 85,
								scrollData: 50,
							}),
							new listColumnTypes.ArrayColumn({
								order: 2,
								name: 'ValGender',
								area: 'PESSO',
								field: 'GENDER',
								label: computed(() => this.Resources.GENUS37471),
								dataLength: 1,
								scrollData: 1,
								array: qProjArrays.QArrayGenero.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArrayGenero.type,
							}),
							new listColumnTypes.DateColumn({
								order: 3,
								name: 'ValDtnascim',
								area: 'PESSO',
								field: 'DTNASCIM',
								label: computed(() => this.Resources.BIRTH21799),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValTelephon',
								area: 'PESSO',
								field: 'TELEPHON',
								label: computed(() => this.Resources.PHONE56703),
								dataLength: 20,
								scrollData: 20,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValEmail',
								area: 'PESSO',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 254,
								scrollData: 30,
							}),
							new listColumnTypes.ImageColumn({
								order: 6,
								name: 'ValPhotogra',
								area: 'PESSO',
								field: 'PHOTOGRA',
								label: computed(() => this.Resources.PHOTO51874),
								scrollData: 3,
								sortable: false,
							}),
							new listColumnTypes.NumericColumn({
								order: 7,
								name: 'ValIdfuncio',
								area: 'PESSO',
								field: 'IDFUNCIO',
								label: computed(() => this.Resources.OFFICIAL_NO_34819),
								scrollData: 6,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'Cmpny.ValDesignat',
								area: 'CMPNY',
								field: 'DESIGNAT',
								label: computed(() => this.Resources.COMPANY52963),
								dataLength: 85,
								scrollData: 30,
								supportForm: 'EMPRE',
								supportFormIsPopup: true,
								params: {
									type: 'form',
									formName: 'EMPRE',
									mode: 'SHOW'
								},
								cellAction: true,
								pkColumn: 'ValCodempre',
							}),
						],
						config: {
							name: 'GQT_Menu_61311',
							serverMode: true,
							pkColumn: 'ValCodpesso',
							tableAlias: 'PESSO',
							tableNamePlural: computed(() => this.Resources.PEOPLE34206),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PEOPLE34206),
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
										formName: 'PESSO1',
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
										formName: 'PESSO1',
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
										formName: 'PESSO1',
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
										formName: 'PESSO1',
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
										formName: 'PESSO1',
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
								id: 'RCA_GQT_613111',
								name: 'form-PESSO1',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodpesso
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'EDIT', formName: 'PESSO1',
								}
							},
							formsDefinition: {
								'PESSO1': {
									fnKeySelector: (row) => row.Fields.ValCodpesso,
									isPopup: false
								},
								'EMPRE': {
									fnKeySelector: (row) => row.Fields.ValCodempre,
									isPopup: true
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: PESSO1
							crudConditions: {
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-PESSO', 'changed-CATEG', 'changed-REGI1', 'changed-CNTRY', 'changed-CMPNY', 'changed-PAIS1'],
						uuid: '43b74fc0-f043-4186-85a5-b0b0e481fb34',
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
// USE /[MANUAL GQT FORM_CODEJS GQT_MENU_61311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS GQT_MENU_61311]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
