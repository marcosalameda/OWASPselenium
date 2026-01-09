import type { Icon } from '@quidgest/ui/components'

export type QActionListProps = {
	/**
	 * The list of actions.
	 */
	items: QActionListItem[]

	/**
	 * The list of groups of actions.
	 */
	groups?: QActionListGroup[]

	/**
	 * Options for the dropdown menu.
	 */
	options?: QActionListOptions

	/**
	 * If the actions are all in readonly.
	 */
	readonly?: boolean
}

export type QActionListItem = {
	/**
	 * The key of the item.
	 */
	key: string

	/**
	 * The label of the item.
	 */
	label: string

	/**
	 * The key of the group.
	 */
	group?: string

	/**
	 * The icon of the item.
	 */
	icon?: Icon

	/**
	 * Whether the item is visible.
	 */
	isVisible?: boolean

	/**
	 * Whether the item is disabled.
	 */
	disabled?: boolean

	/**
	 * The description of the item.
	 */
	description?: string

	/**
	 * List of items to show in the submenu
	 */
	items?: QActionListItem[]
}

export type QActionListGroup = {
	/**
	 * The id of the group.
	 */
	id: string

	/**
	 * The display type of the group.
	 */
	display?: 'dropdown' | 'inline' | 'mixed'

	/**
	 * The title of the group.
	 */
	title?: string

	/**
	 * Whether the group is disabled
	 */
	disabled?: boolean

	/**
	 * The size of the group
	 */
	size?: 'small' | 'regular'

	/**
	 * Whether the group has border
	 */
	borderless?: boolean

	/**
	 * Custom css class for the group
	 */
	customClass?: string
}

export type QActionListOptions = {
	/**
	 * Custom icon for the dropdown button.
	 */
	dropdownIcon?: Icon

	/**
	 * The size of the dropdown button.
	 */
	dropdownSize?: 'small' | 'regular'

	/**
	 * Custom icons for submenus
	 */
	submenusIcons?: typeof DEFAULT_SUBMENU_ICONS
}

// The default icons of the component
export const DEFAULT_SUBMENU_ICONS = {
	expand: {
		icon: 'page-next'
	}
} satisfies Record<string, Icon>

export const DEFAULT_DROPDOWN_ICON = {
	icon: 'more-items'
}
