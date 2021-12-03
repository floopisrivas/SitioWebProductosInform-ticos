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
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class detallearticulo : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A1ArticuloId = (short)(NumberUtil.Val( GetPar( "ArticuloId"), "."));
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A1ArticuloId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus C# 17_0_4-151606", 0) ;
            }
            Form.Meta.addItem("description", "Detalle Articulo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDetalleArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public detallearticulo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public detallearticulo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void release( )
      {
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Detalle Articulo", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx00d0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"DETALLEARTICULOID"+"'), id:'"+"DETALLEARTICULOID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDetalleArticuloId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDetalleArticuloId_Internalname, "Articulo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDetalleArticuloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A42DetalleArticuloId), 4, 0, ".", "")), ((edtDetalleArticuloId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A42DetalleArticuloId), "ZZZ9")) : context.localUtil.Format( (decimal)(A42DetalleArticuloId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDetalleArticuloId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDetalleArticuloId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDetalleArticuloPrecioCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDetalleArticuloPrecioCosto_Internalname, "Precio Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDetalleArticuloPrecioCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A43DetalleArticuloPrecioCosto, 8, 2, ".", "")), ((edtDetalleArticuloPrecioCosto_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A43DetalleArticuloPrecioCosto, "ZZZZ9.99")) : context.localUtil.Format( A43DetalleArticuloPrecioCosto, "ZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDetalleArticuloPrecioCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDetalleArticuloPrecioCosto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Cost", "right", false, "", "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDetalleArticuloPrecioVenta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDetalleArticuloPrecioVenta_Internalname, "Precio Venta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDetalleArticuloPrecioVenta_Internalname, StringUtil.LTrim( StringUtil.NToC( A44DetalleArticuloPrecioVenta, 8, 2, ".", "")), ((edtDetalleArticuloPrecioVenta_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( A44DetalleArticuloPrecioVenta, "ZZZZ9.99")) : context.localUtil.Format( A44DetalleArticuloPrecioVenta, "ZZZZ9.99")), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDetalleArticuloPrecioVenta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDetalleArticuloPrecioVenta_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "Cost", "right", false, "", "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtArticuloId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArticuloId_Internalname, "Articulo Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtArticuloId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ArticuloId), 4, 0, ".", "")), ((edtArticuloId_Enabled!=0) ? StringUtil.LTrim( context.localUtil.Format( (decimal)(A1ArticuloId), "ZZZ9")) : context.localUtil.Format( (decimal)(A1ArticuloId), "ZZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArticuloId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtArticuloId_Enabled, 0, "number", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "Id", "right", false, "", "HLP_DetalleArticulo.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_1_Internalname, sImgUrl, imgprompt_1_Link, "", "", context.GetTheme( ), imgprompt_1_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtArticuloNombre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtArticuloNombre_Internalname, "Articulo Nombre", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtArticuloNombre_Internalname, A2ArticuloNombre, StringUtil.RTrim( context.localUtil.Format( A2ArticuloNombre, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtArticuloNombre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtArticuloNombre_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgImagen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagen", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A4Imagen_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000Imagen_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.PathToRelativeUrl( A4Imagen));
         GxWebStd.gx_bitmap( context, imgImagen_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgImagen_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A4Imagen_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_DetalleArticulo.htm");
         AssignProp("", false, imgImagen_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.PathToRelativeUrl( A4Imagen)), true);
         AssignProp("", false, imgImagen_Internalname, "IsBlob", StringUtil.BoolToStr( A4Imagen_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "rounded", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "rounded", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "rounded", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_DetalleArticulo.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z42DetalleArticuloId = (short)(context.localUtil.CToN( cgiGet( "Z42DetalleArticuloId"), ".", ","));
            Z43DetalleArticuloPrecioCosto = context.localUtil.CToN( cgiGet( "Z43DetalleArticuloPrecioCosto"), ".", ",");
            Z44DetalleArticuloPrecioVenta = context.localUtil.CToN( cgiGet( "Z44DetalleArticuloPrecioVenta"), ".", ",");
            Z1ArticuloId = (short)(context.localUtil.CToN( cgiGet( "Z1ArticuloId"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A40000Imagen_GXI = cgiGet( "IMAGEN_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtDetalleArticuloId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDetalleArticuloId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DETALLEARTICULOID");
               AnyError = 1;
               GX_FocusControl = edtDetalleArticuloId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A42DetalleArticuloId = 0;
               AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
            }
            else
            {
               A42DetalleArticuloId = (short)(context.localUtil.CToN( cgiGet( edtDetalleArticuloId_Internalname), ".", ","));
               AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDetalleArticuloPrecioCosto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDetalleArticuloPrecioCosto_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DETALLEARTICULOPRECIOCOSTO");
               AnyError = 1;
               GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A43DetalleArticuloPrecioCosto = 0;
               AssignAttri("", false, "A43DetalleArticuloPrecioCosto", StringUtil.LTrimStr( A43DetalleArticuloPrecioCosto, 8, 2));
            }
            else
            {
               A43DetalleArticuloPrecioCosto = context.localUtil.CToN( cgiGet( edtDetalleArticuloPrecioCosto_Internalname), ".", ",");
               AssignAttri("", false, "A43DetalleArticuloPrecioCosto", StringUtil.LTrimStr( A43DetalleArticuloPrecioCosto, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtDetalleArticuloPrecioVenta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDetalleArticuloPrecioVenta_Internalname), ".", ",") > 99999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DETALLEARTICULOPRECIOVENTA");
               AnyError = 1;
               GX_FocusControl = edtDetalleArticuloPrecioVenta_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A44DetalleArticuloPrecioVenta = 0;
               AssignAttri("", false, "A44DetalleArticuloPrecioVenta", StringUtil.LTrimStr( A44DetalleArticuloPrecioVenta, 8, 2));
            }
            else
            {
               A44DetalleArticuloPrecioVenta = context.localUtil.CToN( cgiGet( edtDetalleArticuloPrecioVenta_Internalname), ".", ",");
               AssignAttri("", false, "A44DetalleArticuloPrecioVenta", StringUtil.LTrimStr( A44DetalleArticuloPrecioVenta, 8, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtArticuloId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtArticuloId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARTICULOID");
               AnyError = 1;
               GX_FocusControl = edtArticuloId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1ArticuloId = 0;
               AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            }
            else
            {
               A1ArticuloId = (short)(context.localUtil.CToN( cgiGet( edtArticuloId_Internalname), ".", ","));
               AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            }
            A2ArticuloNombre = cgiGet( edtArticuloNombre_Internalname);
            AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
            A4Imagen = cgiGet( imgImagen_Internalname);
            n4Imagen = false;
            AssignAttri("", false, "A4Imagen", A4Imagen);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgImagen_Internalname, ref  A4Imagen, ref  A40000Imagen_GXI);
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A42DetalleArticuloId = (short)(NumberUtil.Val( GetPar( "DetalleArticuloId"), "."));
               AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A13( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0A13( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A13( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z43DetalleArticuloPrecioCosto = T000A3_A43DetalleArticuloPrecioCosto[0];
               Z44DetalleArticuloPrecioVenta = T000A3_A44DetalleArticuloPrecioVenta[0];
               Z1ArticuloId = T000A3_A1ArticuloId[0];
            }
            else
            {
               Z43DetalleArticuloPrecioCosto = A43DetalleArticuloPrecioCosto;
               Z44DetalleArticuloPrecioVenta = A44DetalleArticuloPrecioVenta;
               Z1ArticuloId = A1ArticuloId;
            }
         }
         if ( GX_JID == -1 )
         {
            Z42DetalleArticuloId = A42DetalleArticuloId;
            Z43DetalleArticuloPrecioCosto = A43DetalleArticuloPrecioCosto;
            Z44DetalleArticuloPrecioVenta = A44DetalleArticuloPrecioVenta;
            Z1ArticuloId = A1ArticuloId;
            Z2ArticuloNombre = A2ArticuloNombre;
            Z4Imagen = A4Imagen;
            Z40000Imagen_GXI = A40000Imagen_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_1_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"ARTICULOID"+"'), id:'"+"ARTICULOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0A13( )
      {
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A42DetalleArticuloId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
            A43DetalleArticuloPrecioCosto = T000A5_A43DetalleArticuloPrecioCosto[0];
            AssignAttri("", false, "A43DetalleArticuloPrecioCosto", StringUtil.LTrimStr( A43DetalleArticuloPrecioCosto, 8, 2));
            A44DetalleArticuloPrecioVenta = T000A5_A44DetalleArticuloPrecioVenta[0];
            AssignAttri("", false, "A44DetalleArticuloPrecioVenta", StringUtil.LTrimStr( A44DetalleArticuloPrecioVenta, 8, 2));
            A2ArticuloNombre = T000A5_A2ArticuloNombre[0];
            AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
            A40000Imagen_GXI = T000A5_A40000Imagen_GXI[0];
            n40000Imagen_GXI = T000A5_n40000Imagen_GXI[0];
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            A1ArticuloId = T000A5_A1ArticuloId[0];
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            A4Imagen = T000A5_A4Imagen[0];
            n4Imagen = T000A5_n4Imagen[0];
            AssignAttri("", false, "A4Imagen", A4Imagen);
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            ZM0A13( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0A13( ) ;
      }

      protected void OnLoadActions0A13( )
      {
      }

      protected void CheckExtendedTable0A13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Articulo'.", "ForeignKeyNotFound", 1, "ARTICULOID");
            AnyError = 1;
            GX_FocusControl = edtArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2ArticuloNombre = T000A4_A2ArticuloNombre[0];
         AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
         A40000Imagen_GXI = T000A4_A40000Imagen_GXI[0];
         n40000Imagen_GXI = T000A4_n40000Imagen_GXI[0];
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         A4Imagen = T000A4_A4Imagen[0];
         n4Imagen = T000A4_n4Imagen[0];
         AssignAttri("", false, "A4Imagen", A4Imagen);
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0A13( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( short A1ArticuloId )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Articulo'.", "ForeignKeyNotFound", 1, "ARTICULOID");
            AnyError = 1;
            GX_FocusControl = edtArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2ArticuloNombre = T000A6_A2ArticuloNombre[0];
         AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
         A40000Imagen_GXI = T000A6_A40000Imagen_GXI[0];
         n40000Imagen_GXI = T000A6_n40000Imagen_GXI[0];
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         A4Imagen = T000A6_A4Imagen[0];
         n4Imagen = T000A6_n4Imagen[0];
         AssignAttri("", false, "A4Imagen", A4Imagen);
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A2ArticuloNombre)+"\""+","+"\""+GXUtil.EncodeJSConstant( A4Imagen)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000Imagen_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0A13( )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A42DetalleArticuloId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A42DetalleArticuloId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A13( 1) ;
            RcdFound13 = 1;
            A42DetalleArticuloId = T000A3_A42DetalleArticuloId[0];
            AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
            A43DetalleArticuloPrecioCosto = T000A3_A43DetalleArticuloPrecioCosto[0];
            AssignAttri("", false, "A43DetalleArticuloPrecioCosto", StringUtil.LTrimStr( A43DetalleArticuloPrecioCosto, 8, 2));
            A44DetalleArticuloPrecioVenta = T000A3_A44DetalleArticuloPrecioVenta[0];
            AssignAttri("", false, "A44DetalleArticuloPrecioVenta", StringUtil.LTrimStr( A44DetalleArticuloPrecioVenta, 8, 2));
            A1ArticuloId = T000A3_A1ArticuloId[0];
            AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
            Z42DetalleArticuloId = A42DetalleArticuloId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0A13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0A13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound13 = 0;
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A42DetalleArticuloId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000A8_A42DetalleArticuloId[0] < A42DetalleArticuloId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000A8_A42DetalleArticuloId[0] > A42DetalleArticuloId ) ) )
            {
               A42DetalleArticuloId = T000A8_A42DetalleArticuloId[0];
               AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A42DetalleArticuloId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A42DetalleArticuloId[0] > A42DetalleArticuloId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000A9_A42DetalleArticuloId[0] < A42DetalleArticuloId ) ) )
            {
               A42DetalleArticuloId = T000A9_A42DetalleArticuloId[0];
               AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDetalleArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A42DetalleArticuloId != Z42DetalleArticuloId )
               {
                  A42DetalleArticuloId = Z42DetalleArticuloId;
                  AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DETALLEARTICULOID");
                  AnyError = 1;
                  GX_FocusControl = edtDetalleArticuloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDetalleArticuloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A13( ) ;
                  GX_FocusControl = edtDetalleArticuloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A42DetalleArticuloId != Z42DetalleArticuloId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtDetalleArticuloId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A13( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DETALLEARTICULOID");
                     AnyError = 1;
                     GX_FocusControl = edtDetalleArticuloId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtDetalleArticuloId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A13( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A42DetalleArticuloId != Z42DetalleArticuloId )
         {
            A42DetalleArticuloId = Z42DetalleArticuloId;
            AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DETALLEARTICULOID");
            AnyError = 1;
            GX_FocusControl = edtDetalleArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDetalleArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "DETALLEARTICULOID");
            AnyError = 1;
            GX_FocusControl = edtDetalleArticuloId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0A13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A42DetalleArticuloId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DetalleArticulo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z43DetalleArticuloPrecioCosto != T000A2_A43DetalleArticuloPrecioCosto[0] ) || ( Z44DetalleArticuloPrecioVenta != T000A2_A44DetalleArticuloPrecioVenta[0] ) || ( Z1ArticuloId != T000A2_A1ArticuloId[0] ) )
            {
               if ( Z43DetalleArticuloPrecioCosto != T000A2_A43DetalleArticuloPrecioCosto[0] )
               {
                  GXUtil.WriteLog("detallearticulo:[seudo value changed for attri]"+"DetalleArticuloPrecioCosto");
                  GXUtil.WriteLogRaw("Old: ",Z43DetalleArticuloPrecioCosto);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A43DetalleArticuloPrecioCosto[0]);
               }
               if ( Z44DetalleArticuloPrecioVenta != T000A2_A44DetalleArticuloPrecioVenta[0] )
               {
                  GXUtil.WriteLog("detallearticulo:[seudo value changed for attri]"+"DetalleArticuloPrecioVenta");
                  GXUtil.WriteLogRaw("Old: ",Z44DetalleArticuloPrecioVenta);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A44DetalleArticuloPrecioVenta[0]);
               }
               if ( Z1ArticuloId != T000A2_A1ArticuloId[0] )
               {
                  GXUtil.WriteLog("detallearticulo:[seudo value changed for attri]"+"ArticuloId");
                  GXUtil.WriteLogRaw("Old: ",Z1ArticuloId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A1ArticuloId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"DetalleArticulo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A13( )
      {
         BeforeValidate0A13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A13( 0) ;
            CheckOptimisticConcurrency0A13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A10 */
                     pr_default.execute(8, new Object[] {A43DetalleArticuloPrecioCosto, A44DetalleArticuloPrecioVenta, A1ArticuloId});
                     A42DetalleArticuloId = T000A10_A42DetalleArticuloId[0];
                     AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("DetalleArticulo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0A13( ) ;
            }
            EndLevel0A13( ) ;
         }
         CloseExtendedTableCursors0A13( ) ;
      }

      protected void Update0A13( )
      {
         BeforeValidate0A13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A11 */
                     pr_default.execute(9, new Object[] {A43DetalleArticuloPrecioCosto, A44DetalleArticuloPrecioVenta, A1ArticuloId, A42DetalleArticuloId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("DetalleArticulo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"DetalleArticulo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0A13( ) ;
         }
         CloseExtendedTableCursors0A13( ) ;
      }

      protected void DeferredUpdate0A13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A13( ) ;
            AfterConfirm0A13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A12 */
                  pr_default.execute(10, new Object[] {A42DetalleArticuloId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("DetalleArticulo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0A13( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0A0( ) ;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000A13 */
            pr_default.execute(11, new Object[] {A1ArticuloId});
            A2ArticuloNombre = T000A13_A2ArticuloNombre[0];
            AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
            A40000Imagen_GXI = T000A13_A40000Imagen_GXI[0];
            n40000Imagen_GXI = T000A13_n40000Imagen_GXI[0];
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            A4Imagen = T000A13_A4Imagen[0];
            n4Imagen = T000A13_n4Imagen[0];
            AssignAttri("", false, "A4Imagen", A4Imagen);
            AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
            AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
            pr_default.close(11);
         }
      }

      protected void EndLevel0A13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("detallearticulo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("detallearticulo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A13( )
      {
         /* Using cursor T000A14 */
         pr_default.execute(12);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A42DetalleArticuloId = T000A14_A42DetalleArticuloId[0];
            AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A13( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound13 = 1;
            A42DetalleArticuloId = T000A14_A42DetalleArticuloId[0];
            AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
         }
      }

      protected void ScanEnd0A13( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0A13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A13( )
      {
         edtDetalleArticuloId_Enabled = 0;
         AssignProp("", false, edtDetalleArticuloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDetalleArticuloId_Enabled), 5, 0), true);
         edtDetalleArticuloPrecioCosto_Enabled = 0;
         AssignProp("", false, edtDetalleArticuloPrecioCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDetalleArticuloPrecioCosto_Enabled), 5, 0), true);
         edtDetalleArticuloPrecioVenta_Enabled = 0;
         AssignProp("", false, edtDetalleArticuloPrecioVenta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDetalleArticuloPrecioVenta_Enabled), 5, 0), true);
         edtArticuloId_Enabled = 0;
         AssignProp("", false, edtArticuloId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloId_Enabled), 5, 0), true);
         edtArticuloNombre_Enabled = 0;
         AssignProp("", false, edtArticuloNombre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtArticuloNombre_Enabled), 5, 0), true);
         imgImagen_Enabled = 0;
         AssignProp("", false, imgImagen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImagen_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 348140), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 348140), false, true);
         context.AddJavascriptSource("gxcfg.js", "?2021102516391754", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("detallearticulo.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:none\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
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
         GxWebStd.gx_hidden_field( context, "Z42DetalleArticuloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42DetalleArticuloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z43DetalleArticuloPrecioCosto", StringUtil.LTrim( StringUtil.NToC( Z43DetalleArticuloPrecioCosto, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44DetalleArticuloPrecioVenta", StringUtil.LTrim( StringUtil.NToC( Z44DetalleArticuloPrecioVenta, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1ArticuloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ArticuloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "IMAGEN_GXI", A40000Imagen_GXI);
         GXCCtlgxBlob = "IMAGEN" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A4Imagen);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("detallearticulo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "DetalleArticulo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle Articulo" ;
      }

      protected void InitializeNonKey0A13( )
      {
         A43DetalleArticuloPrecioCosto = 0;
         AssignAttri("", false, "A43DetalleArticuloPrecioCosto", StringUtil.LTrimStr( A43DetalleArticuloPrecioCosto, 8, 2));
         A44DetalleArticuloPrecioVenta = 0;
         AssignAttri("", false, "A44DetalleArticuloPrecioVenta", StringUtil.LTrimStr( A44DetalleArticuloPrecioVenta, 8, 2));
         A1ArticuloId = 0;
         AssignAttri("", false, "A1ArticuloId", StringUtil.LTrimStr( (decimal)(A1ArticuloId), 4, 0));
         A2ArticuloNombre = "";
         AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
         A4Imagen = "";
         n4Imagen = false;
         AssignAttri("", false, "A4Imagen", A4Imagen);
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         A40000Imagen_GXI = "";
         n40000Imagen_GXI = false;
         AssignProp("", false, imgImagen_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A4Imagen)) ? A40000Imagen_GXI : context.convertURL( context.PathToRelativeUrl( A4Imagen))), true);
         AssignProp("", false, imgImagen_Internalname, "SrcSet", context.GetImageSrcSet( A4Imagen), true);
         Z43DetalleArticuloPrecioCosto = 0;
         Z44DetalleArticuloPrecioVenta = 0;
         Z1ArticuloId = 0;
      }

      protected void InitAll0A13( )
      {
         A42DetalleArticuloId = 0;
         AssignAttri("", false, "A42DetalleArticuloId", StringUtil.LTrimStr( (decimal)(A42DetalleArticuloId), 4, 0));
         InitializeNonKey0A13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2021102516391759", true, true);
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
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("detallearticulo.js", "?2021102516391760", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtDetalleArticuloId_Internalname = "DETALLEARTICULOID";
         edtDetalleArticuloPrecioCosto_Internalname = "DETALLEARTICULOPRECIOCOSTO";
         edtDetalleArticuloPrecioVenta_Internalname = "DETALLEARTICULOPRECIOVENTA";
         edtArticuloId_Internalname = "ARTICULOID";
         edtArticuloNombre_Internalname = "ARTICULONOMBRE";
         imgImagen_Internalname = "IMAGEN";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_1_Internalname = "PROMPT_1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Detalle Articulo";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         imgImagen_Enabled = 0;
         edtArticuloNombre_Jsonclick = "";
         edtArticuloNombre_Enabled = 0;
         imgprompt_1_Visible = 1;
         imgprompt_1_Link = "";
         edtArticuloId_Jsonclick = "";
         edtArticuloId_Enabled = 1;
         edtDetalleArticuloPrecioVenta_Jsonclick = "";
         edtDetalleArticuloPrecioVenta_Enabled = 1;
         edtDetalleArticuloPrecioCosto_Jsonclick = "";
         edtDetalleArticuloPrecioCosto_Enabled = 1;
         edtDetalleArticuloId_Jsonclick = "";
         edtDetalleArticuloId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtDetalleArticuloPrecioCosto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Detallearticuloid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A43DetalleArticuloPrecioCosto", StringUtil.LTrim( StringUtil.NToC( A43DetalleArticuloPrecioCosto, 8, 2, ".", "")));
         AssignAttri("", false, "A44DetalleArticuloPrecioVenta", StringUtil.LTrim( StringUtil.NToC( A44DetalleArticuloPrecioVenta, 8, 2, ".", "")));
         AssignAttri("", false, "A1ArticuloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1ArticuloId), 4, 0, ".", "")));
         AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
         AssignAttri("", false, "A4Imagen", context.PathToRelativeUrl( A4Imagen));
         GXCCtlgxBlob = "IMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A4Imagen));
         AssignAttri("", false, "A40000Imagen_GXI", A40000Imagen_GXI);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z42DetalleArticuloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z42DetalleArticuloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z43DetalleArticuloPrecioCosto", StringUtil.LTrim( StringUtil.NToC( Z43DetalleArticuloPrecioCosto, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44DetalleArticuloPrecioVenta", StringUtil.LTrim( StringUtil.NToC( Z44DetalleArticuloPrecioVenta, 8, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1ArticuloId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1ArticuloId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2ArticuloNombre", Z2ArticuloNombre);
         GxWebStd.gx_hidden_field( context, "Z4Imagen", context.PathToRelativeUrl( Z4Imagen));
         GxWebStd.gx_hidden_field( context, "Z40000Imagen_GXI", Z40000Imagen_GXI);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Articuloid( )
      {
         n4Imagen = false;
         n40000Imagen_GXI = false;
         /* Using cursor T000A13 */
         pr_default.execute(11, new Object[] {A1ArticuloId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Articulo'.", "ForeignKeyNotFound", 1, "ARTICULOID");
            AnyError = 1;
            GX_FocusControl = edtArticuloId_Internalname;
         }
         A2ArticuloNombre = T000A13_A2ArticuloNombre[0];
         A40000Imagen_GXI = T000A13_A40000Imagen_GXI[0];
         n40000Imagen_GXI = T000A13_n40000Imagen_GXI[0];
         A4Imagen = T000A13_A4Imagen[0];
         n4Imagen = T000A13_n4Imagen[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2ArticuloNombre", A2ArticuloNombre);
         AssignAttri("", false, "A4Imagen", context.PathToRelativeUrl( A4Imagen));
         GXCCtlgxBlob = "IMAGEN" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A4Imagen));
         AssignAttri("", false, "A40000Imagen_GXI", A40000Imagen_GXI);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_DETALLEARTICULOID","{handler:'Valid_Detallearticuloid',iparms:[{av:'A42DetalleArticuloId',fld:'DETALLEARTICULOID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DETALLEARTICULOID",",oparms:[{av:'A43DetalleArticuloPrecioCosto',fld:'DETALLEARTICULOPRECIOCOSTO',pic:'ZZZZ9.99'},{av:'A44DetalleArticuloPrecioVenta',fld:'DETALLEARTICULOPRECIOVENTA',pic:'ZZZZ9.99'},{av:'A1ArticuloId',fld:'ARTICULOID',pic:'ZZZ9'},{av:'A2ArticuloNombre',fld:'ARTICULONOMBRE',pic:''},{av:'A4Imagen',fld:'IMAGEN',pic:''},{av:'A40000Imagen_GXI',fld:'IMAGEN_GXI',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z42DetalleArticuloId'},{av:'Z43DetalleArticuloPrecioCosto'},{av:'Z44DetalleArticuloPrecioVenta'},{av:'Z1ArticuloId'},{av:'Z2ArticuloNombre'},{av:'Z4Imagen'},{av:'Z40000Imagen_GXI'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ARTICULOID","{handler:'Valid_Articuloid',iparms:[{av:'A1ArticuloId',fld:'ARTICULOID',pic:'ZZZ9'},{av:'A2ArticuloNombre',fld:'ARTICULONOMBRE',pic:''},{av:'A4Imagen',fld:'IMAGEN',pic:''},{av:'A40000Imagen_GXI',fld:'IMAGEN_GXI',pic:''}]");
         setEventMetadata("VALID_ARTICULOID",",oparms:[{av:'A2ArticuloNombre',fld:'ARTICULONOMBRE',pic:''},{av:'A4Imagen',fld:'IMAGEN',pic:''},{av:'A40000Imagen_GXI',fld:'IMAGEN_GXI',pic:''}]}");
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
         pr_default.close(1);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         sImgUrl = "";
         A2ArticuloNombre = "";
         A4Imagen = "";
         A40000Imagen_GXI = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z2ArticuloNombre = "";
         Z4Imagen = "";
         Z40000Imagen_GXI = "";
         T000A5_A42DetalleArticuloId = new short[1] ;
         T000A5_A43DetalleArticuloPrecioCosto = new decimal[1] ;
         T000A5_A44DetalleArticuloPrecioVenta = new decimal[1] ;
         T000A5_A2ArticuloNombre = new string[] {""} ;
         T000A5_A40000Imagen_GXI = new string[] {""} ;
         T000A5_n40000Imagen_GXI = new bool[] {false} ;
         T000A5_A1ArticuloId = new short[1] ;
         T000A5_A4Imagen = new string[] {""} ;
         T000A5_n4Imagen = new bool[] {false} ;
         T000A4_A2ArticuloNombre = new string[] {""} ;
         T000A4_A40000Imagen_GXI = new string[] {""} ;
         T000A4_n40000Imagen_GXI = new bool[] {false} ;
         T000A4_A4Imagen = new string[] {""} ;
         T000A4_n4Imagen = new bool[] {false} ;
         T000A6_A2ArticuloNombre = new string[] {""} ;
         T000A6_A40000Imagen_GXI = new string[] {""} ;
         T000A6_n40000Imagen_GXI = new bool[] {false} ;
         T000A6_A4Imagen = new string[] {""} ;
         T000A6_n4Imagen = new bool[] {false} ;
         T000A7_A42DetalleArticuloId = new short[1] ;
         T000A3_A42DetalleArticuloId = new short[1] ;
         T000A3_A43DetalleArticuloPrecioCosto = new decimal[1] ;
         T000A3_A44DetalleArticuloPrecioVenta = new decimal[1] ;
         T000A3_A1ArticuloId = new short[1] ;
         sMode13 = "";
         T000A8_A42DetalleArticuloId = new short[1] ;
         T000A9_A42DetalleArticuloId = new short[1] ;
         T000A2_A42DetalleArticuloId = new short[1] ;
         T000A2_A43DetalleArticuloPrecioCosto = new decimal[1] ;
         T000A2_A44DetalleArticuloPrecioVenta = new decimal[1] ;
         T000A2_A1ArticuloId = new short[1] ;
         T000A10_A42DetalleArticuloId = new short[1] ;
         T000A13_A2ArticuloNombre = new string[] {""} ;
         T000A13_A40000Imagen_GXI = new string[] {""} ;
         T000A13_n40000Imagen_GXI = new bool[] {false} ;
         T000A13_A4Imagen = new string[] {""} ;
         T000A13_n4Imagen = new bool[] {false} ;
         T000A14_A42DetalleArticuloId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ2ArticuloNombre = "";
         ZZ4Imagen = "";
         ZZ40000Imagen_GXI = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.detallearticulo__default(),
            new Object[][] {
                new Object[] {
               T000A2_A42DetalleArticuloId, T000A2_A43DetalleArticuloPrecioCosto, T000A2_A44DetalleArticuloPrecioVenta, T000A2_A1ArticuloId
               }
               , new Object[] {
               T000A3_A42DetalleArticuloId, T000A3_A43DetalleArticuloPrecioCosto, T000A3_A44DetalleArticuloPrecioVenta, T000A3_A1ArticuloId
               }
               , new Object[] {
               T000A4_A2ArticuloNombre, T000A4_A40000Imagen_GXI, T000A4_n40000Imagen_GXI, T000A4_A4Imagen, T000A4_n4Imagen
               }
               , new Object[] {
               T000A5_A42DetalleArticuloId, T000A5_A43DetalleArticuloPrecioCosto, T000A5_A44DetalleArticuloPrecioVenta, T000A5_A2ArticuloNombre, T000A5_A40000Imagen_GXI, T000A5_n40000Imagen_GXI, T000A5_A1ArticuloId, T000A5_A4Imagen, T000A5_n4Imagen
               }
               , new Object[] {
               T000A6_A2ArticuloNombre, T000A6_A40000Imagen_GXI, T000A6_n40000Imagen_GXI, T000A6_A4Imagen, T000A6_n4Imagen
               }
               , new Object[] {
               T000A7_A42DetalleArticuloId
               }
               , new Object[] {
               T000A8_A42DetalleArticuloId
               }
               , new Object[] {
               T000A9_A42DetalleArticuloId
               }
               , new Object[] {
               T000A10_A42DetalleArticuloId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A13_A2ArticuloNombre, T000A13_A40000Imagen_GXI, T000A13_n40000Imagen_GXI, T000A13_A4Imagen, T000A13_n4Imagen
               }
               , new Object[] {
               T000A14_A42DetalleArticuloId
               }
            }
         );
      }

      private short Z42DetalleArticuloId ;
      private short Z1ArticuloId ;
      private short GxWebError ;
      private short A1ArticuloId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A42DetalleArticuloId ;
      private short GX_JID ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ42DetalleArticuloId ;
      private short ZZ1ArticuloId ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtDetalleArticuloId_Enabled ;
      private int edtDetalleArticuloPrecioCosto_Enabled ;
      private int edtDetalleArticuloPrecioVenta_Enabled ;
      private int edtArticuloId_Enabled ;
      private int imgprompt_1_Visible ;
      private int edtArticuloNombre_Enabled ;
      private int imgImagen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z43DetalleArticuloPrecioCosto ;
      private decimal Z44DetalleArticuloPrecioVenta ;
      private decimal A43DetalleArticuloPrecioCosto ;
      private decimal A44DetalleArticuloPrecioVenta ;
      private decimal ZZ43DetalleArticuloPrecioCosto ;
      private decimal ZZ44DetalleArticuloPrecioVenta ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDetalleArticuloId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtDetalleArticuloId_Jsonclick ;
      private string edtDetalleArticuloPrecioCosto_Internalname ;
      private string edtDetalleArticuloPrecioCosto_Jsonclick ;
      private string edtDetalleArticuloPrecioVenta_Internalname ;
      private string edtDetalleArticuloPrecioVenta_Jsonclick ;
      private string edtArticuloId_Internalname ;
      private string edtArticuloId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_1_Internalname ;
      private string imgprompt_1_Link ;
      private string edtArticuloNombre_Internalname ;
      private string edtArticuloNombre_Jsonclick ;
      private string imgImagen_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A4Imagen_IsBlob ;
      private bool n4Imagen ;
      private bool n40000Imagen_GXI ;
      private string A2ArticuloNombre ;
      private string A40000Imagen_GXI ;
      private string Z2ArticuloNombre ;
      private string Z40000Imagen_GXI ;
      private string ZZ2ArticuloNombre ;
      private string ZZ40000Imagen_GXI ;
      private string A4Imagen ;
      private string Z4Imagen ;
      private string ZZ4Imagen ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000A5_A42DetalleArticuloId ;
      private decimal[] T000A5_A43DetalleArticuloPrecioCosto ;
      private decimal[] T000A5_A44DetalleArticuloPrecioVenta ;
      private string[] T000A5_A2ArticuloNombre ;
      private string[] T000A5_A40000Imagen_GXI ;
      private bool[] T000A5_n40000Imagen_GXI ;
      private short[] T000A5_A1ArticuloId ;
      private string[] T000A5_A4Imagen ;
      private bool[] T000A5_n4Imagen ;
      private string[] T000A4_A2ArticuloNombre ;
      private string[] T000A4_A40000Imagen_GXI ;
      private bool[] T000A4_n40000Imagen_GXI ;
      private string[] T000A4_A4Imagen ;
      private bool[] T000A4_n4Imagen ;
      private string[] T000A6_A2ArticuloNombre ;
      private string[] T000A6_A40000Imagen_GXI ;
      private bool[] T000A6_n40000Imagen_GXI ;
      private string[] T000A6_A4Imagen ;
      private bool[] T000A6_n4Imagen ;
      private short[] T000A7_A42DetalleArticuloId ;
      private short[] T000A3_A42DetalleArticuloId ;
      private decimal[] T000A3_A43DetalleArticuloPrecioCosto ;
      private decimal[] T000A3_A44DetalleArticuloPrecioVenta ;
      private short[] T000A3_A1ArticuloId ;
      private short[] T000A8_A42DetalleArticuloId ;
      private short[] T000A9_A42DetalleArticuloId ;
      private short[] T000A2_A42DetalleArticuloId ;
      private decimal[] T000A2_A43DetalleArticuloPrecioCosto ;
      private decimal[] T000A2_A44DetalleArticuloPrecioVenta ;
      private short[] T000A2_A1ArticuloId ;
      private short[] T000A10_A42DetalleArticuloId ;
      private string[] T000A13_A2ArticuloNombre ;
      private string[] T000A13_A40000Imagen_GXI ;
      private bool[] T000A13_n40000Imagen_GXI ;
      private string[] T000A13_A4Imagen ;
      private bool[] T000A13_n4Imagen ;
      private short[] T000A14_A42DetalleArticuloId ;
      private GXWebForm Form ;
   }

   public class detallearticulo__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A5;
          prmT000A5 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A6;
          prmT000A6 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A8;
          prmT000A8 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A9;
          prmT000A9 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@DetalleArticuloPrecioCosto",GXType.Decimal,8,2) ,
          new ParDef("@DetalleArticuloPrecioVenta",GXType.Decimal,8,2) ,
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@DetalleArticuloPrecioCosto",GXType.Decimal,8,2) ,
          new ParDef("@DetalleArticuloPrecioVenta",GXType.Decimal,8,2) ,
          new ParDef("@ArticuloId",GXType.Int16,4,0) ,
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A12;
          prmT000A12 = new Object[] {
          new ParDef("@DetalleArticuloId",GXType.Int16,4,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          };
          Object[] prmT000A13;
          prmT000A13 = new Object[] {
          new ParDef("@ArticuloId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [DetalleArticuloId], [DetalleArticuloPrecioCosto], [DetalleArticuloPrecioVenta], [ArticuloId] FROM [DetalleArticulo] WITH (UPDLOCK) WHERE [DetalleArticuloId] = @DetalleArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [DetalleArticuloId], [DetalleArticuloPrecioCosto], [DetalleArticuloPrecioVenta], [ArticuloId] FROM [DetalleArticulo] WHERE [DetalleArticuloId] = @DetalleArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [ArticuloNombre], [Imagen_GXI], [Imagen] FROM [Articulo] WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A5", "SELECT TM1.[DetalleArticuloId], TM1.[DetalleArticuloPrecioCosto], TM1.[DetalleArticuloPrecioVenta], T2.[ArticuloNombre], T2.[Imagen_GXI], TM1.[ArticuloId], T2.[Imagen] FROM ([DetalleArticulo] TM1 INNER JOIN [Articulo] T2 ON T2.[ArticuloId] = TM1.[ArticuloId]) WHERE TM1.[DetalleArticuloId] = @DetalleArticuloId ORDER BY TM1.[DetalleArticuloId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A6", "SELECT [ArticuloNombre], [Imagen_GXI], [Imagen] FROM [Articulo] WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT [DetalleArticuloId] FROM [DetalleArticulo] WHERE [DetalleArticuloId] = @DetalleArticuloId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A8", "SELECT TOP 1 [DetalleArticuloId] FROM [DetalleArticulo] WHERE ( [DetalleArticuloId] > @DetalleArticuloId) ORDER BY [DetalleArticuloId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A9", "SELECT TOP 1 [DetalleArticuloId] FROM [DetalleArticulo] WHERE ( [DetalleArticuloId] < @DetalleArticuloId) ORDER BY [DetalleArticuloId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A10", "INSERT INTO [DetalleArticulo]([DetalleArticuloPrecioCosto], [DetalleArticuloPrecioVenta], [ArticuloId]) VALUES(@DetalleArticuloPrecioCosto, @DetalleArticuloPrecioVenta, @ArticuloId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000A10)
             ,new CursorDef("T000A11", "UPDATE [DetalleArticulo] SET [DetalleArticuloPrecioCosto]=@DetalleArticuloPrecioCosto, [DetalleArticuloPrecioVenta]=@DetalleArticuloPrecioVenta, [ArticuloId]=@ArticuloId  WHERE [DetalleArticuloId] = @DetalleArticuloId", GxErrorMask.GX_NOMASK,prmT000A11)
             ,new CursorDef("T000A12", "DELETE FROM [DetalleArticulo]  WHERE [DetalleArticuloId] = @DetalleArticuloId", GxErrorMask.GX_NOMASK,prmT000A12)
             ,new CursorDef("T000A13", "SELECT [ArticuloNombre], [Imagen_GXI], [Imagen] FROM [Articulo] WHERE [ArticuloId] = @ArticuloId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A14", "SELECT [DetalleArticuloId] FROM [DetalleArticulo] ORDER BY [DetalleArticuloId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(5));
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
