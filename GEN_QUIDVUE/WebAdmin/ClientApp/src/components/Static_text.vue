<template>
  <div class="i-text i-static-text">
    <div v-if="label">
      <label class="i-text__label" :for="id">
        <span :class="{ 'i-text__label--bold': boldLabel }">
          {{ label + ":" }}
        </span>
      </label>
    </div>
    <span
      :class="{ 'i-text__label--bold': bold }"
      :id="id">
      {{ modelValue }}
    </span>
  </div>
</template>

<script>
  export default {
    name: 'static-text',
    props: {
      modelValue: [String, Number, Object],

      label: String,

      bold: {
        type: Boolean,
        default: false
      },

      boldLabel: {
        type: Boolean,
        default: false
      }
    },

    data() {
      return {
        id: null
      }
    },

    mounted() {
      var vm = this
      vm.id = 'static_text_' + vm._.uid
    }
  }
</script>