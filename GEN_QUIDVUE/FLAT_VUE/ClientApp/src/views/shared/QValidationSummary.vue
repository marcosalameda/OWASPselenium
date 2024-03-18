<template>
	<div
		v-show="errorList.length > 0"
		class="validation-summary-errors i-text__error">
		<ul>
			<li
				v-for="error in errorList"
				:key="error.id"
				@click.stop.prevent="errorClicked(error.id)">
				<div class="q-validation-error">
					<q-icon icon="error" />
					{{ error.text }}
				</div>
			</li>
		</ul>
	</div>
</template>

<script>
	import { scrollToTop } from '@/mixins/genericFunctions.js'

	export default {
		name: 'QValidationSummary',

		emits: ['error-clicked'],

		props: {
			/**
			 * Data containing error information to be displayed in the validation summary.
			 */
			errorData: {
				type: Object,
				required: true
			}
		},

		expose: [],

		computed: {
			/**
			 * Computes a list of errors based on the provided errorData prop.
			 */
			errorList()
			{
				var list = []

				for (let i in this.errorData)
				{
					if (Array.isArray(this.errorData[i]))
						this.errorData[i].forEach((e) => list.push({ id: i, text: e }))
					else
						list.push({ id: i, text: this.errorData[i] })
				}

				return list
			}
		},

		methods: {
			/**
			 * Emits an error-clicked event when an error is clicked, passing the error's id to the listener.
			 * @param {String} id - The id of the error that was clicked.
			 */
			errorClicked(id)
			{
				this.$emit('error-clicked', id)
			}
		},

		watch: {
			errorList(newVal)
			{
				if (newVal.length > 0)
					scrollToTop()
			}
		}
	}
</script>
