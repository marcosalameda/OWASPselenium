<template>
	<div class="container-fluid" style="flex: 1 1 auto">
		<form class="form-horizontal">
			<fieldset>
				<div class="form-flow">
					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_1"
								label="Small Input"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text', { 'i-text--disabled': false }]">
								<q-text-input
									id="CTRL_1"
									v-model="smallInput"
									:max-characters="15" size="small" />
							</base-input-structure>
						</q-control-wrapper>

						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_2"
								label="Medium Input"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text', { 'i-text--disabled': false }]">
								<q-text-input
									id="CTRL_2"
									size="medium"
									v-model="mediumInput"
									:max-characters="15" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>

					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_1b"
								label="Small Input (ReadOnly)"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text', { 'i-text--disabled': true }]"
								:is-blocked="true">
								<q-text-input
									id="CTRL_1b"
									size="small"
									v-model="smallInput"
									:max-characters="15"
									:is-blocked="true" />
							</base-input-structure>
						</q-control-wrapper>

						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_2b"
								label="Medium Input  (ReadOnly)"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text', { 'i-text--disabled': true }]"
								:is-blocked="true">
								<q-text-input
									id="CTRL_2b"
									size="medium"
									v-model="mediumInput"
									:max-characters="15"
									:is-blocked="true" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>

					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_1c"
								label="Small Input (Required)"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text', { 'i-text--required': true }]"
								:is-required="true">
								<q-text-input
									id="CTRL_1c"
									size="small"
									v-model="smallInput"
									:max-characters="15"
									:is-required="true" />
							</base-input-structure>
						</q-control-wrapper>

						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_2c"
								label="Medium Input (Required + ReadOnly)"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text', { 'i-text--disabled': true, 'i-text--required': true }]"
								:is-required="true"
								:is-blocked="true">
								<q-text-input
									id="CTRL_2c"
									size="medium"
									v-model="mediumInput"
									:max-characters="15"
									:is-required="true"
									:is-blocked="true" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>

					<q-row-container>
						<q-control-wrapper class="control-join-group">
							 <base-input-structure
							 	id="CTRL_3"
								label="Large Input"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_3"
									size="large"
									v-model="largeInput" />
							</base-input-structure>

							<base-input-structure
								id="CTRL_4"
								label="XLarge Input"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_4"
									size="xlarge"
									v-model="largeInput" />
							</base-input-structure>
						</q-control-wrapper>

						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_5"
								label="XXLarge Input"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_5"
									size="xxlarge"
									v-model="completeRowInput" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>

					<q-row-container>
						<q-control-wrapper class="row-line-group">
							<base-input-structure
								id="CTRL_6"
								label="Whole line Input"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_6"
									v-model="completeRowInput" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>

					<q-row-container>
						<q-control-wrapper class="control-join-group">
							<base-input-structure
								id="CTRL_7"
								label="xxlarge input -> TopLeft"
								label-position="topleft"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_7"
									size="xxlarge"
									v-model="largeInput" />
							</base-input-structure>

							<base-input-structure
								id="CTRL_8"
								label="xxlarge input -> Center"
								label-position="center"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_8"
									size="xxlarge"
									v-model="largeInput" />
							</base-input-structure>

							<base-input-structure
								id="CTRL_9"
								label="xxlarge input -> TopRight"
								label-position="topright"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_9"
									size="xxlarge"
									v-model="largeInput" />
							</base-input-structure>

							<base-input-structure
								id="CTRL_10"
								label="xxlarge input -> Left"
								label-position="left"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_10"
									size="xxlarge"
									v-model="largeInput" />
							</base-input-structure>

							<base-input-structure
								id="CTRL_11"
								label="xxlarge input -> Right"
								label-position="right"
								:label-attrs="{ class: 'i-text__label' }"
								:class="['i-text']">
								<q-text-input
									id="CTRL_11"
									size="xxlarge"
									v-model="largeInput" />
							</base-input-structure>
						</q-control-wrapper>
					</q-row-container>
				</div>
			</fieldset>
		</form>
	</div>
</template>

<script>
	import fakeData from './TextInput.mock'

	export default {
		docsfile: "./docs/inputs/TextInput.md",

		inheritAttrs: false,

		data()
		{
			return fakeData.simpleUsage()
		}
	}
</script>