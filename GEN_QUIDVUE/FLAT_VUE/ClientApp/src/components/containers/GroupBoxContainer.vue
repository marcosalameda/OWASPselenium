<template>
	<div
		:id="controlId"
		v-show="isVisible"
		:class="['c-groupbox', { 'c-groupbox--no-border': noBorder }, $attrs.class]">
		<div
			v-if="label"
			class="c-groupbox__title"
			:help-id="id"
			:label-id="id">
			{{ label }}
		</div>

		<div
			:id="`${controlId}-content`"
			class="form-flow">
			<slot></slot>
		</div>
	</div>
</template>

<script>
	export default {
		name: 'QGroupBoxContainer',

		inheritAttrs: false,

		props: {
			/**
			 * Unique identifier for the control.
			 */
			id: {
				type: String,
				default: null
			},

			/**
			 * The group label.
			 */
			label: {
				type: String,
				default: null
			},

			/**
			 * Visible property to hide and show group.
			 */
			isVisible: {
				type: Boolean,
				default: true
			},

			/**
			 * Whether or not the group should have a border.
			 */
			noBorder: {
				type: Boolean,
				default: false
			}
		},

		expose: [],

		data()
		{
			return {
				controlId: this.id || `groupbox-${this._.uid}`
			}
		}
	}
</script>
