<template>
	<div class="container-fluid" style="flex: 1 1 auto">
		<form class="form-horizontal">
			<fieldset>
				<!-- Server dropdown -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<h5>Server request Dropdown</h5>
							<base-input-structure
								:id="id"
								label="Registration no."
								:class="['i-dbedit']"
								:control-type="'enumeration'"
								:is-required="isRequired"
								:is-blocked="isBlocked"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									id="CTRL_1"
									size="xlarge"
									v-model="storeDropdown.selectedKey"
									:options="storeDropdown.options"
									@on-search="fetchStoreData"
									:loaded="storeDropdown.onLoadProc.loaded" />
							</base-input-structure>
						</q-control-wrapper>
						<span>Selected store key: {{ storeDropdown.selectedKey }}</span>
						<span> | Is loaded: {{ storeDropdown.onLoadProc.loaded }}</span>
					</q-row-container>
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_2"
								label="Store item"
								:class="['i-dbedit']"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									id="CTRL_2"
									size="xlarge"
									v-model="storeItemDropdown.selectedKey"
									:options="storeItemDropdown.options"
									:loaded="storeItemDropdown.onLoadProc.loaded"
									@on-search="fetchStoreItemData" />
							</base-input-structure>
						</q-control-wrapper>
						<span>
							Selected store item key:
							{{ storeItemDropdown.selectedKey }}
						</span>
						<span> | Is loaded: {{ storeItemDropdown.onLoadProc.loaded }}</span>
					</q-row-container>
				</div>

				<!-- External Keys -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<h5>Server request Dropdown</h5>
							<base-input-structure
								id="CTRL_1"
								label="Store"
								:class="['i-dbedit']"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									id="CTRL_1"
									size="xlarge"
									v-model="storeDropdown3.selectedKey"
									:options="storeDropdown3.options"
									@on-search="fetchStoreData2" />
							</base-input-structure>
						</q-control-wrapper>
						<span>Selected store key: {{ storeDropdown3.selectedKey }}</span>
					</q-row-container>
					<br />
					<q-row-container>
						<ul v-for="storeKey in auxStoreKeys" :key="storeKey">
							<li>
								<button @click.stop.prevent="storeDropdown3.selectedKey = storeKey">
									{{ storeKey }}
								</button>
							</li>
						</ul>
					</q-row-container>
				</div>

				<!-- Basic Dropdown -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<h5>Basic usage</h5>
							<base-input-structure
								:id="id"
								label="Basic Dropdown"
								:class="['i-dbedit']"
								:control-type="'enumeration'"
								:is-required="isRequired"
								:is-blocked="isBlocked"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									:id="'CTRL_1'"
									size="xlarge"
									:is-blocked="false"
									option-value="value"
									:placeholder="'Select your option'"
									v-model="selected"
									:options="simpleOptions"
									option-label="key" />
							</base-input-structure>
						</q-control-wrapper>
						<span>Selected value: {{ selected }}</span>
					</q-row-container>
				</div>

				<!-- Basic Dropdown with search-->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<h5>Dropdown with Search</h5>
							<base-input-structure
								:id="id"
								label="Registration no."
								:class="['i-dbedit']"
								:control-type="'enumeration'"
								:is-required="isRequired"
								:is-blocked="isBlocked"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									:id="'CTRL_2'"
									:search-timeout="3000"
									v-model="selected2"
									:options="valueAsObjOptions"
									option-label="key"
									option-value="value.id"
									@show="shortlistAction"
									@on-search="searchAction" />
							</base-input-structure>
						</q-control-wrapper>
						<span>Selected value: {{ selected2 }}</span>
					</q-row-container>
				</div>

				<!-- Dropdown with normal options see more -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group input-xxlarge">
							<h5>Dropdown without scrollbar</h5>
							<base-input-structure
								:id="id"
								label="Howdant:"
								:class="['i-dbedit']"
								:control-type="'enumeration'"
								:is-required="isRequired"
								:is-blocked="isBlocked"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									:id="'CTRL_3'"
									:search-timeout="1000"
									v-model="selected2"
									:options="simpleOptions2"
									option-label="key"
									option-value="value"
									@show="shortlistAction"
									@on-search="searchAction"
									@see-more="seeMoreAction" />
							</base-input-structure>
						</q-control-wrapper>
						<span>Selected value: {{ selected2 }}</span>
					</q-row-container>
				</div>

				<!-- Dropdown with see more -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group input-xxlarge">
							<h5>Dropdown with See more</h5>
							<base-input-structure
								:id="id"
								label="Comodatário:"
								:class="['i-dbedit']"
								:control-type="'enumeration'"
								:is-required="isRequired"
								:is-blocked="isBlocked"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									:id="'CTRL_4'"
									:search-timeout="1000"
									v-model="selected2"
									:options="valueAsObjOptions"
									option-label="key"
									option-value="value.id"
									@show="shortlistAction"
									@on-search="searchAction"
									@see-more="seeMoreAction" />
							</base-input-structure>
						</q-control-wrapper>
						<span>Selected value: {{ selected2 }}</span>
					</q-row-container>
				</div>

				<!-- Dropdown with Insert -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<h5>Dropdown with Insert (Activated)</h5>
						<base-input-structure
							:id="id"
							label="Comodatário:"
							:class="['i-dbedit']"
							:control-type="'enumeration'"
							:is-required="isRequired"
							:is-blocked="isBlocked"
							:label-attrs="{ class: 'i-text__label' }">
							<q-dropdown-input
								:id="'CTRL_5'"
								:search-timeout="1000"
								:insert-enabled="true"
								v-model="selected2"
								:options="valueAsObjOptions"
								option-label="key"
								option-value="value.id"
								@show="shortlistAction"
								@on-search="searchAction"
								@see-more="seeMoreAction"
								@insert="insertAction" />
						</base-input-structure>
						<span>Selected value: {{ selected2 }}</span>
					</q-row-container>
				</div>

				<!--Disabled Dropdown -->
				<div class="form-flow" style="margin: 44px">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<h5>Disabled Dropdown</h5>
							<base-input-structure
								:id="id"
								label="Comodatário:"
								:class="['i-dbedit']"
								:control-type="'enumeration'"
								:is-required="isRequired"
								:is-blocked="isBlocked"
								:label-attrs="{ class: 'i-text__label' }">
								<q-dropdown-input
									:id="'CTRL_6'"
									:is-blocked="true"
									label="Loan frequency:"
									:insert-enabled="true"
									v-model="selected2"
									:options="valueAsObjOptions"
									option-label="key"
									option-value="value.id"
									@show="shortlistAction"
									@on-search="searchAction"
									@see-more="seeMoreAction"
									@insert="insertAction" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>
				</div>
			</fieldset>
		</form>
	</div>
</template>

<script>

	import fakeData from './DropdownInput.mock'

	export default {
		docsfile: "./docs/inputs/dropdown/DropdownInput.md",

		inheritAttrs: false,

		data() {
			return {
				...fakeData.simpleUsage(),
				...fakeData.serverCase()
			}
		},

		mounted()
		{
			// Initial setup
			this.storeDropdown.options = this.stores
			this.storeDropdown3.options = this.stores3.slice(0, 3) // JUST 3 Record is visible
		},

		methods: {
			...fakeData.simpleUsageMethods,
			...fakeData.serverCaseMethods
		},

		watch: {
			// When selecting a store, update the store item list
			'storeDropdown3.selectedKey'()
			{
				this.fetchStoreData2()
			},

			// When selecting a store, update the store item list
			'storeDropdown.selectedKey'()
			{
				this.storeItemDropdown.selectedKey = ''
				this.fetchStoreItemData()
			}
		}
	}
</script>