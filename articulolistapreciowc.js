gx.evt.autoSkip=!1;gx.define("articulolistapreciowc",!0,function(n){var t,i;this.ServerClass="articulolistapreciowc";this.PackageName="GeneXus.Programs";this.ServerFullClass="articulolistapreciowc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV6ArticuloId=gx.fn.getIntegerValue("vARTICULOID",",");this.AV6ArticuloId=gx.fn.getIntegerValue("vARTICULOID",",")};this.e111d2_client=function(){return this.executeServerEvent("'DOINSERT'",!1,null,!1,!1)};this.e141d2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e151d2_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,18,19,21,22,23,24,25,26,27,28,29];this.GXLastCtrlId=29;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",20,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"articulolistapreciowc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(62,21,"LISTAFECHA","Fecha","","ListaFecha","date",0,"px",8,8,"right",null,[],62,"ListaFecha",!0,0,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(73,22,"PRECIOCOSTOARTICULO","Costo Articulo","","PrecioCostoArticulo","decimal",0,"px",8,8,"right",null,[],73,"PrecioCostoArticulo",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit(77,23,"PRECIOVENTA","Venta","","PrecioVenta","decimal",0,"px",8,8,"right",null,[],77,"PrecioVenta",!0,2,!1,!1,"Attribute",1,"WWColumn WWOptionalColumn");i.addSingleLineEdit("Update",24,"vUPDATE","","","Update","char",0,"px",20,20,"left",null,[],"Update","Update",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");i.addSingleLineEdit("Delete",25,"vDELETE","","","Delete","char",0,"px",20,20,"left",null,[],"Delete","Delete",!0,0,!1,!1,"TextActionAttribute",1,"WWTextActionColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"",grid:0};t[6]={id:6,fld:"TABLETOP",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[9]={id:9,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"BTNINSERT",grid:0,evt:"e111d2_client"};t[12]={id:12,fld:"",grid:0};t[13]={id:13,fld:"GRIDCELL",grid:0};t[14]={id:14,fld:"GRIDTABLE",grid:0};t[15]={id:15,fld:"",grid:0};t[16]={id:16,fld:"",grid:0};t[18]={id:18,fld:"",grid:0};t[19]={id:19,fld:"",grid:0};t[21]={id:21,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"LISTAFECHA",gxz:"Z62ListaFecha",gxold:"O62ListaFecha",gxvar:"A62ListaFecha",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A62ListaFecha=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z62ListaFecha=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("LISTAFECHA",n||gx.fn.currentGridRowImpl(20),gx.O.A62ListaFecha,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A62ListaFecha=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("LISTAFECHA",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[22]={id:22,lvl:2,type:"decimal",len:8,dec:2,sign:!1,pic:"ZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOCOSTOARTICULO",gxz:"Z73PrecioCostoArticulo",gxold:"O73PrecioCostoArticulo",gxvar:"A73PrecioCostoArticulo",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A73PrecioCostoArticulo=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z73PrecioCostoArticulo=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRECIOCOSTOARTICULO",n||gx.fn.currentGridRowImpl(20),gx.O.A73PrecioCostoArticulo,2,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A73PrecioCostoArticulo=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRECIOCOSTOARTICULO",n||gx.fn.currentGridRowImpl(20),",",".")},nac:gx.falseFn};t[23]={id:23,lvl:2,type:"decimal",len:8,dec:2,sign:!1,pic:"ZZZZ9.99",ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRECIOVENTA",gxz:"Z77PrecioVenta",gxold:"O77PrecioVenta",gxvar:"A77PrecioVenta",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A77PrecioVenta=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z77PrecioVenta=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRECIOVENTA",n||gx.fn.currentGridRowImpl(20),gx.O.A77PrecioVenta,2,".")},c2v:function(n){this.val(n)!==undefined&&(gx.O.A77PrecioVenta=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRECIOVENTA",n||gx.fn.currentGridRowImpl(20),",",".")},nac:gx.falseFn};t[24]={id:24,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vUPDATE",gxz:"ZV13Update",gxold:"OV13Update",gxvar:"AV13Update",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV13Update=n)},v2z:function(n){n!==undefined&&(gx.O.ZV13Update=n)},v2c:function(n){gx.fn.setGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20),gx.O.AV13Update,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV13Update=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vUPDATE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[25]={id:25,lvl:2,type:"char",len:20,dec:0,sign:!1,ro:1,isacc:0,grid:20,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vDELETE",gxz:"ZV14Delete",gxold:"OV14Delete",gxvar:"AV14Delete",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.AV14Delete=n)},v2z:function(n){n!==undefined&&(gx.O.ZV14Delete=n)},v2c:function(n){gx.fn.setGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20),gx.O.AV14Delete,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.AV14Delete=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vDELETE",n||gx.fn.currentGridRowImpl(20))},nac:gx.falseFn};t[26]={id:26,fld:"",grid:0};t[27]={id:27,fld:"",grid:0};t[28]={id:28,fld:"",grid:0};t[29]={id:29,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"ARTICULOID",gxz:"Z1ArticuloId",gxold:"O1ArticuloId",gxvar:"A1ArticuloId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A1ArticuloId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1ArticuloId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("ARTICULOID",gx.O.A1ArticuloId,0);typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(){this.val()!==undefined&&(gx.O.A1ArticuloId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("ARTICULOID",",")},nac:gx.falseFn};this.declareDomainHdlr(29,function(){});this.Z62ListaFecha=gx.date.nullDate();this.O62ListaFecha=gx.date.nullDate();this.Z73PrecioCostoArticulo=0;this.O73PrecioCostoArticulo=0;this.Z77PrecioVenta=0;this.O77PrecioVenta=0;this.ZV13Update="";this.OV13Update="";this.ZV14Delete="";this.OV14Delete="";this.A1ArticuloId=0;this.Z1ArticuloId=0;this.O1ArticuloId=0;this.A1ArticuloId=0;this.AV6ArticuloId=0;this.A62ListaFecha=gx.date.nullDate();this.A73PrecioCostoArticulo=0;this.A77PrecioVenta=0;this.AV13Update="";this.AV14Delete="";this.Events={e111d2_client:["'DOINSERT'",!0],e141d2_client:["ENTER",!0],e151d2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.START=[[{av:"AV17Pgmname",fld:"vPGMNAME",pic:""},{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"}],[{ctrl:"GRID",prop:"Rows"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:'gx.fn.getCtrlProperty("ARTICULOID","Visible")',ctrl:"ARTICULOID",prop:"Visible"}]];this.EvtParms["GRID.LOAD"]=[[{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"A62ListaFecha",fld:"LISTAFECHA",pic:"",hsh:!0}],[{av:'gx.fn.getCtrlProperty("vUPDATE","Link")',ctrl:"vUPDATE",prop:"Link"},{av:'gx.fn.getCtrlProperty("vDELETE","Link")',ctrl:"vDELETE",prop:"Link"}]];this.EvtParms["'DOINSERT'"]=[[{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"A62ListaFecha",fld:"LISTAFECHA",pic:"",hsh:!0}],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ArticuloId",fld:"vARTICULOID",pic:"ZZZ9"},{av:"AV13Update",fld:"vUPDATE",pic:""},{av:"AV14Delete",fld:"vDELETE",pic:""},{av:"sPrefix"}],[]];this.setVCMap("AV6ArticuloId","vARTICULOID",0,"int",4,0);this.setVCMap("AV6ArticuloId","vARTICULOID",0,"int",4,0);this.setVCMap("AV6ArticuloId","vARTICULOID",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6ArticuloId"});i.addRefreshingVar({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingVar({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});i.addRefreshingParm({rfrVar:"AV6ArticuloId"});i.addRefreshingParm({rfrVar:"AV13Update",rfrProp:"Value",gxAttId:"Update"});i.addRefreshingParm({rfrVar:"AV14Delete",rfrProp:"Value",gxAttId:"Delete"});this.Initialize()})