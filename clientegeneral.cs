using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class clientegeneral : GXWebComponent, System.Web.SessionState.IRequiresSessionState
   {
      public clientegeneral( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
      }

      public clientegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( short aP0_ClienteId )
      {
         this.A21ClienteId = aP0_ClienteId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ClienteId");
               gxfirstwebparm_bkp = gxfirstwebparm;
               gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  dyncall( GetNextPar( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  A21ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
                  AssignAttri(sPrefix, false, "A21ClienteId", StringUtil.LTrimStr( (decimal)(A21ClienteId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A21ClienteId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ClienteId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ClienteId");
               }
               else
               {
                  if ( ! IsValidAjaxCall( false) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = gxfirstwebparm_bkp;
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA202( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ClienteGeneral";
               context.Gx_err = 0;
               WS202( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Cliente General") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 348140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20211162273151", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 348140), false, true);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientegeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A21ClienteId,4,0))}, new string[] {"ClienteId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA21ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA21ClienteId), 4, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm202( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ClienteGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente General" ;
      }

      protected void WB200( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "clientegeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ViewActionsCell", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group WWViewActions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnEnter";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "rounded", "'"+sPrefix+"'"+",false,"+"'"+"e11201_client"+"'", TempTags, "", 2, "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "BtnDelete";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "rounded", "'"+sPrefix+"'"+",false,"+"'"+"e12201_client"+"'", TempTags, "", 2, "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteId_Internalname, "Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21ClienteId), 4, 0, ".", "")), ((edtClienteId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A21ClienteId), "ZZZ9")) : context.localUtil.Format( (decimal)(A21ClienteId), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteDescripcion_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteDescripcion_Internalname, "Descripcion", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteDescripcion_Internalname, A22ClienteDescripcion, StringUtil.RTrim( context.localUtil.Format( A22ClienteDescripcion, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteDescripcion_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteDescripcion_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPersonaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPersonaId_Internalname, "Persona Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPersonaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11PersonaId), 4, 0, ".", "")), ((edtPersonaId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A11PersonaId), "ZZZ9")) : context.localUtil.Format( (decimal)(A11PersonaId), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPersonaId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPersonaId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPersonaNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPersonaNombre_Internalname, "Persona Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPersonaNombre_Internalname, A12PersonaNombre, StringUtil.RTrim( context.localUtil.Format( A12PersonaNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPersonaNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPersonaNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPersonaApellido_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtPersonaApellido_Internalname, "Persona Apellido", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPersonaApellido_Internalname, A13PersonaApellido, StringUtil.RTrim( context.localUtil.Format( A13PersonaApellido, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPersonaApellido_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPersonaApellido_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFechaNacimiento_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtFechaNacimiento_Internalname, "Fecha Nacimiento", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtFechaNacimiento_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtFechaNacimiento_Internalname, context.localUtil.Format(A14FechaNacimiento, "99/99/99"), context.localUtil.Format( A14FechaNacimiento, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFechaNacimiento_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFechaNacimiento_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_bitmap( context, edtFechaNacimiento_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFechaNacimiento_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ClienteGeneral.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDNI_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtDNI_Internalname, "DNI", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtDNI_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A15DNI), 8, 0, ".", "")), ((edtDNI_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A15DNI), "ZZZZZZZ9")) : context.localUtil.Format( (decimal)(A15DNI), "ZZZZZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDNI_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtDNI_Enabled, 0, "number", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtEmail_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtEmail_Internalname, "Email", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtEmail_Internalname, A18Email, StringUtil.RTrim( context.localUtil.Format( A18Email, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A18Email, "", "", "", edtEmail_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvinciaId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProvinciaId_Internalname, "Provincia Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProvinciaId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A25ProvinciaId), 4, 0, ".", "")), ((edtProvinciaId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A25ProvinciaId), "ZZZ9")) : context.localUtil.Format( (decimal)(A25ProvinciaId), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvinciaId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProvinciaId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProvNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProvNombre_Internalname, "Prov Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProvNombre_Internalname, A29ProvNombre, StringUtil.RTrim( context.localUtil.Format( A29ProvNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProvNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProvNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCiudadId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCiudadId_Internalname, "Ciudad Id", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCiudadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27CiudadId), 4, 0, ".", "")), ((edtCiudadId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A27CiudadId), "ZZZ9")) : context.localUtil.Format( (decimal)(A27CiudadId), "ZZZ9")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudadId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCiudadId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCiudNombre_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCiudNombre_Internalname, "Ciud Nombre", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCiudNombre_Internalname, A30CiudNombre, StringUtil.RTrim( context.localUtil.Format( A30CiudNombre, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCiudNombre_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCiudNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START202( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus C# 17_0_4-151606", 0) ;
               }
               Form.Meta.addItem("description", "Cliente General", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP200( ) ;
            }
         }
      }

      protected void WS202( )
      {
         START202( ) ;
         EVT202( ) ;
      }

      protected void EVT202( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP200( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP200( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E13202 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP200( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E14202 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP200( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP200( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE202( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm202( ) ;
            }
         }
      }

      protected void PA202( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF202( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ClienteGeneral";
         context.Gx_err = 0;
      }

      protected void RF202( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H00202 */
            pr_default.execute(0, new Object[] {A21ClienteId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A30CiudNombre = H00202_A30CiudNombre[0];
               AssignAttri(sPrefix, false, "A30CiudNombre", A30CiudNombre);
               A27CiudadId = H00202_A27CiudadId[0];
               AssignAttri(sPrefix, false, "A27CiudadId", StringUtil.LTrimStr( (decimal)(A27CiudadId), 4, 0));
               A29ProvNombre = H00202_A29ProvNombre[0];
               AssignAttri(sPrefix, false, "A29ProvNombre", A29ProvNombre);
               A25ProvinciaId = H00202_A25ProvinciaId[0];
               AssignAttri(sPrefix, false, "A25ProvinciaId", StringUtil.LTrimStr( (decimal)(A25ProvinciaId), 4, 0));
               A18Email = H00202_A18Email[0];
               n18Email = H00202_n18Email[0];
               AssignAttri(sPrefix, false, "A18Email", A18Email);
               A15DNI = H00202_A15DNI[0];
               AssignAttri(sPrefix, false, "A15DNI", StringUtil.LTrimStr( (decimal)(A15DNI), 8, 0));
               A14FechaNacimiento = H00202_A14FechaNacimiento[0];
               n14FechaNacimiento = H00202_n14FechaNacimiento[0];
               AssignAttri(sPrefix, false, "A14FechaNacimiento", context.localUtil.Format(A14FechaNacimiento, "99/99/99"));
               A13PersonaApellido = H00202_A13PersonaApellido[0];
               AssignAttri(sPrefix, false, "A13PersonaApellido", A13PersonaApellido);
               A12PersonaNombre = H00202_A12PersonaNombre[0];
               AssignAttri(sPrefix, false, "A12PersonaNombre", A12PersonaNombre);
               A11PersonaId = H00202_A11PersonaId[0];
               n11PersonaId = H00202_n11PersonaId[0];
               AssignAttri(sPrefix, false, "A11PersonaId", StringUtil.LTrimStr( (decimal)(A11PersonaId), 4, 0));
               A22ClienteDescripcion = H00202_A22ClienteDescripcion[0];
               AssignAttri(sPrefix, false, "A22ClienteDescripcion", A22ClienteDescripcion);
               A27CiudadId = H00202_A27CiudadId[0];
               AssignAttri(sPrefix, false, "A27CiudadId", StringUtil.LTrimStr( (decimal)(A27CiudadId), 4, 0));
               A25ProvinciaId = H00202_A25ProvinciaId[0];
               AssignAttri(sPrefix, false, "A25ProvinciaId", StringUtil.LTrimStr( (decimal)(A25ProvinciaId), 4, 0));
               A18Email = H00202_A18Email[0];
               n18Email = H00202_n18Email[0];
               AssignAttri(sPrefix, false, "A18Email", A18Email);
               A15DNI = H00202_A15DNI[0];
               AssignAttri(sPrefix, false, "A15DNI", StringUtil.LTrimStr( (decimal)(A15DNI), 8, 0));
               A14FechaNacimiento = H00202_A14FechaNacimiento[0];
               n14FechaNacimiento = H00202_n14FechaNacimiento[0];
               AssignAttri(sPrefix, false, "A14FechaNacimiento", context.localUtil.Format(A14FechaNacimiento, "99/99/99"));
               A13PersonaApellido = H00202_A13PersonaApellido[0];
               AssignAttri(sPrefix, false, "A13PersonaApellido", A13PersonaApellido);
               A12PersonaNombre = H00202_A12PersonaNombre[0];
               AssignAttri(sPrefix, false, "A12PersonaNombre", A12PersonaNombre);
               A29ProvNombre = H00202_A29ProvNombre[0];
               AssignAttri(sPrefix, false, "A29ProvNombre", A29ProvNombre);
               A30CiudNombre = H00202_A30CiudNombre[0];
               AssignAttri(sPrefix, false, "A30CiudNombre", A30CiudNombre);
               /* Execute user event: Load */
               E14202 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB200( ) ;
         }
      }

      protected void send_integrity_lvl_hashes202( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ClienteGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP200( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E13202 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA21ClienteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA21ClienteId"), ".", ","));
            /* Read variables values. */
            A22ClienteDescripcion = cgiGet( edtClienteDescripcion_Internalname);
            AssignAttri(sPrefix, false, "A22ClienteDescripcion", A22ClienteDescripcion);
            A11PersonaId = (short)(context.localUtil.CToN( cgiGet( edtPersonaId_Internalname), ".", ","));
            n11PersonaId = false;
            AssignAttri(sPrefix, false, "A11PersonaId", StringUtil.LTrimStr( (decimal)(A11PersonaId), 4, 0));
            A12PersonaNombre = cgiGet( edtPersonaNombre_Internalname);
            AssignAttri(sPrefix, false, "A12PersonaNombre", A12PersonaNombre);
            A13PersonaApellido = cgiGet( edtPersonaApellido_Internalname);
            AssignAttri(sPrefix, false, "A13PersonaApellido", A13PersonaApellido);
            A14FechaNacimiento = context.localUtil.CToD( cgiGet( edtFechaNacimiento_Internalname), 1);
            n14FechaNacimiento = false;
            AssignAttri(sPrefix, false, "A14FechaNacimiento", context.localUtil.Format(A14FechaNacimiento, "99/99/99"));
            A15DNI = (int)(context.localUtil.CToN( cgiGet( edtDNI_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A15DNI", StringUtil.LTrimStr( (decimal)(A15DNI), 8, 0));
            A18Email = cgiGet( edtEmail_Internalname);
            n18Email = false;
            AssignAttri(sPrefix, false, "A18Email", A18Email);
            A25ProvinciaId = (short)(context.localUtil.CToN( cgiGet( edtProvinciaId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A25ProvinciaId", StringUtil.LTrimStr( (decimal)(A25ProvinciaId), 4, 0));
            A29ProvNombre = cgiGet( edtProvNombre_Internalname);
            AssignAttri(sPrefix, false, "A29ProvNombre", A29ProvNombre);
            A27CiudadId = (short)(context.localUtil.CToN( cgiGet( edtCiudadId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A27CiudadId", StringUtil.LTrimStr( (decimal)(A27CiudadId), 4, 0));
            A30CiudNombre = cgiGet( edtCiudNombre_Internalname);
            AssignAttri(sPrefix, false, "A30CiudNombre", A30CiudNombre);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E13202 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E13202( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E14202( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Cliente";
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ClienteId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ClienteId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "TransactionContext", "IgnitionPc"));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A21ClienteId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A21ClienteId", StringUtil.LTrimStr( (decimal)(A21ClienteId), 4, 0));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA202( ) ;
         WS202( ) ;
         WE202( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlA21ClienteId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA202( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "clientegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA202( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A21ClienteId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A21ClienteId", StringUtil.LTrimStr( (decimal)(A21ClienteId), 4, 0));
         }
         wcpOA21ClienteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA21ClienteId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A21ClienteId != wcpOA21ClienteId ) ) )
         {
            setjustcreated();
         }
         wcpOA21ClienteId = A21ClienteId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA21ClienteId = cgiGet( sPrefix+"A21ClienteId_CTRL");
         if ( StringUtil.Len( sCtrlA21ClienteId) > 0 )
         {
            A21ClienteId = (short)(context.localUtil.CToN( cgiGet( sCtrlA21ClienteId), ".", ","));
            AssignAttri(sPrefix, false, "A21ClienteId", StringUtil.LTrimStr( (decimal)(A21ClienteId), 4, 0));
         }
         else
         {
            A21ClienteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A21ClienteId_PARM"), ".", ","));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA202( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS202( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS202( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A21ClienteId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A21ClienteId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA21ClienteId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A21ClienteId_CTRL", StringUtil.RTrim( sCtrlA21ClienteId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE202( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20211162273227", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("clientegeneral.js", "?20211162273227", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         edtClienteDescripcion_Internalname = sPrefix+"CLIENTEDESCRIPCION";
         edtPersonaId_Internalname = sPrefix+"PERSONAID";
         edtPersonaNombre_Internalname = sPrefix+"PERSONANOMBRE";
         edtPersonaApellido_Internalname = sPrefix+"PERSONAAPELLIDO";
         edtFechaNacimiento_Internalname = sPrefix+"FECHANACIMIENTO";
         edtDNI_Internalname = sPrefix+"DNI";
         edtEmail_Internalname = sPrefix+"EMAIL";
         edtProvinciaId_Internalname = sPrefix+"PROVINCIAID";
         edtProvNombre_Internalname = sPrefix+"PROVNOMBRE";
         edtCiudadId_Internalname = sPrefix+"CIUDADID";
         edtCiudNombre_Internalname = sPrefix+"CIUDNOMBRE";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("Carmine");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         edtCiudNombre_Jsonclick = "";
         edtCiudNombre_Enabled = 0;
         edtCiudadId_Jsonclick = "";
         edtCiudadId_Enabled = 0;
         edtProvNombre_Jsonclick = "";
         edtProvNombre_Enabled = 0;
         edtProvinciaId_Jsonclick = "";
         edtProvinciaId_Enabled = 0;
         edtEmail_Jsonclick = "";
         edtEmail_Enabled = 0;
         edtDNI_Jsonclick = "";
         edtDNI_Enabled = 0;
         edtFechaNacimiento_Jsonclick = "";
         edtFechaNacimiento_Enabled = 0;
         edtPersonaApellido_Jsonclick = "";
         edtPersonaApellido_Enabled = 0;
         edtPersonaNombre_Jsonclick = "";
         edtPersonaNombre_Enabled = 0;
         edtPersonaId_Jsonclick = "";
         edtPersonaId_Enabled = 0;
         edtClienteDescripcion_Jsonclick = "";
         edtClienteDescripcion_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A21ClienteId',fld:'CLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E11201',iparms:[{av:'A21ClienteId',fld:'CLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E12201',iparms:[{av:'A21ClienteId',fld:'CLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[]}");
         setEventMetadata("VALID_PERSONAID","{handler:'Valid_Personaid',iparms:[]");
         setEventMetadata("VALID_PERSONAID",",oparms:[]}");
         setEventMetadata("VALID_PROVINCIAID","{handler:'Valid_Provinciaid',iparms:[]");
         setEventMetadata("VALID_PROVINCIAID",",oparms:[]}");
         setEventMetadata("VALID_CIUDADID","{handler:'Valid_Ciudadid',iparms:[]");
         setEventMetadata("VALID_CIUDADID",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A22ClienteDescripcion = "";
         A12PersonaNombre = "";
         A13PersonaApellido = "";
         A14FechaNacimiento = DateTime.MinValue;
         A18Email = "";
         A29ProvNombre = "";
         A30CiudNombre = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H00202_A21ClienteId = new short[1] ;
         H00202_A30CiudNombre = new string[] {""} ;
         H00202_A27CiudadId = new short[1] ;
         H00202_A29ProvNombre = new string[] {""} ;
         H00202_A25ProvinciaId = new short[1] ;
         H00202_A18Email = new string[] {""} ;
         H00202_n18Email = new bool[] {false} ;
         H00202_A15DNI = new int[1] ;
         H00202_A14FechaNacimiento = new DateTime[] {DateTime.MinValue} ;
         H00202_n14FechaNacimiento = new bool[] {false} ;
         H00202_A13PersonaApellido = new string[] {""} ;
         H00202_A12PersonaNombre = new string[] {""} ;
         H00202_A11PersonaId = new short[1] ;
         H00202_n11PersonaId = new bool[] {false} ;
         H00202_A22ClienteDescripcion = new string[] {""} ;
         AV7TrnContext = new SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA21ClienteId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientegeneral__default(),
            new Object[][] {
                new Object[] {
               H00202_A21ClienteId, H00202_A30CiudNombre, H00202_A27CiudadId, H00202_A29ProvNombre, H00202_A25ProvinciaId, H00202_A18Email, H00202_n18Email, H00202_A15DNI, H00202_A14FechaNacimiento, H00202_n14FechaNacimiento,
               H00202_A13PersonaApellido, H00202_A12PersonaNombre, H00202_A11PersonaId, H00202_n11PersonaId, H00202_A22ClienteDescripcion
               }
            }
         );
         AV13Pgmname = "ClienteGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ClienteGeneral";
         context.Gx_err = 0;
      }

      private short A21ClienteId ;
      private short wcpOA21ClienteId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A11PersonaId ;
      private short A25ProvinciaId ;
      private short A27CiudadId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6ClienteId ;
      private short nGXWrapped ;
      private int edtClienteId_Enabled ;
      private int edtClienteDescripcion_Enabled ;
      private int edtPersonaId_Enabled ;
      private int edtPersonaNombre_Enabled ;
      private int edtPersonaApellido_Enabled ;
      private int edtFechaNacimiento_Enabled ;
      private int A15DNI ;
      private int edtDNI_Enabled ;
      private int edtEmail_Enabled ;
      private int edtProvinciaId_Enabled ;
      private int edtProvNombre_Enabled ;
      private int edtCiudadId_Enabled ;
      private int edtCiudNombre_Enabled ;
      private int idxLst ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteDescripcion_Internalname ;
      private string edtClienteDescripcion_Jsonclick ;
      private string edtPersonaId_Internalname ;
      private string edtPersonaId_Jsonclick ;
      private string edtPersonaNombre_Internalname ;
      private string edtPersonaNombre_Jsonclick ;
      private string edtPersonaApellido_Internalname ;
      private string edtPersonaApellido_Jsonclick ;
      private string edtFechaNacimiento_Internalname ;
      private string edtFechaNacimiento_Jsonclick ;
      private string edtDNI_Internalname ;
      private string edtDNI_Jsonclick ;
      private string edtEmail_Internalname ;
      private string edtEmail_Jsonclick ;
      private string edtProvinciaId_Internalname ;
      private string edtProvinciaId_Jsonclick ;
      private string edtProvNombre_Internalname ;
      private string edtProvNombre_Jsonclick ;
      private string edtCiudadId_Internalname ;
      private string edtCiudadId_Jsonclick ;
      private string edtCiudNombre_Internalname ;
      private string edtCiudNombre_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string sCtrlA21ClienteId ;
      private DateTime A14FechaNacimiento ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n18Email ;
      private bool n14FechaNacimiento ;
      private bool n11PersonaId ;
      private bool returnInSub ;
      private string A22ClienteDescripcion ;
      private string A12PersonaNombre ;
      private string A13PersonaApellido ;
      private string A18Email ;
      private string A29ProvNombre ;
      private string A30CiudNombre ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00202_A21ClienteId ;
      private string[] H00202_A30CiudNombre ;
      private short[] H00202_A27CiudadId ;
      private string[] H00202_A29ProvNombre ;
      private short[] H00202_A25ProvinciaId ;
      private string[] H00202_A18Email ;
      private bool[] H00202_n18Email ;
      private int[] H00202_A15DNI ;
      private DateTime[] H00202_A14FechaNacimiento ;
      private bool[] H00202_n14FechaNacimiento ;
      private string[] H00202_A13PersonaApellido ;
      private string[] H00202_A12PersonaNombre ;
      private short[] H00202_A11PersonaId ;
      private bool[] H00202_n11PersonaId ;
      private string[] H00202_A22ClienteDescripcion ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private SdtTransactionContext AV7TrnContext ;
      private SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class clientegeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH00202;
          prmH00202 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00202", "SELECT T1.[ClienteId], T4.[CiudNombre], T2.[CiudadId], T3.[ProvNombre], T2.[ProvinciaId], T2.[Email], T2.[DNI], T2.[FechaNacimiento], T2.[PersonaApellido], T2.[PersonaNombre], T1.[PersonaId], T1.[ClienteDescripcion] FROM ((([Cliente] T1 LEFT JOIN [Persona] T2 ON T2.[PersonaId] = T1.[PersonaId]) LEFT JOIN [Provincia] T3 ON T3.[ProvinciaId] = T2.[ProvinciaId]) LEFT JOIN [ProvinciaCiudad] T4 ON T4.[ProvinciaId] = T2.[ProvinciaId] AND T4.[CiudadId] = T2.[CiudadId]) WHERE T1.[ClienteId] = @ClienteId ORDER BY T1.[ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00202,1, GxCacheFrequency.OFF ,true,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((short[]) buf[12])[0] = rslt.getShort(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((string[]) buf[14])[0] = rslt.getVarchar(12);
                return;
       }
    }

 }

}
