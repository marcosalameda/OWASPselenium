<template>
	<h2>{{ Resources.SELECIONE_UMA_OPCAO51988 }}</h2>

	<table class="table table-striped">
		<thead>
			<tr>
				<th>{{ Resources.GENDER44172 }}</th>
				<th></th>
			</tr>
		</thead>

		<tbody>
			<tr
				v-for="item in model.listArray"
				:key="item.key">
				<td>{{ item.value }}</td>
				<td>
					<a
						class="btn"
						href="javascript:void(0)"
						@click.prevent="followUp(item.key)">
						<span>
							<q-icon icon="play" />
							{{ Resources.SEGUINTE24541 }}
						</span>
					</a>
				</td>
			</tr>
		</tbody>
	</table>
</template>

<script>
	import { loadResources } from '@/plugins/i18n'
	import hardcodedTexts from '@/hardcodedTexts.js'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import GenericMenuHandlers from '@/mixins/genericMenuHandlers.js'

	import { QArrayGender } from '@/api/genio/projectArrays.js'

	const requiredTextResources = ['QMenuWMS_4321', 'hardcoded', 'messages']

	export default {
		name: 'QMenuWms4321',

		mixins: [GenericMenuHandlers],

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
			'updateMenuNavigation'
		],

		data()
		{
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuWMS_4321', false),

				interfaceMetadata: {
					id: 'QMenuWMS_4321', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					acronym: 'WMS_4321',
					name: 'Gender',
					route: 'menu-WMS_4321',
					order: '4321'
				},

				model: {
					listArray: new QArrayGender(this.$getResource).elements
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

		created()
		{
			this.componentOnLoadProc.addBusy(loadResources(this, requiredTextResources), this.Resources[hardcodedTexts.genericLoad], 300)
		},

		methods: {
			followUp(itemKey)
			{
				this.setEntryValue({ navigationId: this.navigationId, key: 'perso.gender', value: itemKey })
				this.navigateToRouteName('menu-WMS_43211', { perso_gender: itemKey })
			}
		}
	}
</script>
