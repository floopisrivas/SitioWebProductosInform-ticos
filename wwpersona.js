gx.evt.autoSkip=!1;gx.define("wwpersona",!1,function(){var n,t;this.ServerClass="wwpersona";this.PackageName="GeneXus.Programs";this.ServerFullClass="wwpersona.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A11PersonaId=gx.fn.getIntegerValue("PERSONAID",",")};this.e112e2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e152e2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e162e2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,20,21,23,24,25,26,27,28,29,30,31,32,33];this.GXLastCtrlId=33;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",22,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"wwpersona",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.GridContainer;t.addSingleLineEdit(12,23,"PERSONANOMBRE","Nombre","","PersonaNombre","svchar",0,"px",40,40,"left",null,[],12,"PersonaNombre",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(13,24,"PERSONAAPELLIDO","Apellido","","PersonaApellido","svchar",0,"px",40,40,"left",null,[],13,"PersonaApellido",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(14,25,"FECHANACIMIENTO","Nacimiento","","FechaNacimiento","date",0,"px",8,8,"right",null,[],14,"FechaNacimiento",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(15,26,"DNI","DNI","","DNI","int",0,"px",8,8,"right",null,[],15,"DNI",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(17,27,"TELEFONO","Telefono","","Telefono","char",0,"px",20,20,"left",null,[],17,"Telefono",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(18,28,"EMAIL","Email","","Email","svchar",0,"px",100,80,"left",null,[],18,"Email",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(29,29,"PROVNOMBRE","Prov Nombre","","ProvNombre","svchar",0,"px",40,40,"left",null,[],29,"ProvNombre",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(30,30,"CIUDNOMBRE","Ciud Nombre","","CiudNombre","svchar",0,"px",40,40,"left",null,[],30,"CiudNombre",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit(24,31,"PAISNOMBRE","Pais Nombre","","PaisNombre","svchar",0,"px",40,40,"left",null,[],24,"PaisNombre",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");t.addSingleLineEdit("Update",32,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");t.addSingleLineEdit("Delete",33,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"TABLETOP",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"TITLETEXT",format:0,grid:0,ctrltype:"textblock"};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"",grid:0};n[13]={id:13,fld:"BTNINSERT",grid:0,evt:"e112e2_client"};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"GRIDCELL",grid:0};n[16]={id:16,fld:"GRIDTABLE",grid:0};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[23]={id:23,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERSONANOMBRE",gxz:"Z12PersonaNombre",gxold:"O12PersonaNombre",gxvar:"A12PersonaNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A12PersonaNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z12PersonaNombre=n)},v2c:function(n){gx.fn.setGridControlValue("PERSONANOMBRE",n||gx.fn.currentGridRowImpl(22),gx.O.A12PersonaNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A12PersonaNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PERSONANOMBRE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[24]={id:24,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERSONAAPELLIDO",gxz:"Z13PersonaApellido",gxold:"O13PersonaApellido",gxvar:"A13PersonaApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A13PersonaApellido=n)},v2z:function(n){n!==undefined&&(gx.O.Z13PersonaApellido=n)},v2c:function(n){gx.fn.setGridControlValue("PERSONAAPELLIDO",n||gx.fn.currentGridRowImpl(22),gx.O.A13PersonaApellido,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A13PersonaApellido=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PERSONAAPELLIDO",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[25]={id:25,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHANACIMIENTO",gxz:"Z14FechaNacimiento",gxold:"O14FechaNacimiento",gxvar:"A14FechaNacimiento",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A14FechaNacimiento=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z14FechaNacimiento=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("FECHANACIMIENTO",n||gx.fn.currentGridRowImpl(22),gx.O.A14FechaNacimiento,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A14FechaNacimiento=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("FECHANACIMIENTO",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[26]={id:26,lvl:2,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DNI",gxz:"Z15DNI",gxold:"O15DNI",gxvar:"A15DNI",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"number",v2v:function(n){n!==undefined&&(gx.O.A15DNI=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15DNI=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("DNI",n||gx.fn.currentGridRowImpl(22),gx.O.A15DNI,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A15DNI=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("DNI",n||gx.fn.currentGridRowImpl(22),",")},nac:gx.falseFn};n[27]={id:27,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TELEFONO",gxz:"Z17Telefono",gxold:"O17Telefono",gxvar:"A17Telefono",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"tel",v2v:function(n){n!==undefined&&(gx.O.A17Telefono=n)},v2z:function(n){n!==undefined&&(gx.O.Z17Telefono=n)},v2c:function(n){gx.fn.setGridControlValue("TELEFONO",n||gx.fn.currentGridRowImpl(22),gx.O.A17Telefono,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A17Telefono=this.val(n))},val:function(n){return gx.fn.getGridControlValue("TELEFONO",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[28]={id:28,lvl:2,type:"svchar",len:100,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMAIL",gxz:"Z18Email",gxold:"O18Email",gxvar:"A18Email",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"email",v2v:function(n){n!==undefined&&(gx.O.A18Email=n)},v2z:function(n){n!==undefined&&(gx.O.Z18Email=n)},v2c:function(n){gx.fn.setGridControlValue("EMAIL",n||gx.fn.currentGridRowImpl(22),gx.O.A18Email,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A18Email=this.val(n))},val:function(n){return gx.fn.getGridControlValue("EMAIL",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[29]={id:29,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVNOMBRE",gxz:"Z29ProvNombre",gxold:"O29ProvNombre",gxvar:"A29ProvNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A29ProvNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z29ProvNombre=n)},v2c:function(n){gx.fn.setGridControlValue("PROVNOMBRE",n||gx.fn.currentGridRowImpl(22),gx.O.A29ProvNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A29ProvNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PROVNOMBRE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[30]={id:30,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CIUDNOMBRE",gxz:"Z30CiudNombre",gxold:"O30CiudNombre",gxvar:"A30CiudNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A30CiudNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z30CiudNombre=n)},v2c:function(n){gx.fn.setGridControlValue("CIUDNOMBRE",n||gx.fn.currentGridRowImpl(22),gx.O.A30CiudNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A30CiudNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("CIUDNOMBRE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[31]={id:31,lvl:2,type:"svchar",len:40,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PAISNOMBRE",gxz:"Z24PaisNombre",gxold:"O24PaisNombre",gxvar:"A24PaisNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A24PaisNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z24PaisNombre=n)},v2c:function(n){gx.fn.setGridControlValue("PAISNOMBRE",n||gx.fn.currentGridRowImpl(22),gx.O.A24PaisNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A24PaisNombre=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PAISNOMBRE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[32]={id:32,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV11Update",gxold:"OV11Update",gxvar:"AV11Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV11Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV11Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22),gx.O.AV11Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV11Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};n[33]={id:33,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:22,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV12Delete",gxold:"OV12Delete",gxvar:"AV12Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV12Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV12Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22),gx.O.AV12Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV12Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(22))},nac:gx.falseFn};this.Z12PersonaNombre="";this.O12PersonaNombre="";this.Z13PersonaApellido="";this.O13PersonaApellido="";this.Z14FechaNacimiento=gx.date.nullDate();this.O14FechaNacimiento=gx.date.nullDate();this.Z15DNI=0;this.O15DNI=0;this.Z17Telefono="";this.O17Telefono="";this.Z18Email="";this.O18Email="";this.Z29ProvNombre="";this.O29ProvNombre="";this.Z30CiudNombre="";this.O30CiudNombre="";this.Z24PaisNombre="";this.O24PaisNombre="";this.ZV11Update="";this.OV11Update="";this.ZV12Delete="";this.OV12Delete="";this.A11PersonaId=0;this.A25ProvinciaId=0;this.A23PaisId=0;this.A27CiudadId=0;this.A12PersonaNombre="";this.A13PersonaApellido="";this.A14FechaNacimiento=gx.date.nullDate();this.A15DNI=0;this.A17Telefono="";this.A18Email="";this.A29ProvNombre="";this.A30CiudNombre="";this.A24PaisNombre="";this.AV11Update="";this.AV12Delete="";this.Events={e112e2_client:["'DOINSERT'",!0],e152e2_client:["ENTER",!0],e162e2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.START=[[{av:"AV16Pgmname",fld:"vPGMNAME",pic:""}],[{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["GRID.LOAD"]=[[{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV11Update",fld:"vUPDATE",pic:""},{av:"AV12Delete",fld:"vDELETE",pic:""},{av:"A11PersonaId",fld:"PERSONAID",pic:"ZZZ9",hsh:!0}],[]];this.setVCMap("A11PersonaId","PERSONAID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});t.addRefreshingVar({rfrVar:"AV11Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingVar({rfrVar:"AV12Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingVar({rfrVar:"A11PersonaId"});t.addRefreshingParm({rfrVar:"AV11Update",rfrProp:"Value",gxAttId:"Update"});t.addRefreshingParm({rfrVar:"AV12Delete",rfrProp:"Value",gxAttId:"Delete"});t.addRefreshingParm({rfrVar:"A11PersonaId"});this.Initialize()});gx.wi(function(){gx.createParentObj(this.wwpersona)})