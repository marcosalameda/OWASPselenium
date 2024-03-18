// eslint-disable-next-line no-unused-vars
import { defineAsyncComponent } from 'vue'

export default {
	// eslint-disable-next-line no-unused-vars
	install: (app) => {
		app.component('QFormGrpbPseudtblb', defineAsyncComponent(() => import('@/views/forms/FormGrpb/QFormGrpbPseudtblb.vue')))
	}
}
