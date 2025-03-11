<template>
    <tr :data-id="rowId" ref="vbt_row" :class='rowClasses' @click="handleRowSelect">
        <td v-if="checkboxRows" class="checkbox-column">
            <q-checkbox
                v-model="rowSelected"
                class="q-checkbox--table"
                @update:model-value="emitSelectValue" />
        </td>
        <template v-for="(column, key) in columns">
            <td v-if="canShowColumn(column)" :key="key" :class="cellClasses(column)">
                <slot :name="'vbt-'+getCellSlotName(column)">
                </slot>
            </td>
        </template>
    </tr>
</template>

<script>
    import {
        has,
        get,
        differenceWith,
        isEqual,
        includes,
    } from "lodash-es"

    import { isDefined } from "@/utils/common"

    export default {
        name: 'Row',

        emits: ['add-row', 'remove-row', 'single-row-select'],

        props: {
            row: {
                type: Object,
                required:true
            },
            propRowClasses: {
                type: [Object, String],
                required:false
            },
            propCellClasses: {
                type: [Object, String],
                required:false
            },
            columns: {
                type: Array,
                default: function() {
                    return [];
                }
            },
            uniqueId: {
                type: [Number, String]
            },
            selectedItems: {
                type: Array,
                default: function() {
                    return [];
                }
            },
            checkboxRows: {
                type: Boolean,
                default: false
            },
            highlightRowHover: {
                type: Boolean,
                default: false
            },
            highlightRowHoverColor: {
                type: String,
                default: "#d6d6d6"
            },
            rowIndex: {
                type: Number,
                required: true
            },
            singleRowSelectable: {
                type: Boolean,
                default: false
            }
        },
        data() {
            return {
                rowSelected: false,
                rowHiglighted:false
            }
        },
        mounted() {
            if (this.highlightRowHover) {
                this.$refs.vbt_row.addEventListener('mouseover', () => { this.rowHiglighted = true })
                this.$refs.vbt_row.addEventListener('mouseleave', () => { this.rowHiglighted = false })
            }
            this.checkInSelecteditems(this.selectedItems,this.row)
        },
        methods: {
            emitSelectValue(newVal) {
                if (newVal)
                    this.addRow(false)
                else
                    this.removeRow(false)
            },

            addRow(shiftKey) {
                this.$emit('add-row', {'shiftKey':shiftKey,"rowIndex":this.rowIndex});
            },

            removeRow(shiftKey) {
                this.$emit('remove-row', {'shiftKey':shiftKey,"rowIndex":this.rowIndex});
            },

            handleRowSelect() {
                if (this.singleRowSelectable)
                    this.$emit('single-row-select', { 'rowIndex' : this.rowIndex })
            },

            // compare the selected items list with current row item and update checkbox accordingly
            checkInSelecteditems(selectedItems, row) {
                if (!this.checkboxRows)
                    return

                if (isDefined(this.uniqueId)) {
                    this.rowSelected = selectedItems.some(item => item[this.uniqueId] === row[this.uniqueId])
                    return
                }

                let difference = differenceWith(selectedItems, [row], isEqual)
                const isSelected = difference.length != selectedItems.length
                this.rowSelected = isSelected
            },

            rowHover(state) {
                this.rowHiglighted = state;
            },

            getValueFromRow(row, name) {
                return get(row, name)
            },

            cellClasses(column) {
                let classes = "";

                let default_text_alignment = "text-left";

                //decide text alignment class - starts here
                let alignments = ["text-justify","text-right","text-left","text-center"];
                if (has(column, "row_text_alignment") && includes(alignments, column.row_text_alignment)) {
                    classes = classes + " " + column.row_text_alignment;
                } else {
                    classes = classes + " " + default_text_alignment;
                }
                //decide text alignment class - ends here

                // adding user defined classes from column config to rows - starts here
                if (has(column, "row_classes")) {
                    classes = classes + " " + column.row_classes;
                }
                // adding user defined classes from column config to rows - ends here


                if (typeof this.propCellClasses == "string") {
                    return this.propCellClasses
                } 
                else if (typeof this.propCellClasses == "object") {
                    Object.entries(this.propCellClasses).forEach(([key, value]) => {
                        if (typeof value == "boolean" && value) {
                            classes += (" " + key)
                        } 
                        else if (typeof value == "function") {
                            let truth = value(this.row, column, this.getValueFromRow(this.row, column.name))
                            if (typeof truth == "boolean" && truth) {
                                classes += " "
                                classes += key
                            }
                        }
                    })
                }

                return classes
            },

            getCellSlotName(column) {
                if (has(column,"slot_name")) {
                    return column.slot_name
                }

                return column.name.replace(/\./g,'_');
            },

            canShowColumn(column) {
                return (column.visibility == undefined || column.visibility) ? true : false
            }
        },
        computed: {
            rowClasses() {
                let classes = this.userRowClasses

                if (this.rowSelected) {
                    classes += " "
                    classes += "vbt-row-selected"
                }

                if (this.singleRowSelectable) {
                    classes += " clickable"
                }

                classes += this.rowHiglighted ? " highlighted" : ""

                return classes
            },
            userRowClasses() {
                let classes = ""
                if (typeof this.propRowClasses == "string") {
                    return this.propRowClasses
                } 
                else if (typeof this.propRowClasses == "object") {
                    Object.entries(this.propRowClasses).forEach(([key, value]) => {
                        if (typeof value == "boolean" && value) {
                            classes += key
                        } 
                        else if (typeof value == "function") {
                            let truth = value(this.row)
                            if (typeof truth == "boolean" && truth) {
                                classes += " "
                                classes += key
                            }
                        }
                    })
                }

                return classes
            },
            rowId() {
                if (!isDefined(this.uniqueId))
                    return 'vbt_id'

                return this.getValueFromRow(this.row, this.uniqueId)
            }
        },
        watch: {
            row: {
                handler(newVal) {
                    this.checkInSelecteditems(this.selectedItems, newVal)
                },
                deep: true
            }
        }
    }
</script>
