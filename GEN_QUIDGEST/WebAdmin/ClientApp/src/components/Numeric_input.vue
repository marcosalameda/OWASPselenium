<template>  
    <div class="i-text">
        <div class="d-flex" v-if="label">
            <label class="i-text__label" :for="id">{{ label }}</label>
        </div>
        <input
          type="number"
          :class="style_class"
          :id="id"
          v-model="curValue"
          :readonly="isReadOnly">
    </div>
</template>

<script>
  export default {
    name: 'numeric-input',
    emits: ['update:modelValue'],
    props: {
      modelValue: [Number, String],
      label: String,
      size: String,
      isReadOnly: Boolean,
      integerOnly: {
        type: Boolean,
        default: false
      }
    },
    data() {
      return {
        id: null
      }
    },
    computed: {
      curValue: {
        get() { return this.modelValue; },
        set(newValue) {
          let valueToEmit = newValue;
          if (this.integerOnly && newValue !== '' && !isNaN(newValue)) {
            valueToEmit = parseInt(newValue);
          }
          this.$emit('update:modelValue', valueToEmit);
        }
      },
      style_class() {
          return 'i-text__field i-text input-' + (this.size || 'xxlarge');
      }
    },
    mounted() {
      this.id = "input_n_" + this._.uid;
    },
  };
</script>
