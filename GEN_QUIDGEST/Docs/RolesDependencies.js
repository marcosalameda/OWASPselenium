var model_roles = [
{"name":"A", "imports":[]}
,{"name":"ADMINISTRATOR", "imports":[["EDIT_PESSO", ""],["VIEW_PESSO", ""],["EDIT", ""],["VIEW", ""],["MANAGER", ""],["EMPLOYEE", ""],["VIEW", ""],["VIEW_PESSO", ""],["EDIT", ""],["VIEW", ""]]}
,{"name":"EDIT", "imports":[["VIEW", ""]]}
,{"name":"EDIT_PESSO", "imports":[["VIEW_PESSO", ""]]}
,{"name":"EMPLOYEE", "imports":[["VIEW", ""],["VIEW_PESSO", ""]]}
,{"name":"MANAGER", "imports":[["EMPLOYEE", ""],["VIEW", ""],["VIEW_PESSO", ""],["EDIT", ""],["VIEW", ""]]}
,{"name":"SYSADMIN", "imports":[["EDIT", ""],["VIEW", ""],["ADMINISTRATOR", ""],["EDIT_PESSO", ""],["VIEW_PESSO", ""],["EDIT", ""],["VIEW", ""],["MANAGER", ""],["EMPLOYEE", ""],["VIEW", ""],["VIEW_PESSO", ""],["EDIT", ""],["VIEW", ""]]}
,{"name":"VIEW", "imports":[]}
,{"name":"VIEW_PESSO", "imports":[]}
]