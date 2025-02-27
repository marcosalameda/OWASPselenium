<template>
    <div class="i-date-picker">
      <div class="d-flex" v-if="label">
        <label class="i-text__label i-text" :for="id">{{ label }}</label>
      </div>
      <div class="i-input-group date">
		<Datepicker :id="id" :modelValue="modelValue" @update:modelValue="updateValue" :readonly="isReadOnly" data-ref="cur_elem"></Datepicker>
      </div>
    </div>
</template>

<script>
    import moment from 'moment';
    // https://www.npmjs.com/package/vue-bootstrap-datetimepicker
    // http://eonasdan.github.io/bootstrap-datetimepicker/Options/

	import Datepicker from '@vuepic/vue-datepicker';
	import '@vuepic/vue-datepicker/dist/main.css';

    export default {
        name: 'datetime-input',
		components: { Datepicker },
        emits: ['update:modelValue', 'dp-hide', 'dp-show', 'dp-change', 'dp-error', 'dp-update'],
        props: {
            modelValue: {
                default: null,
                required: true,
                validator(modelValue) {
                    return modelValue === null || modelValue instanceof Date || typeof modelValue === 'string' || modelValue instanceof String || modelValue instanceof moment
                }
            },
            label: String,
            isReadOnly: Boolean
        },
        data: function () {
            return {
                id: null,
                dp: null,
                // jQuery DOM
                elem: null,
                // http://eonasdan.github.io/bootstrap-datetimepicker/Options/
                config: {
                    showClear: true
                },
                events: ['hide', 'show', 'change', 'error', 'update']
            }
        },
        mounted: function () {
            var vm = this;//, comp = $(vm.$el);
            vm.id = 'input_t_' + vm._.uid;
        },
        watch: {
            /**
             * Listen to change from outside of component and update DOM
             *
             * @param newValue
             */
            modelValue(newValue) {
                this.dp && this.dp.date(newValue || null)
            },

            /**
             * Watch for any change in options and set them
             *
             * @param newConfig Object
             */
            config: {
                deep: true,
                handler(newConfig) {
                    this.dp && this.dp.options(newConfig);
                }
            }
        },
        methods: {
            /**
             * Update v-model upon change triggered by date-picker itself
             *
             * @param event
             */
            onChange(event) {
                let formattedDate = event.date ? event.date.format(this.dp.format()) : null;
                this.$emit('update:modelValue', formattedDate);
            },

            updateValue(newValue) {
                this.$emit('update:modelValue', newValue);
            },

            pluginClick() {
                if (!this.isReadOnly && this.dp) {
                    this.dp.toggle();
                }
            }
        },
        /**
         * Free up memory
         */
        beforeUnmount() {
            /* istanbul ignore else */
            if (this.dp) {
                this.dp.destroy();
                this.dp = null;
                this.elem = null;
            }
        }
    };
</script>


