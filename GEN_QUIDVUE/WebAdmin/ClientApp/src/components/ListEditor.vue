<template>
	<div :class="[`input-${size}`, 'i-list-editor']" :id="ctrlId">
		<div class="d-flex" v-if="label">
			<label class="i-text__label i-text i-list-editor__label" :for="ctrlId">{{ label }}</label>
			<span v-if="helpText" class="field-help glyphicons glyphicons-info-sign" :title="helpText"></span>
		</div>
		<div class="i-list-editor__content">
			<ul class="i-list-editor__list">
				<li v-for="(_, index) in localItems" :key="index" class="i-list-editor__item">
					<input 
						type="text"
						:class="['i-text__field', 'i-text', 'i-list-editor__item-field']"
						v-model="localItems[index]"
						@input="updateItem(index, $event.target.value)"
						:aria-label="`${defaultEditText} ${index + 1}`"
						:readonly="isReadOnly"
					/>
					<button 
						v-if="!isReadOnly"
						@click="removeItem(index)" 
						class="q-btn q-btn--secondary q-btn--borderless i-list-editor__item-remove"
						:aria-label="`${defaultRemoveText} ${index + 1}`">
						<slot 
							name="remove-icon"
							:text="defaultRemoveText">
							<span 
								role="img" 
								class="q-btn__content"
								:aria-label="`${defaultRemoveText} ${index + 1}`">
								<i class="q-icon q-icon__font glyphicons glyphicons-bin"></i>
							</span>
						</slot>
					</button>
				</li>
			</ul>
			<button 
				v-if="!isReadOnly"
				@click="addItem" 
				class="q-btn q-btn--primary i-list-editor__add-button"
				:aria-label="defaultAddText">
				<slot 
					name="add-icon"
					:text="defaultAddText">
					<span 
						role="img" 
						class="q-btn__content"
						:aria-label="`${defaultRemoveText} ${index + 1}`">
						<i class="q-icon q-icon__font glyphicons glyphicons-plus"></i>
						{{ defaultAddText }}
					</span>
				</slot>
			</button>
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
