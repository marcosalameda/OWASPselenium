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

	const requiredTextResources = ['QMenuSTY_CARDIMGTOP', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT FORM_INCLUDEJS STY_MENU_CARDIMGTOP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuStyCardimgtop',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSTY_CARDIMGTOP', false),

				interfaceMetadata: {
					id: 'QMenuSTY_CARDIMGTOP', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: 'CARDIMGTOP',
					isMenuList: true,
					acronym: 'STY_CARDIMGTOP',
					name: 'WPESS',
					route: 'menu-STY_CARDIMGTOP',
					order: '2231',
					controller: 'WPESS',
					action: 'STY_Menu_CARDIMGTOP',
					isPopup: false
				},

				model: {
					menu: new controlClass.TableSpecialRenderingControl({
						controller: 'WPESS',
						action: 'STY_Menu_CARDIMGTOP',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValName',
								area: 'WPESS',
								field: 'NAME',
								label: computed(() => this.Resources.NAME31974),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.DateColumn({
								order: 2,
								name: 'ValDate',
								area: 'WPESS',
								field: 'DATE',
								label: computed(() => this.Resources.DATA_DE_NASCIMENTO48110),
								scrollData: 8,
								dateTimeType: 'Date',
							}),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'ValSex',
								area: 'WPESS',
								field: 'SEX',
								label: computed(() => this.Resources.SEXO52099),
								dataLength: 9,
								scrollData: 9,
								array: qProjArrays.QArraySexo.setResources(vm.$getResource).elements,
								arrayType: qProjArrays.QArraySexo.type,
							}),
							new listColumnTypes.NumericColumn({
								order: 4,
								name: 'ValNfunc',
								area: 'WPESS',
								field: 'NFUNC',
								label: computed(() => this.Resources.NOFUNCIONARIO21429),
								scrollData: 1,
								maxDigits: 6,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 5,
								name: 'ValAdress',
								area: 'WPESS',
								field: 'ADRESS',
								label: computed(() => this.Resources.ADDRESS04342),
								dataLength: 100,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 6,
								name: 'ValZipcode',
								area: 'WPESS',
								field: 'ZIPCODE',
								label: computed(() => this.Resources.ZIP_CODE56964),
								dataLength: 8,
								scrollData: 8,
							}),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValCountry',
								area: 'WPESS',
								field: 'COUNTRY',
								label: computed(() => this.Resources.PAIS04637),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'ValEmail',
								area: 'WPESS',
								field: 'EMAIL',
								label: computed(() => this.Resources.EMAIL25170),
								dataLength: 150,
								scrollData: 30,
							}),
							new listColumnTypes.NumericColumn({
								order: 9,
								name: 'ValCellphon',
								area: 'WPESS',
								field: 'CELLPHON',
								label: computed(() => this.Resources.NOTELEFONE56747),
								scrollData: 9,
								maxDigits: 9,
								decimalPlaces: 0,
							}),
							new listColumnTypes.TextColumn({
								order: 10,
								name: 'ValNaturali',
								area: 'WPESS',
								field: 'NATURALI',
								label: computed(() => this.Resources.NATURALNESS33189),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 11,
								name: 'ValNacional',
								area: 'WPESS',
								field: 'NACIONAL',
								label: computed(() => this.Resources.NACIONALIDADE23735),
								dataLength: 50,
								scrollData: 30,
							}),
							new listColumnTypes.TextColumn({
								order: 12,
								name: 'Wareh.ValWarehdes',
								area: 'WAREH',
								field: 'WAREHDES',
								label: computed(() => this.Resources.WAREHOUSE51864),
								dataLength: 85,
								scrollData: 30,
								pkColumn: 'ValCodwareh',
							}),
							new listColumnTypes.ImageColumn({
								order: 13,
								name: 'ValFtimgtop',
								area: 'WPESS',
								field: 'FTIMGTOP',
								label: computed(() => this.Resources.IMAGE_TOP34930),
								scrollData: 3,
								sortable: false,
							}),
						],
						config: {
							name: 'STY_Menu_CARDIMGTOP',
							serverMode: true,
							pkColumn: 'ValCodpess',
							tableAlias: 'WPESS',
							tableNamePlural: computed(() => this.Resources.EMPLOYEES22728),
							viewManagement: 'U',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.CARD_IMAGE_TOP01944),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
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
										formName: 'ARMAPESS',
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
								id: 'RCA_STY_22311',
								name: 'form-ARMAPESS',
								params: {
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodpess
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'ARMAPESS',
								}
							},
							formsDefinition: {
								'ARMAPESS': {
									fnKeySelector: (row) => row.Fields.ValCodpess,
									isPopup: false
								},
							},
							rowValidation: {
								fnValidate: (row) => row.Fields.ValZzstate === 0,
								message: computed(() => this.Resources.ATENCAO__ESTA_FICHA_24725),
								class: 'c-table__row--pending'
							},
							// The list support form: ARMAPESS
							crudConditions: {
							},
							defaultSearchColumnName: 'ValName',
							defaultSearchColumnNameOriginal: 'ValName',
							initialSortColumnName: '',
							initialSortColumnOrder: 'asc'
						},
						changeEvents: ['changed-WAREH', 'changed-WPESS'],
						uuid: '0e99ffff-7adf-43a1-9968-81840cdfb35c',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'LIST',
								type: 'list',
								subtype: '',
								label: computed(() => this.Resources.LISTA13474),
								order: 1,
								mappingVariables: readonly({
								}),
								styleVariables: {
								},
								groups: {
								}
							},
							{
								id: 'CARDS',
								type: 'cards',
								subtype: 'card-img-top',
								label: computed(() => this.Resources.CARTOES27587),
								order: 2,
								mappingVariables: readonly({
									title: {
										allowsMultiple: false,
										sources: [
											'WPESS.NAME',
										]
									},
									subtitle: {
										allowsMultiple: false,
										sources: [
											'WPESS.DATE',
										]
									},
									text: {
										allowsMultiple: true,
										sources: [
											'WPESS.NACIONAL',
											'WPESS.NFUNC',
											'WPESS.EMAIL',
										]
									},
									image: {
										allowsMultiple: false,
										sources: [
											'WPESS.FTIMGTOP',
										]
									},
								}),
								styleVariables: {
									actionsAlignment: {
										rawValue: 'right',
										isMapped: false
									},
									actionsStyle: {
										rawValue: 'dropdown',
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
										rawValue: true,
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
// USE /[MANUAL GQT FORM_CODEJS STY_MENU_CARDIMGTOP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL GQT LISTING_CODEJS STY_MENU_CARDIMGTOP]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
