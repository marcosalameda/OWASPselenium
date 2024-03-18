<template>
  <button type="button" :class="style_class" :id="id" @click="emitClick">
    <i v-if="icon" :class="'glyphicons glyphicons-' + icon + ' e-icon'"></i>{{ label }}
  </button>
</template>

<script>
  export default {
    name: 'qbutton',
    emits: ['click'],
    props: {
      label: String,
      bstyle: String,
      icon: String,
      isReadOnly: {
        type: Boolean,
        default: false
      }
    },
    data: function () {
      return {
        id: null
      }
    },
    computed: {
      style_class: function () {
        var vm = this;
        var _btnState = vm.bstyle || 'primary';
        if(vm.isReadOnly) { _btnState = 'disabled'; }
        return $.isEmptyObject(vm.label) && !$.isEmptyObject(vm.icon) ?
          `b-icon b-icon--${_btnState}` :
          `b-icon-text b-icon-text--${_btnState}`;
      }
    },
    mounted: function () {
      var vm = this;//, comp = $(vm.$el);
      vm.id = 'button_' + vm._.uid;
    },
    methods: {
      emitClick: function (event) { if(!this.isReadOnly) { this.$emit("click", event); } }
    }
  };
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

</style>
