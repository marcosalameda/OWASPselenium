<template>
  <div :class="{'i-text--required': isRequired, 'i-text': !isRequired}">
    <div v-if="label">
      <label class="i-text__label" :for="id">{{ label }}</label>
      <q-icon
        v-if="helpText"
        :title="helpText"
        icon="information-outline" />
    </div>
    <input type="text" :class="style_class" :id="id" v-model="curValue" :readonly="isReadOnly" :placeholder="placeholder">
  </div>
</template>

<script>
  export default {
    name: 'text-input',
    emits: ['update:modelValue'],
    props: {
      modelValue: String,
      label: String,
      size: String,
      isReadOnly: {
          type: Boolean,
          default: false
      },
      isRequired: {
          type: Boolean,
          default: false
      },
      placeholder: {
        type: String,
        default: null
      },
      helpText: {
        type: String,
        default: null        
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
      },
      style_class: function () {
        return 'i-text__field i-text input-' + (this.size || 'xxlarge');
      }
    },
    mounted: function () {
      var vm = this;
      vm.id = 'input_t_' + vm._.uid;
    },
  };
</script>
