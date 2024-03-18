// FullCalendar v5.10.1
import { Theme, createPlugin } from '@fullcalendar/common'
import _get from 'lodash-es/get'

class QFullCalendarTheme extends Theme
{
	constructor(calendarOptions)
	{
		super(calendarOptions)

		// file://fileserver/FTProot/Investigacao/RefatorizacaoGenio/WebAdmin/webAdmin_root/index.html
		this.classes = {
			root: 'fc-theme-standard', // 'fc-theme-bootstrap',
			table: 'c-table-bordered', // 'table-bordered',
			tableCellShaded: 'fc-cell-shaded', // 'table-active',
			buttonGroup: 'q-btn-group',
			button: 'q-btn q-btn--secondary',
			buttonActive: 'q-btn--active',
			popover: 'popover',
			popoverHeader: 'popover-header',
			popoverContent: 'popover-body'
		}

		this.baseIconClass = 'glyphicons e-icon'

		this.iconClasses = {
			close: 'fc-icon-x',
			prev: 'glyphicons-chevron-left',
			next: 'glyphicons-chevron-right',
			prevYear: 'glyphicons-rewind',
			nextYear: 'glyphicons-forward'
		}

		this.rtlIconClasses = {
			prev: 'glyphicons-chevron-right', // fc-icon-chevron-right
			next: 'glyphicons-chevron-left', // fc-icon-chevron-left
			prevYear: 'glyphicons-forward', // fc-icon-chevrons-right
			nextYear: 'glyphicons-rewind' // fc-icon-chevrons-left
		}

		this.iconOverrideOption = 'buttonIcons'

		this.iconOverrideCustomButtonOption = 'icon' // icon

		this.iconOverridePrefix = 'fc-icon-' // 'glyphicons-'

		// if(window.qfc !== undefined) //tests - ui
		// 	Object.assign(this, window.qfc)

		if (this.iconOverrideOption)
			this.setIconOverride(_get(calendarOptions, this.iconOverrideOption, null))
	}
}

const themePlugin = createPlugin({
	themeClasses: {
		quidgest: QFullCalendarTheme
	}
})

export default themePlugin
export { QFullCalendarTheme, themePlugin }
