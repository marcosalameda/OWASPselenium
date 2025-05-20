interface VueContext {
	Resources: Record<string, object>
}

class UsersTexts
{
	private readonly resources: Record<string, object>

	constructor(vueContext: VueContext)
	{
		this.resources = vueContext.Resources
	}
		get assignRolesQuickly() {
			return this.resources.ATRIBUIR_RAPIDAMENTE15967
		}
		get selectUsers() {
			return this.resources._1__SELECIONE_UTILIZ36383
		}
		get selectRoles() {
			return this.resources._2__SELECIONE_FUNCOE01301
		}
		get reviewAndConfirm() {
			return this.resources._3__REVEJA_E_CONFIRM63315
		}
		get selectUsersTitle() {
			return this.resources.SELECIONAR_UTILIZADO21626
		}
		get addUsers() {
			return this.resources.ADICIONAR_UTILIZADOR22913
		}
		get clearSelection() {
			return this.resources.LIMPAR_SELECAO41464
		}
		get selectRolesTitle() {
			return this.resources.SELECIONAR_FUNCOES46892
		}
		get addRoles() {
			return this.resources.ADICIONAR_FUNCOES60841
		}
		get rolesPreviewTitle() {
			return this.resources.PRE_VISUALIZACAO_DE_00891
		}
		get removeRoles() {
			return this.resources.REMOVER_FUNCOES01798
		}
		get clearPreview() {
			return this.resources.LIMPAR_PRE_VISUALIZA29077
		}
		get assignmentReport() {
			return this.resources.RELATORIO_DE_ATRIBUI30810
		}
		get numberOfRoles() {
			return this.resources.NO_DE_FUNCOES46075
		}
		get registrationDate() {
			return this.resources.DATA_DE_REGISTO14978
		}
		get allUsers() {
			return this.resources.TODOS_OS_UTILIZADORE41512
		}
		get searchUser() {
			return this.resources.PESQUISAR_UTILIZADOR60804
		}
		get userRoles() {
			return this.resources.USER_ROLES25359
		}
		get roleAlreadyAssigned() {
			return this.resources.FUNCAO_AT_ROLE_JA_TINH60074
		}
		get roleNotAssigned() {
			return this.resources.FUNCAO_AT_ROLE_NAO_EST14526
		}
		get accessManagementReport() {
			return this.resources.RELATORIO_DE_GESTAO_29557
		}
		get redundantPermissionsWarning() {
			return this.resources.ATENCAO__ALGUMAS_PER50140
		}
		get roleIgnoredDueTo() {
			return this.resources.CHILD_FOI_IGNORADO_D53929
		}

}

export {
	UsersTexts
}
