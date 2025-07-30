// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { defineAsyncComponent } from 'vue'

export default {
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	install: (app) => {
		app.component('QGridFormFldscondpseudgridtbl', defineAsyncComponent(() => import('@/views/forms/FormFldscond/QGridFormFldscondpseudgridtbl.vue')))
		app.component('QGridFormGrpbPseudtblb', defineAsyncComponent(() => import('@/views/forms/FormGrpb/QGridFormGrpbPseudtblb.vue')))
	}
}
