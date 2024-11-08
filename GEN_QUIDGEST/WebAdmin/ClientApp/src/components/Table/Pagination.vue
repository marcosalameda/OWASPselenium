<template>
    <div>
        <nav id="pagination">
            <q-button-group>
                <!-- BEGIN: Page navigation buttons -->
                <!-- BEGIN: First page button -->
                <q-button aria-label="First"
                    b-style="secondary"
                    :disabled="!prevButtonEnabled"
                    @click="pageHandler(1)">
                    <span class="mdi mdi-chevron-double-left"></span>
                </q-button>
                <!-- END: First page button -->
                <!-- BEGIN: Previous page button -->
                <q-button aria-label="Previous"
                    b-style="secondary"
                    :disabled="!prevButtonEnabled"
                    @click="pageHandler(page - 1)">
                    <span class="mdi mdi-chevron-left"></span>
                </q-button>
                <!-- END: Previous page button -->
                <!-- BEGIN: Visible page number buttons -->
                <template v-if="totalPages">
                    <q-button v-for="index in range"
                        b-style="secondary"
                        :key="index"
                        :label="index"
                        :active="index === page"
                        :disabled="disabled"
                        :class="pageButtonClass(index, page)"
                        @click="pageHandler(index)">
                    </q-button>
                </template>
                <!-- END: Visible page number buttons -->
                <!-- BEGIN: Next page button -->
                <q-button aria-label="Next"
                    b-style="secondary"
                    :disabled="!nextButtonEnabled"
                    @click="pageHandler(page + 1)">
                    <span class="mdi mdi-chevron-right"></span>
                </q-button>
                <!-- END: Next page button -->
                <!-- BEGIN: Last page button -->
                <q-button aria-label="Last"
                    b-style="secondary"
                    :disabled="!nextButtonEnabled"
                    @click="pageHandler(totalPages)">
                    <span class="mdi mdi-chevron-double-right"></span>
                </q-button>
                <!-- END: Last page button -->
                <!-- END: Page navigation buttons -->
            </q-button-group>
        </nav>
    </div>
</template>

<script>
import {
range,
includes,
} from "lodash-es";

    export default {
        name: 'Pagination',
        emits: ['update:page', 'update:per_page'],
        props: {
            page: {
                type: [String, Number],
                required: true
            },
            per_page: {
                type: [String, Number],
                required: true
            },
            total: {
                type: [String, Number],
                required: true
            },
            num_of_visibile_pagination_buttons: {
                type: [String, Number],
                default: 7
            },
            /**
			 * Whether the pagination is disabled.
			 */
			disabled: {
				type: Boolean,
				default: false
			},
        },
        data() {
            return {
                start: (this.page + 0),
                end: 0
            }
        },
        mounted() {
            this.calculatePageRange(true);
        },
        methods: {
            pageHandler(index) {
                if (index >= 1 && index <= this.totalPages) {
                    this.$emit('update:page', index);
                }
            },
            perPageHandler(option) {
                this.$emit('update:per_page', option);
            },
            calculatePageRange(force = false) {
                //Skip calculating if all pages can be shown
                if (this.totalPages <= this.num_of_visibile_pagination_buttons) {
                    this.start = 1;
                    this.end = this.totalPages;
                    return;
                }

                //Skip recalculating if the previous and next pages are already visible
                if (!force &&
                    (includes(this.range, this.page - 1) || this.page == 1) &&
                    (includes(this.range, this.page + 1) || this.page == this.totalPages)
                ) { return; }

                //Current page is the start page minus one
                this.start = (this.page == 1) ? 1 : this.page - 1;

                //Reserved entries: firstpage, ellipsis (2x), prev. page, last page, current page
                this.end = this.start + this.num_of_visibile_pagination_buttons - 5;

                //If the user navigates on page one or two, we set start to one (ellipsis pointless)
                //and can potentially shift up end
                if (this.start <= 3) {
                    this.end += 3 - this.start;
                    this.start = 1;
                }

                //If the user navigates on the last two pages or out of bounds, we can shift down start
                //This will also handle end overflow, substract 2 for ellipsis and last page
                if (this.end >= this.totalPages - 2) {
                    this.start -= this.end - (this.totalPages - 2);
                    this.end = this.totalPages;
                }

                //Handle start underflow
                this.start = Math.max(this.start, 1);
            },
            isPositiveInteger(str) {
                return /^\+?(0|[1-9]\d*)$/.test(str);
            },
            /**
             * Get the class for the paging button
             * @param index {Number} Index of the button
             * @param page {Number} Active page number
             * @returns String
             */
            pageButtonClass(index, page) {
                // Difference between the index and active page number
                const diff = Math.abs(index - page)

                // Index is the active page
                if (diff === 0)
                    return null
                // Index is next to the active page
                else if (diff === 1)
                    return 'btn-page-adjacent'
                // Index is farther from the active page
                return 'btn-page-other'
            }
        },
        computed: {
            totalPages() {
                return Math.ceil(this.total / this.per_page);
            },
            disablePreviousButton() {
                return this.page == this.start;
            },
            disableNextButton() {
                return this.page == this.end;
            },
            range() {
                return range(this.start, this.end + 1);
            },
            isEmpty() {
                return this.total == 0;
            },
            prevButtonEnabled() {
                return this.totalPages > 1 && this.page !== 1 && !this.disabled
            },
            nextButtonEnabled() {
                return this.totalPages > 1 && this.page < this.totalPages && !this.disabled
            }
        },
        watch: {
            page(newVal, oldVal) {
                this.calculatePageRange();
            },
            rowCount(newVal, oldVal) {
                this.calculatePageRange();
            },
            totalPages(newVal, oldVal) {
                this.calculatePageRange();
            },
        }
    }
</script>

<style scoped>
    ul.pagination {
        margin-bottom: 0;
    }
    .vbt-per-page-dropdown {
        margin-left: 8px;
    }
</style>
