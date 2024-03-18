<template>
	<h1>Input Group</h1>

	<br />

	<h5>Single input</h5>
	<base-input-structure>
		<q-input-group prepend-icon="user">
			<q-text-input placeholder="John Doe" size="medium"/>
		</q-input-group>
	</base-input-structure>
	
	<br />

	<base-input-structure>
		<q-input-group prepend-icon="envelope">
			<q-text-input placeholder="john.doe" size="large"/>
			<template #append>
				<span>@mail.com</span>
			</template>
		</q-input-group>
	</base-input-structure>
	
	<br />

	<h5>Multiple inputs</h5>
	<base-input-structure>
		<q-input-group>
			<template #prepend>
				<span>First and last name</span>
			</template>
			<q-text-input placeholder="John" size="medium"/>
			<q-text-input placeholder="Doe" size="medium"/>
		</q-input-group>
	</base-input-structure>

	<br />

	<h5>Button addon</h5>
	<base-input-structure>
	<q-input-group>
		<q-text-input v-model="description" placeholder="Description" size="xlarge"/>
		<template #append>
			<q-button title="Clear value" b-style="secondary" @click="clearDescription">
				<q-icon icon="bin" />
			</q-button>
		</template>
	</q-input-group>
	</base-input-structure>
</template>

<script>
	export default {
		docsfile: './docs/inputs/QInputGroup.md',

		inheritAttrs: false,

		data()
		{
			return {
				description: ''
			}
		},

		methods: {
			clearDescription()
			{
				this.description = ''
			}
		}
	}
</script>
