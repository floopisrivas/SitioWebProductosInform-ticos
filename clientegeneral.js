gx.evt.autoSkip=!1;gx.define("clientegeneral",!0,function(n){this.ServerClass="clientegeneral";this.PackageName="GeneXus.Programs";this.ServerFullClass="clientegeneral.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){};this.Valid_Clienteid=function(){return this.validCliEvt("Valid_Clienteid",0,function(){try{var n=gx.util.balloon.getNew("CLIENTEID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Personaid=function(){return this.validCliEvt("Valid_Personaid",0,function(){try{var n=gx.util.balloon.getNew("PERSONAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Provinciaid=function(){return this.validCliEvt("Valid_Provinciaid",0,function(){try{var n=gx.util.balloon.getNew("PROVINCIAID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.Valid_Ciudadid=function(){return this.validCliEvt("Valid_Ciudadid",0,function(){try{var n=gx.util.balloon.getNew("CIUDADID");this.AnyError=0}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e11201_client=function(){return this.clearMessages(),this.call("cliente.aspx",["UPD",this.A21ClienteId],null,["Mode","ClienteId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e12201_client=function(){return this.clearMessages(),this.call("cliente.aspx",["DLT",this.A21ClienteId],null,["Mode","ClienteId"]),this.refreshOutputs([]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e15202_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e16202_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73];this.GXLastCtrlId=73;t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"BTNUPDATE",grid:0,evt:"e11201_client"};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"BTNDELETE",grid:0,evt:"e12201_client"};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"ATTRIBUTESTABLE",grid:0};t[14]={id:14,fld:"",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[17]={id:17,fld:"",grid:0};t[18]={id:18,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Clienteid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEID",gxz:"Z21ClienteId",gxold:"O21ClienteId",gxvar:"A21ClienteId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A21ClienteId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z21ClienteId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CLIENTEID",gx.O.A21ClienteId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A21ClienteId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CLIENTEID",",")},nac:gx.falseFn};this.declareDomainHdlr(18,function(){});t[19]={id:19,fld:"",grid:0};t[20]={id:20,fld:"",grid:0};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,lvl:0,type:"svchar",len:80,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CLIENTEDESCRIPCION",gxz:"Z22ClienteDescripcion",gxold:"O22ClienteDescripcion",gxvar:"A22ClienteDescripcion",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A22ClienteDescripcion=n)},v2z:function(n){n!==undefined&&(gx.O.Z22ClienteDescripcion=n)},v2c:function(){gx.fn.setControlValue("CLIENTEDESCRIPCION",gx.O.A22ClienteDescripcion,0)},c2v:function(){this.val()!==undefined&&(gx.O.A22ClienteDescripcion=this.val())},val:function(){return gx.fn.getControlValue("CLIENTEDESCRIPCION")},nac:gx.falseFn};t[24]={id:24,fld:"",grid:0};t[25]={id:25,fld:"",grid:0};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Personaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERSONAID",gxz:"Z11PersonaId",gxold:"O11PersonaId",gxvar:"A11PersonaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A11PersonaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z11PersonaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PERSONAID",gx.O.A11PersonaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A11PersonaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PERSONAID",",")},nac:gx.falseFn};this.declareDomainHdlr(28,function(){});t[29]={id:29,fld:"",grid:0};t[30]={id:30,fld:"",grid:0};t[31]={id:31,fld:"",grid:0};t[32]={id:32,fld:"",grid:0};t[33]={id:33,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERSONANOMBRE",gxz:"Z12PersonaNombre",gxold:"O12PersonaNombre",gxvar:"A12PersonaNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A12PersonaNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z12PersonaNombre=n)},v2c:function(){gx.fn.setControlValue("PERSONANOMBRE",gx.O.A12PersonaNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A12PersonaNombre=this.val())},val:function(){return gx.fn.getControlValue("PERSONANOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(33,function(){});t[34]={id:34,fld:"",grid:0};t[35]={id:35,fld:"",grid:0};t[36]={id:36,fld:"",grid:0};t[37]={id:37,fld:"",grid:0};t[38]={id:38,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PERSONAAPELLIDO",gxz:"Z13PersonaApellido",gxold:"O13PersonaApellido",gxvar:"A13PersonaApellido",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A13PersonaApellido=n)},v2z:function(n){n!==undefined&&(gx.O.Z13PersonaApellido=n)},v2c:function(){gx.fn.setControlValue("PERSONAAPELLIDO",gx.O.A13PersonaApellido,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A13PersonaApellido=this.val())},val:function(){return gx.fn.getControlValue("PERSONAAPELLIDO")},nac:gx.falseFn};this.declareDomainHdlr(38,function(){});t[39]={id:39,fld:"",grid:0};t[40]={id:40,fld:"",grid:0};t[41]={id:41,fld:"",grid:0};t[42]={id:42,fld:"",grid:0};t[43]={id:43,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"FECHANACIMIENTO",gxz:"Z14FechaNacimiento",gxold:"O14FechaNacimiento",gxvar:"A14FechaNacimiento",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A14FechaNacimiento=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z14FechaNacimiento=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("FECHANACIMIENTO",gx.O.A14FechaNacimiento,0)},c2v:function(){this.val()!==undefined&&(gx.O.A14FechaNacimiento=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("FECHANACIMIENTO")},nac:gx.falseFn};t[44]={id:44,fld:"",grid:0};t[45]={id:45,fld:"",grid:0};t[46]={id:46,fld:"",grid:0};t[47]={id:47,fld:"",grid:0};t[48]={id:48,lvl:0,type:"int",len:8,dec:0,sign:!1,pic:"ZZZZZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"DNI",gxz:"Z15DNI",gxold:"O15DNI",gxvar:"A15DNI",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A15DNI=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z15DNI=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("DNI",gx.O.A15DNI,0)},c2v:function(){this.val()!==undefined&&(gx.O.A15DNI=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("DNI",",")},nac:gx.falseFn};t[49]={id:49,fld:"",grid:0};t[50]={id:50,fld:"",grid:0};t[51]={id:51,fld:"",grid:0};t[52]={id:52,fld:"",grid:0};t[53]={id:53,lvl:0,type:"svchar",len:100,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"EMAIL",gxz:"Z18Email",gxold:"O18Email",gxvar:"A18Email",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A18Email=n)},v2z:function(n){n!==undefined&&(gx.O.Z18Email=n)},v2c:function(){gx.fn.setControlValue("EMAIL",gx.O.A18Email,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A18Email=this.val())},val:function(){return gx.fn.getControlValue("EMAIL")},nac:gx.falseFn};this.declareDomainHdlr(53,function(){gx.fn.setCtrlProperty("EMAIL","Link",gx.fn.getCtrlProperty("EMAIL","Enabled")?"":"mailto:"+this.A18Email)});t[54]={id:54,fld:"",grid:0};t[55]={id:55,fld:"",grid:0};t[56]={id:56,fld:"",grid:0};t[57]={id:57,fld:"",grid:0};t[58]={id:58,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Provinciaid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVINCIAID",gxz:"Z25ProvinciaId",gxold:"O25ProvinciaId",gxvar:"A25ProvinciaId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A25ProvinciaId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z25ProvinciaId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PROVINCIAID",gx.O.A25ProvinciaId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A25ProvinciaId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PROVINCIAID",",")},nac:gx.falseFn};this.declareDomainHdlr(58,function(){});t[59]={id:59,fld:"",grid:0};t[60]={id:60,fld:"",grid:0};t[61]={id:61,fld:"",grid:0};t[62]={id:62,fld:"",grid:0};t[63]={id:63,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PROVNOMBRE",gxz:"Z29ProvNombre",gxold:"O29ProvNombre",gxvar:"A29ProvNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A29ProvNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z29ProvNombre=n)},v2c:function(){gx.fn.setControlValue("PROVNOMBRE",gx.O.A29ProvNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A29ProvNombre=this.val())},val:function(){return gx.fn.getControlValue("PROVNOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(63,function(){});t[64]={id:64,fld:"",grid:0};t[65]={id:65,fld:"",grid:0};t[66]={id:66,fld:"",grid:0};t[67]={id:67,fld:"",grid:0};t[68]={id:68,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:this.Valid_Ciudadid,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CIUDADID",gxz:"Z27CiudadId",gxold:"O27CiudadId",gxvar:"A27CiudadId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A27CiudadId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27CiudadId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("CIUDADID",gx.O.A27CiudadId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A27CiudadId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("CIUDADID",",")},nac:gx.falseFn};this.declareDomainHdlr(68,function(){});t[69]={id:69,fld:"",grid:0};t[70]={id:70,fld:"",grid:0};t[71]={id:71,fld:"",grid:0};t[72]={id:72,fld:"",grid:0};t[73]={id:73,lvl:0,type:"svchar",len:40,dec:0,sign:!1,ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"CIUDNOMBRE",gxz:"Z30CiudNombre",gxold:"O30CiudNombre",gxvar:"A30CiudNombre",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A30CiudNombre=n)},v2z:function(n){n!==undefined&&(gx.O.Z30CiudNombre=n)},v2c:function(){gx.fn.setControlValue("CIUDNOMBRE",gx.O.A30CiudNombre,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A30CiudNombre=this.val())},val:function(){return gx.fn.getControlValue("CIUDNOMBRE")},nac:gx.falseFn};this.declareDomainHdlr(73,function(){});this.A21ClienteId=0;this.Z21ClienteId=0;this.O21ClienteId=0;this.A22ClienteDescripcion="";this.Z22ClienteDescripcion="";this.O22ClienteDescripcion="";this.A11PersonaId=0;this.Z11PersonaId=0;this.O11PersonaId=0;this.A12PersonaNombre="";this.Z12PersonaNombre="";this.O12PersonaNombre="";this.A13PersonaApellido="";this.Z13PersonaApellido="";this.O13PersonaApellido="";this.A14FechaNacimiento=gx.date.nullDate();this.Z14FechaNacimiento=gx.date.nullDate();this.O14FechaNacimiento=gx.date.nullDate();this.A15DNI=0;this.Z15DNI=0;this.O15DNI=0;this.A18Email="";this.Z18Email="";this.O18Email="";this.A25ProvinciaId=0;this.Z25ProvinciaId=0;this.O25ProvinciaId=0;this.A29ProvNombre="";this.Z29ProvNombre="";this.O29ProvNombre="";this.A27CiudadId=0;this.Z27CiudadId=0;this.O27CiudadId=0;this.A30CiudNombre="";this.Z30CiudNombre="";this.O30CiudNombre="";this.A21ClienteId=0;this.A22ClienteDescripcion="";this.A11PersonaId=0;this.A12PersonaNombre="";this.A13PersonaApellido="";this.A14FechaNacimiento=gx.date.nullDate();this.A15DNI=0;this.A18Email="";this.A25ProvinciaId=0;this.A29ProvNombre="";this.A27CiudadId=0;this.A30CiudNombre="";this.Events={e15202_client:["ENTER",!0],e16202_client:["CANCEL",!0],e11201_client:["'DOUPDATE'",!1],e12201_client:["'DODELETE'",!1]};this.EvtParms.REFRESH=[[{av:"A21ClienteId",fld:"CLIENTEID",pic:"ZZZ9"}],[]];this.EvtParms.START=[[{av:"AV13Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6ClienteId",fld:"vCLIENTEID",pic:"ZZZ9"}],[]];this.EvtParms.LOAD=[[],[]];this.EvtParms["'DOUPDATE'"]=[[{av:"A21ClienteId",fld:"CLIENTEID",pic:"ZZZ9"}],[]];this.EvtParms["'DODELETE'"]=[[{av:"A21ClienteId",fld:"CLIENTEID",pic:"ZZZ9"}],[]];this.EvtParms.VALID_CLIENTEID=[[],[]];this.EvtParms.VALID_PERSONAID=[[],[]];this.EvtParms.VALID_PROVINCIAID=[[],[]];this.EvtParms.VALID_CIUDADID=[[],[]];this.Initialize()})