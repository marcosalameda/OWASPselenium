/**
 * @jest-environment jsdom
 */
import { within } from '@testing-library/dom'
import '@testing-library/jest-dom'
import { fireEvent } from '@testing-library/vue'
import { render } from './utils'
import { flushPromises } from '@vue/test-utils'
import cloneDeep from 'lodash-es/cloneDeep'
import { vi } from 'vitest'
import { nextTick } from 'vue'

import QTable from '@/components/table/QTable.vue'
import fakeData from '../cases/Table.mock.js'

const global = {
	stubs: ['inline-svg']
}

describe('QTable.vue', () => {
	let tableTest
	beforeEach(() => tableTest = fakeData.getTableTest())

	it('Table with row data displays rows', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})

		const rowCount = tableTest.rows.length

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		expect(rows).toHaveLength(rowCount)
	})

	it('Table with no row data displays <empty> row', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: [],
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})

		// When it's empty, there will be a row with a placeholder.
		const rowCount = 1

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		expect(rows).toHaveLength(rowCount)
		const emptyRow = await wrapper.findByText('No data to show')
		expect(emptyRow)
	})

	it('Table in normal mode displays insert button, clicking button emits insert event', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: false
			}
		})

		await nextTick()
		await flushPromises()
		await vi.dynamicImportSettled()

		// Insert button
		const button = await wrapper.findByTitle(tableTest.config.generalActions[0].title)
		expect(button)

		// Click insert button and check emit
		await fireEvent.click(button)

		expect(wrapper.emitted()).toHaveProperty('row-action')
		expect(wrapper.emitted()['row-action'][0][0]['name']).toBe(tableTest.config.generalActions[0].name)
		expect(wrapper.emitted()['row-action'][0][0]['params']['formName']).toBe(tableTest.config.generalActions[0].params.formName)
		expect(wrapper.emitted()['row-action'][0][0]['params']['mode']).toBe(tableTest.config.generalActions[0].params.mode)
		expect(wrapper.emitted()['row-action'][0][0]['params']['type']).toBe(tableTest.config.generalActions[0].params.type)
	})

	it('Table in read-only mode does not display insert button', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: true
			}
		})

		await nextTick()

		// No insert button
		const button = await wrapper.queryByTitle(tableTest.config.generalActions[0].title)
		expect(button).toBeNull()
	})

	it('Invalid row is highlighted', async () => {
		const cssClasses = fakeData.cssClasses
		const dataRows = fakeData.rowsInvalid, dataColumns = fakeData.columns01
		const wrapper = render(QTable, {
			global,
			props: {
				rows: dataRows,
				columns: dataColumns,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})
		const rowNum = 0

		const rowCount = dataRows.length

		await nextTick()

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		expect(rows).toHaveLength(rowCount)

		expect(rows[rowNum]).toHaveClass(cssClasses.invalidRow)
	})

	it('Rows where "Currency" column > 100 have style "color: #00A000"', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})

		await nextTick()

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		expect(rows[4]).toHaveStyle("color: #00A000;")
		expect(rows[6]).toHaveStyle("color: #00A000;")
	})

	it('Rows where "Array" column = 5 have style "background-color: #E0E0E0"', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})

		await nextTick()

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		expect(rows[3]).toHaveStyle("background-color: #E0E0E0")
		expect(rows[5]).toHaveStyle("background-color: #E0E0E0")
	})

	it('Cells where "Val" column length > 3 have style "color: #C08000"', async () => {
		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: tableTest.columns.value,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})

		await nextTick()

		// Get index of column with textColor property
		const columnIdx = tableTest.columnsOriginal.value.findIndex(obj => obj.textColor !== undefined)
		var domColumnIdx = columnIdx
		// Account for extra column if table has checklist
		if (tableTest.config.rowsCheckable !== undefined && tableTest.config.rowsCheckable !== false)
			domColumnIdx++

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		var cells = []
		cells = await within(rows[0]).queryAllByRole('cell')
		expect(cells[domColumnIdx + 1]).toHaveStyle('color: #C08000;')
		cells = await within(rows[1]).queryAllByRole('cell')
		expect(cells[domColumnIdx + 1]).toHaveStyle('color: #C08000;')
		cells = await within(rows[2]).queryAllByRole('cell')
		expect(cells[domColumnIdx + 1]).toHaveStyle('color: #C08000;')
		cells = await within(rows[3]).queryAllByRole('cell')
		expect(cells[domColumnIdx + 1]).toHaveStyle('color: #C08000;')
		cells = await within(rows[4]).queryAllByRole('cell')
		expect(cells[domColumnIdx + 1]).toHaveStyle('color: #C08000;')
		cells = await within(rows[5]).queryAllByRole('cell')
		expect(cells[domColumnIdx + 1]).toHaveStyle('color: #C08000;')
	})

	it('Cell with column scroll has truncated text followed by (...)', async () => {
		// Copy columns and add scrollData property
		const columnsScroll = cloneDeep(tableTest.columns.value)
		columnsScroll[2].scrollData = 5

		const wrapper = render(QTable, {
			global,
			props: {
				rows: tableTest.rows,
				columns: columnsScroll,
				config: tableTest.config,
				totalRows: tableTest.totalRows,
				groupFilters: tableTest.groupFilters,
				activeFilters: tableTest.activeFilters,
				headerLevel: 1,
				readonly: tableTest.readonly
			}
		})
		const rowIdx = 2

		await nextTick()

		// Get index of column with scroll
		const columnIdx = columnsScroll.findIndex(obj => obj.scrollData !== undefined)
		var domColumnIdx = columnIdx
		// Account for extra column if table has checklist
		if (tableTest.config.rowsCheckable !== undefined && tableTest.config.rowsCheckable !== false)
			domColumnIdx++

		await flushPromises()
		await vi.dynamicImportSettled()

		// Get rows
		const rows = await wrapper.getAllByTestId('table-row')

		var cells = []
		cells = await within(rows[rowIdx]).queryAllByRole("cell")
		expect(cells[domColumnIdx + 1]).toHaveTextContent("thing (...)")
	})
})
