<template>
    <div class="col-auto search" style="display: block;" v-if="visibility">
        <div class="form-group has-clear-right" :class="classes">
            <span v-if="showClearButton" class="form-control-feedback vbt-global-search-clear" @click="clearGlobalSearch">
                <slot name="global-search-clear-icon">
                    &#x24E7;
                </slot>
            </span>
            <q-text-field
                class="search-input"
                v-model="searchValue"
                ref="globalSearch"
                size="xlarge"
                :placeholder="placeholder" 
                @keyup.enter="emitSearch">
                <template #append>
                    <q-button
                        b-style="tertiary"
                        @click="emitSearch">
                        <q-icon icon="magnify" />
                    </q-button>
                    <q-button
                        b-style="tertiary"
                        @click="resetQuery">
                        <q-icon icon="close" />
                    </q-button>
                </template>
            </q-text-field>
        </div>
    </div>
</template>

<script>
    export default {
        name: "Search",
        props: {
            initPlaceholder: {
                type: String,
                default: ""
            },
            initClasses: {
                type: String,
                default: ""
            },
            initVisibility: {
                type: Boolean,
                default: true
            },
            initCaseSensitive: {
                type: Boolean,
                default: false
            },
            initShowRefreshButton: {
                type: Boolean,
                default: true
            },
            initShowResetButton: {
                type: Boolean,
                default: true
            },
            initShowClearButton: {
                type: Boolean,
                default: false
            },
            initSearchOnPressEnter: {
                type: Boolean,
                default: false
            },
            initSearchDebounceRate: {
                type: Number,
                default: 60
            }
        },
        data() {
            return {
                searchValue: "",
                placeholder: this.initPlaceholder,
                classes: this.initClasses,
                visibility: this.initVisibility,
                caseSensitive: this.initCaseSensitive,
                showRefreshButton: this.initShowRefreshButton,
                showResetButton: this.initShowResetButton,
                showClearButton: this.initShowClearButton,
                searchOnPressEnter: this.initSearchOnPressEnter,
                searchDebounceRate: this.initSearchDebounceRate
            }
        },
        methods: {
            emitSearch() {
                this.$emit('emitSearch', this.searchValue);
            },
            clearGlobalSearch() {
                this.searchValue = "";
                this.$emit('clearGlobalSearch');
            },

            resetQuery() {
                this.searchValue = "";
                this.$emit('resetQuery');
            }

        },
        emits: ['clearGlobalSearch', 'updateGlobalSearchHandler', 'updateGlobalSearch', 'emitSearch', 'resetQuery']
    };
</script>
