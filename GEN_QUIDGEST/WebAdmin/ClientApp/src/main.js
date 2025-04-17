import { createApp } from 'vue'
import 'bootstrap'
import QGlobal from './global'
import App from './App.vue'
import { setupRouter } from './router'
import store from './store'
import { setupI18n } from './plugins/i18n'
import ComponentsInit from './mixins/components'
import EventBus from './utils/eventBus'
import framework from './plugins/quidgest-ui'

import $ from 'jquery'
// export for others scripts to use: TODO: remove this after eliminating dependencies and testing
window.$ = $
window.jQuery = $

import '@/utils/globalUtils.js'

const app = createApp(App)

app.use(store)
app.use(framework)

const i18n = setupI18n()
app.config.globalProperties.$__i18n = i18n

app.use(i18n)

const router = setupRouter(i18n)

app.use(router)

// Init global components
ComponentsInit(app)

/* Create the Global event bus
For communicating between the components in different levels */
app.config.globalProperties.$eventHub = EventBus

// Global mixin applied to every vue instance
app.mixin({
	computed: {
		currentApp: {
			get: function () {
				if ($.isEmptyObject(this.$store)) {
					return ''
				}
				return this.$store.getters.App
			},
			set: function (newValue) {
				this.$store.dispatch('changeApp', newValue)
			}
		},

		isMultiYearApp: {
			get: function () {
				if ($.isEmptyObject(this.$store)) {
					return ''
				}
				return this.$store.getters.MultiYearStatus
			},
			set: function (newValue) {
				this.$store.dispatch('changeMultiYearStatus', newValue)
			}
		},

		currentYear: {
			get: function () {
				if ($.isEmptyObject(this.$store)) {
					return ''
				}
				return this.$store.getters.Year
			},
			set: function (newValue) {
				this.$store.dispatch('changeYear', newValue)
				this._changeRouteData(this.currentLang, newValue)
			}
		},

		currentLang: {
			get: function () {
				if ($.isEmptyObject(this.$store)) {
					return ''
				}
				return this.$store.getters.Language
			},
			set: function (newValue) {
				this.$store.dispatch('changeLanguage', newValue)
				this._changeRouteData(newValue, this.currentYear)
			}
		}
	},

	created() {
		if (this.$i18n && this.currentLang !== this.$i18n.locale) {
			this.currentLang = this.$i18n.locale
		}
		if ($.isEmptyObject(this.currentYear)) {
			this.currentYear = QGlobal.defaultSystem
		}
		if (!$.isEmptyObject(this.$route)) {
			var params = this.$route.params
			if (!$.isEmptyObject(params.culture) && this.currentLang !== params.culture)
				this.currentLang = params.culture
			if (!$.isEmptyObject(params.system) && this.currentYear !== params.system)
				this.currentYear = params.system
		}
	},

	methods: {
		_changeRouteData(culture, system) {
			var route = this.$route,
				rName = route.name,
				rParams = Object.assign({}, route.params)

			if (rParams.culture === culture && rParams.system === system) return
			if ($.isEmptyObject(rName) || rName === 'main' || rName === 'main_params') return

			rParams.culture = culture
			rParams.system = system

			this.$router.replace(
				{ name: rName, params: rParams },
				() => {},
				() => {}
			)
		}
	}
})

app.mount('#app')
