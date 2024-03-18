import _startsWith from 'lodash-es/startsWith'
import _filter from 'lodash-es/filter'
import _isEmpty from 'lodash-es/isEmpty'
import _toLower from 'lodash-es/toLower'

import { fetchFakeData } from '@/api/network'
import asyncProcMonitoring from '@/api/global/asyncProcMonitoring'

export default {
	simpleUsage()
	{
		return {
			id: 'test',
			size: '235',
			label: 'Best Web Development Framework',
			isBlocked: false,
			isRequired: true,
			selected: null,
			simpleOptions: [
				{ key: 'Rails', value: 'RA' },
				{ key: 'Django', value: 'DJ' },
				{ key: 'Angular', value: 'AN' },
				{ key: 'Vue.js', value: 'VU' },
				{ key: 'React', value: 'RE' },
			],
			selected2: '',
			simpleOptions2: [
				{ key: 'Rail', value: 'RA' },
				{ key: 'Django', value: 'DJ' },
				{ key: 'Angular', value: 'AN' },
				{ key: 'Vue.js', value: 'VU' },
				{ key: 'React', value: 'RE' },
				{ key: 'Ionic', value: 'IN' },
				{ key: 'Quasar', value: 'Qr' },
			],
			valueAsObjOptions: [
				{ key: 'Rails', value: { id: 'RA', label: 'abc' } },
				{ key: 'Django', value: { id: 'DJ', label: 'xyz' } },
				{ key: 'Angular', value: { id: 'AN', label: 'pqr' } },
				{ key: 'Vue.js', value: { id: 'VU', label: 'qaz' } },
				{ key: 'C', value: { id: 'C', label: 'mko' } },
				{ key: 'C#', value: { id: 'CS', label: 'mko' } },
				{ key: 'Python', value: { id: 'PY', label: 'mko' } },
				{ key: 'Java', value: { id: 'JV', label: 'mko' } },
				{ key: 'Swift', value: { id: 'SW', label: 'mko' } },
				{ key: 'Quasar', value: { id: 'QU', label: 'mko' } },
			],
			groupOptions: [
				{
					Group: 'Valid options',
					Values: [
						{ Value: 'AN', Text: 'Angular' },
						{ Value: 'VU', Text: 'Vue.js' },
						{ Value: 'RE', Text: 'React' },
					]
				},
				{
					Group: 'Valid options too',
					Values: [
						{ Value: 'RA', Text: 'Rails' },
						{ Value: 'DJ', Text: 'Django' },
					]
				}
			],
			iconOptions: [
				{ Value: 'RA', Text: 'Rails', Icon: 'Q_icon.png' },
				{ Value: 'DJ', Text: 'Django', Icon: 'Q_icon.png' },
				{ Value: 'AN', Text: 'Angular', Icon: 'Q_icon.png' },
				{ Value: 'VU', Text: 'Vue.js', Icon: 'Q_icon.png' },
				{ Value: 'RE', Text: 'React', Icon: 'Q_icon.png' },
			]
		}
	},
	serverCase()
	{
		return {
			storeDropdown3: {
				selectedKey: '',
				options: [],
			},
			stores3: [
				{
					key: '225e8ffa-c693-4346-ba16-dece1ab60901',
					value: 'Lisbon Store',
				},
				{
					key: 'f181dbb9-109f-42f6-8746-48eab558474c',
					value: 'Porto Store',
				},
				{
					key: '127dcc37-c7ac-4abf-a4a7-3ec93e866902',
					value: 'Store A1',
				},
				//not visible after this
				{
					key: '2b00edfb-d3dc-4d37-aac1-8245f9a98ab4',
					value: 'Store B2',
				},
				{
					key: 'f56f7e26-39a9-49f2-9b89-8e2731fece1e',
					value: 'Store B3',
				},
				{
					key: 'd5c99fb0-5746-4a1c-ab8b-16bea72b54de',
					value: 'Store B4',
				},
				{
					key: 'c4fb6590-b2b7-4e23-bf82-3dca744e1f73',
					value: 'Store C5',
				},
				{
					key: 'e576b055-8544-457b-a94f-602cf92a85d6',
					value: 'Store C6',
				},
				{
					key: '4cde3eec-f7c3-4f59-b03a-7fbc60e70b1a',
					value: 'Store C7',
				},
				{
					key: 'bd29a481-7f01-4b3b-9e7b-9bbf33996ab0',
					value: 'Store D8',
				},
				{
					key: '80d23c9a-64c2-4bdd-9bae-adfcf5cbc53c',
					value: 'Store D9',
				},
				{
					key: '521e3515-94e0-49a3-a5f9-e771446d92e5',
					value: 'Store D10',
				},
			],
			stores: [
				{
					key: '225e8ffa-c693-4346-ba16-dece1ab60901',
					value: 'Lisbon Store',
				},
				{
					key: 'f181dbb9-109f-42f6-8746-48eab558474c',
					value: 'Porto Store',
				},
			],
			storeItems: {
				'225e8ffa-c693-4346-ba16-dece1ab60901': [
					{
						key: '127dcc37-c7ac-4abf-a4a7-3ec93e866902',
						value: 'Esferográfica preta (Lisboa).',
					},
					{
						key: '2b00edfb-d3dc-4d37-aac1-8245f9a98ab4',
						value: 'Esferográfica vermelha (Lisboa)',
					},
					{
						key: 'f56f7e26-39a9-49f2-9b89-8e2731fece1e',
						value: 'Esferográfica verde (Lisboa)',
					},
				],
				'f181dbb9-109f-42f6-8746-48eab558474c': [
					{
						key: 'd5c99fb0-5746-4a1c-ab8b-16bea72b54de',
						value: 'Esferográfica verde (Porto)',
					},
					{
						key: 'c4fb6590-b2b7-4e23-bf82-3dca744e1f73',
						value: 'Papel A4 80 g/m² (Porto)',
					},
					{
						key: 'e576b055-8544-457b-a94f-602cf92a85d6',
						value: 'Esferográfica azul (Porto)',
					},
					{
						key: '4cde3eec-f7c3-4f59-b03a-7fbc60e70b1a',
						value: 'Esferográfica preta (Porto)',
					},
					{
						key: 'bd29a481-7f01-4b3b-9e7b-9bbf33996ab0',
						value: 'Papel A4 100 g/m² (Porto)',
					},
					{
						key: '80d23c9a-64c2-4bdd-9bae-adfcf5cbc53c',
						value: 'Papel A4 80 g/m²',
					},
					{
						key: '521e3515-94e0-49a3-a5f9-e771446d92e5',
						value: 'Esferográfica vermelha (Porto)',
					},
				],
			},
			auxStoreKeys: [
				'127dcc37-c7ac-4abf-a4a7-3ec93e866902', // Store 1
				'2b00edfb-d3dc-4d37-aac1-8245f9a98ab4', // Store 2
				'e576b055-8544-457b-a94f-602cf92a85d6', // Store 6
				'521e3515-94e0-49a3-a5f9-e771446d92e5', // Store
			],
			storeDropdown: {
				selectedKey: '',
				options: [],
				onLoadProc: asyncProcMonitoring.getProcListMonitor(
					'store_dropdown',
					true
				),
			},
			storeItemDropdown: {
				selectedKey: '',
				options: [],
				onLoadProc: asyncProcMonitoring.getProcListMonitor(
					'store_item_dropdown',
					true
				),
			},
		}
	},
	simpleUsageMethods: {
		shortlistAction()
		{
			window.alert('shortlist emit')
		},
		searchAction(e)
		{
			const str = `on-search\n
					keywords: ${JSON.stringify(e.filterValue)}\n
					timeout: ${JSON.stringify(e.searchTimeOut)}ms`
			window.alert(str)
		},
		seeMoreAction()
		{
			const str = 'event: see-more'
			window.alert(str)
		},
		insertAction()
		{
			const str = 'event: insert'
			window.alert(str)
		}
	},
	serverCaseMethods: {
		fetchStoreData(searchText)
		{
			this.storeDropdown.options = []
			let filtredStore = _isEmpty(searchText)
				? this.stores
				: _filter(this.stores, (store) =>
						_startsWith(_toLower(store.value), _toLower(searchText))
					)

			this.storeDropdown.onLoadProc.Add(
				fetchFakeData(
					'MyStoreController',
					'MyStoreAction',
					{ find: searchText },
					{ Data: filtredStore },
					(data) => {
						this.storeDropdown.options = data
					}
				),
				true
			)
		},
		fetchStoreData2(searchText)
		{
			let filtredStore = [
				..._filter(
					this.stores3,
					(store) => store.key === this.storeDropdown3.selectedKey
				),
				..._filter(
					this.stores3,
					(store) =>
						store.key !== this.storeDropdown3.selectedKey &&
						(_isEmpty(searchText) ||
							_startsWith(_toLower(store.value), _toLower(searchText)))
				),
			].slice(0, 3) // JUST 3 Records are visible

			this.storeItemDropdown.onLoadProc.Add(
				fetchFakeData(
					'MyStoreController',
					'MyStoreAction',
					{ find: searchText },
					{ Data: filtredStore },
					(data) => {
						this.storeDropdown3.options = data
					}
				),
				true
			)
		},
		fetchStoreItemData(searchText)
		{
			this.storeItemDropdown.options = []
			let selectedStoreItems =
					this.storeItems[this.storeDropdown.selectedKey] || [],
				filtredStoreItems = _isEmpty(searchText)
					? selectedStoreItems
					: _filter(selectedStoreItems, (storeItem) =>
							_startsWith(_toLower(storeItem.value), _toLower(searchText))
						)

			this.storeItemDropdown.onLoadProc.Add(
				fetchFakeData(
					'MyStoreItemController',
					'MyStoreItemAction',
					{ find: searchText },
					{ Data: filtredStoreItems },
					(data) => {
						this.storeItemDropdown.options = data
					}
				),
				true
			)
		}
	}
}