<template>
  <div :class="{'i-textarea--required': isRequired, 'i-textarea': !isRequired, 'i-textarea--disabled': isReadOnly }">
    <div class="d-flex" v-if="label"><label class="i-textarea__label i-textarea" :for="id">{{ label }}</label></div>
    <textarea class="i-textarea__field i-textarea" :id="id" v-model="curValue" :readonly="isReadOnly" :disabled="isReadOnly" :rows="rows" :cols="cols"></textarea>
  </div>
</template>

<script>
    export default {
        name: 'textarea-input',
        emits: ['update:modelValue'],
        props: {
            modelValue: String,
            label: String,
            //size: String,
            isReadOnly: {
                type: Boolean,
                default: false
            },
            isRequired: {
                type: Boolean,
                default: false
            },
            rows: {
                type: Number,
                default: 2
            },
            cols: {
                type: Number,
                default: 20
            }
        },
        data: function () {
            return {
                id: null
            }
        },
        computed: {
            curValue: {
                get: function () { return this.modelValue; },
                set: function (newValue) { this.$emit('update:modelValue', newValue); }
            }
        },
        mounted: function () {
            var vm = this;
            vm.id = 'input_ta_' + vm._.uid;
        },
    };
</script>
