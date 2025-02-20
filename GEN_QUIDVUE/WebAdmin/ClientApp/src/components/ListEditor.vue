<template>
	<div :class="[`input-${size}`, 'i-list-editor']" :id="ctrlId">
		<div class="d-flex" v-if="label">
			<label class="i-text__label i-text i-list-editor__label" :for="ctrlId">{{ label }}</label>
			<q-icon
				v-if="helpText"
				class="field-help"
				icon="information-outline"
				:title="helpText" />
		</div>
		<div class="i-list-editor__content">
			<ul class="i-list-editor__list">
				<li v-for="(_, index) in localItems" :key="index" class="i-list-editor__item">
					<q-text-field 
						v-model="localItems[index]"
						class="i-list-editor__item-field"
						size="block"
						:label="`${defaultEditText} ${index + 1}`"
						:readonly="isReadOnly"
						@update:model-value="updateItem(index, $event.target.value)"
					/>
					<q-button 
						v-if="!isReadOnly"
						b-style="tertiary"
						class="i-list-editor__item-remove"
						:title="`${defaultRemoveText} ${index + 1}`"
						@click="removeItem(index)">
						<q-icon icon="bin" />
					</q-button>
				</li>
			</ul>
			<q-button 
				v-if="!isReadOnly"
				class="i-list-editor__add-button"
				:label="defaultAddText"
				@click="addItem">
					<q-icon icon="add" />
			</q-button>
		</div>
	</div>
</template>

<script>
import { ref, watch, defineComponent, getCurrentInstance } from 'vue'

export default defineComponent({
	name: 'ListEditor',
	props: {
		id: {
			type: String,
		},
		modelValue: {
			type: Array,
			default: () => []
		},
		size: {
			type: String,
			default: 'xxlarge'
		},
		isReadOnly: {
			type: Boolean,
			default: false
		},
		label: {
			type: String,
			default: null
		},
		helpText: {
			type: String,
			default: null
		},
		addText: {
			type: String,
			default: 'Add item'
		},
		removeText: {
			type: String,
			default: 'Remove item'
		},
		editText: {
			type: String,
			default: 'Edit item'
		}
	},
	setup(props, { emit }) {
		const vm = getCurrentInstance()
		const ctrlId = props.id || 'input_' + vm.uid

		// Local copy of the items for reactive editing
		const localItems = ref(Array.isArray(props.modelValue) ? [...props.modelValue] : [])

		// Watch for changes in props.items to keep LocalItems in sync
		watch(
			() => props.modelValue,
			(newItems) => {
				localItems.value = Array.isArray(newItems) ? [...newItems] : []
			},
			{ immediate: true }
		)

		// Emits the updated list to parent component
		const updateItem = (index, value) => {
			localItems.value[index] = value;
			emit('update:modelValue', localItems.value)
		}

		// Add a new empty item to the list
		const addItem = () => {
			if(props.isReadOnly)
				return;
			localItems.value.push('')
			emit('update:modelValue', localItems.value)
		}

		// Remove an item by index
		const removeItem = (index) => {
			if(props.isReadOnly)
				return;
			localItems.value.splice(index, 1)
			emit('update:modelValue', localItems.value)
		}

		return {
			ctrlId,
			localItems,
			updateItem,
			addItem,
			removeItem,
			defaultAddText: props.addText,
			defaultRemoveText: props.removeText,
			defaultEditText: props.editText
		}
	}
})
</script>
