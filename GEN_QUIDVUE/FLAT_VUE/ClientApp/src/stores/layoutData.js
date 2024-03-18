/*****************************************************************
 *                                                               *
 * This store holds data specific for the vertical layout,       *
 * also defining functions to access and mutate it.              *
 *                                                               *
 *****************************************************************/

import { defineStore } from 'pinia'

import { useGenericLayoutDataStore } from './genericLayoutData.js'

/**
 * Returns an object with the default state of the store.
 */
function getDefaultState()
{
	const genericLayoutDataStore = useGenericLayoutDataStore()
	genericLayoutDataStore.resetStore()
	genericLayoutDataStore.setHeaderHeight(50)

	return {
		...genericLayoutDataStore,
		...state(),
		...actions
	}
}

//----------------------------------------------------------------
// State variables
//----------------------------------------------------------------

const state = () => {
	return {
		layoutType: 'vertical',

		sidebarIsCollapsed: false,

		sidebarIsVisible: true,

		bookmarkMenuIsOpen: false,

		moduleMenuIsOpen: false,

		isAccordionMenu: true
	}
}

//----------------------------------------------------------------
// Actions
//----------------------------------------------------------------

const actions = {
	/**
	 * Sets the collapse state of the sidebar.
	 * @param {boolean} isCollapsed Whether or not the sidebar is collapsed
	 */
	setSidebarCollapseState(isCollapsed)
	{
		if (typeof isCollapsed !== 'boolean')
			return

		this.sidebarIsCollapsed = isCollapsed
	},

	/**
	 * Sets the visibility of the sidebar.
	 * @param {boolean} isVisible Whether or not the sidebar is visible
	 */
	setSidebarVisibility(isVisible)
	{
		if (typeof isVisible !== 'boolean')
			return

		this.sidebarIsVisible = isVisible
	},

	/**
	 * Sets the state of the bookmarks menu.
	 * @param {boolean} isOpen Whether or not the bookmarks menu is open
	 */
	setBookmarkMenuState(isOpen)
	{
		if (typeof isOpen !== 'boolean')
			return

		this.bookmarkMenuIsOpen = isOpen
	},

	/**
	 * Sets the state of the modules menu.
	 * @param {boolean} isOpen Whether or not the modules menu is open
	 */
	setModuleMenuState(isOpen)
	{
		if (typeof isOpen !== 'boolean')
			return

		this.moduleMenuIsOpen = isOpen
	},

	/**
	 * Sets the type of the dropdown menus.
	 * @param {boolean} isAccordion Whether or not the dropdown menu is an accordion
	 */
	setMenuTypeAccordion(isAccordion)
	{
		if (typeof isAccordion !== 'boolean')
			return

		this.isAccordionMenu = isAccordion
	},

	/**
	 * Resets the layout info.
	 */
	resetStore()
	{
		Object.assign(this, getDefaultState())
	}
}

//----------------------------------------------------------------
// Store export
//----------------------------------------------------------------

export const useLayoutDataStore = defineStore('layoutData', () => getDefaultState())
