<template>
	<teleport :to="`#q-modal-file-versions-${controlId}-body`">
		<div class="content">
			<q-table
				:rows="tableRows"
				:columns="tableColumns"
				:config="tableConfig"
				@row-action="findVersionToDownload($event)" />
		</div>
	</teleport>

	<teleport
		v-if="!readonly"
		:to="`#q-modal-file-versions-${controlId}-footer`">
		<div class="actions">
			<q-button
				b-style="primary"
				:label="texts.deleteLastLabel"
				@click="$emit('delete-last')">
				<q-icon icon="delete" />
			</q-button>

			<q-button
				b-style="secondary"
				:label="texts.deleteHistoryLabel"
				@click="$emit('delete-history')">
				<q-icon icon="delete" />
			</q-button>
		</div>
	</teleport>
</template>

<script>
	import QTable from '@/components/table/QTable.vue'

	export default {
		name: 'QDocumentVersions',

		emits: [
			'get-file-version',
			'delete-last',
			'delete-history'
		],

		components: {
			QTable
		},

		inheritAttrs: false,

		props: {
			/**
			 * Unique ID for the control.
			 */
			controlId: String,

			/**
			 * Necessary strings to be used in labels and buttons.
			 */
			texts: {
				type: Object,
				required: true
			},

			/**
			 * Whether the field is readonly.
			 */
			readonly: {
				type: Boolean,
				default: false
			},

			/**
			 * The current version numbers of the document.
			 */
			versions: {
				type: Object,
				default: () => ({})
			},

			/**
			 * The details about the version history of the document.
			 */
			versionsInfo: {
				type: Array,
				default: () => []
			},

			/**
			 * The resources path.
			 */
			resourcesPath: {
				type: String,
				required: true
			}
		},

		inject: [
			'downloadVersion'
		],

		expose: [],

		computed: {
			/**
			 * The detailed history of versions, in the format the QTable component expects.
			 */
			tableRows()
			{
				var rows = []

				if (this.versionsInfo && this.versionsInfo.length > 0)
				{
					for (let i = 0; i < this.versionsInfo.length; i++)
					{
						const row = {
							Rownum: i,
							Fields: this.versionsInfo[i],
							rowKey: this.versionsInfo[i].id
						}

						rows.push(row)
					}
				}

				return rows
			},

			/**
			 * The configuration of the versions history table.
			 */
			tableConfig()
			{
				return {
					showFooter: false,
					customActions: [
						{
							id: 'download',
							name: 'download',
							title: this.texts.downloadLabel,
							icon: {
								icon: 'download',
								type: 'svg'
							},
							isInReadOnly: true
						}
					],
					globalSearch: {
						visibility: false
					},
					config: {
						allowFileExport: false,
						allowFileImport: false
					},
					resourcesPath: this.resourcesPath
				}
			},

			/**
			 * The columns of the versions history table.
			 */
			tableColumns()
			{
				return [
					{
						order: 1,
						dataType: 'Text',
						label: this.texts.version,
						name: 'version',
						sortable: true
					},
					{
						order: 2,
						dataType: 'Text',
						label: this.texts.documentLabel,
						name: 'fileName',
						sortable: true
					},
					{
						order: 3,
						dataType: 'Text',
						label: this.texts.bytesLabel,
						name: 'bytes',
						sortable: true
					},
					{
						order: 4,
						dataType: 'Text',
						label: this.texts.author,
						name: 'author',
						sortable: true
					},
					{
						order: 5,
						dataType: 'Text',
						label: this.texts.createdOnLabel,
						name: 'createdOn',
						sortable: true
					}
				]
			}
		},

		methods: {
			/**
			 * Finds the number of the version to be downloaded, according to the key of the clicked row.
			 * @param {object} rowData The data of the clicked row
			 */
			findVersionToDownload(rowData)
			{
				if (typeof rowData !== 'object' || typeof rowData.rowKey !== 'string')
					return

				for (let i in this.versions)
				{
					if (this.versions[i] === rowData.rowKey)
					{
						this.downloadVersion(i)
						return
					}
				}
			}
		}
	}
</script>
