import { computed } from 'vue'

export default class CalendarResources
{
	constructor(fnGetResource)
	{
		this._fnGetResource = typeof fnGetResource !== 'function' ? resId => resId : fnGetResource
		Object.defineProperty(this, '_fnGetResource', { enumerable: false })

		this.startDate = computed(() => this._fnGetResource('DATA_DE_INICIO37610'))
		this.endDate = computed(() => this._fnGetResource('DATA_DE_FIM18270'))
		this.eventTitle = computed(() => this._fnGetResource('TITULO_DO_EVENTO64085'))
		this.eventDescription = computed(() => this._fnGetResource('DESCRICAO_DO_EVENTO47400'))
		this.yes = computed(() => this._fnGetResource('SIM28552'))
		this.cancel = computed(() => this._fnGetResource('CANCELAR49513'))
		this.move = computed(() => this._fnGetResource('MOVER62644'))
		this.duplicate = computed(() => this._fnGetResource('DUPLICAR09748'))
		this.doMoveEvent = computed(() => this._fnGetResource('PRETENDE_MOVER_O_EVE36449'))
		this.doEditEvent = computed(() => this._fnGetResource('PRETENDE_ALTERAR_O_E59231'))
		this.successfulEventEdit = computed(() => this._fnGetResource('EVENTO_ALTERADO_COM_57794'))
		this.successfulEventMove = computed(() => this._fnGetResource('EVENTO_MOVIDO_COM_SU59433'))
		this.successfulDuplication = computed(() => this._fnGetResource('DUPLICACAO_BEM_SUCED21475'))
		this.errorOnlyEventsLastLevel = computed(() => this._fnGetResource('APENAS_E_PERMITIDO_A39067'))
		this.errorProcessingRequest = computed(() => this._fnGetResource('OCORREU_UM_ERRO_AO_P53091'))
		this.close = computed(() => this._fnGetResource('FECHAR32496'))
	}
}
