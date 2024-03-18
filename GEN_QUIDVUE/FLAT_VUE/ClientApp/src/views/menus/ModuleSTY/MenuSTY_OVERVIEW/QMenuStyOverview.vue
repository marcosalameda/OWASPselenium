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

	const requiredTextResources = ['QMenuSTY_OVERVIEW', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS STY_MENU_OVERVIEW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuStyOverview',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_OVERVIEW', false),

				interfaceMetadata: {
					id: 'QMenuSTY_OVERVIEW', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'OVERVIEW',
					isMenuList: true,
					acronym: 'STY_OVERVIEW',
					name: 'UICOM',
					route: 'menu-STY_OVERVIEW',
					order: '11',
					controller: 'UICOM',
					action: 'STY_Menu_OVERVIEW',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableSpecialRenderingControl({
						controller: 'UICOM',
						action: 'STY_Menu_OVERVIEW',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'UICOM',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValCategory',
								area: 'UICOM',
								field: 'CATEGORY',
								label: computed(() => this.Resources.CATEGORY18978),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValMenuid',
								area: 'UICOM',
								field: 'MENUID',
								label: computed(() => this.Resources.FIXED_MENU_NAME38578),
								dataLength: 30,
								scrollData: 30,
							}),
							new listColumnTypes.ImageColumn({
								order: 4,
								name: 'ValThumbnai',
								area: 'UICOM',
								field: 'THUMBNAI',
								label: computed(() => this.Resources.THUMBNAIL30025),
								scrollData: 3,
								sortable: false,
							}),
						],
						config: {
							name: 'STY_Menu_OVERVIEW',
							serverMode: true,
							pkColumn: 'ValCoduicom',
							tableAlias: 'UICOM',
							tableNamePlural: computed(() => this.Resources.UI_COMPONENTS21662),
							viewManagement: 'N',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.UI_COMPONENTS21662),
							perPage: -1,
							pagination: false,
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							globalSearch: {
								visibility: true,
								searchOnPressEnter: true
							},
							filtersVisible: true,
							allowColumnFilters: true,
							allowColumnSort: true,
							crudActions: [
							],
							generalActions: [
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
								id: 'RCA_STY_111',
								name: 'form-UICOM',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCoduicom
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'UICOM',
								}
							},
							formsDefinition: {
								'UICOM': {
									fnKeySelector: (row) => row.Fields.ValCoduicom,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: UICOM
							crudConditions: {
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-UICOM'],
						uuid: '7a94d3ef-80ac-4408-8016-eb66cf9a4ae5',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'CARDS',
								type: 'cards',
								subtype: 'card-img-top',
								label: computed(() => this.Resources.CARTOES27587),
								order: 1,
								mappingVariables: readonly({
									title: {
										allowsMultiple: false,
										sources: [
											'UICOM.NAME',
										]
									},
									image: {
										allowsMultiple: false,
										sources: [
											'UICOM.THUMBNAI',
										]
									},
								}),
								styleVariables: {
									actionsAlignment: {
										rawValue: 'right',
										isMapped: false
									},
									actionsStyle: {
										rawValue: 'grouped',
										isMapped: false
									},
									backgroundColor: {
										rawValue: 'auto',
										isMapped: false
									},
									contentAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									customFollowupDefaultTarget: {
										rawValue: 'blank',
										isMapped: false
									},
									customInsertCard: {
										rawValue: false,
										isMapped: false
									},
									customInsertCardStyle: {
										rawValue: 'secondary',
										isMapped: false
									},
									displayMode: {
										rawValue: 'grid',
										isMapped: false
									},
									containerAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									hoverScaleAmount: {
										rawValue: 1.05,
										isMapped: false
									},
									imageShape: {
										rawValue: 'rectangular',
										isMapped: false
									},
									showColumnTitles: {
										rawValue: false,
										isMapped: false
									},
									showEmptyColumnTitles: {
										rawValue: true,
										isMapped: false
									},
									size: {
										rawValue: 'regular',
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
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
// USE /[MANUAL GQT FORM_CODEJS STY_MENU_OVERVIEW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS STY_MENU_OVERVIEW]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
