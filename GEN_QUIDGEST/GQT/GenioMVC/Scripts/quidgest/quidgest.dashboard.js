/**
 * Dashboard.
 */
class QDashboard
{
	/**
	 * Initializes a new instance of the QDashboard class.
	 * 
	 * @constructor
	 * @param {Object} cfg - The configuration of the dashboard.
	 */
	constructor(cfg)
	{
		this.Grid = cfg.grid
		this.uuid = cfg.uuid
		this.UrlActions = cfg.urlActions
		this.Texts = cfg.texts
		this.InEditMode = false
		this.RequestStack = []
		this.Widgets = []
		this.Groups = cfg.groups

		const vm = this
		cfg.widgets.forEach(function (widget)
		{
			const qWidget = vm.CreateWidget(widget)
			vm.Widgets.push(qWidget)
		})

		this.WidgetPanel = new QWidgetPanel(this)

		this.Init()
	}

	/**
	 * Creates a widget of a concrete type
	 * based on the provided information.
	 * 
	 * @param {Object} cfg - The widget configuration.
	 * @returns {QWidget} A widget.
	 */
	CreateWidget(cfg)
	{
		switch (cfg.Type)
		{
			case 0: // Alert
				return new QAlertWidget(this, cfg)
			case 1: // 
			case 4:
				return new QMenuWidget(this, cfg)
			case 2:
				return new QCustomWidget(this, cfg)
			case 3:
				return new QCustomPaginatedWidget(this, cfg)
			default:
				console.error("Unknown widget type:", cfg.Type)
		}
	}

	/**
	 * Initializes this instance of the dashboard.
	 */
	Init()
	{
		this.LoadWidgets()

		this.Element = $(".grid-stack")

		// Resize the grid to fit the current window dimension
		this.ResizeGrid()

		// Adjust when future resizes happen
		window.addEventListener("resize", () => this.ResizeGrid())
		window.addEventListener("load", () => this.ResizeGrid())
		window.addEventListener("cavtoggleoff", () => this.ResizeGrid())
		window.addEventListener("collapsed.lte.pushmenu", () => this.ResizeGrid())
		window.addEventListener("shown.lte.pushmenu", () => this.ResizeGrid())

		// Set the necessary "click" event listeners
		const editBtn = document.getElementById("dashboard-edit-btn")
		editBtn.addEventListener("click", () => this.EditDashboard())

		const emptyEditButton = document.getElementById("no-widgets").getElementsByTagName("button")[0]
		emptyEditButton.addEventListener("click", () => this.EditDashboard())

		const compactBtn = document.getElementById("dashboard-compact-btn")
		compactBtn.addEventListener("click", () => this.CompactDashboard())

		const saveBtn = document.getElementById("dashboard-save-btn")
		saveBtn.addEventListener("click", () => this.SaveDashboard())

		const cancelBtn = document.getElementById("dashboard-cancel-btn")
		cancelBtn.addEventListener("click", () => this.CancelEdit())

		// Drag and drop (grid side)
		const gridstack = this.Element[0]
		gridstack.addEventListener("drop", (ev) =>
		{
			this.Drop(ev)
			this.SetDirty()
		})

		gridstack.addEventListener("dragover", (ev) => this.AllowDrop(ev))

		// Detect widget position changes
		this.Grid.on("dragstart", (_event, el) =>
		{
			const x = parseInt(el.getAttribute("gs-x")) || 0
			const y = parseInt(el.getAttribute("gs-y")) || 0

			this.CurrentDragOrig = {
				x: x,
				y: y,
			}
		})

		this.Grid.on("dragstop", (_event, el) =>
		{
			const x = parseInt(el.getAttribute("gs-x")) || 0
			const y = parseInt(el.getAttribute("gs-y")) || 0

			if (x != this.CurrentDragOrig.x || y != this.CurrentDragOrig.y)
				this.SetDirty()
		})

		this.ChainableUtilObj = $.Deferred()

		$.when(this.ChainableUtilObj).then(() =>
		{
			return this.RequestStack.reduce((promise, fnRequest) =>
			{
				return promise.then(() => fnRequest())
			}, Promise.resolve())
		})

		if (this.ChainableUtilObj && this.ChainableUtilObj.state() !== "resolved")
			this.ChainableUtilObj.resolve(true)

		$("#main").css("background-color", "var(--light)")

		this.ToggleNoWidgetsPanel()
	}

	/**
	 * Gets the widget with the provided id.
	 * 
	 * @param {String} widgetId - The widget identifier.
	 */
	GetWidgetById(widgetId)
	{
		return this.Widgets.find((w) => w.id + "-" + w.rowkey === widgetId)
	}

	/**
	 * Adds the provided widget to the dashboard grid.
	 * 
	 * @param {Object} widget - The widget to add to the dashboard grid.
	 */
	AddWidget(widget)
	{
		const gridstackItemContent = document.createElement("div")

		// The fixed action bar at the top of the widget
		const actions = document.createElement("div")
		actions.classList.add("widget-actions")

		// Widget group identifier
		const widgetGroup = document.createElement("span")
		widgetGroup.innerHTML = this.GetWidgetGroupName(widget.Group)
		widgetGroup.classList.add("widget-tag", "c-card__subtitle", "float-left")

		// The group of buttons, floats to the right of the action bar
		const btnGroup = document.createElement("div")
		btnGroup.classList.add("widget-actionlist", "float-right")
		btnGroup.setAttribute("role", "menubar")

		// Add widget type-specific buttons
		const widgetTypeSpecificBtns = widget.GetTypeSpecificButtons()
		if (widgetTypeSpecificBtns)
			btnGroup.appendChild(widgetTypeSpecificBtns)

		if (!widget.Required)
		{
			// Button to remove the widget
			const deleteBtn = document.createElement("button")
			deleteBtn.classList.add("dashboard-action-btn", "widget-delete-btn")
			deleteBtn.title = this.Texts.DELETE
			deleteBtn.setAttribute("role", "menuitem")

			const icon = document.createElement("i")
			icon.classList.add("glyphicons", "glyphicons-bin", "e-icon")

			deleteBtn.appendChild(icon)
			btnGroup.appendChild(deleteBtn)
		}

		if (widget.RefreshMode == 1)
		{
			// Manual refresh
			const refreshBtn = document.createElement("button")
			refreshBtn.classList.add("dashboard-action-btn", "widget-refresh-btn")
			refreshBtn.title = this.Texts.REFRESH
			refreshBtn.setAttribute("role", "menuitem")

			const icon = document.createElement("i")
			icon.classList.add("glyphicons", "glyphicons-repeat", "e-icon")

			refreshBtn.appendChild(icon)
			btnGroup.appendChild(refreshBtn)
		} else if (widget.RefreshMode == 2 &&
			widget.RefreshRate > 0 &&
			!this.InEditMode)
		{
			// Automatic (periodic) refresh
			widget.StartRefreshWorker()
		}

		actions.appendChild(widgetGroup)
		actions.appendChild(btnGroup)

		const content = document.createElement("div")
		content.classList.add("widget-content", widget.GetTagName())

		gridstackItemContent.appendChild(actions)
		gridstackItemContent.appendChild(content)

		widget.visible = true
		let props = {
			id: widget.id + '-' + widget.rowkey,
			w: widget.Width,
			h: widget.Height,
			content: gridstackItemContent.innerHTML,
		}

		if (widget.x >= 0)
		{
			props.x = widget.x
		}
		if (widget.y >= 0)
		{
			props.y = widget.y
		}

		this.Grid.addWidget(props)
		widget.Element = $("[gs-id='" + widget.id + '-' + widget.rowkey + "']")

		// Get the widget content
		widget.Render()

		this.WidgetPanel.RemoveWidgetFromPanel(widget)
	}

	RefreshWidget(widgetId)
	{
		const widget = this.GetWidgetById(widgetId)
		widget.Refresh()
	}

	RemoveWidget(widgetId)
	{
		const widgetEl = $("[gs-id='" + widgetId + "']")[0]
		this.Grid.removeWidget(widgetEl)

		const widget = this.GetWidgetById(widgetId)
		if (widget)
		{
			widget.visible = false
			widget.x = -1
			widget.y = -1
			widget.StopRefreshWorker()

			this.WidgetPanel.AddWidgetToPanel(widget)
		}
	}

	LoadWidgets()
	{
		const vm = this
		this.Widgets.sort((a, b) => (a.Order > b.Order ? 1 : -1)).forEach(function (
			widget
		)
		{
			if (widget.visible)
			{
				vm.AddWidget(widget)
				vm.WidgetPanel.IncreaseGroupCounter(widget)
			} else
				vm.WidgetPanel.AddWidgetToPanel(widget)
		})
	}

	ResizeGrid()
	{
		// Possible values: 'moveScale' | 'move' | 'scale' | 'none'
		const layout = "none"
		const width = document.getElementById("dashboard").getBoundingClientRect().width

		if (width < 700)
		{
			this.Grid.column(1, layout)
		} else if (width < 950)
		{
			this.Grid.column(6, layout)
		} else
		{
			this.Grid.column(12, layout)
		}
	}

	EditDashboard()
	{
		this.InEditMode = true

		// Temp list to aid the "cancel" and "save" operations
		this.PrevGrid = this.ExportGrid()

		this.Grid.enableMove(true)
		$(".grid-stack").removeClass("grid-stack-disabled")

		$("#dashboard-save-btn").attr("disabled", true)
		$("#dashboard-save-btn").addClass("disabled")

		$("#dashboard-edit-mode-controls").show()
		$("#dashboard-view-mode-controls").hide()

		$(".widget-delete-btn").show()
		$(".widget-refresh-btn").hide()

		$(".widget-content").each((_idx, div) =>
		{
			$(div).append('<div class="widget-tmp-content edit-mode"></div>')
		})

		this.Widgets.forEach(function (widget)
		{
			widget.StopRefreshWorker()
		})

		this.WidgetPanel.Open()
		$("#dashboard").removeClass("empty")
	}

	CompactDashboard()
	{
		this.Grid.compact()
		this.SetDirty()
	}

	SaveDashboard()
	{
		const vm = this

		// Grid
		this.Grid.enableMove(false)
		$(".grid-stack").addClass("grid-stack-disabled")
		$("#dashboard-edit-mode-controls").hide()
		$("#dashboard-view-mode-controls").show()

		// Widgets
		$(".widget-delete-btn").hide()
		$(".widget-refresh-btn").show()
		$(".widget-tmp-content").remove()

		this.InEditMode = false
		this.WidgetPanel.Close()

		this.Widgets.forEach(function (widget)
		{
			if (widget.RefreshMode == 2 && widget.RefreshRate > 0 && widget.visible)
			{
				widget.StartRefreshWorker()
			}
		})

		// Save configuration
		const grid = this.ExportGrid()
		$.ajax({
			type: "POST",
			url: vm.UrlActions.SaveConfiguration,
			data: JSON.stringify({
				grid: grid,
				uuid: vm.uuid,
			}),
			beforeSend: function ()
			{
				qAddLoading(1000)
			},
			complete: function ()
			{
				qRemoveLoading()
			},
			contentType: "application/json",
		})

		this.ToggleNoWidgetsPanel()
	}

	CancelEdit()
	{
		this.InEditMode = false

		// Grid
		this.Grid.enableMove(false)
		$(".grid-stack").addClass("grid-stack-disabled")
		$("#dashboard-edit-mode-controls").hide()
		$("#dashboard-view-mode-controls").show()

		// Widgets
		$(".widget-delete-btn").hide()
		$(".widget-refresh-btn").show()
		$(".widget-tmp-content").remove()

		this.Widgets.forEach(function (widget)
		{
			if (widget.RefreshMode == 2 && widget.RefreshRate > 0 && widget.visible)
			{
				widget.StartRefreshWorker()
			}
		})

		this.RevertPositionChanges()
		this.WidgetPanel.Close()
		this.ToggleNoWidgetsPanel()
	}

	RevertPositionChanges()
	{
		const vm = this

		this.PrevGrid.forEach(function (prev)
		{
			const current = vm.GetWidgetById(prev.id)

			const inUseBeforeEdit = prev.visible
			const inUseAfterEdit = current.visible

			if (inUseBeforeEdit && !inUseAfterEdit)
			{
				// Widget has been removed, let's add it back
				current.x = prev.x
				current.y = prev.y
				vm.AddWidget(current)
			} else if (!inUseBeforeEdit && inUseAfterEdit)
			{
				// Widget has been added, let's remove it
				vm.RemoveWidget(current.id)
			} else if (inUseAfterEdit)
			{
				// Revert potential position changes of widgets in use
				const x = prev.x
				const y = prev.y
				vm.Grid.update(current.Element[0], { x: x, y: y })
			}
		})
	}

	Drag(ev)
	{
		const widgetId = ev.target.id.replace("widget-info-", "")
		ev.dataTransfer.setData("widget-id", widgetId)
	}

	AllowDrop(ev)
	{
		ev.preventDefault()
	}

	Drop(ev)
	{
		ev.preventDefault()
		const widgetId = ev.dataTransfer.getData("widget-id")

		const widget = this.GetWidgetById(widgetId)
		if (widget)
		{
			this.AddWidget(widget)
		}
	}

	ExportGrid()
	{
		const result = []
		this.Widgets.forEach(function (widget)
		{
			var item = {
				id: widget.id,
				rowkey: widget.GetRowkey(),
				visible: widget.visible,
			}

			if (widget.visible && widget.Element)
			{
				const el = widget.Element[0]

				// Grab these attributes from the DOM
				// (they are handled by gridstack)
				const x = parseInt(el.getAttribute("gs-x")) || 0
				const y = parseInt(el.getAttribute("gs-y")) || 0

				item.x = x
				item.y = y
			}

			result.push(item)
		})

		return result
	}

	SetDirty()
	{
		$("#dashboard-save-btn").removeAttr("disabled")
		$("#dashboard-save-btn").removeClass("disabled")
	}

	GetWidgetGroupName(id)
	{
		const group = this.Groups.find((g) => g.Identifier == id)
		return group ? group.Title : "Tag"
	}

	ToggleNoWidgetsPanel()
	{
		const visibleWidgets = this.Widgets.filter((widget) => widget.visible).length

		if (visibleWidgets == 0)
			$("#dashboard").addClass("empty")
	}
}

/**
 * Widget panel.
 */
class QWidgetPanel
{
	constructor(dashboard)
	{
		this.Dashboard = dashboard

		this.Init()
	}

	Init()
	{
		this.Element = $("#widgets-panel")
		this.Selected = []

		const vm = this
		const addBtn = $("#widgets-panel button")
		addBtn.append(vm.Dashboard.Texts.ADD)
		addBtn.on("click", () =>
		{
			vm.AddSelected()
		})

		// Sort the groups by group.Order
		this.Dashboard.Groups.sort((a, b) => { return a.Order - b.Order; });

		const parent = $("#available-widgets")
		this.Dashboard.Groups.forEach(function (group)
		{
			const item = document.createElement("li")
			item.setAttribute("role", "option")
			item.classList.add(
				"widget-panel-group",
				"widget-panel-item",
				"disabled"
			)
			item.setAttribute("data-group-id", group.Identifier)

			const widgetType = document.createElement("div")
			widgetType.classList.add("widget-type")

			const title = document.createElement("p")
			title.innerHTML = group.Title

			const numberOfInstances = document.createElement("span")
			numberOfInstances.classList.add("widget-instance-count")
			numberOfInstances.innerHTML = "0"

			const icon = document.createElement("i")
			icon.classList.add(
				"right",
				"glyphicons",
				"glyphicons-chevron-down",
				"float-right"
			)

			widgetType.appendChild(title)
			widgetType.appendChild(numberOfInstances)
			widgetType.appendChild(icon)

			const instanceList = document.createElement("ul")
			instanceList.classList.add(
				"nav",
				"nav-treeview",
				"widget-type-instances"
			)

			item.appendChild(widgetType)
			item.appendChild(instanceList)

			parent.append(item)
		})

		const groups = this.Element.find(".widget-panel-group")
		groups.each(function (_index)
		{
			$(this).on("click", () =>
			{
				if ($(this).hasClass("menu-open"))
				{
					// Close this
					$(this).removeClass("menu-open")
				}
				else
				{
					// Close others
					groups.removeClass("menu-open")
					// Expand this
					$(this).addClass("menu-open")
				}
			})
		})

		const help = this.Dashboard.Texts.HELP.replace(
			"%s",
			'"' + this.Dashboard.Texts.ADD + '"'
		)
		this.Element.find(".widgets-panel-help").text(help)
	}

	IncreaseGroupCounter(widget)
	{
		const group = $("[data-group-id=" + widget.Group + "]")
		const count = parseInt(group.find(".widget-instance-count").html())

		if (count == 0)
			$(group).removeClass("disabled")
		group.find(".widget-instance-count").html(count + 1)
	}

	DecreaseGroupCounter(widget)
	{
		const group = $("[data-group-id=" + widget.Group + "]")
		const count = parseInt(group.find(".widget-instance-count").html())

		if (count == 1)
		{
			$(group).removeClass("menu-open")
			$(group).addClass("disabled")
		}

		group.find(".widget-instance-count").html(count - 1)
	}

	Open()
	{
		// Open the panel
		$("#v-pills-3-tab")[0].click()
		openSidebar()
		$("#widgets-panel").removeClass("closed")

		// Disable other tabs to avoid conflicts with the widgets panel
		$("#v-pills-tab")
			.children()
			.each(function (_idx, tab)
			{
				$(tab).attr("disabled", "true")
				$(tab).addClass("disabled")
			})

		// Disable the notifications bell
		$("#usravt-notifications-bell").parent().attr("disabled", "true")
		$("#usravt-notifications-bell").parent().addClass("disabled")
	}

	Close()
	{
		// Enable back the other tabs
		$("#v-pills-tab")
			.children()
			.each(function (_idx, tab)
			{
				$(tab).removeAttr("disabled")
				$(tab).removeClass("disabled")
			})

		// Enable the notifications bell
		$("#usravt-notifications-bell").parent().removeAttr("disabled")
		$("#usravt-notifications-bell").parent().removeClass("disabled")

		// Close all widget groups
		const groups = this.Element.find(".widget-panel-item")
		groups.removeClass("menu-open")

		// Close panel
		$("#widgets-panel").addClass("closed")
		closeSidebar()
	}

	AddWidgetToPanel(widget)
	{
		let parent

		if (widget.Group)
		{
			parent = $("[data-group-id=" + widget.Group + "]").find(
				".widget-type-instances"
			)
		}
		else
		{
			parent = $("#widgets-panel > ul")
		}

		const item = document.createElement("li")
		item.id = "widget-info-" + widget.id + "-" + widget.rowkey
		item.setAttribute("role", "option")
		item.classList.add("widget-panel-item", "widget-info")
		item.setAttribute("draggable", "true")

		const title = widget.Title ? widget.Title : "Untitled widget" // FIXME: add resource
		const widgetName = document.createElement("p")
		widgetName.classList.add("widget-name")
		widgetName.title = title
		widgetName.innerHTML = title

		item.appendChild(widgetName)
		$(parent).append(item)

		const vm = this
		const widgetInfo = document.getElementById("widget-info-" + widget.id + "-" + widget.rowkey)
		widgetInfo.addEventListener("dragstart", (ev) =>
		{
			vm.Dashboard.Drag(ev)
		})
		widgetInfo.addEventListener("click", (ev) =>
		{
			ev.stopPropagation()
			vm.SelectToAdd(ev)
		})

		widget.x = -1
		widget.y = -1

		if (widget.Group)
			this.IncreaseGroupCounter(widget)
	}

	SelectToAdd(ev)
	{
		const targetEl = $(ev.target)
		const widgetId = ev.target.id.replace("widget-info-", "")

		if (targetEl.hasClass("selected"))
		{
			targetEl.removeClass("selected")

			const index = this.Selected.indexOf(widgetId)
			this.Selected.splice(index, 1)
		}
		else
		{
			targetEl.addClass("selected")

			this.Selected.push(widgetId)
		}

		this.UpdateAddButton()
	}

	AddSelected(_ev)
	{
		const vm = this

		// original will be changed inside the forEach
		const selected = [...this.Selected]

		// ``selected` contains the ids of the selected tiles
		selected.forEach(function (widgetId)
		{
			const widget = vm.Dashboard.GetWidgetById(widgetId)
			vm.Dashboard.AddWidget(widget)
		})

		this.Dashboard.SetDirty()
	}

	UpdateAddButton(_ev)
	{
		const addBtn = this.Element.find("button")

		if (this.Selected.length)
		{
			addBtn.removeClass("disabled")
			addBtn.removeAttr("disabled")
		}
		else
		{
			addBtn.addClass("disabled")
			addBtn.attr("disabled", "true")
		}
	}

	RemoveWidgetFromPanel(widget)
	{
		let parent

		if (widget.Group)
		{
			parent = $("[data-group-id=" + widget.Group + "]").find(
				".widget-type-instances"
			)
		}
		else
		{
			parent = $("#widgets-panel > ul")
		}

		const widgetInfo = $(parent).find("#widget-info-" + widget.id + '-' + widget.rowkey)
		widgetInfo.remove()

		if (widget.Group)
			this.DecreaseGroupCounter(widget)

		// If item was selected, remove from the list
		if (this.Selected)
		{
			const index = this.Selected.indexOf(widget.id + '-' + widget.rowkey)
			if (index > -1)
				this.Selected.splice(index, 1)

			this.UpdateAddButton()
		}
	}
}

/**
 * Widget.
 */
class QWidget
{
	constructor(dashboard, props)
	{
		this.Dashboard = dashboard
		this.id = props.Id
		this.rowkey = props.Rowkey
		this.Type = props.Type
		this.Order = props.Order
		this.x = props.Hposition
		this.y = props.Vposition
		this.Width = props.Width
		this.Height = props.Height
		this.ColoredLeftBorder = props.ColoredLeftBorder
		this.CacheTTL = props.CacheTTL
		this.RefreshMode = props.RefreshMode
		this.RefreshRate = props.RefreshRate
		this.Required = props.Required
		this.Title = props.Title
		this.Group = props.Group
		this.visible = props.Visible
	}

	Init()
	{
		if (this.ColoredLeftBorder)
		{
			const content = this.Element.find(".widget-content")
			content.parent().addClass("colored-border")
		}

		this.SetEventListeners()
	}

	SetEventListeners()
	{
		const vm = this

		const deleteBtn = this.Element.find(".widget-delete-btn")
		deleteBtn.off("click")
		deleteBtn.on("click", (event) =>
		{
			event.preventDefault()
			vm.Dashboard.RemoveWidget(vm.id + '-' + vm.rowkey)
			vm.Dashboard.SetDirty()
		})

		const refreshBtn = this.Element.find(".widget-refresh-btn")
		refreshBtn.off("click")
		refreshBtn.on("click", (event) =>
		{
			event.preventDefault()
			vm.Refresh()
		})
	}

	Render()
	{
		if (this.Dashboard.ChainableUtilObj &&
			this.Dashboard.ChainableUtilObj.state() !== "resolved")
		{
			var deferred = $.Deferred(), vm = this
			this.Dashboard.RequestStack.push(() =>
			{
				$.when(vm._render()).then(function (result)
				{
					deferred.resolve(result)
				})
			})
			return deferred.promise()
		} else
			return this._render()
	}

	_render()
	{
		const content = this.Element.find(".widget-content")
		this.DisplayLoading(content)

		const vm = this, deferred = $.Deferred()

		$.ajax({
			type: "GET",
			url: vm.RenderWidgetEndpoint,
			data: vm.RenderParams,
			contentType: "application/json",
		}).done(function (data)
		{
			const widgetEl = $("[gs-id='" + vm.id + '-' + vm.rowkey + "']")
			const content = widgetEl.find(".widget-content")
			content.html(data)

			// Remove loading overlay
			widgetEl.find(".widget-tmp-content").remove()

			if (vm.Dashboard.InEditMode)
			{
				content.append('<div class="widget-tmp-content edit-mode"></div>')
			}

			content.addClass("widget-data-loading")
			vm.Init()

			deferred.resolve(true)
		})

		return deferred.promise()
	}

	FetchData()
	{
		if (this.Dashboard.ChainableUtilObj &&
			this.Dashboard.ChainableUtilObj.state() !== "resolved")
		{
			var deferred = $.Deferred(), vm = this
			this.Dashboard.RequestStack.push(function ()
			{
				$.when(vm._fetchData()).then(function (result)
				{
					deferred.resolve(result)
				})
			})
			return deferred.promise()
		} else
			return this._fetchData()
	}

	_fetchData()
	{
		const vm = this, deferred = $.Deferred()

		$.ajax({
			type: "GET",
			url: vm.Dashboard.UrlActions.GetWidgetData,
			data: {
				widgetType: vm.Type,
				widgetId: vm.id,
			},
			contentType: "application/json",
		}).done(function (data)
		{
			const content = vm.Element.find(".widget-content")
			content.removeClass("widget-data-loading")
			vm.UpdateUI(data)

			deferred.resolve(true)
		})

		return deferred.promise()
	}

	Refresh()
	{
		const refreshBtn = this.Element.find(".widget-refresh-btn")
		refreshBtn.blur()

		this.FetchData()
	}

	AnimateNumber(elementToAnimate, numberToDisplay)
	{
		var currentDisplayedNumber = 0
		if (numberToDisplay == currentDisplayedNumber)
		{
			return
		}

		const interval = window.setInterval(() =>
		{
			if (currentDisplayedNumber < numberToDisplay)
			{
				let change = (numberToDisplay - currentDisplayedNumber) / 10
				change = change >= 0 ? Math.ceil(change) : Math.floor(change)
				currentDisplayedNumber = currentDisplayedNumber + change

				elementToAnimate.html(currentDisplayedNumber)
			}
			else
			{
				clearInterval(interval)
			}
		}, 20)
	}

	DisplayLoading(content)
	{
		const tmpcontent = document.createElement("div")
		tmpcontent.classList.add("widget-tmp-content")

		const loading = document.createElement("span")
		loading.innerHTML = this.Dashboard.Texts.LOADING

		tmpcontent.appendChild(loading)

		$(content).html(tmpcontent.outerHTML)
	}

	StartRefreshWorker()
	{
		const vm = this

		if (!this.RefreshWorker)
		{
			// Refresh rate is defined in seconds,
			// setInterval expects milliseconds
			this.RefreshWorker = setInterval(function ()
			{
				vm.Refresh()
			}, vm.RefreshRate * 1000)
		}
	}

	StopRefreshWorker()
	{
		if (this.RefreshWorker)
		{
			clearInterval(this.RefreshWorker)
			this.RefreshWorker = null
		}
	}

	GetRowkey()
	{
		return this.rowkey
	}

	GetTypeSpecificButtons()
	{
		return
	}
}

/**
 * Alert widget.
 */
class QAlertWidget extends QWidget
{
	constructor(dashboard, props)
	{
		super(dashboard, props)

		this.RenderWidgetEndpoint = this.Dashboard.UrlActions.RenderAlertWidget
	}

	Init()
	{
		Object.getPrototypeOf(QAlertWidget.prototype).Init.call(this)

		this.FetchData()
	}

	GetTagName()
	{
		return "alert-widget"
	}

	UpdateUI(alert)
	{
		if (alert)
		{
			// Title
			const titleElement = this.Element.find(".c-card__title")
			const title = this.Title ? this.Title : alert.title
			$(titleElement).html(title)

			// Icon
			const iconElement = this.Element.find(".alert-widget-icon")
			$(iconElement).addClass(
				"glyphicons-" + getAlertIcon(alert.type)
			)

			// Display the count
			const countElement = this.Element.find(".c-card__text--strong")
			if (alert.count == 0)
				$(countElement).html(0)
			else
				this.AnimateNumber(countElement, alert.count)
			countElement.css("color", "var(--" + getAlertColor(alert.type) + ")")
			this.Element.find(".grid-stack-item-content").css(
				"border-left",
				"5px solid var(--" + getAlertColor(alert.type) + ")"
			)

			// Set the click event
			const target = this.Element.find(".alert-widget-target")
			$(target).attr("href", alert.url)
		}
		else
		{
			// If the protection provided by Genio is bypassed
			const content = this.Element.find(".widget-content")
			$(content).addClass("empty-alert-widget")
			$(content).html(
				'<i class="glyphicons glyphicons-alert c-sidebar__alert-icon"></i>'
			)
		}
	}
}

/**
 * Menu widget.
 */
class QMenuWidget extends QWidget
{
	constructor(dashboard, props)
	{
		super(dashboard, props)

		this.RenderWidgetEndpoint = this.Dashboard.UrlActions.RenderMenuWidget
		this.RenderParams = { type: this.Type, widgetId: this.id }
	}

	Init()
	{
		Object.getPrototypeOf(QMenuWidget.prototype).Init.call(this)
	}

	GetTagName()
	{
		return "menu-widget"
	}

	UpdateUI(_bookmark)
	{
		// EMPTY
	}
}

/**
 * Custom widget.
 */
class QCustomWidget extends QWidget
{
	constructor(dashboard, props)
	{
		super(dashboard, props)

		this.RenderWidgetEndpoint =
			this.Dashboard.UrlActions.RenderWidget + this.id

		if (this.rowkey)
			this.RenderParams = { fk: this.rowkey }
		else
			this.RenderParams = { fk: this.id }
	}

	Init()
	{
		Object.getPrototypeOf(QCustomWidget.prototype).Init.call(this)

		const resizeObserver = new ResizeObserver((entry) =>
		{
			const container = entry[0].target
			const hc = $(container).find(".highcharts-container.container-fluid")

			if (window["hc_instances"])
			{
				const potentialChart = window["hc_instances"][$(hc).attr("id")]
				if (potentialChart)
					potentialChart.reflow()
			}
		})

		resizeObserver.observe(this.Element[0])
	}

	GetTagName()
	{
		return "custom-widget"
	}

	Refresh()
	{
		// TODO: check if this should be removed to improve accessibility
		const refreshBtn = this.Element.find(".widget-refresh-btn")
		refreshBtn.blur()

		// Custom widgets need to be re-rendered
		this.Render()
	}
}

/**
 * Paginated custom widget.
 */
class QCustomPaginatedWidget extends QWidget
{
	constructor(dashboard, props)
	{
		super(dashboard, props)

		this.RenderWidgetEndpoint =
			this.Dashboard.UrlActions.RenderWidget + this.id

		this.Pages = props.Keys
		this.CurrentPage = 0

		if (this.rowkey)
		{
			let idx = this.Pages.indexOf(this.rowkey)

			if (idx == -1)
				idx = 0
			else
				this.CurrentPage = idx
		}
	}

	Init()
	{
		Object.getPrototypeOf(QCustomPaginatedWidget.prototype).Init.call(this)

		this.PaginationControl = new QWidgetPagination(this)

		const resizeObserver = new ResizeObserver((entry) =>
		{
			const container = entry[0].target
			const hc = $(container).find(".highcharts-container.container-fluid")

			if (window["hc_instances"])
			{
				const potentialChart = window["hc_instances"][$(hc).attr("id")]
				if (potentialChart)
					potentialChart.reflow()
			}
		})

		resizeObserver.observe(this.Element[0])
	}

	Render()
	{
		this.RenderParams = { fk: this.Pages[this.CurrentPage] }

		Object.getPrototypeOf(QCustomPaginatedWidget.prototype).Render.call(this)
	}

	GetTagName()
	{
		return "custom-widget"
	}

	Refresh()
	{
		// TODO: check if this should be removed to improve accessibility
		const refreshBtn = this.Element.find(".widget-refresh-btn")
		refreshBtn.blur()

		// Custom widgets need to be re-rendered
		this.Render()
	}

	GetRowkey()
	{
		return this.Pages[this.CurrentPage]
	}

	GetTypeSpecificButtons()
	{
		// Prev button
		const prevBtn = document.createElement("button")
		prevBtn.classList.add("dashboard-action-btn")
		prevBtn.title = this.Dashboard.Texts.PREV_PAGE
		prevBtn.setAttribute("type", "button")
		prevBtn.setAttribute("role", "menuitem")
		prevBtn.setAttribute("data-slide", "prev")

		const prevIcon = document.createElement("i")
		prevIcon.classList.add("glyphicons", "glyphicons-chevron-left", "e-icon")

		prevBtn.appendChild(prevIcon)

		// Next
		const nextBtn = document.createElement("button")
		nextBtn.classList.add("dashboard-action-btn")
		nextBtn.title = this.Dashboard.Texts.NEXT_PAGE
		nextBtn.setAttribute("type", "button")
		nextBtn.setAttribute("role", "menuitem")
		nextBtn.setAttribute("data-slide", "next")

		const nextIcon = document.createElement("i")
		nextIcon.classList.add("glyphicons", "glyphicons-chevron-right", "e-icon")

		nextBtn.appendChild(nextIcon)

		// Pagination
		const el = document.createElement("ul")
		el.classList.add("custom-widget-pagination")
		el.appendChild(prevBtn)
		el.appendChild(nextBtn)

		return el
	}
}

/**
 * Widget pagination.
 */
class QWidgetPagination
{
	constructor(widget)
	{
		this.Widget = widget
		this.Element = widget.Element.find(".custom-widget-pagination")

		this.Init()
	}

	Init()
	{
		const vm = this
		const prevBtn = this.Element.find("[data-slide='prev']")
		const nextBtn = this.Element.find("[data-slide='next']")

		prevBtn.off("click")
		prevBtn.click(function ()
		{
			vm.Previous()
		})

		nextBtn.off("click")
		nextBtn.click(function ()
		{
			vm.Next()
		})

		this.UpdateUI()
	}

	Next()
	{
		if (this.Widget.Pages.length > this.Widget.CurrentPage + 1)
		{
			this.Widget.CurrentPage++

			this.Widget.Render()
			this.Widget.Dashboard.SetDirty()
		}
	}

	Previous()
	{
		if (this.Widget.CurrentPage > 0)
		{
			this.Widget.CurrentPage--

			this.Widget.Render()
			this.Widget.Dashboard.SetDirty()
		}
	}

	UpdateUI()
	{
		const label = this.Element.find("span")
		const prevBtn = this.Element.find("[data-slide='prev']")
		const nextBtn = this.Element.find("[data-slide='next']")

		$(prevBtn).removeClass("disabled")
		$(prevBtn).removeClass("disabled")

		if (this.Widget.CurrentPage == 0)
			$(prevBtn).addClass("disabled")

		if (this.Widget.CurrentPage + 1 == this.Widget.Pages.length)
			$(nextBtn).addClass("disabled")

		label.text(
			this.Widget.CurrentPage +
			1 +
			" " +
			this.Widget.Dashboard.Texts.OF +
			" " +
			this.Widget.Pages.length
		)
	}
}
